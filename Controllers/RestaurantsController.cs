using AutoMapper;
using easyeat.DTOs.Restaurants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantsController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        // LIST: /api/restaurants
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Restaurant, Admin, Customer")]
        public async Task<IActionResult> List()
        {
            var restaurants = await _restaurantService.List();

            return Ok(restaurants);
        }

        // GET: /api/restaurants/{id}
        [HttpGet("{restaurantId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Restaurant, Admin, Customer")]
        public async Task<IActionResult> Get(int restaurantId)
        {
            var restaurant = await _restaurantService.Get(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Restaurant>(restaurant));
        }

        // GET: /api/restaurants/{restaurantName}
        [HttpGet("name/{restaurantName}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Restaurant, Admin, Customer")]
        public async Task<IActionResult> Get(string restaurantName)
        {
            var restaurant = await _restaurantService.Get(restaurantName);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Restaurant>(restaurant));
        }

        // DELETE: /api/restaurants/{id}
        [HttpDelete("{restaurantId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Restaurant, Admin")]
        public async Task<IActionResult> Delete(int restaurantId)
        {
            var restaurant = await _restaurantService.Get(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }
            
            await _restaurantService.Delete(restaurantId);

            return Ok();
        }

        // PUT: /api/restaurants/{id}
        [HttpPut("{restaurantId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Restaurant, Admin")]
        public async Task<IActionResult> Update(Restaurant restaurant, int restaurantId)
        {
            var existentRestaurant = await _restaurantService.Get(restaurantId);

            if (existentRestaurant == null)
            {
                return NotFound();
            }

            if(restaurant.Id != restaurantId)
            {
                return BadRequest();
            }
            
            await _restaurantService.Update(_mapper.Map<Business.Model.Restaurant>(restaurant));

            return Ok();
        }
    }
}
