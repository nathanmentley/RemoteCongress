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
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// An interface around encoding and decoding data.
    /// </summary>
    /// <typeparam name="TData">
    /// The data type to encode or decode.
    /// </typeparam>
    public interface ICodec<TData>
    {
        /// <summary>
        /// Gets the preferred <see cref="RemoteCongressMediaType"/> for the codec.
        /// </summary>
        /// <returns>
        /// The preferred <see cref="RemoteCongressMediaType"/>.
        /// </returns>
        RemoteCongressMediaType GetPreferredMediaType();

        /// <summary>
        /// Checks if <paramref name="mediaType"/> can be handled by the codec.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to check if it can be handled.
        /// </param>
        /// <returns>
        /// True if <paramref name="mediaType"/> can be handled.
        /// </returns>
        bool CanHandle(RemoteCongressMediaType mediaType);

        /// <summary>
        /// Encodes <paramref name="data"/> into <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to encode the data to.
        /// </param>
        /// <param name="data">
        /// The data to encode.
        /// </param>
        /// <returns>
        /// A <see cref="Stream"/> containing the encoded data.
        /// </returns>
        Task<Stream> Encode(RemoteCongressMediaType mediaType, TData data);

        /// <summary>
        /// Decodes a <paramref name="data"/> into a <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="Stream"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <typeparamref name="TData"/> from <paramref name="data"/>.
        /// </returns>
        Task<TData> Decode(RemoteCongressMediaType mediaType, Stream data);

        /// <summary>
        /// Encodes <paramref name="data"/> into <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to encode the data to.
        /// </param>
        /// <param name="data">
        /// The data to encode.
        /// </param>
        /// <returns>
        /// A <see cref="string"/> containing the encoded data.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the <paramref name="mediaType"/> cannot be handled.
        /// </exception>
        public async Task<string> EncodeToString(RemoteCongressMediaType mediaType, TData data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (!CanHandle(mediaType))
            {
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );
            }

            using Stream stream = await Encode(mediaType, data);

            using StreamReader reader = new StreamReader(stream);

            return await reader.ReadToEndAsync();
        }

        /// <summary>
        /// Decodes a <paramref name="data"/> into a <typeparamref name="TData"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="string"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <typeparamref name="TData"/> from <paramref name="data"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the <paramref name="mediaType"/> cannot be handled.
        /// </exception>
        public async Task<TData> DecodeFromString(RemoteCongressMediaType mediaType, string data)
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            if (!CanHandle(mediaType))
            {
                throw new InvalidOperationException(
                    $"{GetType()} cannot handle {mediaType}"
                );
            }

            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using Stream stream = new MemoryStream(dataBytes);
            return await Decode(mediaType, stream);
        }
    }
}