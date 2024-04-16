using AutoMapper;
using easyeat.Business.Services.Interfaces;
using easyeat.DTOs.Dishes;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Controllers
{
    [ApiController]
    [Route("api/dishes")]
    public class DishesController : ControllerBase
    {
        private readonly IDishService _dishService;
        private readonly IMapper _mapper;

        public DishesController(IDishService dishService, IMapper mapper)
        {
            _dishService = dishService;
            _mapper = mapper;
        }

        // GET: /api/dishes
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var dishes = await _dishService.List();

            return Ok(dishes);
        }

        // GET: /api/dishes/{id}
        [HttpGet("{dishId}")]
        public async Task<IActionResult> Get(int dishId)
        {
            var dish = await _dishService.Get(dishId);

            if (dish == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Dish>(dish));
        }

        // DELETE: /api/dishes/{id}
        [HttpDelete("{dishId}")]
        public async Task<IActionResult> Delete(int dishId)
        {
            var dish = await _dishService.Get(dishId);

            if (dish == null)
            {
                return NotFound();
            }
            
            await _dishService.Delete(dishId);

            return Ok();
        }

        // PUT: /api/dishes/{id}
        [HttpPut("{dishId}")]
        public async Task<IActionResult> Update(Dish dish, int dishId)
        {
            var existentDish= await _dishService.Get(dishId);

            if (existentDish == null)
            {
                return NotFound();
            }

            if(dish.Id != dishId)
            {
                return BadRequest();
            }
            
            await _dishService.Update(_mapper.Map<Business.Model.Dish>(dish));

            return Ok();
        }

        // POST: /api/dishes
        [HttpPost]
        public async Task<IActionResult> Create(NewDish newDish)
        {      
            var dish = await _dishService.Create(_mapper.Map<Business.Model.Dish>(newDish));

            return Ok(_mapper.Map<Dish>(dish));
        }
    }
}
