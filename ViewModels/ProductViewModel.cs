using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using electronics_shop_mvc_1.Models;

namespace electronics_shop_mvc_1.ViewModels;

public class ProductViewModel
{
    [Key] public int ProductId { get; set; }

    [Required] public string Name { get; set; }

    [Required] public string Description { get; set; }

    // public string ProductImage { get; set; }

    [Required] public decimal Price { get; set; }

    [Required] public int Quantity { get; set; }

    [Required]
    [ForeignKey("ProductCategory")]
    public int CategoryId { get; set; }

    public virtual ProductCategory? Category { get; set; }

    [Required] public decimal RegistrationDiscount { get; set; }

    [Required] public decimal MultiUnitDiscount { get; set; }
    public IFormFile File { get; set; }
}