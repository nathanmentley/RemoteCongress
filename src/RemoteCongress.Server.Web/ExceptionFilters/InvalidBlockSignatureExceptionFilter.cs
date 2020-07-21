using Microsoft.Extensions.Logging;
using RemoteCongress.Common.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class InvalidBlockSignatureExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 403;
        protected override Type ExceptionType => typeof(InvalidBlockSignatureException);
    
        public InvalidBlockSignatureExceptionFilter(ILogger logger): base(logger) {}
    }
}