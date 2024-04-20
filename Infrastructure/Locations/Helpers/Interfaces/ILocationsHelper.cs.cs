using easyeat.Infrastructure.Locations.API.DTOs;

namespace easyeat.Infrastructure.Locations.Helpers.Interfaces
{
    public interface ILocationsHelper
    {
        Task<List<Country>> GetCountries();

        Task<Country> GetCountryByCode(string code);
    }
}
