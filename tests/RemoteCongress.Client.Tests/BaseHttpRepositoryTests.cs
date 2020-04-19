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
using Moq;
using Newtonsoft.Json.Linq;
using RemoteCongress.Common;
using System;
using System.Net.Http;

namespace RemoteCongress.Client.Tests
{
    [TestClass]
    public class BaseHttpRepositoryTests
    {
        private readonly Mock<HttpClient> _client =
            new Mock<HttpClient>();

        private readonly ClientConfig _config =
            new ClientConfig("http", "localhost");

        private readonly Func<string, ISignedData, FakeType> _creator =
            (id, data) => new FakeType(id, data);

        private class FakeType: BaseBlockModel
        {
            public FakeType(ISignedData data): base(data) {}
            public FakeType(string id, ISignedData data): base(id, data) {}
            protected override void Decode(JToken token) {}
        }

        private class SubjectType : BaseHttpRepository<FakeType>
        {
            public SubjectType(
                ClientConfig config,
                HttpClient httpClient,
                Func<string, ISignedData, FakeType> creator
            ):
                base(config, httpClient, creator) {}

            protected override string Endpoint => "Fake";
        }

        private SubjectType GetSubject() =>
            new SubjectType(_config, _client.Object, _creator);

        [TestMethod]
        public void CtorThrowsWhenCreatorIsNull()
        {
            //Arrange
            Func<SubjectType> action = () =>
                new SubjectType(_config, _client.Object, null);

            //Act
            action

            //Assert
                .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("creator");
        }

        [TestMethod]
        public void CtorThrowsWhenClientIsNull()
        {
            //Arrange
            Func<SubjectType> action = () =>
                new SubjectType(_config, null, _creator);

            //Act
            action

            //Assert
                .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("httpClient");
        }

        [TestMethod]
        public void CtorThrowsWhenConfigIsNull()
        {
            //Arrange
            Func<SubjectType> action = () =>
                new SubjectType(null, _client.Object, _creator);

            //Act
            action

            //Assert
                .Should().Throw<ArgumentNullException>()
                    .And.ParamName.Should()
                        .Be("config");
        }
    }
}
