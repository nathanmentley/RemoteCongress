using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class BlockNotStorableExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 500;
    
        public BlockNotStorableExceptionFilter(ILogger logger): base(logger) {}

        protected override bool CanHandle(Exception exception) =>
            exception is BlockNotStorableException;
    }
}