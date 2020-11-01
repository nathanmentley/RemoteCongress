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
using RemoteCongress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml.Linq;

namespace RemoteCongress.Server.DataSeeder
{
    public class SenateDataSeeder: IDataSeeder
    {
        private readonly IDictionary<string, (string, string)> _keys =
            new Dictionary<string, (string, string)>();

        private readonly IKeyGenerator _keyGenerator;
        private readonly int _congress;
        private readonly int _session;

        public SenateDataSeeder(
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

        public async IAsyncEnumerable<Member> GetMembers([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = AppDomain.CurrentDomain.BaseDirectory;

            Directory.CreateDirectory(Path.Combine(path, "workspace"));

            XElement senatorsData = XElement.Load(
                Path.Combine(path, "data/cvc_member_data.xml")
            );

            foreach(XElement senatorData in senatorsData.Descendants("senator"))
            {
                string id = senatorData.Attribute("lis_member_id").Value;

                (string privateKey, string publicKey) = await _keyGenerator.GenerateKeys(1024, cancellationToken);
                _keys[id] = (privateKey, publicKey);

                yield return new Member()
                {
                    Id = id,
                    FirstName = senatorData.Element("name").Element("first").Value,
                    LastName = senatorData.Element("name").Element("last").Value,
                    Seat = senatorData.Element("state").Value + senatorData.Element("stateRank").Value,
                    Party = senatorData.Element("party").Value,
                    PublicKey = publicKey
                };
            }
        }

        public async IAsyncEnumerable<(Bill, string)> GetBills([EnumeratorCancellation] CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string searchPattern = $"vote_{_congress}_{_session}_*.xml";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(FileInfo file in directoryInfo.GetFiles(searchPattern))
            {
                using MemoryStream stream = new MemoryStream(
                    await File.ReadAllBytesAsync(file.FullName, cancellationToken)
                );

                XElement voteData = await XElement.LoadAsync(
                    stream,
                    new LoadOptions(),
                    CancellationToken.None
                );

                yield return (
                    new Bill()
                    {
                        Title = voteData.Element("vote_number").Value,
                        Content = voteData.Element("vote_number").Value
                    },
                    voteData.Element("vote_number").Value.PadLeft(5, '0')
                );
            }
        }

        public async IAsyncEnumerable<(Vote vote, string memberPrivateKey, string memberPublicKey)> GetVotes(
            string id,
            VerifiedData<Bill> bill,
            [EnumeratorCancellation] CancellationToken cancellationToken
        )
        {
            cancellationToken.ThrowIfCancellationRequested();

            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string searchPattern = $"vote_{_congress}_{_session}_{id}.xml";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(FileInfo file in directoryInfo.GetFiles(searchPattern))
            {
                using MemoryStream stream = new MemoryStream(
                    await File.ReadAllBytesAsync(file.FullName, cancellationToken)
                );

                XElement voteData = await XElement.LoadAsync(
                    stream,
                    new LoadOptions(),
                    CancellationToken.None
                );

                foreach(XElement member in voteData.Element("members").Descendants("member"))
                {
                    string memberId = member.Element("lis_member_id").Value;
                    (string memberPrivateKey, string memberPublicKey) = _keys[memberId];
                    string voteCast = member.Element("vote_cast").Value;
                    string memberFull = member.Element("member_full").Value;
                    bool? opinion = voteCast switch
                    {
                        "Yea" => true,
                        "Nay" => false,
                        _ => null
                    };
                    string message = $"{memberFull} voted {voteCast}";

                    Vote vote = new Vote()
                    {
                        BillId = bill.Id,
                        Opinion = opinion,
                        Message = message
                    };

                    yield return (vote, memberPrivateKey, memberPublicKey);
                }
            }
        }
    }
}