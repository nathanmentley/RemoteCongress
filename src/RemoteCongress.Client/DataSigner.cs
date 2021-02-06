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
using Microsoft.Extensions.Logging;
using RemoteCongress.Common;
using RemoteCongress.Common.Encryption;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RemoteCongress.Client
{
    /// <summary>
    /// A client used to interact an endpoint of the api.
    /// </summary>
    internal class DataSigner<TModel>: IDataSigner<TModel>
    {
        /// <summary>
        /// An <see cref="ILogger"/> instance to log against.
        /// </summary>
        private readonly ILogger<DataSigner<TModel>> _logger;

        /// <summary>
        /// A collection of codecs to endode and decode data.
        /// </summary>
        private readonly IEnumerable<ICodec<TModel>> _codecs;
        
        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> to log against.
        /// </param>
        /// <param name="codecs">
        /// An <see cref="ICodec{TModel}"/> for <typeparamref name="TModel"/>s.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="logger"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="codecs"/> is null.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// Thrown if <paramref name="codecs"/> contains zero <see cref="ICodec{TModel}"/>s.
        /// </exception>
        internal DataSigner(
            ILogger<DataSigner<TModel>> logger,
            IEnumerable<ICodec<TModel>> codecs
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(codecs)),
                    LogLevel.Debug
                );

            if (_codecs.Count() < 1)
            {
                throw _logger.LogException(
                    new ArgumentException(
                        $"{nameof(codecs)} must contain atleast one {nameof(ICodec<TModel>)}.",
                        nameof(codecs)
                    ),
                    LogLevel.Debug
                );
            }
        }

        /// <summary>
        /// Creates, signs, and persists a <typeparamref name="TModel"/> instance.
        /// </summary>
        /// <param name="privateKey">
        /// The private key to use to generate the <see cref="ISignedData.Signature"/> of the <typeparamref name="TModel"/>.
        /// </param>
        /// <param name="publicKey">
        /// The public key that matches <paramref name="privateKey"/> to link the immutable <typeparamref name="TModel"/> to the producing individual.
        /// </param>
        /// <param name="data">
        /// The <typeparamref name="TModel"/> data to persist.
        /// </param>
        /// <param name="cancellationToken">
        /// A <see cref="CancellationToken"/> to handle cancellation requests.
        /// </param>
        /// <returns>
        /// The persisted <typeparamref name="TModel"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="privateKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="publicKey"/> is null.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="data"/> is null.
        /// </exception>
        /// <exception cref="OperationCanceledException">
        /// Thrown if <paramref name="cancellationToken"/> is null.
        /// </exception>
        public async Task<VerifiedData<TModel>> Create(
            string privateKey,
            string publicKey,
            TModel data,
            CancellationToken cancellationToken
        )
        {
            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(privateKey)),
                    LogLevel.Debug
                );
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(publicKey)),
                    LogLevel.Debug
                );
            }

            if (data is null)
            {
                throw _logger.LogException(
                    new ArgumentNullException(nameof(data)),
                    LogLevel.Debug
                );
            }

            cancellationToken.ThrowIfCancellationRequested();

            ICodec<TModel> codec = GetCodec(GetPreferredMediaType());

            string blockContent = await codec.EncodeToString(
                codec.GetPreferredMediaType(),
                data
            );

            SignedData signedData = new SignedData(
                publicKey,
                blockContent,
                RsaUtils.GenerateSignature(privateKey, blockContent),
                codec.GetPreferredMediaType()
            );

            return new VerifiedData<TModel>(signedData, data);
        }

        /// <summary>
        /// Gets the primary media type for the client.
        /// </summary>
        /// <returns>
        /// The primary media type.
        /// </returns>
        private RemoteCongressMediaType GetPreferredMediaType() =>
            _codecs.First().GetPreferredMediaType();

        /// <summary>
        /// Fetches the codec for a media type.
        /// </summary>
        /// <param name="mediaType">
        /// The media type to find a codec for
        /// </param>
        /// <returns>
        /// The codec.
        /// </returns>
        /// <exception cref="UnknownBlockMediaTypeException">
        /// Thrown if a codec could not be found for the media type.
        /// </exception>
        private ICodec<TModel> GetCodec(RemoteCongressMediaType mediaType) =>
            _codecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            ) ??
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"{mediaType.ToString()} is not supported."
                    ),
                    LogLevel.Debug
                );
    }
}