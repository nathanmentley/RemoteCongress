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
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicVote.Common.Encryption;

namespace PublicVote.Common.Tests.Encyption
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
    }
}