using AutoMapper;
using easyeat.Business.Exceptions;
using easyeat.DTOs.Restaurants;
using easyeat.Infrastructure.Auth.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace easyeat.Infrastructure.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IRestaurantService _restaurantService;
        private readonly IMapper _mapper;

        public AuthService(IConfiguration config, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IRestaurantService restaurantService, IMapper mapper)
        {
            _config = config;
            _userManager = userManager;
            _roleManager = roleManager;
            _restaurantService = restaurantService;
            _mapper = mapper;
        }

        public async Task<string> Login(LoginData loginData)
        {
            var user = await _userManager.FindByNameAsync(loginData.Username);

            if (user == null && !await _userManager.CheckPasswordAsync(user, loginData.Password))
            {
                throw new EasyeatBusinessException("Nombre de usuario y/o contraseña incorrecta");
            }
            
            var userRoles = await _userManager.GetRolesAsync(user);

            return GenerateToken(user, userRoles);
        }

        public async Task<string> Register(RegisterData registerData)
        {
            var userExists = await _userManager.FindByNameAsync(registerData.UserName);

            if (userExists != null)
                throw new EasyeatBusinessException("Oops, usuario ya registrado.");

            IdentityUser user = new()
            {
                Email = registerData.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerData.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerData.Password);

            if (!result.Succeeded)
                throw new EasyeatBusinessException("Oops, hubo un error al intentar crear su usuario, por favor intente nuevamente.");
           
            if (!await _roleManager.RoleExistsAsync("Customer"))
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

            await _userManager.AddToRoleAsync(user, "Customer");
           
            var userRoles = await _userManager.GetRolesAsync(user);

            return GenerateToken(user, userRoles);
        }

        public async Task<string> RegisterRestaurant(RegisterRestaurantData registerData, NewRestaurant newRestaurant)
        {
            var restaurant = await _restaurantService.Get(newRestaurant.Name);

            if (restaurant != null)
                throw new EasyeatBusinessException("Oops, restaurante ya registrado.");

            var userExists = await _userManager.FindByNameAsync(newRestaurant.Name);

            if (userExists != null)
                throw new EasyeatBusinessException("Oops, restaurante ya registrado.");

            IdentityUser user = new()
            {
                Email = registerData.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = newRestaurant.Name,
            };

            var result = await _userManager.CreateAsync(user, registerData.Password);

            if (!result.Succeeded)
                throw new EasyeatBusinessException("Oops, hubo un error al intentar crear su usuario, por favor intente nuevamente.");

            if (!await _roleManager.RoleExistsAsync("Restaurant"))
                await _roleManager.CreateAsync(new IdentityRole("Restaurant"));

            await _userManager.AddToRoleAsync(user, "Restaurant");

            var userRoles = await _userManager.GetRolesAsync(user);

            await _restaurantService.Create(_mapper.Map<Business.Model.Restaurant>(newRestaurant));

            return GenerateToken(user, userRoles);
        }

        private string GenerateToken(IdentityUser user, ICollection<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(720),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Secret"])), SecurityAlgorithms.HmacSha256Signature));

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
    }
}
