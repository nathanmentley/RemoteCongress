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
using Avro.IO;
using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Logging;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RemoteCongress.Common.Serialization
{
    /// <summary>
    /// A base <see cref="ICodec{TData}"/> for implementing avro codecs.
    /// </summary>
    public abstract class BaseAvroCodec<T>: ICodec<T>
    {
        /// <summary>
        /// An <see cref="ILogger"/> instance to log against.
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance to log against.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        protected BaseAvroCodec(ILogger logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Gets the preferred <see cref="RemoteCongressMediaType"/> for the codec.
        /// </summary>
        /// <returns>
        /// The preferred <see cref="RemoteCongressMediaType"/>.
        /// </returns>
        public abstract RemoteCongressMediaType GetPreferredMediaType();

        /// <summary>
        /// Checks if <paramref name="mediaType"/> can be handled by the codec.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to check if it can be handled.
        /// </param>
        /// <returns>
        /// True if <paramref name="mediaType"/> can be handled.
        /// </returns>
        public virtual bool CanHandle(RemoteCongressMediaType mediaType) =>
            GetPreferredMediaType().Equals(mediaType);

        /// /// <summary>
        /// Decodes a <paramref name="decoder"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="decoder">
        /// The <see cref="Decoder"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <typeparamref name="T"/> from <paramref name="decoder"/>.
        /// </returns>
        protected abstract T DecodeAvro(RemoteCongressMediaType mediaType, Decoder decoder);

        /// /// <summary>
        /// Encodes <paramref name="data"/> into <paramref name="mediaType"/>.
        /// </summary>
        /// <param name="encoder">
        /// The <see cref="Encoder"/> to encode data to.
        /// </param>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to encode the data to.
        /// </param>
        /// <param name="data">
        /// The data to encode.
        /// </param>
        protected abstract void EncodeAvro(Encoder encoder, RemoteCongressMediaType mediaType, T data);

        /// <summary>
        /// Decodes a <paramref name="data"/> into a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="mediaType">
        /// The <see cref="RemoteCongressMediaType"/> to decode the data from.
        /// </param>
        /// <param name="data">
        /// The <see cref="Stream"/> to decode data from.
        /// </param>
        /// <returns>
        /// The <typeparamref name="T"/> from <paramref name="data"/>.
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
        public Task<T> Decode(RemoteCongressMediaType mediaType, Stream data)
        {
            if (data is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(data)),
                    LogLevel.Debug
                );
            }

            if (!CanHandle(mediaType))
            {
                throw _logger.LogException(
                    new InvalidOperationException(
                        $"{GetType()} cannot handle {mediaType}"
                    ),
                    LogLevel.Debug
                );
            }

            Decoder decoder = new BinaryDecoder(data);

            return Task.FromResult(DecodeAvro(mediaType, decoder));
        }

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
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="mediaType"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        /// Thrown if the <paramref name="mediaType"/> cannot be handled.
        /// </exception>
        public Task<Stream> Encode(RemoteCongressMediaType mediaType, T data)
        {
            if (data is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(data)),
                    LogLevel.Debug
                );
            }

            if (!CanHandle(mediaType))
            {
                throw _logger.LogException(
                    new InvalidOperationException(
                        $"{GetType()} cannot handle {mediaType}"
                    ),
                    LogLevel.Debug
                );
            }

            using MemoryStream stream = new MemoryStream();

            Encoder encoder = new BinaryEncoder(stream);

            EncodeAvro(encoder, mediaType, data);

            stream.Seek(0, SeekOrigin.Begin);

            return Task.FromResult(stream as Stream);
        }
    }
}