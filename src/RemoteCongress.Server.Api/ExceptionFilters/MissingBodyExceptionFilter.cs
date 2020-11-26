using Microsoft.Extensions.Logging;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Api.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class MissingBodyExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 400;
    
        public MissingBodyExceptionFilter(ILogger logger): base(logger) {}

        protected override bool CanHandle(Exception exception) =>
            exception is MissingBodyException;
    }
}