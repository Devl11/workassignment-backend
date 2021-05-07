using System;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using WorkAssignment.Shared;

namespace OpenChargeApiClient
{
    public static class OpenChargeServiceExtension
    {
        public static void AddOpenChargeServices(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient<IOpenChargeHttpClient, OpenChargeHttpClient>(httpClient =>
            {
                var productValue = new ProductInfoHeaderValue("WorkAssignment", "1.0");

                httpClient.DefaultRequestHeaders.UserAgent.Add(productValue);
                httpClient.DefaultRequestHeaders.Add("X-API-Key", appSettings.OpenChange.ApiKey);
                httpClient.BaseAddress = new Uri(appSettings.OpenChange.BaseUri);
               });
        }
    }
}