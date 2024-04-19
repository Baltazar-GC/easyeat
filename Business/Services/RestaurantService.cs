using easyeat.Business.Data;
using easyeat.Business.Exceptions;
using easyeat.Business.Model;
using Microsoft.EntityFrameworkCore;

namespace easyeat.Business.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly EasyeatDbContext _context;

        public RestaurantService(EasyeatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> List()
        {
            return await _context.Restaurants.ToListAsync();
        }

        public async Task<Restaurant> Get(int restaurantId)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurantId);
        }

        public async Task<Restaurant> Get(string restaurantName)
        {
            return await _context.Restaurants.FirstOrDefaultAsync(x => x.Name == restaurantName);
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            await ValidateName(restaurant.Name);

            _context.Restaurants.Add(restaurant);

            await _context.SaveChangesAsync();
            
            return restaurant;
        }

        public async Task Update(Restaurant restaurant)
        {
            await ValidateName(restaurant.Name);

            _context.Restaurants.Update(restaurant);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int restaurantId)
        {
            var restaurant = await Get(restaurantId);

            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);

                await _context.SaveChangesAsync();
            }
        }
        
        private async Task ValidateName(string name)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Name == name);

            if(restaurant == null)
            {
                return;
            }

            throw new EasyeatBusinessException("Ya existe un restaurant con ese nombre.");
        }
    }
}
