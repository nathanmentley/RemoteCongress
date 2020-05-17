using Newtonsoft.Json.Linq;
using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;

namespace RemoteCongress.UnitIntegrationTests
{
    public class MockData
    {
        /// <remarks>
        /// Throw away private / pub key
        /// </remarks>
        public static string PrivateKey = @"MIICWgIBAAKBgGiz/dPcdEo6G6b/+zf8VN65fgSUFTwpq3tjtOwR6jj9zzWG6o3S
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
        public static string PublicKey = @"MIGeMA0GCSqGSIb3DQEBAQUAA4GMADCBiAKBgGiz/dPcdEo6G6b/+zf8VN65fgSU
FTwpq3tjtOwR6jj9zzWG6o3Sd6V/XmJhrAzuyvnZP+779nhvuUaT7ks2hZXOEV40
FKdqbPS9sqAz1op32vOHHvB1rc8HVopFY5UqpN1SJ/15BMImaAb/ucGe/YBpNTkw
kwMRyHisc6diIMoNAgMBAAE=";


        /// <summary>
        /// </summary>
        /// <param name="title">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <returns>
        /// </returns>
        public static Bill GetBill(string title, string content)
        {
            var blockContent = JToken.FromObject(new {
                title = title,
                content = content
            }).ToString();

            var signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent)
            );

            return new Bill(signedData);
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <param name="title">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <returns>
        /// </returns>
        public static Bill GetBill(string id, string title, string content)
        {
            var blockContent = JToken.FromObject(new {
                title = title,
                content = content
            }).ToString();

            var signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent)
            );

            return new Bill(id, signedData);
        }

        /// <summary>
        /// </summary>
        /// <param name="billId">
        /// </param>
        /// <param name="opinion">
        /// </param>
        /// <param name="message">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vote GetVote(string billId, bool opinion, string message)
        {
            var blockContent = JToken.FromObject(new {
                billId = billId,
                opinion = opinion,
                message = message
            }).ToString();

            var signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent)
            );

            return new Vote(signedData);
        }

        /// <summary>
        /// </summary>
        /// <param name="id">
        /// </param>
        /// <param name="billId">
        /// </param>
        /// <param name="opinion">
        /// </param>
        /// <param name="message">
        /// </param>
        /// <returns>
        /// </returns>
        public static Vote GetVote(string id, string billId, bool opinion, string message)
        {
            var blockContent = JToken.FromObject(new {
                billId = billId,
                opinion = opinion,
                message = message
            }).ToString();

            var signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent)
            );

            return new Vote(id, signedData);
        }
    }
}
