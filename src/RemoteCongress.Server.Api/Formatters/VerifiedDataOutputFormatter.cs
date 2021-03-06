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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Logging;
using RemoteCongress.Common.Serialization;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Api.Formatters
{
    /// <summary>
    /// Validates a signed <see cref="VerifiedData{TData}"/> and writes it to the http response <see cref="Stream"/>.
    /// </summary>
    /// <typeparam name="TData">
    /// Verified data model
    /// </typeparam>
    public class VerifiedDataOutputFormatter<TData>: TextOutputFormatter
    {
        private readonly IEnumerable<ICodec<SignedData>> _codecs;

        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public VerifiedDataOutputFormatter(
            ILogger logger,
            IEnumerable<ICodec<SignedData>> codecs
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _codecs = codecs ??
                throw _logger.LogException(
                    new ArgumentNullException(nameof(logger)),
                    LogLevel.Debug
                );

            foreach(ICodec<SignedData> codec in _codecs)
            {
                SupportedMediaTypes.Add(
                    MediaTypeHeaderValue.Parse(
                        codec.GetPreferredMediaType().ToString()
                    )
                );
            }

            SupportedEncodings.Add(Encoding.UTF8);
        }

        /// <summary>
        /// Writes the signed and validated <see cref="VerifiedData{TData}"/> to the http response <see cref="Stream"/>.
        /// </summary>
        /// <param name="context">
        /// The <see cref="OutputFormatterWriteContext"/>.
        /// </param>
        /// <param name="selectedEncoding">
        /// The selected <see cref="Encoding"/>.
        /// </param>
        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding
        )
        {
            if (!(context.Object is VerifiedData<TData> signedData))
            {
                throw _logger.LogException(
                    new InvalidOperationException(
                        $"{nameof(context.Object)} is of type[{context.ObjectType}]. It must be a {typeof(VerifiedData<TData>)}."
                    ),
                    LogLevel.Debug
                );
            }

            if (!(signedData as ISignedData).IsValid)
            {
                throw _logger.LogException(
                    new InvalidBlockSignatureException(
                        $"Invalid signature[{signedData.Signature}] for content[{signedData.BlockContent}] " +
                            $"using public key[{signedData.PublicKey}]"
                    ),
                    LogLevel.Debug
                );
            }

            StringValues accepts = context.HttpContext.Request.Headers["Accept"];

            ICodec<SignedData> codec = _codecs.FirstOrDefault(
                codec => accepts.Any(accept =>
                    codec.CanHandle(
                        RemoteCongressMediaType.Parse(
                            accept
                        )
                    )
                )
            );

            if (codec is null)
            {
                throw _logger.LogException(
                    new UnacceptableMediaTypeException(
                        $"Cannot return any media types {accepts} for type {typeof(TData)}"
                    ),
                    LogLevel.Debug
                );
            }

            await context.HttpContext.Response.WriteAsync(
                await codec.EncodeToString(
                    codec.GetPreferredMediaType(),
                    new SignedData(signedData)
                )
            );
        }

        /// <summary>
        /// Checks if a <see cref="Type"/> can be handled by this <see cref="TextOutputFormatter"/>.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to test.
        /// </param>
        /// <returns>
        /// True if <paramref name="type"/> can be handled by this <see cref="TextOutputFormatter"/>.
        /// </returns>
        protected override bool CanWriteType(Type type) =>
            type.Equals(typeof(VerifiedData<TData>));
    }
}