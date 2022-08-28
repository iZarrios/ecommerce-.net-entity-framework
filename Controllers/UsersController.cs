using electronics_shop_mvc_1.Areas.Identity.Data;
using electronics_shop_mvc_1.Models;
using electronics_shop_mvc_1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace electronics_shop_mvc_1.Controllers;

[Authorize(Roles = "super-admin")]
public class UsersController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }


    public async Task<IActionResult> Index()
    {
        var users = await _userManager.Users.Select(user => new UserViewModel
        {
            Id = user.Id,
            Name = user.Name,
            UserName = user.UserName,
            Email = user.Email,
            Roles = _userManager.GetRolesAsync(user).Result
        }).ToListAsync();

        return View(users);
    }

    public async Task<IActionResult> ManageRoles(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return NotFound();

        var roles = await _roleManager.Roles.ToListAsync();

        var viewModel = new UserRolesViewModel
        {
            UserId = user.Id,
            UserName = user.UserName,
            Roles = roles.Select(role => new RoleViewModel
            {
                RoleId = role.Id,
                RoleName = role.Name,
                IsSelected = _userManager.IsInRoleAsync(user, role.Name).Result
            }).ToList()
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ManageRoles(UserRolesViewModel model)
    {
        var user = await _userManager.FindByIdAsync(model.UserId);

        if (user == null)
            return NotFound();

        var userRoles = await _userManager.GetRolesAsync(user);

        foreach (var role in model.Roles)
        {
            if (userRoles.Any(r => r == role.RoleName) && !role.IsSelected)
                await _userManager.RemoveFromRoleAsync(user, role.RoleName);

            if (!userRoles.Any(r => r == role.RoleName) && role.IsSelected)
                await _userManager.AddToRoleAsync(user, role.RoleName);
        }

        return RedirectToAction(nameof(Index));
    }
}