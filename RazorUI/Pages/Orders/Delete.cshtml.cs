using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorUI.Pages.Orders
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderData _orderdata;

        public DeleteModel(IOrderData orderdata)
        {
            _orderdata = orderdata;
        }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public OrderModel Order { get; set; }

        //OnGet you are populating all the info you need
        public async Task OnGet()
        {
            Order = await _orderdata.GetOrderById(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await _orderdata.DeleteOrder(Id);

            return RedirectToPage("./Create");
        }
    }
}
