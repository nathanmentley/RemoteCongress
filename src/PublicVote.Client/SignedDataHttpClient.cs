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
    public class SignedDataHttpClient: ISignedDataHttpClient
    {
        private readonly ClientConfig _config;
        private readonly HttpClient _httpClient;


        public SignedDataHttpClient(ClientConfig config, HttpClient httpClient)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));

            _httpClient = httpClient ??
                throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<SignedData> CreateSignedData(string endpoint, SignedData content)
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

        public async Task<SignedData> FetchSignedData(string endpoint, string id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(
                $"{_config.Protocol}://{_config.ServerHostName}/{endpoint}/{id}"
            );

            return await GetSignedData(response);
        }

        private static string GetJson(SignedData signedData)
        {
            //TODO: move this code to common, and share between server and client.
            return JsonConvert.SerializeObject(new SignedData(signedData));
        }

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