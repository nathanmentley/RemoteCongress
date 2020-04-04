using System;
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
using System.Linq;

namespace PublicVote.Common
{
    public class SignedData: ISignedData, IIdentifiable
    {
        public string Id { get; set; }

        public string PublicKey { get; set; }
        public string BlockContent { get; set; }
        public byte[] Signature { get; set; }

        public SignedData(string publicKey, string blockContent, byte[] signature)
        {
            if(string.IsNullOrWhiteSpace(publicKey))
                throw new ArgumentNullException(nameof(publicKey));

            if(string.IsNullOrWhiteSpace(blockContent))
                throw new ArgumentNullException(nameof(blockContent));

            if(signature is null)
                throw new ArgumentNullException(nameof(signature));

            PublicKey = publicKey;
            BlockContent = blockContent;
            Signature = signature.ToArray();
        }

        public SignedData(ISignedData data)
        {
            if (data is null)
                throw new ArgumentNullException(nameof(data));

            PublicKey = data.PublicKey;
            BlockContent = data.BlockContent;
            Signature = data.Signature.ToArray();

            if (data is IIdentifiable identifiable)
                Id = identifiable.Id;
        }

        public SignedData()
        {
            Id = string.Empty;

            PublicKey = string.Empty;
            BlockContent = string.Empty;
            Signature = new byte[] {};
        }
    }
}