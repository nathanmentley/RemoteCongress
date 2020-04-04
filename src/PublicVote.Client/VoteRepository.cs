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
using PublicVote.Common.Repositories;
using System;
using System.Threading.Tasks;

namespace PublicVote.Client
{
    public class VoteRepository: IVoteRepository
    {
        private readonly static string Endpoint = "vote";
        private readonly ISignedDataHttpClient _signedDataHttpClient;

        public VoteRepository(ISignedDataHttpClient signedDataHttpClient)
        {
            _signedDataHttpClient = signedDataHttpClient ??
                throw new ArgumentNullException(nameof(signedDataHttpClient));
        }

        public async Task<Vote> Create(Vote instance)
        {
            var signedData = await _signedDataHttpClient.CreateSignedData(
                Endpoint,
                new SignedData(instance)
            );

            return new Vote(signedData);
        }

        public async Task<Vote> Fetch(string id)
        {
            var signedData = await _signedDataHttpClient.FetchSignedData(Endpoint, id);

            return new Vote(id, signedData);
        }
    }
}
