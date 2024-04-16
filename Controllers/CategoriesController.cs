using AutoMapper;
using easyeat.Business.Services.Interfaces;
using easyeat.DTOs.Categories;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesApiController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // GET: /api/categories
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var categories = await _categoryService.List();

            return Ok(categories);
        }

        // GET: /api/categories/{id}
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> Get(int categoryId)
        {
            var category = await _categoryService.Get(categoryId);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Category>(category));
        }

        // DELETE: /api/categories/{id}
        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> Delete(int categoryId)
        {
            var category = await _categoryService.Get(categoryId);

            if (category == null)
            {
                return NotFound();
            }
            
            await _categoryService.Delete(categoryId);

            return Ok();
        }

        // PUT: /api/categories/{id}
        [HttpPut("{categoryId}")]
        public async Task<IActionResult> Update(Category category, int categoryId)
        {
            var existentCategory= await _categoryService.Get(categoryId);

            if (existentCategory == null)
            {
                return NotFound();
            }

            if(category.Id != categoryId)
            {
                return BadRequest();
            }
            
            await _categoryService.Update(_mapper.Map<Business.Model.Category>(category));

            return Ok();
        }

        // POST: /api/categories
        [HttpPost]
        public async Task<IActionResult> Create(Category newCategory)
        {      
            var category = await _categoryService.Create(_mapper.Map<Business.Model.Category>(newCategory));

            return Ok(_mapper.Map<Category>(category));
        }
    }
}
