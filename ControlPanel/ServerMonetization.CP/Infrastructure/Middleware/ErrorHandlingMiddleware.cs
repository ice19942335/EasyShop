using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ServerMonetization.CP.Infrastructure.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                await HandleExceptionAsync(context, error);
                throw;
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            _logger.LogError(e, $"An unhandled exception occurred while processing an incoming request. Error: {e.Message}. Stack trace: {e.StackTrace}");
            return Task.CompletedTask;
        }
    }
}