using easyeat.Infrastructure.Locations.API.DTOs;

namespace easyeat.Infrastructure.Locations.API.Interfaces
{
    public interface ILocationsAPIClient
    {
        Task<List<Country>> GetCountries();
    }
}
