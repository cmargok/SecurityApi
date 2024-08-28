using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedSecure.Infrastructure.Correlation;
using System.Net;

namespace RedSecure.Api.Configurations.Middleware
{
    public sealed class GlobalExceptionHandler : IExceptionHandler
    {
        private const string ErrorMessage = "A problem has ocurred while your request is being processed.";


        private readonly IHostEnvironment env;       
        public GlobalExceptionHandler(IHostEnvironment env)
        {
            this.env = env;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var problemDetails = CreateProblemDetails(httpContext, exception);

            await httpContext.Response.WriteAsJsonAsync(
                problemDetails,
                options: null, 
                contentType: "application/problem+json", 
                cancellationToken: cancellationToken);

            return true;
        }

        public ProblemDetails CreateProblemDetails(in HttpContext context, in Exception exception)
        {
            var problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = exception.GetType().Name,
                Title = ErrorMessage,
            };

            if (!env.IsDevelopment()) 
                return problemDetails;

            var correlationSentinel = context.RequestServices.GetRequiredService<ICorrelationIdSentinel>();

            var correlationIdObject = context.Items[correlationSentinel.GetHeaderName()]!.ToString();

            string correlationId = correlationIdObject is not null ? correlationIdObject.ToString() : correlationSentinel.Get();

            problemDetails.Detail = exception.Message;
            problemDetails.Extensions[correlationSentinel.GetHeaderName()] = correlationId;
            problemDetails.Extensions["Date"] = $"{DateTime.Now:dd:mm:yyyy:hh:mm:ss}";
            problemDetails.Instance = context.Request.Path;

            return problemDetails;

        }
    }
}
