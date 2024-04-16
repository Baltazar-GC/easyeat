using AutoMapper;
using easyeat.DTOs.Categories;

namespace easyeat.DTOs.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<NewCategory, Business.Model.Category>();

            CreateMap<Business.Model.Category, Category>();
            CreateMap<Category, Business.Model.Category>();
        }
    }
}