using easyeat.Business.Model;

namespace easyeat.Business.Services.Interfaces
{
    public interface IMealPlanService
    {
        Task<List<MealPlan>> List();

        Task<MealPlan> Get(int mealPlanId);

        Task<List<MealPlan>> ListByRestaurant(int restaurantId);

        Task<MealPlan> Create(MealPlan mealPlan);

        Task Update(MealPlan mealPlan);
        
        Task Delete(int mealPlanId);
    }
}