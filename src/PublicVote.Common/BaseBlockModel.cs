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
    public abstract class BaseBlockModel: IIdentifiable, ISignedData
    {
        public string Id { get; } =
            string.Empty;

        public string PublicKey { get; }
        public string BlockContent { get; }
        public byte[] Signature { get; }

        protected BaseBlockModel(string id, ISignedData data): this(data)
        {
            if(string.IsNullOrWhiteSpace(id))
                throw new ArgumentNullException(nameof(id));

            Id = id;
        }

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

        //TODO: this ties the content to a single format / version
        //  setup a system to dynamically decode BlockContent for multiple formats. Not just json.
        protected abstract void Decode(JToken token);
    }
}