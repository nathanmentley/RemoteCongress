/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

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
using RemoteCongress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace RemoteCongress.Utils.DataSeeder
{
    /// <summary>
    /// A <see cref="IDataProvider"/> for fetching data for the US Senate from xml files.
    /// </summary>
    public class SenateDataProvider: IDataProvider
    {
        /// <summary>
        /// A local in memory cache of members, and their pub/priv keys.
        /// </summary>
        private readonly IDictionary<string, (string, string)> _keys =
            new Dictionary<string, (string, string)>();

        /// <summary>
        /// A <see cref="IKeyGenerator"/> to create keys for seeded <see cref="Member"/>s.
        /// </summary>
        private readonly IKeyGenerator _keyGenerator;

        /// <summary>
        /// The congress number to seed.
        /// </summary>
        private readonly int _congress;

        /// <summary>
        /// The session number to seed.
        /// </summary>
        private readonly int _session;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="keyGenerator">
        /// A <see cref="IKeyGenerator"/> to create keys for seeded <see cref="Member"/>s.
        /// </param>
        /// <param name="congress">
        /// The congress number to seed.
        /// </param>
        /// <param name="session">
        /// The session number to seed.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="keyGenerator"/> is null.
        /// </exception>
        public SenateDataProvider(
            IKeyGenerator keyGenerator,
            int congress,
            int session
        )
        {
            _keyGenerator = keyGenerator ??
                throw new ArgumentNullException(nameof(keyGenerator));

            _congress = congress;

            _session = session;
        }

        /// <summary>
        /// Fetches all <see cref="Member"/>s to seed.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Member"/>s to seed.
        /// </returns>
        public async IAsyncEnumerable<Member> GetMembers([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            XElement senatorsData = XElement.Load(
                Path.Combine(path, "data/senate/member_data.xml")
            );

            foreach(XElement senatorData in senatorsData.Descendants("senator"))
            {
                cancellationToken.ThrowIfCancellationRequested();

                string id = senatorData.Attribute("lis_member_id").Value;

                (string privateKey, string publicKey) = await _keyGenerator.GenerateKeys(1024, cancellationToken);
                _keys[id] = (privateKey, publicKey);

                yield return new Member()
                {
                    Id = id,
                    FirstName = senatorData.Element("name").Element("first").Value,
                    LastName = senatorData.Element("name").Element("last").Value,
                    Seat = senatorData.Element("state").Value + senatorData.Element("stateRank").Value,
                    Chamber = "senate",
                    Party = senatorData.Element("party").Value,
                    PublicKey = publicKey
                };
            }
        }

        /// <summary>
        /// Fetches all <see cref="Bill"/>s to seed.
        /// </summary>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Bill"/>s to seed.
        /// </returns>
        public async IAsyncEnumerable<(Bill, string)> GetBills([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "senate");
            string searchPattern = $"vote_{_congress}_{_session}_*.xml";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(FileInfo file in directoryInfo.GetFiles(searchPattern))
            {
                cancellationToken.ThrowIfCancellationRequested();

                using MemoryStream stream = new MemoryStream(
                    await File.ReadAllBytesAsync(file.FullName, cancellationToken)
                );

                XElement voteData = await XElement.LoadAsync(
                    stream,
                    new LoadOptions(),
                    cancellationToken
                );

                yield return (
                    new Bill()
                    {
                        Title = voteData.Element("vote_question_text").Value,
                        Content = voteData.Element("vote_document_text").Value,
                        Chamber = "senate"
                    },
                    voteData.Element("vote_number").Value.PadLeft(5, '0')
                );
            }
        }

        /// <summary>
        /// Fetches all <see cref="Vote"/>s for a <see cref="Bill"/> to seed.
        /// </summary>
        /// <param name="id">
        /// The unique id of the bill.
        /// </param>
        /// <param name="bill">
        /// The seeded <see cref="Bill"/> wrapped in a <see cref="VerifiedData{TModel}"/>.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> that triggers a cancellation.
        /// </param>
        /// <returns>
        /// A collection of <see cref="Vote"/>s to seed.
        /// </returns>
        public async IAsyncEnumerable<(Vote vote, string memberPrivateKey, string memberPublicKey)> GetVotes(
            string id,
            VerifiedData<Bill> bill,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "senate");
            string searchPattern = $"vote_{_congress}_{_session}_{id}.xml";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(FileInfo file in directoryInfo.GetFiles(searchPattern))
            {
                cancellationToken.ThrowIfCancellationRequested();

                using MemoryStream stream = new MemoryStream(
                    await File.ReadAllBytesAsync(file.FullName, cancellationToken)
                );

                XElement voteData = await XElement.LoadAsync(
                    stream,
                    new LoadOptions(),
                    cancellationToken
                );

                foreach(XElement member in voteData.Element("members").Descendants("member"))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string memberId = member.Element("lis_member_id").Value;

                    if (!_keys.ContainsKey(memberId))
                    {
                        continue;
                    }

                    (string memberPrivateKey, string memberPublicKey) = _keys[memberId];
                    Vote vote = BuildVote(bill, member);

                    yield return (vote, memberPrivateKey, memberPublicKey);
                }
            }
        }

        /// <summary>
        /// Generates a <see cref="Vote"/> poco.
        /// </summary>
        /// <param name="bill">
        /// The <see cref="Bill"/> related to the <see cref="Vote"/>.
        /// </param>
        /// <param name="member">
        /// The XML element containing the vote data.
        /// </param>
        /// <returns>
        /// The <see cref="Vote"/> poco to use.
        /// </returns>
        private static Vote BuildVote(VerifiedData<Bill> bill, XElement member) =>
            new Vote()
            {
                BillId = bill.Id,
                Opinion =
                    member.Element("vote_cast")?.Value switch
                    {
                        "Yea" => true,
                        "Guilty" => true,
                        "Nay" => false,
                        "Not Guilty" => false,
                        _ => null
                    },
                Message = $"{member.Element("member_full")?.Value} voted {member.Element("vote_cast")?.Value}"
            };
    }
}