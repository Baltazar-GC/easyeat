using System.ComponentModel.DataAnnotations;
using easyeat.Business.Model;
using easyeat.DTOs.Addresses;

namespace easyeat.DTOs.Restaurants
{
    public class NewRestaurant
    {   
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public NewAddress Address { get; set; }

        public string CuisineType { get; set; }

        public decimal Rating { get; set; }

        public List<MealPlan> OfferedPlans { get; set; }
        
        public string OperatingHours { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}