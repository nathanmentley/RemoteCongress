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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Server.DataSeeder
{
    /// <summary>
    /// An implementation of <see cref="IKeyGenerator"/> that'll return RSA key pairs.
    /// </summary>
    public class KeyGenerator: IKeyGenerator
    {
        private static readonly IEnumerable<Byte> RsaEncryptionOid =
            new byte[] { 0x2a, 0x86, 0x48, 0x86, 0xf7, 0x0d, 0x01, 0x01, 0x01 };

        private readonly ILogger<KeyGenerator> _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        public KeyGenerator(ILogger<KeyGenerator> logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Generates a public and private key pair.
        /// </summary>
        /// <param name="bit">
        /// How many bits should the key be.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation.
        /// </param>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if <paramref name="bit"/> is less than 1.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is cancelled.
        /// </exception>
        public Task<(string privateKey, string publicKey)> GenerateKeys(
            int bit,
            CancellationToken cancellationToken = default
        )
        {
            if (bit < 1)
            {
                throw _logger.LogException(
                    new ArgumentOutOfRangeException(
                        nameof(bit),
                        $"{nameof(bit)} cannot be less than 1"
                    )
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            using RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(bit);
            using StringWriter privateKeyWriter = ExportPrivateKey(rsa);
            using StringWriter publicKeyWriter = ExportPublicKey(rsa);

            return Task.FromResult(
                (
                    privateKeyWriter.ToString(),
                    publicKeyWriter.ToString()
                )
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="csp">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        private StringWriter ExportPublicKey(RSACryptoServiceProvider csp)
        {
            StringWriter outputStream = new StringWriter();

            using MemoryStream stream = new MemoryStream();
            
            WritePublicHeader(csp, stream);

            char[] base64 = Convert
                .ToBase64String(stream.GetBuffer(), 0, (int)stream.Length)
                .ToCharArray();

            for (int i = 0; i < base64.Length; i += 64)
            {
                outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
            }

            return outputStream;
        }

        /// /// <summary>
        /// 
        /// </summary>
        /// <param name="csp">
        /// 
        /// </param>
        /// <returns>
        /// 
        /// </returns>
        private StringWriter ExportPrivateKey(RSACryptoServiceProvider csp)
        {
            if (csp.PublicOnly)
            {
                throw _logger.LogException(
                    new ArgumentException(
                        "CSP does not contain a private key",
                        nameof(csp)
                    )
                );
            }

            StringWriter outputStream = new StringWriter();

            RSAParameters parameters = csp.ExportParameters(true);

            using MemoryStream stream = new MemoryStream();
            using MemoryStream innerStream = new MemoryStream();

            BinaryWriter writer = new BinaryWriter(stream);
            BinaryWriter innerWriter = new BinaryWriter(innerStream);

            writer.Write((byte)0x30); // SEQUENCE
            EncodeIntegerBigEndian(innerWriter, new byte[] { 0x00 }); // Version
            EncodeIntegerBigEndian(innerWriter, parameters.Modulus);
            EncodeIntegerBigEndian(innerWriter, parameters.Exponent);
            EncodeIntegerBigEndian(innerWriter, parameters.D);
            EncodeIntegerBigEndian(innerWriter, parameters.P);
            EncodeIntegerBigEndian(innerWriter, parameters.Q);
            EncodeIntegerBigEndian(innerWriter, parameters.DP);
            EncodeIntegerBigEndian(innerWriter, parameters.DQ);
            EncodeIntegerBigEndian(innerWriter, parameters.InverseQ);

            int length = (int)innerStream.Length;
            EncodeLength(writer, length);
            writer.Write(innerStream.GetBuffer(), 0, length);

            char[] base64 = Convert
                .ToBase64String(stream.GetBuffer(), 0, (int)stream.Length)
                .ToCharArray();

            // Output as Base64 with lines chopped at 64 characters
            for (int i = 0; i < base64.Length; i += 64)
            {
                outputStream.WriteLine(base64, i, Math.Min(64, base64.Length - i));
            }
            return outputStream;
        }

        private void WritePublicHeader(RSACryptoServiceProvider csp, MemoryStream stream)
        {
            RSAParameters parameters = csp.ExportParameters(false);

            using MemoryStream innerStream = new MemoryStream();
            using MemoryStream bitStringStream = new MemoryStream();
            using MemoryStream paramsStream = new MemoryStream();

            BinaryWriter writer = new BinaryWriter(stream);
            BinaryWriter innerWriter = new BinaryWriter(innerStream);
            BinaryWriter bitStringWriter = new BinaryWriter(bitStringStream);
            BinaryWriter paramsWriter = new BinaryWriter(paramsStream);

            writer.Write((byte)0x30); // SEQUENCE
            innerWriter.Write((byte)0x30); // SEQUENCE
            EncodeLength(innerWriter, 13);
            innerWriter.Write((byte)0x06); // OBJECT IDENTIFIER
            EncodeLength(innerWriter, RsaEncryptionOid.Count());
            innerWriter.Write(RsaEncryptionOid.ToArray());
            innerWriter.Write((byte)0x05); // NULL
            EncodeLength(innerWriter, 0);
            innerWriter.Write((byte)0x03); // BIT STRING
            bitStringWriter.Write((byte)0x00); // # of unused bits
            bitStringWriter.Write((byte)0x30); // SEQUENCE

            EncodeIntegerBigEndian(paramsWriter, parameters.Modulus); // Modulus
            EncodeIntegerBigEndian(paramsWriter, parameters.Exponent); // Exponent
            int paramsLength = (int)paramsStream.Length;
            EncodeLength(bitStringWriter, paramsLength);
            bitStringWriter.Write(paramsStream.GetBuffer(), 0, paramsLength);

            int bitStringLength = (int)bitStringStream.Length;
            EncodeLength(innerWriter, bitStringLength);
            innerWriter.Write(bitStringStream.GetBuffer(), 0, bitStringLength);

            int length = (int)innerStream.Length;
            EncodeLength(writer, length);
            writer.Write(innerStream.GetBuffer(), 0, length);
        }

        private void EncodeIntegerBigEndian(
            BinaryWriter stream,
            byte[] value,
            bool forceUnsigned = true
        )
        {
            stream.Write((byte)0x02); // INTEGER

            int prefixZeros = 0;
            for (int i = 0; i < value.Length; i++)
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

                for (int i = prefixZeros; i < value.Length; i++)
                {
                    stream.Write(value[i]);
                }
            }
        }

        private void EncodeLength(BinaryWriter stream, int length)
        {
            if (length < 0)
            {
                throw _logger.LogException(
                    new ArgumentOutOfRangeException(
                        nameof(length),
                        "Length must be non-negative"
                    )
                );
            }

            if (length < 0x80)
            {
                // Short form
                stream.Write((byte)length);
            }
            else
            {
                // Long form
                int temp = length;
                int bytesRequired = 0;

                while (temp > 0)
                {
                    temp >>= 8;
                    bytesRequired++;
                }

                stream.Write((byte)(bytesRequired | 0x80));

                for (int i = bytesRequired - 1; i >= 0; i--)
                {
                    stream.Write((byte)(length >> (8 * i) & 0xff));
                }
            }
        }
    }
}