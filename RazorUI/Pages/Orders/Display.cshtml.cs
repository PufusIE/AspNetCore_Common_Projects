using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorUI.Model;

namespace RazorUI.Pages.Orders
{
    public class DisplayModel : PageModel
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public DisplayModel(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        [BindProperty]
        public OrderUpdateModel UpdatedOrder { get; set; }
        public OrderModel Order { get; set; }
        public string ItemPurchased { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Order = await _orderData.GetOrderById(Id);

            if (Order != null)
            {
                var food = (await _foodData.GetAllMeals()).ToList();

                ItemPurchased = food.Where(x => x.Id == Order.FoodId).FirstOrDefault()?.Title;
            }            

            return Page(); //Iactionresult and return page allows you to returns bad requests when ex is thrown
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            await _orderData.UpdateOrderName(UpdatedOrder.Id, UpdatedOrder.OrderName); //bindproperty allows you to capture info from the view (client/page)
            return RedirectToPage("./Display", new { Id = UpdatedOrder.Id });
        }
    }
}
