using Microsoft.Extensions.Logging;
using RemoteCongress.Server.Web.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class MissingPathParameterExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 400;
        protected override Type ExceptionType => typeof(MissingPathParameterException);
    
        public MissingPathParameterExceptionFilter(ILogger logger): base(logger) {}
    }
}