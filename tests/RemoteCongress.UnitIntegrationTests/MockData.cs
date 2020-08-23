using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;
using RemoteCongress.Common.Serialization;
using System.Threading.Tasks;

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

        private static readonly ICodec<Bill> _billDataCodec =
            new BillV1JsonCodec();

        private static readonly ICodec<Vote> _voteDataCodec =
            new VoteV1JsonCodec();

        /// <summary>
        /// </summary>
        /// <param name="title">
        /// </param>
        /// <param name="content">
        /// </param>
        /// <returns>
        /// </returns>
        public static async Task<VerifiedData<Bill>> GetBill(string title, string content)
        {
            Bill billData = new Bill()
            {
                Title = title,
                Content = content
            };

            string blockContent = await _billDataCodec.EncodeToString(
                _billDataCodec.GetPreferredMediaType(),
                billData
            );

            SignedData signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent),
                _billDataCodec.GetPreferredMediaType()
            );

            return new VerifiedData<Bill>(signedData, billData);
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
        public static async Task<VerifiedData<Bill>> GetBill(string id, string title, string content)
        {
            Bill billData = new Bill()
            {
                Title = title,
                Content = content
            };

            string blockContent = await _billDataCodec.EncodeToString(
                _billDataCodec.GetPreferredMediaType(),
                billData
            );

            SignedData signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent),
                _billDataCodec.GetPreferredMediaType()
            );

            return new VerifiedData<Bill>(id, signedData, billData);
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
        public static async Task<VerifiedData<Vote>> GetVote(string billId, bool opinion, string message)
        {
            Vote voteData = new Vote()
            {
                BillId = billId,
                Opinion = opinion,
                Message = message
            };

            string blockContent = await _voteDataCodec.EncodeToString(
                _voteDataCodec.GetPreferredMediaType(),
                voteData
            );

            SignedData signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent),
                _voteDataCodec.GetPreferredMediaType()
            );

            return new VerifiedData<Vote>(signedData, voteData);
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
        public static async Task<VerifiedData<Vote>> GetVote(string id, string billId, bool opinion, string message)
        {
            Vote voteData = new Vote()
            {
                BillId = billId,
                Opinion = opinion,
                Message = message
            };

            string blockContent = await _voteDataCodec.EncodeToString(
                _voteDataCodec.GetPreferredMediaType(),
                voteData
            );

            SignedData signedData = new SignedData(
                PublicKey,
                blockContent,
                RsaUtils.GenerateSignature(PrivateKey, blockContent),
                _voteDataCodec.GetPreferredMediaType()
            );

            return new VerifiedData<Vote>(id, signedData, voteData);
        }
    }
}