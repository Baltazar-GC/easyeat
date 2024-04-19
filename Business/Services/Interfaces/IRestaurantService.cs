using easyeat.Business.Model;

public interface IRestaurantService
{
    Task<List<Restaurant>> List();

    Task<Restaurant> Get(int restaurantId);

    Task<Restaurant> Get(string restaurantName);

    Task<Restaurant> Create(Restaurant restaurant);

    Task Update(Restaurant restaurant);
    
    Task Delete(int restaurantId);
}
