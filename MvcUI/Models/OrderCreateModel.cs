using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcUI.Models
{
    public class OrderCreateModel
    {
        public OrderModel Order { get; set; }
        public List<SelectListItem> FoodItems { get; set; } = new List<SelectListItem>();
    }
}
