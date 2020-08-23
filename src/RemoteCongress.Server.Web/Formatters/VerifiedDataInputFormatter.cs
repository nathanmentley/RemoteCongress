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
using RemoteCongress.Common.Serialization;
using System;
using System.Text;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Web.Formatters
{
    /// <summary>
    /// Reads and validates a signed <see cref="BaseBlockModel"/> from the input.
    /// </summary>
    /// <typeparam name="TData">
    /// Verified data model
    /// </typeparam>
    public class VerifiedDataInputFormatter<TData>: TextInputFormatter
    {
        private readonly ICodec<SignedData> _codec;
        private readonly ICodec<TData> _dataCodec;
        private readonly ILogger _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public VerifiedDataInputFormatter(
            ILogger logger,
            ICodec<SignedData> codec,
            ICodec<TData> dataCodec
        )
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));

            _codec = codec ??
                throw new ArgumentNullException(nameof(codec));

            _dataCodec = dataCodec ??
                throw new ArgumentNullException(nameof(dataCodec));

            SupportedMediaTypes.Add(
                MediaTypeHeaderValue.Parse(
                    _codec.GetPreferredMediaType().ToString()
                )
            );

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
            SignedData signedData = await _codec.Decode(
                _codec.GetPreferredMediaType(),
                context.HttpContext.Request.Body
            );

            if (signedData is null)
                throw new Exception("TODO: Get a better exception for this.");

            if(!_dataCodec.CanHandle(signedData.MediaType))
                throw new InvalidOperationException("TODO: Get a better exception for this.");

            TData model = await _dataCodec.DecodeFromString(signedData.MediaType, signedData.BlockContent);

            if (model is null)
                throw new Exception("TODO: Get a better exception for this.");

            VerifiedData<TData> result = new VerifiedData<TData>(signedData, model);
            if (!(result as ISignedData).IsValid)
                throw new InvalidBlockSignatureException(
                    $"Invalid signature[{result.Signature}] for content[{result.BlockContent}] " +
                        $"using public key[{result.PublicKey}]"
                );

            return await InputFormatterResult.SuccessAsync(result);
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