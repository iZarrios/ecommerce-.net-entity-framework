using System.ComponentModel.DataAnnotations;

namespace electronics_shop_mvc_1.Models
{
    public class ProductCategory
    {
        [Key] public int CategoryId { get; set; }

        [Required] public string Name { get; set; }
    }
}
