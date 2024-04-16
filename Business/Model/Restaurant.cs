using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace easyeat.Business.Model
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string CuisineType { get; set; }

        public decimal Rating { get; set; }
        
        public string OperatingHours { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public ApplicationUser Owner { get; set; }

        public List<MealPlan> MealPlans { get; set; }

        public List<Dish> Dishes { get; set; }

        public int AddressId { get; set; }

        [ForeignKey("AddressId")]
        public Address Address { get; set; }
    }
}