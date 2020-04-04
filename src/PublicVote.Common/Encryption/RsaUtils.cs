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
using System;
using System.Security.Cryptography;
using System.Text;

namespace PublicVote.Common.Encryption
{
    public static class RsaUtils
    {
        public static byte[] GenerateSignature(string privateKey, string message)
        {
            if (string.IsNullOrWhiteSpace(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            var converter = GetEncoding();
            byte[] privateKeyBytes = Convert.FromBase64String(privateKey);
            byte[] messageBytes = converter.GetBytes(message);

            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(privateKeyBytes, out _);

            return rsa.SignData(
                messageBytes,
                GetAlgorithmName(),
                GetPadding()
            );
        }

        public static bool VerifySignature(string publicKey, string message, byte[] signatureBytes)
        {
            if (string.IsNullOrWhiteSpace(publicKey))
                throw new ArgumentNullException(nameof(publicKey));

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentNullException(nameof(message));

            if (signatureBytes is null)
                throw new ArgumentNullException(nameof(signatureBytes));

            var converter = GetEncoding();
            byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
            byte[] messageBytes = converter.GetBytes(message);

            using var rsa = RSA.Create();
            rsa.ImportSubjectPublicKeyInfo(publicKeyBytes, out _);

            return rsa.VerifyData(
                messageBytes,
                signatureBytes,
                GetAlgorithmName(),
                GetPadding()
            );
        }

        private static HashAlgorithmName GetAlgorithmName() =>
            HashAlgorithmName.SHA512;

        private static RSASignaturePadding GetPadding() =>
            RSASignaturePadding.Pkcs1;

        private static Encoding GetEncoding() =>
            new UnicodeEncoding();
    }
}