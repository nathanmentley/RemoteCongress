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
using RemoteCongress.Server.DAL.InMemory;
using System;

namespace RemoteCongress.Tests.Server.DAL.InMemory
{
    [TestClass]
    public class InMemoryBlockTests
    {
        [TestMethod]
        public void CreateGenisysBlockSuccess()
        {
            InMemoryBlock block = InMemoryBlock.CreateGenisysBlock();

            block.Id.Should().NotBeNullOrWhiteSpace();
            block.LastBlockHash.Should().Be(string.Empty);
            block.Content.Should().Be(string.Empty);
            block.Hash.Should().NotBeNullOrWhiteSpace();
            block.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void CtorShouldThrowNullBlock()
        {
            //arrange
            Func<InMemoryBlock> action = () =>
                new InMemoryBlock(null, "content");

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
            Func<InMemoryBlock> action = () =>
                new InMemoryBlock(InMemoryBlock.CreateGenisysBlock(), null);

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
            InMemoryBlock genisysBlock = InMemoryBlock.CreateGenisysBlock();
            InMemoryBlock block = new InMemoryBlock(genisysBlock, "content");

            block.Id.Should().NotBeNullOrWhiteSpace();
            block.LastBlockHash.Should().Be(genisysBlock.Hash);
            block.Content.Should().Be("content");
            block.Hash.Should().NotBeNullOrWhiteSpace();
            block.IsValid.Should().BeTrue();
        }
    }
}