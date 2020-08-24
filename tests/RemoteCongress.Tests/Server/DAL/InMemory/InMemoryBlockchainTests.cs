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
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using RemoteCongress.Common;

namespace RemoteCongress.Tests.Server.DAL.InMemory
{
    [TestClass]
    public class InMemoryBlockchainTests
    {
        private InMemoryBlockchain GetSubject() =>
            new InMemoryBlockchain();

        private void SetContent(InMemoryBlock block, string content) =>
            typeof(InMemoryBlock)
                .GetProperty("Content", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(block, content);

        private void SetLastBlockHash(InMemoryBlock block, string value) =>
            typeof(InMemoryBlock)
                .GetProperty("LastBlockHash", BindingFlags.NonPublic | BindingFlags.Instance)
                .SetValue(block, value);

        private IList<InMemoryBlock> GetBlocks(InMemoryBlockchain blockchain) =>
            typeof(InMemoryBlockchain)
                .GetField("_blocks", BindingFlags.NonPublic | BindingFlags.Instance)
                .GetValue(blockchain) as IList<InMemoryBlock>;

        [TestMethod]
        public void AppendWillAddABlock()
        {
            //arrange
            InMemoryBlockchain subject = GetSubject();

            //act
            InMemoryBlock block = subject.AppendToChain("content", RemoteCongressMediaType.None);
            IList<InMemoryBlock> blocks = GetBlocks(subject);

            //assert
            block.Id.Should().NotBeNullOrWhiteSpace();
            block.Content.Should().Be("content");
            blocks.Count.Should().Be(2);
            subject.FetchFromChain(block.Id).Should().NotBeNull();
            subject.IsValid.Should().BeTrue();
        }

        [TestMethod]
        public void IsValidFailsForAlteredContent()
        {
            //arrange
            InMemoryBlockchain subject = GetSubject();
            subject.AppendToChain("content", RemoteCongressMediaType.None);
            subject.AppendToChain("content", RemoteCongressMediaType.None);
            subject.AppendToChain("content", RemoteCongressMediaType.None);
            subject.AppendToChain("content", RemoteCongressMediaType.None);
            IList<InMemoryBlock> blocks = GetBlocks(subject);

            //act
            SetContent(blocks.Skip(2).First(), "altered");

            //assert
            subject.IsValid.Should().BeFalse();
        }
    }
}