/*
    RemoteCongress - A platform for conducting small secure public elections
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
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Common
{
    /// <summary>
    /// A model that contains the immutable and verified data around a vote.
    /// </summary>
    /// <remarks>
    /// We know that in most cases the data on instances is valid because:
    ///     It's inherited from <see cref="BaseBlockModel"/> so the signature is valided when the instance is created.
    ///     The data is only set by the constructor or the <see cref="Decode"/> method called by the constructor.
    ///     All the fields are either readonly or only private set. So we can expect them not to change.
    ///     The class is sealed so we don't need to worry about overriden behavior.
    /// 
    /// *However, reflection can stil tamper with this. So blind faith isn't great. Injected crazy code can still mess
    ///   things up. The important thing is we validate the data coming into the system and persisted in the data layer.
    ///   So we can always know the data created and stored is the intended data.
    ///   If there is any question you can always call <see cref="ISignedData.IsValid"/> to ensure the data hasn't
    ///   been tampered with, and at the end of the day we can always verify block in the blockchain against their
    ///   stored signature.
    /// </remarks>
    [ExcludeFromCodeCoverage]
    public sealed class Vote: BaseBlockModel
    {
        /// <summary>
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="Bill"/> being voted on.
        /// </summary>
        public string BillId { get; private set; }
        
        /// <summary>
        /// The opinion of the <see cref="Vote"/>. True if voting yes, False if voting no, and null if present.
        /// </summary>
        public bool? Opinion { get; private set; }
        
        /// <summary>
        /// A short optional message explaining the <see cref="Opinion"/>.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Constructor for a persisted version of the data.
        /// </summary>
        /// <param name="id">
        /// The <see cref="Id"/> of the persisted data.
        /// </param>
        /// <param name="data">
        /// The <see cref="ISignedData"/> data to use to construct the <see cref="Vote"/>.
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
        /// It'll then call the abstract method <see cref="Decode"/> to populate <see cref="BillId"/>,
        ///     <see cref="Opinion"/>, and <see cref="Message"/>.
        /// </remarks>
        public Vote(string id, ISignedData data) : base(id, data) {}

        /// <summary>
        /// Constructor for a non-persisted version of the data.
        /// </summary>
        /// <param name="data">
        /// The <see cref="ISignedData"/> data to use to construct the <see cref="Vote"/>.
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
        /// It'll then call the abstract method <see cref="Decode"/> to populate <see cref="BillId"/>,
        ///     <see cref="Opinion"/>, and <see cref="Message"/>.
        /// </remarks>
        public Vote(ISignedData data): base(data) {}

        /// <summary>
        /// Populates properties on the instance from the <see cref="BlockContent"/> data.
        /// </summary>
        /// <param name="token">
        /// The <see cref="BlockContent"/> json data that has been tokenized.
        /// </param>
        protected override void Decode(JToken token)
        {
            BillId = token.Value<string>("billId") ?? string.Empty;
            Message = token.Value<string>("message") ?? string.Empty;
            Opinion = token.Value<bool?>("opinion");
        }
    }
}