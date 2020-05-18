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
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoteCongress.Common.Encryption;
using System;

namespace RemoteCongress.Tests.Common.Encyption
{
    [TestClass]
    public class RsaUtilsTests
    {
        [DynamicData(
            nameof(RsaUtilsTestData.EncryptionTests),
            typeof(RsaUtilsTestData),
            DynamicDataSourceType.Property
        )]
        [TestMethod]
        public void RsaPrivateKeyEncryptionRoundTrip(string privateKey, string publicKey, string message)
        {
            //Arrange
            //Act
            var verification = RsaUtils.VerifySignature(
                publicKey,
                message,
                RsaUtils.GenerateSignature(privateKey, message)
            );

            //Assert
            verification
                .Should()
                .BeTrue();
        }

        [TestMethod]
        public void GenerateSignatureThrowsNullForNullPublicKey()
        {
            //Arrange
            Func<byte[]> action = () =>
                RsaUtils.GenerateSignature(
                    null,
                    "message"
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                    .Be("privateKey");
        }

        [TestMethod]
        public void GenerateSignatureThrowsNullForNullMessage()
        {
            //Arrange
            Func<byte[]> action = () =>
                RsaUtils.GenerateSignature(
                    "private key",
                    null
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                    .Be("message");
        }

        [TestMethod]
        public void VerifySignatureThrowsNullForNullPublicKey()
        {
            //Arrange
            Func<bool> action = () =>
                RsaUtils.VerifySignature(
                    null,
                    "message",
                    new byte[] {}
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                    .Be("publicKey");
        }

        [TestMethod]
        public void VerifySignatureThrowsNullForNullMessage()
        {
            //Arrange
            Func<bool> action = () =>
                RsaUtils.VerifySignature(
                    "public key",
                    null,
                    new byte[] {}
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                    .Be("message");
        }

        [TestMethod]
        public void VerifySignatureThrowsNullForNullSignature()
        {
            //Arrange
            Func<bool> action = () =>
                RsaUtils.VerifySignature(
                    "public key",
                    "message",
                    null
                );

            //Act
            action

            //Assert
                .Should()
                .Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                    .Be("signatureBytes");
        }
    }
}