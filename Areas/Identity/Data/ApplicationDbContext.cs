using electronics_shop_mvc_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace electronics_shop_mvc_1.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<ApplicationUser> ApplicationUsers { get;set; }
    public DbSet<Product> Products { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

        base.OnModelCreating(builder);
        IList<ProductCategory> defaultCategories = new List<ProductCategory>();

        defaultCategories.Add(new ProductCategory { CategoryId = 101, Name = "lcd" });
        defaultCategories.Add(new ProductCategory { CategoryId = 102, Name = "tv" });
        defaultCategories.Add(new ProductCategory { CategoryId = 103, Name = "soundsystem" });

        builder.Entity<ProductCategory>().HasData(defaultCategories);

        IList<Product> defaultProducts = new List<Product>();
        //https://random.imagecdn.app/v1/image?width=750&height=750
        defaultProducts.Add(new Product
        { ProductId = 1, Name = "test1", Description = "test11", Price = 1001, Quantity = 101, CategoryId = 101, RegistrationDiscount = 50, MultiUnitDiscount = 50 ,ProductImage= "https://images.unsplash.com/photo-1659682413041-4fe07d26c872?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIyMDI2Mg&ixlib=rb-1.2.1&q=80&w=750" });
        defaultProducts.Add(new Product
        { ProductId = 2, Name = "test2", Description = "test22", Price = 1002, Quantity = 102, CategoryId = 102, RegistrationDiscount = 50, MultiUnitDiscount = 50 ,ProductImage= "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750" });
        defaultProducts.Add(new Product
        { ProductId = 3, Name = "test3", Description = "test33", Price = 1003, Quantity = 103, CategoryId = 103, RegistrationDiscount = 50, MultiUnitDiscount = 50,ProductImage = "https://images.unsplash.com/photo-1657779189956-0ce6ebfa74b9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIyMDMwOA&ixlib=rb-1.2.1&q=80&w=750" });


        builder.Entity<Product>().HasData(defaultProducts);

    }
}
