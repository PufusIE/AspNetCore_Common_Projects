using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodData _foodData;

        public FoodController(IFoodData foodData)
        {
            _foodData = foodData;
        }

        [HttpGet]
        public async Task<List<FoodModel>> Get()
        {
            return await _foodData.GetAllMeals();
        }
    }
}
