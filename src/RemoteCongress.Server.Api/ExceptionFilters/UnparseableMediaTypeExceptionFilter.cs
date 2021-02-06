using Microsoft.Extensions.Logging;
using RemoteCongress.Server.Api.Exceptions;
using System;
using System.Diagnostics.CodeAnalysis;

namespace RemoteCongress.Server.Api.ExceptionFilters
{
    /// <summary>
    /// An excpetion handler for <see cref="UnparsableMediaTypeException"/>
    /// </summary>
    [ExcludeFromCodeCoverage]
    public sealed class UnparsableMediaTypeExceptionFilter: BaseExceptionFilter
    {
        /// <summary>
        /// The http status code to be returned from this handler
        /// </summary>
        protected override int StatusCode => 415;
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance for logging
        /// </param>
        public UnparsableMediaTypeExceptionFilter(
            ILogger<UnparsableMediaTypeExceptionFilter> logger
        ): base(logger) {}

        /// <summary>
        /// Checks if the exception can be handled by this handler
        /// </summary>
        /// <param name="exception">
        /// The exception that needs handling
        /// </param>
        /// <returns>
        /// true, if the exception can be handled
        /// </returns>
        protected override bool CanHandle(Exception exception) =>
            exception is UnparsableMediaTypeException;
    }
}