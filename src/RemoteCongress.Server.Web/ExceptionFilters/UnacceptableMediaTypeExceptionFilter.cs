using Microsoft.Extensions.Logging;
using RemoteCongress.Server.Web.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class UnacceptableMediaTypeExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 406;
        protected override Type ExceptionType => typeof(UnacceptableMediaTypeException);
    
        public UnacceptableMediaTypeExceptionFilter(ILogger logger): base(logger) {}
    }
}