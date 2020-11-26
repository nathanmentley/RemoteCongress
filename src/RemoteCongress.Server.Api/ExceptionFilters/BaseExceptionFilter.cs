using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Api.ExceptionFilters
{
    public abstract class BaseExceptionFilter: ExceptionFilterAttribute
    {
        private ILogger _Logger;
    
        protected abstract int StatusCode { get; }
    
        protected BaseExceptionFilter(ILogger logger)
        {
            _Logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }
    
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
    
            base.OnException(context);
        }
    
        protected abstract bool CanHandle(Exception exception);

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