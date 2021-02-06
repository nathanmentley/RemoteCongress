/*
    RemoteCongress - A platform for conducting small secure public elections
    Copyright (C) 2021  Nathan Mentley

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
using RemoteCongress.Common;
using RemoteCongress.Server.DAL.IpfsBlockchainDb;
using System;

namespace RemoteCongress.Tests.Server.DAL.IpfsBlockchainDb
{
    [TestClass]
    public class BlockTests
    {
        [TestMethod]
        public void CreateGenisysBlockSuccess()
        {
            Block block = Block.CreateGenisysBlock();

            block.LastBlockHash.Should().Be(string.Empty);
            block.Content.Should().Be(string.Empty);
            block.Hash.Should().NotBeNullOrWhiteSpace();
            block.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void CtorShouldThrowNullBlock()
        {
            //arrange
            Func<Block> action = () =>
                new Block(null, "content", RemoteCongressMediaType.None);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("previousBlock");
        }

        [TestMethod]
        public void CtorShouldThrowNullContent()
        {
            //arrange
            Func<Block> action = () =>
                new Block(Block.CreateGenisysBlock(), null, RemoteCongressMediaType.None);

            //act
            action

            //assert
                .Should()
                .Throw<ArgumentNullException>()
                .And.ParamName.Should().Be("content");
        }

        [TestMethod]
        public void CtorSuccess()
        {
            Block genisysBlock = Block.CreateGenisysBlock();
            Block block = new Block(genisysBlock, "content", RemoteCongressMediaType.None);

            block.LastBlockHash.Should().Be(genisysBlock.Hash);
            block.Content.Should().Be("content");
            block.Hash.Should().NotBeNullOrWhiteSpace();
            block.IsValid.Should().BeTrue();
        }
    }
}