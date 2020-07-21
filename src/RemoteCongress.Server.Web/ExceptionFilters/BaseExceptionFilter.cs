using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace RemoteCongress.Server.Web.ExceptionFilters
{
    public abstract class BaseExceptionFilter: ExceptionFilterAttribute
    {
        private ILogger _Logger;
    
        protected abstract int StatusCode { get; }
        protected abstract Type ExceptionType { get; }
    
        protected BaseExceptionFilter(ILogger logger)
        {
            _Logger = logger ??
                throw new ArgumentNullException(nameof(logger));
        }
    
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            _Logger.LogTrace(
                "Running {onException} for {type}.",
                nameof(OnException),
                GetType()
            );
    
            if (context.Exception.GetType().Equals(ExceptionType))
            {
                _Logger.LogTrace(
                    "Running {logic} for {type} because the exception is {exceptionType}.",
                    nameof(Logic),
                    GetType(),
                    ExceptionType
                );
    
                await Logic(context);
            }
    
            base.OnException(context);
        }
    
        protected virtual Task Logic(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCode;
    
            return Task.CompletedTask;
        }
    }
}