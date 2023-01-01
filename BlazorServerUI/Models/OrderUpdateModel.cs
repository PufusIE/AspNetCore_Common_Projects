using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorServerUI.Models
{
    public class OrderUpdateModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("New Order Name")]
        [MaxLength(20, ErrorMessage = "You need to keep the name to a max of 20 characters.")]
        [MinLength(3, ErrorMessage = "You need to exnter at least 3 characters for an order name.")]
        public string UpdatedName { get; set; }
    }
}
