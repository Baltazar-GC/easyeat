using System.ComponentModel.DataAnnotations;
using easyeat.DTOs.Dishes;
using easyeat.DTOs.Restaurants;

namespace easyeat.DTOs.MealPlans
{
    public class NewMealPlan
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<int> IncludedDishesIds { get; set; }

        public int OfferedById { get; set; }
    }
}