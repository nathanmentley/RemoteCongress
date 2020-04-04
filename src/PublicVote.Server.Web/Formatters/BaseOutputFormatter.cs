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
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicVote.Server.Web.Formatters
{
    public class BaseOutputFormatter<T>: TextOutputFormatter
        where T: ISignedData
    {
        public BaseOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context,
            Encoding selectedEncoding
        )
        {
            if (!(context.Object is T signedData))
                throw new InvalidOperationException(
                    $"{nameof(context.Object)} is of type[{context.ObjectType}]. It must be a {typeof(T)}."
                );

            await context.HttpContext.Response.WriteAsync(
                JsonSerializer.Serialize(new SignedData(signedData))
            );
        }

        protected override bool CanWriteType(Type type) =>
            type.Equals(typeof(T));
    }
}