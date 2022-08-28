using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using electronics_shop_mvc_1.Areas.Identity.Data;
using electronics_shop_mvc_1.Models;
// using electronics_shop_mvc_1.Resources;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Certificate;
//using ExtendingIdentityUser.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UsersDbContextConnection") ?? throw new InvalidOperationException("Connection string 'UsersDbContextConnection' not found.");


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en"),
        new CultureInfo("ar")
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

builder.Services.AddControllersWithViews();

builder.Services.AddCors();

builder.Services.AddAuthentication(
        CertificateAuthenticationDefaults.AuthenticationScheme)
    .AddCertificate();
//builder.`

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

//app.UseHttpsRedirection();
app.UseStaticFiles();


app.UseRouting();

// var locOptions = app.ApplicationServices.GetService<IOption<RequestLocalizationOptions>>();

var locOptions = ((IApplicationBuilder)app).ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions!.Value);





app.UseAuthentication();


app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapRazorPages(); //to map identity server razor pages to endpoints
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
