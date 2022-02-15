using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using BLL.Response;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [EnableCors]
    public class WhoICDController : MainController
    {
        private readonly IWhoSearchApiService _searchApiService;

        public WhoICDController(IWhoSearchApiService searchApiService)
        {
            _searchApiService = searchApiService;
        }


        [HttpGet()]

        public async Task<IActionResult> GetDiagnoses()
        {
            return Ok(await _searchApiService.GetBearerTokenAsync());
        }

        [HttpPost("{term}")]
        public async Task<IActionResult> PostDiagnoses(string term )
        {
            var token = await _searchApiService.GetBearerTokenAsync();
            var linearizationName = "mms";
            var releaseId = "2021-05";
            var client = new HttpClient();
            client.SetBearerToken(token.Token.AccessToken);

            HttpRequestMessage request;


            var url = $"https://id.who.int/icd/release/11/{releaseId}/{linearizationName}/search?q={term}";
            request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
            request.Headers.Add("API-Version", "v2");

            var response = await client.SendAsync(request);
            var resultJson = response.Content.ReadAsStringAsync().Result;
            //var prettyJson = JValue.Parse(resultJson).ToString(Formatting.Indented);
            JObject entities = JObject.Parse(resultJson);

            IList<JToken> results = entities["destinationEntities"].Children().ToList();

            IList<ICDResponse> searchResults = new List<ICDResponse>();
            foreach (JToken result in results)
            {
                
                ICDResponse retVal = result.ToObject<ICDResponse>();
                searchResults.Add(retVal);
            }

            return Ok(searchResults);




        }


    }


}


