
namespace electronics_shop_mvc_1.ViewModels;

public class UserViewModel
{
            public string Id { get; set; }
            public string Name { get; set; }
            
            public string UserName { get; set; }
            public string Email { get; set; }
            
            public IEnumerable<string> Roles { get; set; }
}