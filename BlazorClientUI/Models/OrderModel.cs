using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorClientUI.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You need to enter at least 2 characters for an order name")]
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        [DisplayName("Name on the Order")]
        public string OrderName { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Range(1, int.MaxValue, ErrorMessage = "You need to select a meal from the list")]
        [DisplayName("Meal")]
        public int FoodId { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "You can select up to 10 meals")]
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}
