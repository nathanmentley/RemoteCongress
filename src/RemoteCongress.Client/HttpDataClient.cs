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
using Newtonsoft.Json;
using RemoteCongress.Common;
using RemoteCongress.Common.Repositories;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// An abstraction layer implementing <see cref="IBillRepository"/> that fetches and creates
    ///     <see cref="Bill"/> instances.
    /// </summary>
    /// <remarks>
    /// This implementation of <see cref="IBillRepository"/> of the repository is built for connecting over an http
    ///     conntection. It's expecting to send <see cref="SignedData"/> instances to a web server.
    /// </remarks>
    public class HttpDataClient: IDataClient
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        private readonly string _endpoint;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">
        /// A <see cref="ClientConfig"/> instance that holds configuration data on connecting to the server.
        /// </param>
        /// <param name="httpClient">
        /// A <see cref="HttpClient"/> instance to use to communicate with the server.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        public HttpDataClient(
            ClientConfig config,
            HttpClient httpClient,
            string endpoint
        )
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));

            _endpoint = endpoint ??
                throw new ArgumentNullException(nameof(endpoint));
        }

        public async Task<string> AppendToChain(ISignedData data, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var json = GetJson(new SignedData(data));
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(
                $"{_config.Protocol}://{_config.ServerHostName}/{_endpoint}",
                byteContent,
                cancellationToken
            );

            var result = await GetSignedData(response);

            return result.Id;
        }

        public async Task<ISignedData> FetchFromChain(string id, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{_config.Protocol}://{_config.ServerHostName}/{_endpoint}/{id}",
                cancellationToken
            );

            return await GetSignedData(response);
        }

        /// <summary>
        /// Converts <see cref="SignedData"/> to a json string.
        /// </summary>
        private static string GetJson(SignedData signedData) =>
            JsonConvert.SerializeObject(new SignedData(signedData));

        /// <summary>
        /// Pulls a <see cref="SignedData"/> instance from a <see cref="HttpResponseMessage"/>.
        /// </summary>
        private static async Task<SignedData> GetSignedData(HttpResponseMessage response)
        {
            using var body = await response.Content.ReadAsStreamAsync();

            using var sr = new StreamReader(body);
            using var reader = new JsonTextReader(sr);
            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<SignedData>(reader);
        }
    }
}