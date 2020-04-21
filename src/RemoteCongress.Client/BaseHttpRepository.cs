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
    public abstract class BaseHttpRepository<T>: IImmutableDataRepository<T> where T: BaseBlockModel
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;
        private readonly Func<string, ISignedData, T> _creator;

        /// <summary>
        /// The endpoint to hit with the repository.
        /// </summary>
        protected abstract string Endpoint { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config">
        /// A <see cref="ClientConfig"/> instance that holds configuration data on connecting to the server.
        /// </param>
        /// <param name="httpClient">
        /// A <see cref="HttpClient"/> instance to use to communicate with the server.
        /// </param>
        /// <param name="creator">
        /// Injected logic to construct an instance of <typeparamref name="T"/> from an Id, and <see cref="ISignedData"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="config"/> is null.
        /// </excpetion>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="httpClient"/> is null.
        /// </excpetion>
        protected BaseHttpRepository(
            ClientConfig config,
            HttpClient httpClient,
            Func<string, ISignedData, T> creator
        )
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));

            _creator = creator ??
                throw new ArgumentNullException(nameof(creator));
        }

        /// <summary>
        /// Creates and persist the signed and verified <paramref name="instance"/>.
        /// </summary>
        /// <param name="instance">
        /// A signed and verified instance of type <typeparamref name="T"/> to persist.
        /// </param>
        /// <returns>
        /// The persisted <paramref name="instance"/> model.
        /// </returns>
        public async Task<T> Create(T instance)
        {
            var signedData = await CreateSignedData(
                Endpoint,
                new SignedData(instance)
            );

            //Since the _creator should be calling a ctor of a BaseBlockModel
            // we can be sure that this model's signature hash is valid against 
            // the data.
            return _creator(signedData.Id, signedData);
        }

        /// <summary>
        /// Fetches a persisted instance of <typeparamref name="T"/> that has an <see cref="IIdentifiable.Id"/> that
        ///     matches <paramref name="id"/>.
        /// </summary>
        /// <param name="id">
        /// The unique <see cref="IIdentifiable.Id"/> of an <typeparamref name="T"/> instance to fetch.
        /// </param>
        /// <returns>
        /// The immutable, and verified <typeparamref name="T"/> instance with an <see cref="IIdentifiable.Id"/>
        ///     of <paramref name="id"/>.
        /// </returns>
        public async Task<T> Fetch(string id)
        {
            var signedData = await FetchSignedData(Endpoint, id);

            //Since the _creator should be calling a ctor of a BaseBlockModel
            // we can be sure that this model's signature hash is valid against 
            // the data.
            return _creator(id, signedData);
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
        private async Task<SignedData> CreateSignedData(string endpoint, SignedData content)
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
        private async Task<SignedData> FetchSignedData(string endpoint, string id)
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