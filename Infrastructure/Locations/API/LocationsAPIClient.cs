using easyeat.Infrastructure.Locations.API.DTOs;
using easyeat.Infrastructure.Locations.API.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace easyeat.Infrastructure.Locations.API
{
    public class LocationsAPIClient : ILocationsAPIClient
    {
        private readonly IConfiguration _configuration;

        public LocationsAPIClient(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<Country>> GetCountries()
        {
            var apiKey = await GetAPIKey();

            if(string.IsNullOrEmpty(apiKey)) 
                return new List<Country>();

            var baseUrl = _configuration["LocationsAPI:URL"];

            var url = $"country/all/?key={apiKey}";

            var client = new RestClient(baseUrl);

            var request = new RestRequest(url, Method.Get);

            var response = await client.ExecuteAsync(request);

            if(!response.IsSuccessful)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.Forbidden)
                    return await GetCountries();

                return new List<Country>();
            }

            return JsonConvert.DeserializeObject<List<Country>>(response.Content);
        }

        private async Task<string> GetAPIKey(int retry = 0)
        {
            if (retry == 10)
                return null;

            var APIKeys = _configuration.GetSection("LocationsAPI:APIKeys").Get<string[]>();

            var random = new Random(DateTime.UtcNow.Millisecond);

            var index = random.Next(0, APIKeys.Length);

            var apiKey = APIKeys[index];

            if (string.IsNullOrEmpty(apiKey))
                return apiKey;

            return await GetAPIKey(retry + 1);
        }
    }
}
