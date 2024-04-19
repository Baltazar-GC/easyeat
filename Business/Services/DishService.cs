using easyeat.Business.Data;
using easyeat.Business.Exceptions;
using easyeat.Business.Model;
using easyeat.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace easyeat.Business.Services
{
    public class DishService : IDishService
    {
        private readonly EasyeatDbContext _context;

        public DishService(EasyeatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dish>> List()
        {
            return await _context.Dishes.Include(d => d.Category).ToListAsync();
        }

        public async Task<List<Dish>> List(int restaurantId)
        {
            return await _context.Dishes
                .Include(d => d.Category)
                .Include(x => x.Restaurant)
                .Where(x => x.RestaurantId == restaurantId)
                .ToListAsync();
        }

        public async Task<Dish> Get(int dishId)
        {
            return await _context.Dishes.Include(x => x.Category).FirstOrDefaultAsync(mp => mp.Id == dishId);
        }

        public async Task<Dish> Create(Dish dish)
        {
            await VerifyDish(dish);

            _context.Dishes.Add(dish);

            await _context.SaveChangesAsync();

            return await Get(dish.Id);
        }

        public async Task Update(Dish dish)
        {
            await VerifyDish(dish);

            _context.Dishes.Update(dish);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int dishId)
        {
            var dish = await Get(dishId);

            if (dish != null)
            {
                _context.Dishes.Remove(dish);

                await _context.SaveChangesAsync();
            }
        }

        private async Task VerifyDish(Dish dish)
        {
            var dishExists = await _context.Dishes.FirstOrDefaultAsync(c => c.Name == dish.Name);

            if(dishExists != null)
            {
                throw new EasyeatBusinessException($"Dish '{dish.Name}' already exists.");
            }
        }
    }
}