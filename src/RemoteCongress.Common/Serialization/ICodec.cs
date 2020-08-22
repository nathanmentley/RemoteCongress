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
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Serialization
{
    public interface ICodec<T>
    {
        RemoteCongressMediaType GetPreferredMediaType();

        bool CanHandle(RemoteCongressMediaType mediaType);

        Task<Stream> Encode(RemoteCongressMediaType mediaType, T data);
        Task<T> Decode(RemoteCongressMediaType mediaType, Stream data);

        public async Task<string> EncodeToString(RemoteCongressMediaType mediaType, T data)
        {
            if (mediaType is null)
                throw new ArgumentNullException(nameof(mediaType));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (!CanHandle(mediaType))
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );

            using Stream stream = await Encode(mediaType, data);

            using StreamReader reader = new StreamReader(stream);

            return await reader.ReadToEndAsync();
        }

        public async Task<T> DecodeFromString(RemoteCongressMediaType mediaType, string data)
        {
            if (mediaType is null)
                throw new ArgumentNullException(nameof(mediaType));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            if (!CanHandle(mediaType))
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using Stream stream = new MemoryStream(dataBytes);
            return await Decode(mediaType, stream);
        }
    }
}