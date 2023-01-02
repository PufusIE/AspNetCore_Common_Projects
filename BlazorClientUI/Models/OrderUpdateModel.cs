using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BlazorClientUI.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "You need to enter at least 2 characters for an order name")]
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters")]
        [DisplayName("Name on the Order")]
        public string UpdatedName { get; set; }
    }
}
