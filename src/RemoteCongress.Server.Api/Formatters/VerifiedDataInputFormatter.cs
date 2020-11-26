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
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Serialization;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Api.Formatters
{
    /// <summary>
    /// Reads and validates a signed <see cref="BaseBlockModel"/> from the input.
    /// </summary>
    /// <typeparam name="TData">
    /// Verified data model
    /// </typeparam>
    public class VerifiedDataInputFormatter<TData>: TextInputFormatter
    {
        private readonly IEnumerable<ICodec<SignedData>> _signedDataCodecs;
        private readonly IEnumerable<ICodec<TData>> _dataCodecs;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public VerifiedDataInputFormatter(
            ILogger logger,
            IEnumerable<ICodec<SignedData>> signedDataCodecs,
            IEnumerable<ICodec<TData>> dataCodecs
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _signedDataCodecs = signedDataCodecs ??
                throw new ArgumentNullException(nameof(signedDataCodecs));

            _dataCodecs = dataCodecs ??
                throw new ArgumentNullException(nameof(dataCodecs));

            foreach(ICodec<SignedData> signedDataCodec in _signedDataCodecs)
            {
                SupportedMediaTypes.Add(
                    MediaTypeHeaderValue.Parse(
                        signedDataCodec.GetPreferredMediaType().ToString()
                    )
                );
            }

            SupportedEncodings.Add(Encoding.UTF8);
        }

        /// <summary>
        /// Reads a <see cref="SignedData"/> from a http request <see cref="Stream"/>.
        /// </summary>
        /// <param name="context">
        /// The <see cref="InputFormatterContext"/>.
        /// </param>
        /// <param name="encoding">
        /// The selected <see cref="Encoding"/>.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> with the signed and validated <see cref="BaseBlockModel"/>.
        /// </returns>
        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding
        )
        {
            RemoteCongressMediaType mediaType = RemoteCongressMediaType.Parse(
                context.HttpContext.Request.ContentType
            );

            ICodec<SignedData> codec = _signedDataCodecs.FirstOrDefault(
                codec => codec.CanHandle(mediaType)
            );

            if (codec is null)
                throw _logger.LogException(
                    new UnparsableMediaTypeException(
                        $"Cannot handle {mediaType.ToString()}"
                    )
                );

            SignedData signedData = await codec.Decode(
                codec.GetPreferredMediaType(),
                context.HttpContext.Request.Body
            );

            if (signedData is null)
                throw new Exception("TODO: Get a better exception for this.");

            ICodec<TData> dataCodec = _dataCodecs.FirstOrDefault(
                codec => codec.CanHandle(signedData.MediaType)
            );

            if (dataCodec is null)
                throw _logger.LogException(
                    new UnknownBlockMediaTypeException(
                        $"Cannot handle {signedData.MediaType.ToString()}"
                    )
                );

            TData model = await dataCodec.DecodeFromString(signedData.MediaType, signedData.BlockContent);

            if (model is null)
                throw new Exception("TODO: Get a better exception for this.");

            VerifiedData<TData> result = new VerifiedData<TData>(signedData, model);
            if ((result as ISignedData).IsValid)
                return await InputFormatterResult.SuccessAsync(result);

            throw new InvalidBlockSignatureException(
                $"Invalid signature[{result.Signature}] for content[{result.BlockContent}] " +
                    $"using public key[{result.PublicKey}]"
            );
        }

        /// <summary>
        /// Checks if a <see cref="Type"/> can be handled by this <see cref="TextInputFormatter"/>.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to test.
        /// </param>
        /// <returns>
        /// True if <paramref name="type"/> can be handled by this <see cref="TextInputFormatter"/>.
        /// </returns>
        protected override bool CanReadType(Type type) =>
            type.Equals(typeof(VerifiedData<TData>));
    }
}