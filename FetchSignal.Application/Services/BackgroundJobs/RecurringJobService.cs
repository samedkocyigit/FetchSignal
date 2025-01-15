using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchSignal.Application.Services.BackgroundJobs
{
    public class RecurringJobService
    {
        protected readonly HttpClient _httpClient;
        public RecurringJobService(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient.CreateClient("ApiClient");
        }

        public async Task CallApiEndpointAsync()
        {
            try
            {
                var response = await _httpClient.PostAsync("api/RawData/without-url", null);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"API call failed with status code: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Request failed. Please check your API server.", ex);
            }
        }
    }

}
