using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Api.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class BlockNotFoundExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 404;
    
        public BlockNotFoundExceptionFilter(ILogger logger): base(logger) {}

        protected override bool CanHandle(Exception exception) =>
            exception is BlockNotFoundException;
    }
}