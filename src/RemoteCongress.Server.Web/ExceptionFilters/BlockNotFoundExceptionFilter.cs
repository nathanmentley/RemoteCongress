using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class BlockNotFoundExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 404;
        protected override Type ExceptionType => typeof(BlockNotFoundException);
    
        public BlockNotFoundExceptionFilter(ILogger logger): base(logger) {}
    }
}