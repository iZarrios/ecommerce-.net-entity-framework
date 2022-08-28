using System.ComponentModel.DataAnnotations;

namespace electronics_shop_mvc_1.ViewModels;

public class CreateTestViewModel
{
    [Display(Name = "Name"), 
    Required(ErrorMessage = "Required")]
    public string Name { get; set; }
}