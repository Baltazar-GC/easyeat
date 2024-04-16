
using easyeat.DTOs.Dishes;
using easyeat.DTOs.Restaurants;

namespace easyeat.DTOs.MealPlans
{
    public class MealPlan
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<Dish> IncludedDishes { get; set; }

        public Restaurant OfferedBy { get; set; }
    }
}