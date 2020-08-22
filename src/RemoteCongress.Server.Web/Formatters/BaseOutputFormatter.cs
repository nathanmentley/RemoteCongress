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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using RemoteCongress.Common;
using RemoteCongress.Common.Exceptions;
using RemoteCongress.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Web.Formatters
{
    /// <summary>
    /// Validates a signed <see cref="BaseBlockModel"/> and writes it to the http response <see cref="Stream"/>.
    /// </summary>
    /// <typeparam name="TSignedData">
    /// A type that inherits from <see cref="BaseBlockModel"/>.
    /// </typeparam>
    public abstract class BaseOutputFormatter<TSignedData>: TextOutputFormatter
        where TSignedData: BaseBlockModel
    {
        private readonly ICodec<SignedData> _codec =
            new SignedDataV1JsonCodec();

        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public BaseOutputFormatter(ILogger logger)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            SupportedMediaTypes.Add(
                MediaTypeHeaderValue.Parse(
                    _codec.PreferredMediaType.ToString()
                )
            );

            SupportedEncodings.Add(Encoding.UTF8);
        }

        /// <summary>
        /// Writes the signed and validated <see cref="BaseBlockModel"/> to the http response <see cref="Stream"/>.
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
            if (!(context.Object is TSignedData signedData))
                throw new InvalidOperationException(
                    $"{nameof(context.Object)} is of type[{context.ObjectType}]. It must be a {typeof(TSignedData)}."
                );

            if (!(signedData as ISignedData).IsValid)
                throw new InvalidBlockSignatureException(
                    $"Invalid signature[{signedData.Signature}] for content[{signedData.BlockContent}] " +
                        $"using public key[{signedData.PublicKey}]"
                );

            await context.HttpContext.Response.WriteAsync(
                await _codec.EncodeToString(
                    _codec.PreferredMediaType,
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
            type.Equals(typeof(TSignedData));
    }
}