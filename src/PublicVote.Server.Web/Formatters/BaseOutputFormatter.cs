using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PublicVote.Common;

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
        ) =>
            await context.HttpContext.Response.WriteAsync(
                JsonSerializer.Serialize(context.Object, context.ObjectType)
            );

        protected override bool CanWriteType(Type type) =>
            type.Equals(typeof(T));
    }
}