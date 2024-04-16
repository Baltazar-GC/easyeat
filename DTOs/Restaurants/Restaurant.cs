
using easyeat.DTOs.Addresses;
using easyeat.DTOs.MealPlans;

namespace easyeat.DTOs.Restaurants
{
    public class Restaurant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Address Address { get; set; }

        public string CuisineType { get; set; }

        public decimal Rating { get; set; }

        public List<MealPlan> OfferedPlans { get; set; }
        
        public string OperatingHours { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}