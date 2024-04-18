using System.ComponentModel.DataAnnotations;
using easyeat.DTOs.Addresses;
using easyeat.DTOs.MealPlans;

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

        public List<int> OfferedPlansIds { get; set; }
        
        public string OperatingHours { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}