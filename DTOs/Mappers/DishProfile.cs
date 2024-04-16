using AutoMapper;
using easyeat.DTOs.Dishes;

namespace easyeat.DTOs.Mappers
{
    public class DishProfile : Profile
    {
        public DishProfile()
        {
            CreateMap<NewDish, Business.Model.Dish>();

            CreateMap<Business.Model.Dish, Dish>();
            CreateMap<Dish, Business.Model.Dish>();
        }
    }
}