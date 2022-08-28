using System.ComponentModel.DataAnnotations;

namespace electronics_shop_mvc_1.ViewModels;

public class RoleFormViewModel
{
   [Required,StringLength(256)] 
   public string Name { get; set; }
}