using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorUI.Pages.Food
{
    public class MenuModel : PageModel
    {
        private readonly IFoodData _foodData;

        public MenuModel(IFoodData foodData)
        {
            _foodData = foodData;
        }

        public List<FoodModel> Foods { get; set; }
        public async Task OnGet()
        {
            Foods = (await _foodData.GetAllMeals()).ToList();
        }
    }
}
