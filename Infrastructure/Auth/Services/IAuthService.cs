using easyeat.Infrastructure.Auth.DTOs;

namespace easyeat.Infrastructure.Auth.Services
{
    public interface IAuthService
    {
        public Task<string> Login(LoginData loginData);

        public Task<string> Register(RegisterData registerData);

        public Task<string> RegisterRestaurant(RegisterRestaurantData registerRestaurantData);
    }
}
