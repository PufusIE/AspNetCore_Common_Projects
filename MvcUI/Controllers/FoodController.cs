using DataLibrary.Data;
using Microsoft.AspNetCore.Mvc;

namespace MvcUI.Controllers
{
    public class FoodController : Controller
    {
        private readonly IFoodData _foodData;

        public FoodController(IFoodData foodData)
        {
            _foodData = foodData;
        }

        public async Task<IActionResult> Index()
        {
            var food = await _foodData.GetAllMeals();

            return View(food.AsEnumerable());
        }
    }
}
