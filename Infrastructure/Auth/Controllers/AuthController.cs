using easyeat.Business.Exceptions;
using easyeat.DTOs.Restaurants;
using easyeat.Infrastructure.Auth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Infrastructure.Auth.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager, IAuthService authService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<string>> Login(DTOs.LoginData model)
        {
            var token = await _authService.Login(model);

            if(string.IsNullOrEmpty(token)) 
            {
                return Forbid();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<string>> Register(DTOs.RegisterData model)
        {
            var token = await _authService.Register(model);

            if (string.IsNullOrEmpty(token))
            {
                return Forbid();
            }

            return Ok(token);
        }

        [HttpPost]
        [Route("restaurant/register")]
        public async Task<ActionResult<string>> RegisterRestaurant(DTOs.RegisterRestaurantData model)
        {
            var restaurant = new NewRestaurant()
            { 
                Address = model.Address, 
                Name = model.Name, 
                CuisineType = model.CuisineType, 
                Description = model.Description, 
                Email = model.Email, 
                OperatingHours = model.OperatingHours, 
                PhoneNumber = model.PhoneNumber 
            };

            var token = await _authService.RegisterRestaurant(model, restaurant);

            if (string.IsNullOrEmpty(token))
            {
                return Forbid();
            }

            return Ok(token);
        }
    }
}
