/*
    PublicVote - A platform for conducting small secure public elections
    Copyright (C) 2020  Nathan Mentley

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Affero General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Affero General Public License for more details.

    You should have received a copy of the GNU Affero General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/
using Newtonsoft.Json.Linq;
using PublicVote.Common.Exceptions;
using System;
using System.Linq;

namespace PublicVote.Common
{
    /// <summary>
    /// A model that contains the base logic for generating immutable and verified data models.
    /// </summary>
    /// <remarks>
    /// To ensure inherited classes are immutable and signed:
    /// * Inheriting classes must only have properties that have private setters or no setters at all.
    /// * The only decoding from the <see cref="BlockContent"/> data for inheriting classes must be done in the
    ///     abstract <see cref="Decode"/> method.
    /// * Inheriting classes must be sealed.
    /// 
    /// If those rules are followed you can be pretty confident that your models are verified and immutable.
    ///   You can also be sure the data coming in from api calls, and up from the data storage layer are
    ///   untampered with and signed.
    /// </remarks>
    public abstract class BaseBlockModel: IIdentifiable, ISignedData
    {
        /// <summary>
        /// The unique Identifier of the persisted version.
        /// </summary>
        /// <remarks>
        /// If this data isn't persisted this will be <see cref="string.Empty"/>.
        /// </remarks>
        public string Id { get; } =
            string.Empty;

        /// <summary>
        /// The string representation of the data producer's public key.
        /// </summary>
        public string PublicKey { get; }
        /// <summary>
        /// The content of the model.
        /// </summary>
        /// <remarks>
        /// Currently in this proof of concept this needs to be json, but in a more built out version
        ///  I'd expect this to be any number of formats, and we'd have a way to handle different
        ///  formats.
        /// </remarks>
        public string BlockContent { get; }
        /// <summary>
        /// The signature of the <see cref="BlockContent"/> that can be verified with <see cref="PublicKey"/>.
        /// </summary>
        public byte[] Signature { get; }

        /// <summary>
        /// Constructor for a persisted version of the data.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Id"/> of the persisted data.
        /// </param>
        /// <param name="data">
        /// The <see cref="ISignedData"/> data to use to construct the <see cref="BaseBlockModel"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="id"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidBlockSignatureException">
        /// Thrown if <see cref="Signature"/> is invalid, and we can't ensure the data hasn't been tampered with.
        /// </exception>
        /// <remarks>
        /// This will populate <see cref="PublicKey"/>, <see cref="BlockContent"/>, and <see cref="Signature"/>
        ///     from <paramref name="data"/>, and check if the signature is valid.
        /// It'll then call the abstract method <see cref="Decode"/> to populate any properties from the
        ///     <see cref="BlockContent"/> data for the specific implementation of <see cref="BaseBlockModel"/>.
        /// </remarks>
        protected BaseBlockModel(string id, ISignedData data): this(data)
        {
            if(string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            Id = id;
        }

        /// <summary>
        /// Constructor for a non-persisted version of the data.
        /// </summary>
        /// <param name="data">
        /// The <see cref="ISignedData"/> data to use to construct the <see cref="BaseBlockModel"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidBlockSignatureException">
        /// Thrown if <see cref="Signature"/> is invalid, and we can't ensure the data hasn't been tampered with.
        /// </exception>
        /// <remarks>
        /// This will populate <see cref="PublicKey"/>, <see cref="BlockContent"/>, and <see cref="Signature"/>
        ///     from <paramref name="data"/>, and check if the signature is valid.
        /// It'll then call the abstract method <see cref="Decode"/> to populate any properties from the
        ///     <see cref="BlockContent"/> data for the specific implementation of <see cref="BaseBlockModel"/>.
        /// </remarks>
        protected BaseBlockModel(ISignedData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if(!data.IsValid)
                throw new InvalidBlockSignatureException(
                    $"Invalid signature[{data.Signature}] for content[{data.BlockContent}] " +
                        $"using public key[{data.PublicKey}]"
                );

            PublicKey = data.PublicKey;
            BlockContent = data.BlockContent;
            Signature = data.Signature.ToArray();

            if (data is IIdentifiable identifiable)
                Id = identifiable.Id;

            Decode(JToken.Parse(BlockContent));
        }

        /// <summary>
        /// Populates properties on the instance from the <see cref="BlockContent"/> data.
        /// </summary>
        /// <param name="token">
        /// The <see cref="BlockContent"/> json data that has been tokenized.
        /// </param>
        protected abstract void Decode(JToken token);
    }
}