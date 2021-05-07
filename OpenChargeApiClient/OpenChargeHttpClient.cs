using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;

namespace OpenChargeApiClient
{
    public class OpenChargeHttpClient : IOpenChargeHttpClient
    {
        private readonly HttpClient _httpClient;

        public OpenChargeHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IList<OpenChargerResponse>> GetChargers(string boudingBox)
        {
            try
            {
                var queryParams = new Dictionary<string, string>
                {
                    {"output", "json" },
                    {"maxresults", "250" },
                    {"boundingbox", boudingBox },
                    {"compact", "true" },
                    {"verbose", "false" },
                    {"includecomments", "true" },
                };
                var requestUrl = QueryHelpers.AddQueryString("/v3/poi/", queryParams);
                var response = await _httpClient.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    return JsonConvert.DeserializeObject<IList<OpenChargerResponse>>(json);
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }
    }
}