/*
    PublicVote - A platform for conducting small secure internal elections
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
using PublicVote.Common;
using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PublicVote.Client
{
    /// <summary>
    /// A Http Repository that can be used to easily interact with the PublicVote api.
    /// </summary>
    /// <remarks>
    /// This doesn't validate data. Repositories that use this should be doing that.
    ///     In theory, they're operating on <see cref="Bill"/>s, <see cref="Votes"/>,
    ///     or another they that inherits correctly from <see cref="BaseBlockModel"/>
    ///     and we're getting validation when converting <see cref="SignedData"/> to
    ///     one of those types.
    /// </remarks>
    internal class HttpRepository
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">
        /// The PublicApi connection configuration data.
        /// </param>
        /// <param name="httpClient">
        /// The <see cref="HttpClient"/> to connect to the PublicVote API.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </exception>
        internal HttpRepository(ClientConfig config, HttpClient httpClient)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Persits the <paramref name="content"/> if it passes validation.
        /// </summary>
        /// <param name="endpoint">
        /// The endpoint to send the request to.
        /// </param>
        /// <param name="content">
        /// The <see cref="SignedData"/> content to send to the endpoint.
        /// </param>
        /// <returns>
        /// An unvalidated <see cref="SignedData"/> that was returned from the server.
        /// </returns>
        internal async Task<SignedData> CreateSignedData(string endpoint, SignedData content)
        {
            var json = GetJson(content);
            var buffer = Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync(
                $"{_config.Protocol}://{_config.ServerHostName}/{endpoint}",
                byteContent
            );

            return await GetSignedData(response);
        }

        /// <summary>
        /// Fetches a <see cref="SignedData"/> instance by it's <see cref="IIdentifiable.Id"/>.
        /// </summary>
        /// <param name="endpoint">
        /// The endpoint to send the request to.
        /// </param>
        /// <param name="id">
        /// The <see cref="IIdentifiable.Id"/> of the <see cref="SignedData"/> to fetch.
        /// </param>
        /// <returns>
        /// An unvalidated <see cref="SignedData"/> that was returned from the server.
        /// </returns>
        internal async Task<SignedData> FetchSignedData(string endpoint, string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{_config.Protocol}://{_config.ServerHostName}/{endpoint}/{id}"
            );

            return await GetSignedData(response);
        }

        /// <summary>
        /// Converts <see cref="SignedData"/> to a json string.
        /// </summary>
        private static string GetJson(SignedData signedData)
        {
            //TODO: move this code to common, and share between server and client.
            return JsonConvert.SerializeObject(new SignedData(signedData));
        }

        /// <summary>
        /// Pulls a <see cref="SignedData"/> instance from a <see cref="HttpResponseMessage"/>.
        /// </summary>
        private static async Task<SignedData> GetSignedData(HttpResponseMessage response)
        {
            using var body = await response.Content.ReadAsStreamAsync();

            //TODO: move this code to common, and share between server and client.
            using var sr = new StreamReader(body);
            using var reader = new JsonTextReader(sr);
            JsonSerializer serializer = new JsonSerializer();

            return serializer.Deserialize<SignedData>(reader);
        }
    }
}