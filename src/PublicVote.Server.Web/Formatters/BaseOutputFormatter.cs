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
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PublicVote.Common;
using PublicVote.Common.Exceptions;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicVote.Server.Web.Formatters
{
    /// <summary>
    /// Validates a signed <see cref="BaseBlockModel"/> and writes it to the http response <see cref="Stream"/>.
    /// </summary>
    /// <typeparam name="T">
    /// A type that inherits from <see cref="BaseBlockModel"/>.
    /// </typeparam>
    public abstract class BaseOutputFormatter<T>: TextOutputFormatter
        where T: BaseBlockModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

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
            if (!(context.Object is T signedData))
                throw new InvalidOperationException(
                    $"{nameof(context.Object)} is of type[{context.ObjectType}]. It must be a {typeof(T)}."
                );

            if (!(signedData as ISignedData).IsValid)
                throw new InvalidBlockSignatureException(
                    $"Invalid signature[{signedData.Signature}] for content[{signedData.BlockContent}] " +
                        $"using public key[{signedData.PublicKey}]"
                );

            await context.HttpContext.Response.WriteAsync(
                JsonSerializer.Serialize(new SignedData(signedData))
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
            type.Equals(typeof(T));
    }
}