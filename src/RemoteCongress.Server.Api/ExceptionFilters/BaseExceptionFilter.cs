using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Api.ExceptionFilters
{
    /// <summary>
    /// An abstract excpetion handler implementation to transform exceptions into http status codes.
    /// </summary>
    public abstract class BaseExceptionFilter: ExceptionFilterAttribute
    {
        private ILogger _Logger;
    
        /// <summary>
        /// The http status code to be returned from this handler
        /// </summary>
        protected abstract int StatusCode { get; }
    
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="logger">
        /// An <see cref="ILogger"/> instance for logging
        /// </param>
        protected BaseExceptionFilter(ILogger logger)
        {
            _Logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }
    
        /// <summary>
        /// Tests and runs this handle for an exceptional event
        /// </summary>
        /// <param name="context">
        /// The exception context of the exceptional event.
        /// </param>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            _Logger.LogDebug(
                "Running {onException} for {type}.",
                nameof(OnException),
                GetType()
            );
    
            if (CanHandle(context.Exception))
            {
                _Logger.LogDebug(
                    "Running {logic} for {type}.",
                    nameof(Logic),
                    GetType()
                );
    
                await Logic(context);
            }
            else
            {
                _Logger.LogTrace(
                    "Skipping {logic} for {type} because it cannot handle this exception.",
                    nameof(Logic),
                    GetType()
                );
            }
    
            base.OnException(context);
        }
    
        /// <summary>
        /// Checks if the exception can be handled by this handler
        /// </summary>
        /// <param name="exception">
        /// The exception that needs handling
        /// </param>
        /// <returns>
        /// true, if the exception can be handled
        /// </returns>
        protected abstract bool CanHandle(Exception exception);

        /// <summary>
        /// Updates the status code for the response.
        /// </summary>
        /// <param name="context">
        /// The exception context of the exceptional event.
        /// </param>
        protected virtual Task Logic(ExceptionContext context)
        {
            _Logger.LogDebug(
                "Setting status code to {statusCode} in {type}.",
                nameof(Logic),
                GetType()
            );
    
            context.HttpContext.Response.StatusCode = StatusCode;
    
            return Task.CompletedTask;
        }
    }
}