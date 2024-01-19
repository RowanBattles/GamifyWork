using GamifyWork.ServiceLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GamifyWork.ServiceLibrary.Helpers
{
    public interface IKeycloakLogic
    {
        Task<List<UserModel>> AddUsernamesForUsers(List<UserModel> userModels);
        Task<UserModel> AddUsernameForUser(UserModel userModel);
    }

    public class KeycloakLogic : IKeycloakLogic
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly IConfiguration _configuration;
        private readonly ILogger<KeycloakLogic> _logger;

        public KeycloakLogic(IHttpClientFactory httpClient, IConfiguration configuration, ILogger<KeycloakLogic> logger)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<UserModel> AddUsernameForUser(UserModel userModel) 
        {
            try
            {
                string accessToken = await GetAccessToken();
                await SetUsernameForUser(accessToken, userModel);
                return userModel;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving username from userId");
                throw;
            }
        }

        public async Task<List<UserModel>> AddUsernamesForUsers(List<UserModel> userModels)
        {
            try
            {
                List<UserModel> users = new();
                string accessToken = await GetAccessToken();

                foreach(UserModel user in userModels)
                {
                    await SetUsernameForUser(accessToken, user);
                    users.Add(user);
                }

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving users from Keycloak");
                throw;
            }
        }

        private async Task SetUsernameForUser(string accessToken, UserModel userModel)
        {
            string? username = await GetUsernameByUserId(userModel.User_ID, accessToken);
            userModel.SetUsername(username);
        }

        private async Task<string?> GetUsernameByUserId(Guid user_ID, string accessToken)
        {
            try
            {
                var httpClient = _httpClient.CreateClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await httpClient.GetAsync($"http://localhost:8080/auth/admin/realms/GamifyWork/users/{user_ID}");
                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);
                var username = jsonDoc.RootElement.GetProperty("username").GetString();
                return username;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error retrieving username from userId");
                return null;
            }
        }

        private async Task<string> GetAccessToken()
        {
            try
            {
                var clientId = _configuration["Keycloak:ClientId"];
                var clientSecret = _configuration["Keycloak:ClientSecret"];
                var grantType = _configuration["Keycloak:GrantType"];

                if (clientId == null || clientSecret == null || grantType == null)
                {
                    _logger.LogError("Keycloak configuration values are null");
                    throw new InvalidOperationException("Keycloak configuration values are null");
                }

                var tokenRequest = new Dictionary<string, string>
                {
                    {"client_id", clientId},
                    {"grant_type", grantType},
                    {"client_secret", clientSecret}
                };

                var httpClient = _httpClient.CreateClient();
                var response = await httpClient.PostAsync("http://localhost:8080/auth/realms/GamifyWork/protocol/openid-connect/token", new FormUrlEncodedContent(tokenRequest));
                var responseContent = await response.Content.ReadAsStringAsync();
                using var jsonDoc = JsonDocument.Parse(responseContent);
                var accessToken = jsonDoc.RootElement.GetProperty("access_token").GetString();

                if(accessToken == null)
                {
                    _logger.LogError("Access token is null");
                    throw new InvalidOperationException("Access token is null");
                }
                return accessToken;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving access token from Keycloak");
                throw;
            }
        }
    }
}
