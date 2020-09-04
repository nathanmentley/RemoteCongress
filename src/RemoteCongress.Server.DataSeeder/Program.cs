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
using Microsoft.Extensions.DependencyInjection;
using RemoteCongress.Client;
using RemoteCongress.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace RemoteCongress.Server.DataSeeder
{
    class Program
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string AdminPrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
d6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40FKdqbPS9sqAz1op32vOHHvB1
rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkwkwMRyHisc6diIMoNAgMBAAEC
gYAi/1buxBeS4A1yKso8EnoD4JjAywa2D2+kVNWauvpBhoUGbUxlj14y0XopBGDQ
CdmK3hVCurHN2/pgHv5d4aGQ3E394Nslog33uiz/Ianlt0mWQV/s9JolHJymI+na
njP+gMZafqVIePvlHWheJaqhdAF80yU44JJV9E/1RwQg+QJBAMGM0TFwJSOWgkZs
lMshTa8yQUjPtyXjQeqaZFwDF6ZdZLoQQ48ZNrXHz2Kxnkf22s5eovRAORJAPIf5
xvdcld8CQQCKfHA6j62ea2E9FzzDo4FAbaOZ1ZzHfiZJkP5V02g5PvqDa9pL5o2i
Q9MApt3UVzj2KtXZMx5yHSK0nao0YqWTAkAmt7qpPxvO0K7i05m4QMM/hrgUjqi+
hYWMHrJwzZWPjCM4LUS2fX66Qmwz/AADuVfv7HKAldBU3FC/irHIjdbVAkBjYHrU
u0f2t822nhc/uPRGfKb6/Hwd+BuXjRHGGwfelKAGcP3cm5ylhZBEFnp3JwQ8Om7t
By7g6qF+BOof3247AkAkBiZ5okAVl8BGBG4m4RPoUgVzi+ZKwFSxWko4hoo8tMKV
1YvXub7/GoRzqUdnxmo6F3qHl1+uT2CnSJuvkcqI";

        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        private static readonly string AdminPublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";

        private static readonly string HostName = "127.0.0.1:8000";
        private static readonly string Protocol = "http";

        public static async Task Main(string[] args)
        {
            using ServiceProvider serviceProvider = GetServiceProvider(
                new ClientConfig(Protocol, HostName)
            );

            IRemoteCongressClient client = serviceProvider.GetRequiredService<IRemoteCongressClient>();

            Console.WriteLine($"Seeding members");
            foreach(Member member in GetMembers())
            {
                Console.WriteLine($"{member.Id} {member.FirstName} {member.LastName}");

                await client.CreateMember(
                    AdminPrivateKey,
                    AdminPublicKey,
                    member,
                    CancellationToken.None
                );
            }

            await PopulateBillAndVoteData(client);
        }

        private static async Task PopulateBillAndVoteData(IRemoteCongressClient client)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data");
            string searchPattern = "vote_*.xml";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            foreach(FileInfo file in directoryInfo.GetFiles(searchPattern))
            {
                await PopulateRollCallVote(
                    client,
                    file.FullName
                );
            }
        }

        private static async Task PopulateRollCallVote(IRemoteCongressClient client, string file)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            XElement voteData = XElement.Load(file);

            Bill billData = new Bill()
            {
                Title = voteData.Element("vote_number").Value,
                Content = voteData.Element("vote_number").Value
            };

            Console.WriteLine($"{billData.Title}");

            VerifiedData<Bill> bill = await client.CreateBill(
                AdminPrivateKey,
                AdminPublicKey,
                billData,
                CancellationToken.None
            );

            foreach(XElement member in voteData.Element("members").Descendants("member"))
            {
                string memberId = member.Element("lis_member_id").Value;

                Console.WriteLine($"Processing vote from member {memberId} for bill {bill.Id}");

                string memberPublicKey = File.ReadAllText(
                    Path.Combine(path, "workspace", $"{memberId}.pub")
                );
                string memberPrivateKey = File.ReadAllText(
                    Path.Combine(path, "workspace", $"{memberId}")
                );

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

                await client.CreateVote(
                    memberPrivateKey,
                    memberPublicKey,
                    vote,
                    CancellationToken.None
                );
            }
        }

        private static IEnumerable<Member> GetMembers()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;

            Directory.CreateDirectory(Path.Combine(path, "workspace"));

            XElement senatorsData = XElement.Load(
                Path.Combine(path, "data/cvc_member_data.xml")
            );

            foreach(XElement senatorData in senatorsData.Descendants("senator"))
            {
                string id = senatorData.Attribute("lis_member_id").Value;

                (string privateKey, string publicKey) = GenerateKeys();

                File.WriteAllText(
                    Path.Combine(path, "workspace", $"{id}"),
                    privateKey
                );

                File.WriteAllText(
                    Path.Combine(path, "workspace", $"{id}.pub"),
                    publicKey
                );

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

        private static (string privateKey, string publicKey) GenerateKeys()
        {
            //use a higher bit key. For speed in a proof of concept this is fine. But this
            // should probably be 4096 in the real world.
            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024);

            using StringWriter publicKeyWriter = new StringWriter();
            ExportPublicKey(rsa, publicKeyWriter);
            string publicKey = publicKeyWriter.ToString();

            using StringWriter privateKeyWriter = new StringWriter();
            ExportPrivateKey(rsa, privateKeyWriter);
            string privateKey = privateKeyWriter.ToString();

            return (privateKey, publicKey);
        }

        private static ServiceProvider GetServiceProvider(ClientConfig config) =>
            new ServiceCollection()
                .AddRemoteCongressClient(config)
                .BuildServiceProvider();

        private static void ExportPublicKey(RSACryptoServiceProvider csp, TextWriter outputStream)
        {
            var parameters = csp.ExportParameters(false);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    innerWriter.Write((byte)0x30); // SEQUENCE
                    EncodeLength(innerWriter, 13);
                    innerWriter.Write((byte)0x06); // OBJECT IDENTIFIER
                    var rsaEncryptionOid = new byte[] { 0x2a, 0x86, 0x48, 0x86, 0xf7, 0x0d, 0x01, 0x01, 0x01 };
                    EncodeLength(innerWriter, rsaEncryptionOid.Length);
                    innerWriter.Write(rsaEncryptionOid);
                    innerWriter.Write((byte)0x05); // NULL
                    EncodeLength(innerWriter, 0);
                    innerWriter.Write((byte)0x03); // BIT STRING
                    using (var bitStringStream = new MemoryStream())
                    {
                        var bitStringWriter = new BinaryWriter(bitStringStream);
                        bitStringWriter.Write((byte)0x00); // # of unused bits
                        bitStringWriter.Write((byte)0x30); // SEQUENCE
                        using (var paramsStream = new MemoryStream())
                        {
                            var paramsWriter = new BinaryWriter(paramsStream);
                            EncodeIntegerBigEndian(paramsWriter, parameters.Modulus); // Modulus
                            EncodeIntegerBigEndian(paramsWriter, parameters.Exponent); // Exponent
                            var paramsLength = (int)paramsStream.Length;
                            EncodeLength(bitStringWriter, paramsLength);
                            bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength);
                        }
                        var bitStringLength = (int)bitStringStream.Length;
                        EncodeLength(innerWriter, bitStringLength);
                        innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength);
                    }
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
            }
        }

        private static void ExportPrivateKey(RSACryptoServiceProvider csp, TextWriter outputStream)
        {
            if (csp.PublicOnly) throw new ArgumentException("CSP does not contain a private key", "csp");
            var parameters = csp.ExportParameters(true);
            using (var stream = new MemoryStream())
            {
                var writer = new BinaryWriter(stream);
                writer.Write((byte)0x30); // SEQUENCE
                using (var innerStream = new MemoryStream())
                {
                    var innerWriter = new BinaryWriter(innerStream);
                    EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
                    EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
                    EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
                    EncodeIntegerBigEndian(innerWriter, parameters.D);
                    EncodeIntegerBigEndian(innerWriter, parameters.P);
                    EncodeIntegerBigEndian(innerWriter, parameters.Q);
                    EncodeIntegerBigEndian(innerWriter, parameters.DP);
                    EncodeIntegerBigEndian(innerWriter, parameters.DQ);
                    EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);
                    var length = (int)innerStream.Length;
                    EncodeLength(writer, length);
                    writer.Write(innerStream.GetBuffer(), 0, length);
                }

                var base64 = Convert.ToBase64String(stream.GetBuffer(), 0, (int)stream.Length).ToCharArray();
                // Output as Base64 with lines chopped at 64 characters
                for (var i = 0; i < base64.Length; i += 64)
                {
                    outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
                }
            }
        }

        private static void EncodeLength(BinaryWriter stream, int length)
        {
            if (length < 0) throw new ArgumentOutOfRangeException("length", "Length must be non-negative");
            if (length < 0x80)
            {
                // Short form
                stream.Write((byte)length);
            }
            else
            {
                // Long form
                var temp = length;
                var bytesRequired = 0;
                while (temp > 0)
                {
                    temp >>= 8;
                    bytesRequired++;
                }
                stream.Write((byte)(bytesRequired | 0x80));
                for (var i = bytesRequired - 1; i >= 0; i--)
                {
                    stream.Write((byte)(length >> (8 * i) & 0xff));
                }
            }
        }

        private static void EncodeIntegerBigEndian(BinaryWriter stream, byte[] value, bool forceUnsigned = true)
        {
            stream.Write((byte)0x02); // INTEGER
            var prefixZeros = 0;
            for (var i = 0; i < value.Length; i++)
            {
                if (value[i] != 0) break;
                prefixZeros++;
            }
            if (value.Length - prefixZeros == 0)
            {
                EncodeLength(stream, 1);
                stream.Write((byte)0);
            }
            else
            {
                if (forceUnsigned && value[prefixZeros] > 0x7f)
                {
                    // Add a prefix zero to force unsigned if the MSB is 1
                    EncodeLength(stream, value.Length - prefixZeros + 1);
                    stream.Write((byte)0);
                }
                else
                {
                    EncodeLength(stream, value.Length - prefixZeros);
                }
                for (var i = prefixZeros; i < value.Length; i++)
                {
                    stream.Write(value[i]);
                }
            }
        }
    }
}
