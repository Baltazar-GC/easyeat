using AutoMapper;
using easyeat.Business.Services.Interfaces;
using easyeat.DTOs.MealPlans;
using easyeat.DTOs.Restaurants;
using Microsoft.AspNetCore.Mvc;

namespace easyeat.Controllers
{
    [ApiController]
    [Route("api/mealplans")]
    public class MealPlansApiController : ControllerBase
    {
        private readonly IMealPlanService _mealPlanService;
        private readonly IMapper _mapper;

        public MealPlansApiController(IMealPlanService mealPlanService, IMapper mapper)
        {
            _mealPlanService = mealPlanService;
            _mapper = mapper;
        }

        // GET: /api/mealplans
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var mealplans = await _mealPlanService.List();

            return Ok(mealplans);
        }

        // GET: /api/mealplans/restaurant
        [HttpGet("restaurant/{restaurantId}")] 
        public async Task<IActionResult> List(int restaurantId)
        {
            var mealplans = await _mealPlanService.ListByRestaurant(restaurantId);

            return Ok(mealplans);
        }

        // GET: /api/mealplans/{id}
        [HttpGet("{mealPlanId}")]
        public async Task<IActionResult> Get(int mealPlanId)
        {
            var mealplan = await _mealPlanService.Get(mealPlanId);

            if (mealplan == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MealPlan>(mealplan));
        }

        // DELETE: /api/mealplans/{id}
        [HttpDelete("{mealPlanId}")]
        public async Task<IActionResult> Delete(int mealPlanId)
        {
            var mealPlan = await _mealPlanService.Get(mealPlanId);

            if (mealPlan == null)
            {
                return NotFound();
            }
            
            await _mealPlanService.Delete(mealPlanId);

            return Ok();
        }

        // PUT: /api/mealplans/{id}
        [HttpPut("{mealPlanId}")]
        public async Task<IActionResult> Update(MealPlan mealPlan, int mealPlanId)
        {
            var existentMealPlan= await _mealPlanService.Get(mealPlanId);

            if (existentMealPlan == null)
            {
                return NotFound();
            }

            if(mealPlan.Id != mealPlanId)
            {
                return BadRequest();
            }
            
            await _mealPlanService.Update(_mapper.Map<Business.Model.MealPlan>(mealPlan));

            return Ok();
        }

        // POST: /api/mealplans
        [HttpPost]
        public async Task<IActionResult> Create(MealPlan newMealPlan)
        {      
            var mealplan = await _mealPlanService.Create(_mapper.Map<Business.Model.MealPlan>(newMealPlan));

            return Ok(_mapper.Map<MealPlan>(mealplan));
        }
    }
}
