using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace electronics_shop_mvc_1.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        //public virtual ICollection<Order> Orders { get; set; }
    }

}
