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
using Ipfs.CoreApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RemoteCongress.Server.DAL.IpfsBlockchainDb;

namespace RemoteCongress.Tests.Server.DAL.IpfsBlockchainDb
{
    [TestClass]
    public class BlockchainTests
    {
        private (Mock<ICoreApi>, Mock<IFileSystemApi>) GetIpfsMocks()
        {
            Mock<ICoreApi> engineMock = new Mock<ICoreApi>();
            Mock<IFileSystemApi> fileSystemApiMock = new Mock<IFileSystemApi>();

            engineMock.Setup(engine => engine.FileSystem)
                .Returns(fileSystemApiMock.Object);

            return (engineMock, fileSystemApiMock);
        }

        private IpfsBlockchainConfig GetConfig() =>
            new IpfsBlockchainConfig()
            {
                LastBlockId = null,
                Password = "password"
            };

        [Ignore]
        [TestMethod]
        public void CtorSuccess()
        {/*
            var config = GetConfig();
            var (engineMock, fileSystemApiMock) = GetIpfsMocks();

            var result = new FileSystemNode();
            result.Id = Cid.Decode("{}");

            fileSystemApiMock
                .Setup(fs => fs.AddTextAsync(It.IsAny<string>(), null, CancellationToken.None))
                .ReturnsAsync(result);

            //Arrange
            Func<Blockchain> action = () =>
                new Blockchain(engineMock.Object, config);

            //Act
            action

            //Assert
                .Should()
                .NotThrow();*/
        }
    }
}