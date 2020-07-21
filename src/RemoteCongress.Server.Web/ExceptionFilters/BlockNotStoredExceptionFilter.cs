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
        protected override Type ExceptionType => typeof(BlockNotStorableException);
    
        public BlockNotStorableExceptionFilter(ILogger logger): base(logger) {}
    }
}