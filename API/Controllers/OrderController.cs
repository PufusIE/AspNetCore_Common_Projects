using API.models;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IFoodData _foodData;
        private readonly IOrderData _orderData;

        public OrderController(IFoodData foodData, IOrderData orderData)
        {
            _foodData = foodData;
            _orderData = orderData;
        }

        [HttpPost]
        [ValidateModel]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(OrderModel order)
        {
            order.Total = (await _foodData.GetAllMeals()).Where(x => x.Id == order.FoodId).First().Price * order.Quantity;
            var id = await _orderData.CreateOrder(order);

            return Ok(new { Id = id });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var order = await _orderData.GetOrderById(id);

            if (order == null)
            {
                return NotFound();
            }
            else
            {
                var output = new
                {
                    Order = order,
                    ItemPurchased = (await _foodData.GetAllMeals()).Where(x => x.Id == order.FoodId).FirstOrDefault()?.Title
                };

                return Ok(output);
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromBody]OrderUpdateModel order)
        {
            await _orderData.UpdateOrderName(order.Id, order.OrderName);

            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderData.DeleteOrder(id);        
            
            return Ok();
        }
    }
}
