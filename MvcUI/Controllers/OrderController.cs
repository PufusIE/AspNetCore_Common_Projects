using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MvcUI.Models;

namespace MvcUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderData _orderData;
        private readonly IFoodData _foodData;

        public OrderController(IOrderData orderData, IFoodData foodData)
        {
            _orderData = orderData;
            _foodData = foodData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var food = await _foodData.GetAllMeals();

            OrderCreateModel model = new OrderCreateModel();

            food.ForEach(x =>
            {
                model.FoodItems.Add(new SelectListItem { Value = x.Id.ToString(), Text = x.Title });
            });

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderModel order)
        {
            if (ModelState.IsValid == false)
            {
                return View();
            }

            var food = await _foodData.GetAllMeals();

            order.Total = order.Quantity * food.Where(x => x.Id == order.FoodId).First().Price;

            int id = await _orderData.CreateOrder(order);

            return RedirectToAction("Display", new { Id = id });
        }

        public async Task<IActionResult> Display(int id)
        {
            var displayOrder = new OrderDisplayModel();
            displayOrder.Order = await _orderData.GetOrderById(id);

            if (displayOrder.Order is not null)
            {
                displayOrder.OrderedMeal = (await _foodData.GetAllMeals()).Where(x => x.Id == displayOrder.Order.FoodId).FirstOrDefault()?.Title;
            }

            return View(displayOrder);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateName(int id, string orderName)
        {
            await _orderData.UpdateOrderName(id, orderName);

            return RedirectToAction("Display", new { Id = id });
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var model = await _orderData.GetOrderById(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Deleteorder(OrderModel model)
        {
            await _orderData.DeleteOrder(model.Id);

            return RedirectToAction("Create");
        }
    }
}
