using AutoMapper;
using easyeat.DTOs.Restaurants;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public RestaurantController(IRestaurantService restaurantService, IMapper mapper)
        {
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        // GET: /api/restaurants
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var restaurants = await _restaurantService.List();

            return Ok(restaurants);
        }

        // GET: /api/restaurants/{id}
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> Get(int restaurantId)
        {
            var restaurant = await _restaurantService.Get(restaurantId);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Restaurant>(restaurant));
        }

        // DELETE: /api/restaurants/{id}
        [HttpDelete("{restaurantId}")]
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

        // POST: /api/restaurants
        [HttpPost]
        public async Task<IActionResult> Createe(NewRestaurant newRestaurant)
        {      
            var restaurant = await _restaurantService.Create(_mapper.Map<Business.Model.Restaurant>(newRestaurant));

            return Ok(_mapper.Map<Restaurant>(restaurant));
        }

        // PUT: /api/restaurants/{id}
        [HttpPut("{restaurantId}")]
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
