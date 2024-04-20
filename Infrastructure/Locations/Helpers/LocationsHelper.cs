using easyeat.Infrastructure.Locations.API.DTOs;
using easyeat.Infrastructure.Locations.API.Interfaces;
using easyeat.Infrastructure.Locations.Helpers.Interfaces;

namespace easyeat.Infrastructure.Locations.Helpers
{
    public class LocationsHelper : ILocationsHelper
    {
        private readonly ILocationsAPIClient _countriesAPIClient;

        public LocationsHelper(ILocationsAPIClient countriesAPIClient)
        {
            _countriesAPIClient = countriesAPIClient;
        }

        public async Task<List<Country>> GetCountries()
        {
            return await _countriesAPIClient.GetCountries();
        }

        public async Task<Country> GetCountryByCode(string code)
        {
            var countries = await _countriesAPIClient.GetCountries();

            return countries.FirstOrDefault(c => c.Code == code);
        }
    }
}
