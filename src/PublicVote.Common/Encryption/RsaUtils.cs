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
    /// <summary>
    /// A simple utility class to handle RSA Signing and Verification
    /// </summary>
    public static class RsaUtils
    {
        /// <summary>
        /// Generates an rsa signature hash with a private key that can be verified with the public key.
        /// </summary>
        /// <param name="privateKey">
        /// A rsa private key to use to generate a signature hash.
        /// </param>
        /// <param name="message">
        /// The message to generate the signature for.
        /// </param>
        /// <returns>
        /// A <see cref="byte[]"/> containing the signature.
        /// </returns>
        /// <remarks>
        /// We're using this signature hash to ensure the message that is signed is tied to who created it, and 
        ///  so we can make this message immutable. If any of the content of <paramref name="message"/> changes
        ///  later on, the signature verification will fail.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Throw if <paramref name="privateKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throw if <paramref name="message"/> is null.
        /// </exception>
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

        /// <summary>
        /// Validates that a signature matches the passed message, and is sent from who is being claimed by the public key.
        /// </summary>
        /// <param name="publicKey">
        /// A rsa public key to match the signature against.
        /// </param>
        /// <param name="message">
        /// The message content to ensure is valid and unmutated since signed.
        /// </param>
        /// <param name="signatureBytes">
        /// The signature to test against <paramref name="publicKey"/> and <paramref name="message"/>.
        /// </param>
        /// <returns>
        /// <see cref="true"/> if <paramref name="signatureBytes"/> is a valid signature for <paramref name="publicKey"/>
        ///     and <paramref name="message"/>.
        /// </returns>
        /// <remarks>
        /// We're using this verification to know that our signed data content is coming from the individual who is
        ///  represnted by <paramref name="publicKey"/> and that their <paramref name="message"/> isn't tampered with.
        /// </remarks>
        /// <exception cref="ArgumentNullException">
        /// Throw if <paramref name="publicKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throw if <paramref name="message"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Throw if <paramref name="signatureBytes"/> is null.
        /// </exception>
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

        /// <summary>
        /// Fetches a common Hashing Algorithm to used throughout this class.
        /// </summary>
        /// <returns>
        /// <see cref="HashAlgorithmName.SHA512"/>
        /// </returns>
        /// <remarks>
        /// In a production version of this platform this should be dynamic.
        /// </remarks>
        private static HashAlgorithmName GetAlgorithmName() =>
            HashAlgorithmName.SHA512;

        /// <summary>
        /// Fetches a common signature padding configuration to use through out this class.
        /// </summary>
        /// <returns>
        /// <see cref="RSASignaturePadding.Pkcs1"/>
        /// </returns>
        /// <remarks>
        /// In a production version of this platform this should be dynamic.
        /// </remarks>
        private static RSASignaturePadding GetPadding() =>
            RSASignaturePadding.Pkcs1;

        /// <summary>
        /// Fetches a common <see cref="Encoding"/> to use throughout this class.
        /// </summary>
        /// <returns>
        /// <see cref="Encoding.Unicode"/>
        /// </returns>
        /// <remarks>
        /// In a production version of this platform this should be dynamic.
        /// </remarks>
        private static Encoding GetEncoding() =>
            Encoding.Unicode;
    }
}