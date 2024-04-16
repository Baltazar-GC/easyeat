using AutoMapper;
using easyeat.DTOs.MealPlans;

namespace easyeat.DTOs.Mappers
{
    public class MealPlanProfile : Profile
    {
        public MealPlanProfile()
        {
            CreateMap<NewMealPlan, Business.Model.MealPlan>();

            CreateMap<Business.Model.MealPlan, MealPlan>();
            CreateMap<MealPlan, Business.Model.MealPlan>();
        }
    }
}