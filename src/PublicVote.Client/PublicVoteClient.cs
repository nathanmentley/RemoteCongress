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
using PublicVote.Common;
using PublicVote.Common.Encryption;
using PublicVote.Common.Repositories;
using System;
using System.Threading.Tasks;

namespace PublicVote.Client
{
    public class PublicVoteClient: IPublicVoteClient
    {
        private readonly IBillRepository _billRepository;
        private readonly IVoteRepository _voteRepository;

        public PublicVoteClient(
            IBillRepository billRepository,
            IVoteRepository voteRepository
        )
        {
            _billRepository = billRepository ??
                throw new ArgumentNullException(nameof(billRepository));

            _voteRepository = voteRepository ??
                throw new ArgumentNullException(nameof(voteRepository));
        }

        public async Task<Bill> CreateBill(
            string privateKey,
            string publicKey,
            string title,
            string content
        )
        {
            //TODO: generate content
            var blockContent = "{title: \"title\", content: \"content\"}";

            var signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent)
            );

            var bill = new Bill(signedData);

            return await _billRepository.Create(bill);
        }

        public async Task<Bill> GetBill(string id) =>
            await _billRepository.Fetch(id);

        public async Task<Vote> CreateVote(
            string privateKey,
            string publicKey,
            string billId,
            bool? opinon,
            string message
        )
        {
            //TODO: generate content
            var blockContent = "{billId: \"title\", message: \"content\", opinion: false}";

            var signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent)
            );

            var vote = new Vote(signedData);

            return await _voteRepository.Create(vote);
        }

        public async Task<Vote> GetVote(string id) =>
            await _voteRepository.Fetch(id);
    }
}