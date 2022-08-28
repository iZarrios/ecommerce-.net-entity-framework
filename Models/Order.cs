using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace electronics_shop_mvc_1.Models
{
    public class Order
    {
        [Key] 
        public int OrderId { get; set; }

        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }


        [Required]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public virtual Product? product { get; set; }


        [Required]
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser? user { get; set; }

        [Required] 
        public DateTime CreatedAt { get; set; }
    }

}
