using System.ComponentModel.DataAnnotations;
using easyeat.Business.Model;

namespace easyeat.DTOs.MealPlans
{
    public class NewMealPlan
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<Dish> IncludedDishes { get; set; }

        public Restaurant OfferedBy { get; set; }
    }
}