using easyeat.Business.Data;
using easyeat.Business.Exceptions;
using easyeat.Business.Model;
using easyeat.Business.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace easyeat.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EasyeatDbContext _context;

        public CategoryService(EasyeatDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> List()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Get(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(mp => mp.Id == categoryId);
        }

        public async Task<Category> Create(Category category)
        {
            await VerifyCategory(category);

            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return category;
        }

        public async Task Update(Category category)
        {
            await VerifyCategory(category);

            _context.Categories.Update(category);

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int categoryId)
        {
            var category = await Get(categoryId);

            if (category != null)
            {
                _context.Categories.Remove(category);

                await _context.SaveChangesAsync();
            }
        }

        private async Task VerifyCategory(Category category)
        {
            var categoryExists = await _context.Categories.FirstOrDefaultAsync(c => c.Name == category.Name);

            if(categoryExists != null)
            {
                throw new EasyeatBusinessException($"Category '{category.Name}' already exists.");
            }
        }
    }
}