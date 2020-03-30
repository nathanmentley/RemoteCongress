using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using PublicVote.Common;
using PublicVote.Common.Serializers;
using PublicVote.Server.DAL;

namespace PublicVote.Server.Web.Formatters
{
    public abstract class BaseInputFormatter<T>: TextInputFormatter
        where T: ISignedData
    {
        private readonly ISerializer<T> _serializer;

        protected BaseInputFormatter(ISerializer<T> serializer)
        {
            _serializer = serializer ??
                throw new ArgumentNullException(nameof(serializer));

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));

            SupportedEncodings.Add(Encoding.UTF8);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(
            InputFormatterContext context,
            Encoding encoding
        ) =>
            await InputFormatterResult.SuccessAsync(
                await _serializer.Deserialize(
                    await JsonSerializer.DeserializeAsync<SignedData>(context.HttpContext.Request.Body)
                )
            );

        protected override bool CanReadType(Type type) =>
            type.Equals(typeof(T));
    }
}