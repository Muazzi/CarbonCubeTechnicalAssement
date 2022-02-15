using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using BLL.Response;
using IdentityModel.Client;
using Utilities.Exceptions;

namespace BLL.Services
{
    public interface IWhoSearchApiService
    {
        Task<ICDToken>  GetBearerTokenAsync();


    }

    public class WhoSearchApiService : IWhoSearchApiService
    {
        private readonly IConfiguration _configuration;
        public WhoSearchApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ICDToken> GetBearerTokenAsync()
        {
            var clientid = _configuration.GetSection("AuthDetails:ClientId").Value;
            var clienSecret = _configuration.GetSection("AuthDetails:ClientSecret").Value;

            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("https://icdaccessmanagement.who.int");
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientid,
                ClientSecret = clienSecret,
                Scope = "icdapi_access",
                GrantType = "client_credentials",
                ClientCredentialStyle = ClientCredentialStyle.AuthorizationHeader
            });

            if (!tokenResponse.IsError)
            {
                return new ICDToken {Token = tokenResponse };
            }

            throw new ApplicationValidationException(message: "Problem occured while  obtaining access token");

        }
    }
}
