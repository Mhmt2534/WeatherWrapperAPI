using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Caching.Distributed;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WeatherWrapperAPI.Services
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IDistributedCache _cache;
        public WeatherService(IConfiguration configuration,HttpClient httpClient, IDistributedCache cache)
        {
            _httpClient = httpClient;
            _configuration =configuration;
            _cache = cache;
        }

        public async Task<string> GetWeatherAsync(string city)
        {
            string cacheKey = $"weather:{city}";

            var cachedData = await _cache.GetStringAsync(cacheKey);
            if (cachedData == null)
            {
                string apiKey = _configuration["VisualCrossingApiKey"];
                string url = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{city}?unitGroup=us&key={apiKey}";

                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

            


                if (responseMessage.IsSuccessStatusCode)
                {
                    string json = await responseMessage.Content.ReadAsStringAsync();

                    var options = new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(12),
                        SlidingExpiration = TimeSpan.FromMinutes(30)
                    };

                    await _cache.SetStringAsync(cacheKey, json, options);

                    return json;
                }


                return $"Error: {responseMessage.StatusCode}";
            }

            return cachedData;
          
        }



    }
}
