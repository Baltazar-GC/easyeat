using easyeat.Business.Data;
using easyeat.Business.Model;
using easyeat.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace easyeat.Business.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly EasyeatDbContext _context;

        public MealPlanService(EasyeatDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealPlan>> List()
        {
            return await _context.MealPlans.Include(mp => mp.OfferedBy).ToListAsync();
        }

        public async Task<MealPlan> Get(int mealPlanId)
        {
            return await _context.MealPlans.Include(mp => mp.OfferedBy).FirstOrDefaultAsync(mp => mp.Id == mealPlanId);
        }

        public async Task<List<MealPlan>> ListByRestaurant(int restaurantId)
        {
            return await _context.MealPlans.Where(mp => mp.OfferedBy.Id == restaurantId).Include(mp => mp.OfferedBy).ToListAsync();
        }

        public async Task<MealPlan> Create(MealPlan mealPlan)
        {
            _context.MealPlans.Add(mealPlan);

            await _context.SaveChangesAsync();

            return mealPlan;
        }

        public async Task Update(MealPlan mealPlan)
        {
            _context.MealPlans.Update(mealPlan);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int mealPlanId)
        {
            var mealPlan = await Get(mealPlanId);

            if (mealPlan != null)
            {
                _context.MealPlans.Remove(mealPlan);

                await _context.SaveChangesAsync();
            }
        }
    }
}