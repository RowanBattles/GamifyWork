using GamifyWork.API.Middleware;
using GamifyWork.ServiceLibrary.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GamifyWork.Api.tests.Middleware
{
    public class ExceptionHandlerMiddlewareTests
    {
        [Fact]
        public async Task InvokeAsync_Catches_TaskException_ReturnsProperResponse()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ExceptionHandlerMiddleware>>();
            var next = new RequestDelegate(_ => throw new TaskException("Task exception", (int)HttpStatusCode.BadRequest));
            var middleware = new ExceptionHandlerMiddleware(next, loggerMock.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal((int)HttpStatusCode.BadRequest, context.Response.StatusCode);
            Assert.Equal("application/json", context.Response.ContentType);
        }

        [Fact]
        public async Task InvokeAsync_Catches_RewardException_ReturnsProperResponse()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ExceptionHandlerMiddleware>>();
            var next = new RequestDelegate(_ => throw new RewardException("Reward exception", (int)HttpStatusCode.Conflict));
            var middleware = new ExceptionHandlerMiddleware(next, loggerMock.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal((int)HttpStatusCode.Conflict, context.Response.StatusCode);
            Assert.Equal("application/json", context.Response.ContentType);
        }

        [Fact]
        public async Task InvokeAsync_Catches_GenericException_ReturnsInternalServerError()
        {
            // Arrange
            var context = new DefaultHttpContext();
            var loggerMock = new Mock<ILogger<ExceptionHandlerMiddleware>>();
            var next = new RequestDelegate(_ => throw new Exception("Generic exception"));
            var middleware = new ExceptionHandlerMiddleware(next, loggerMock.Object);

            // Act
            await middleware.InvokeAsync(context);

            // Assert
            Assert.Equal((int)HttpStatusCode.InternalServerError, context.Response.StatusCode);
            Assert.Equal("application/json", context.Response.ContentType);
        }

        private async Task<string> ReadResponseBody(Stream body)
        {
            body.Seek(0, SeekOrigin.Begin); // Rewind the stream to the beginning
            using var reader = new StreamReader(body, Encoding.UTF8);
            return await reader.ReadToEndAsync();
        }
    }
}
