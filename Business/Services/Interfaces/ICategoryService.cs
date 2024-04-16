using easyeat.Business.Model;

namespace easyeat.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> List();

        Task<Category> Get(int categoryId);

        Task<Category> Create(Category category);

        Task Update(Category category);
        
        Task Delete(int categoryId);
    }
}