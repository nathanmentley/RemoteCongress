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
    /// A <see cref="IDataProvider"/> for fetching data for the US House from xml files.
    /// </summary>
    public class HouseDataProvider: IDataProvider
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
        public HouseDataProvider(
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

            XElement membersData = XElement.Load(
                Path.Combine(path, "data/house/member_data.xml")
            );

            foreach(XElement houseData in membersData.Element("members").Descendants("member"))
            {
                cancellationToken.ThrowIfCancellationRequested();

                string id = houseData.Element("member-info").Element("bioguideID").Value;

                (string privateKey, string publicKey) = await _keyGenerator.GenerateKeys(1024, cancellationToken);
                _keys[id] = (privateKey, publicKey);

                yield return new Member()
                {
                    Id = id,
                    FirstName = houseData.Element("member-info").Element("firstname").Value,
                    LastName = houseData.Element("member-info").Element("lastname").Value,
                    Seat = houseData.Element("statedistrict").Value,
                    Chamber = "house",
                    Party = houseData.Element("member-info").Element("party").Value,
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

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "house");
            string searchPattern = $"roll*.xml";
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

                string title = voteData.Element("vote-metadata")?.Element("legis-num")?.Value ?? "";
                string content = voteData.Element("vote-metadata")?.Element("vote-question")?.Value ?? "";
                string id = voteData.Element("vote-metadata")?.Element("rollcall-num")?.Value?.PadLeft(3, '0') ?? "";

                if (
                    string.IsNullOrWhiteSpace(title) ||
                    string.IsNullOrWhiteSpace(content) ||
                    string.IsNullOrWhiteSpace(id)
                )
                {
                    continue;
                }

                yield return (
                    new Bill()
                    {
                        Title = title,
                        Content = content,
                        Chamber = "house",
                        Code = id
                    },
                    id
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

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "house");
            string searchPattern = $"roll{id}.xml";
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

                foreach(XElement recordedVote in voteData.Element("vote-data").Descendants("recorded-vote"))
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    string memberId = recordedVote.Element("legislator").Attribute("name-id").Value;

                    if (!_keys.ContainsKey(memberId))
                    {
                        continue;
                    }

                    (string memberPrivateKey, string memberPublicKey) = _keys[memberId];
                    Vote vote = BuildVote(bill, recordedVote);

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
        /// <param name="recordedVote">
        /// The XML element containing the vote data.
        /// </param>
        /// <returns>
        /// The <see cref="Vote"/> poco to use.
        /// </returns>
        private static Vote BuildVote(VerifiedData<Bill> bill, XElement recordedVote) =>
            new Vote()
            {
                BillId = bill.Id,
                Opinion =
                    recordedVote.Element("vote")?.Value switch
                    {
                        "Yea" => true,
                        "Present" => true,
                        "Nay" => false,
                        _ => null
                    },
                Message = $"{recordedVote.Element("vote")?.Value}"
            };
    }
}