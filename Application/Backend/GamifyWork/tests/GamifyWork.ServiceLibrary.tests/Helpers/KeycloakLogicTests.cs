using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using GamifyWork.ServiceLibrary.Helpers;
using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace GamifyWork.ServiceLibrary.tests.Helpers
{
    public class KeycloakLogicTests
    {
        [Fact]
        public async Task AddUsernameForUser_ShouldSetUsernameForUser()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<KeycloakLogic>>();

            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var httpClient = new HttpClient(new MockHttpMessageHandler());

            var keycloakLogic = new KeycloakLogic(httpClientFactoryMock.Object, configurationMock.Object, loggerMock.Object);
            var userModel = new UserModel(Guid.NewGuid(), 0);

            var accessToken = "fakeAccessToken";

            // Custom IHttpClientFactory mock
            var customFactoryMock = new Mock<IHttpClientFactory>();
            customFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns((string name) => customFactoryMock.Object.CreateClient(name));

            configurationMock.Setup(config => config["Keycloak:ClientId"]).Returns("fakeClientId");
            configurationMock.Setup(config => config["Keycloak:ClientSecret"]).Returns("fakeClientSecret");
            configurationMock.Setup(config => config["Keycloak:GrantType"]).Returns("fakeGrantType");

            // Act
            await keycloakLogic.AddUsernameForUser(userModel);

            // Assert
            Assert.NotNull(userModel.Username);
        }

        [Fact]
        public async Task AddUsernamesForUsers_ShouldSetUsernamesForUsers()
        {
            // Arrange
            var httpClientFactoryMock = new Mock<IHttpClientFactory>();
            var configurationMock = new Mock<IConfiguration>();
            var loggerMock = new Mock<ILogger<KeycloakLogic>>();

            var serviceProvider = new ServiceCollection().BuildServiceProvider();
            var httpClient = new HttpClient(new MockHttpMessageHandler());

            var keycloakLogic = new KeycloakLogic(httpClientFactoryMock.Object, configurationMock.Object, loggerMock.Object);
            var userModels = new List<UserModel>
            {
                new UserModel(Guid.NewGuid(), 0),
                new UserModel(new Guid(), 0)
            };

            var accessToken = "fakeAccessToken";

            // Custom IHttpClientFactory mock
            var customFactoryMock = new Mock<IHttpClientFactory>();
            customFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns(httpClient);

            httpClientFactoryMock.Setup(factory => factory.CreateClient(It.IsAny<string>()))
                .Returns((string name) => customFactoryMock.Object.CreateClient(name));

            configurationMock.Setup(config => config["Keycloak:ClientId"]).Returns("fakeClientId");
            configurationMock.Setup(config => config["Keycloak:ClientSecret"]).Returns("fakeClientSecret");
            configurationMock.Setup(config => config["Keycloak:GrantType"]).Returns("fakeGrantType");

            // Act
            await keycloakLogic.AddUsernamesForUsers(userModels);

            // Assert
            foreach (var userModel in userModels)
            {
                Assert.NotNull(userModel.Username);
            }
        }

        // Custom HttpMessageHandler for mocking HttpClient
        public class MockHttpMessageHandler : HttpMessageHandler
        {
            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.RequestUri.AbsoluteUri.EndsWith("/token"))
                {
                    // Mock access token response
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"access_token\": \"fakeAccessToken\"}");
                    return response;
                }
                else if (request.RequestUri.AbsoluteUri.Contains("/users/"))
                {
                    // Mock username response
                    var response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("{\"username\": \"fakeUsername\"}");
                    return response;
                }

                // Return a default response for other requests
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
