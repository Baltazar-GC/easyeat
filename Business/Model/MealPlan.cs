using System.ComponentModel.DataAnnotations;

namespace easyeat.Business.Model
{
    public class MealPlan
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public List<Dish> IncludedDishes { get; set; }

        public Restaurant OfferedBy { get; set; }
    }
}