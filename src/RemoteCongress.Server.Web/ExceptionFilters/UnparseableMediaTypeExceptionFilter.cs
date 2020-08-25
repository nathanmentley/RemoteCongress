using Microsoft.Extensions.Logging;
using RemoteCongress.Server.Web.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    [ExcludeFromCodeCoverage]
    public sealed class UnparsableMediaTypeExceptionFilter: BaseExceptionFilter
    {
        protected override int StatusCode => 415;
    
        public UnparsableMediaTypeExceptionFilter(ILogger logger): base(logger) {}

        protected override bool CanHandle(Exception exception) =>
            exception is UnparsableMediaTypeException;
    }
}