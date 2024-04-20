using easyeat.Infrastructure.Locations.API.DTOs;
using easyeat.Infrastructure.Locations.API.Interfaces;
using easyeat.Infrastructure.Locations.Helpers.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Infrastructure.Locations.Controllers
{
    [Route("api/locations")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationsHelper _locationsHelper;

        public LocationsController(ILocationsHelper locationsHelper)
        {
            _locationsHelper = locationsHelper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<Country>>> GetCountries()
        {
            var countries = await _locationsHelper.GetCountries();

            return Ok(countries.Select(x => new Country { Name = x.Name, Code = x.Code }));
        }
    }
}
