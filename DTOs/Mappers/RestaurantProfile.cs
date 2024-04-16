using AutoMapper;
using easyeat.DTOs.Restaurants;

namespace easyeat.DTOs.Mappers
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<NewRestaurant, Business.Model.Restaurant>();

            CreateMap<Business.Model.Restaurant, Restaurant>();
            CreateMap<Restaurant, Business.Model.Restaurant>();
        }
    }
}