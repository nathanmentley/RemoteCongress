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
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PublicVote.Common;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PublicVote.Server.Web.Formatters
{
    public abstract class BaseInputFormatter<T>: TextInputFormatter
        where T: ISignedData
    {
        protected BaseInputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding
        )
        {
            var signedData = await JsonSerializer.DeserializeAsync(context.HttpContext.Request.Body, typeof(SignedData));

            return await InputFormatterResult.SuccessAsync(
                FromSignedData(signedData as SignedData)
            );
        }

        protected abstract T FromSignedData(SignedData data);

        protected override bool CanReadType(Type type) =>
            type.Equals(typeof(T));
    }
}