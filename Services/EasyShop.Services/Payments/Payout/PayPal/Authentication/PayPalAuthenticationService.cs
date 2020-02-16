using System;
using System.Net;
using System.Text;
using EasyShop.Domain.Contracts.CP.PayPal.Authentication.Response;
using EasyShop.Domain.Entries.Identity;
using EasyShop.Domain.Settings;
using EasyShop.Interfaces.Services.Payments.Payout.PayPal.Authentication;
using EasyShop.Services.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace EasyShop.Services.Payments.Payout.PayPal.Authentication
{
    public class PayPalAuthenticationService : IPayPalAuthenticationService
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<PayPalAuthenticationService> _logger;
        private readonly string _userCredentialsBase64;
        private readonly AppUser _currentRequestUser;

        public PayPalAuthenticationService(
            IConfiguration configuration,
            PayPalSettings payPalSettings,
            UserManager<AppUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            ILogger<PayPalAuthenticationService> logger)
        {
            var credentialsTextBytes = Encoding.UTF8.GetBytes($"{payPalSettings.ClientId}:{payPalSettings.ClientSecret}");
            _userCredentialsBase64 = Convert.ToBase64String(credentialsTextBytes);

            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;

            _currentRequestUser = userManager.FindByEmailAsync(httpContextAccessor.HttpContext.User.Identity.Name).Result;
        }

        public PayPalAuthenticationResponse GetAccessToken()
        {
            var client = new RestClient(_configuration["PayPalApiBase"] + "v1/oauth2/token") { Timeout = -1 };
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Authorization", $"Basic {_userCredentialsBase64}");
            request.AddParameter("grant_type", "client_credentials");

            Log("Created client with 'RestClient' against PayPal API");

            try
            {
                var response = client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    PayPalAuthenticationResponse authResponse =
                        JsonConvert.DeserializeObject<PayPalAuthenticationResponse>(response.Content);

                    Log($"Successfully authenticated\nHttp request response: {response.Content}");

                    return authResponse;
                }

                Log($"Request response status code: {response.StatusCode}");

                return null;

            }
            catch (Exception e)
            {
                Log($"Error: {e.Message} | InnerMessage: {e.InnerException?.Message}");

                return null;
            }
        }

        private void Log(string message)
        {
            _logger.LogInformation(string.Format("\nUserEmail: {0}\nUserId: {1}\nRequest: {2}\nMessage: {3}",
                _currentRequestUser.Email,
                _currentRequestUser.Id,
                _httpContextAccessor.HttpContext.Request.GetRawTarget(),
                message));
        }
    }
}
