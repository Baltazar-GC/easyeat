using easyeat.Business.Model;

namespace easyeat.Business.Services.Interfaces
{
    public interface IDishService
    {
        Task<List<Dish>> List();

        Task<List<Dish>> List(int restaurantId);

        Task<Dish> Get(int dishId);

        Task<Dish> Create(Dish dish);

        Task Update(Dish dish);
        
        Task Delete(int dishId);
    }
}