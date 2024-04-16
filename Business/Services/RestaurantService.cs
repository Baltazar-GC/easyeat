using easyeat.Business.Data;
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
            return await _context.Restaurants.FindAsync(restaurantId);
        }

        public async Task<Restaurant> Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);

            await _context.SaveChangesAsync();
            
            return restaurant;
        }

        public async Task Update(Restaurant restaurant)
        {
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
    }
}
