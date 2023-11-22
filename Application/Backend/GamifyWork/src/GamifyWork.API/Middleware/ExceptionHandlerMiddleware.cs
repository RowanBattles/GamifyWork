using GamifyWork.ServiceLibrary.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace GamifyWork.API.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (TaskException taskEx)
            {
                await HandleExceptionAsync(context, taskEx, taskEx.Message, taskEx.ErrorCode);
            }
            catch (RewardException rewardEx)
            {
                await HandleExceptionAsync(context, rewardEx, rewardEx.Message, rewardEx.ErrorCode);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, "An unexpected error occurred", (int)HttpStatusCode.InternalServerError);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex, string errorMessage, int errorCode)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = errorCode;
            context.Response.ContentType = "application/json";

            var error = new Error(errorMessage, context.Response.StatusCode);
            var jsonResponse = JsonConvert.SerializeObject(error);

            await context.Response.WriteAsync(jsonResponse);
        }
    }

    public static class ExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }

}
