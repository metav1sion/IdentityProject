using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using IdentityProject.Web.Models;
using IdentityProject.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace IdentityProject.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager)
    {
        _logger = logger;
        _userManager = userManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Signup()
    {

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Signup(SignupViewModel model)
    {
        var result = await _userManager.CreateAsync(new AppUser
        {
            UserName = model.UserName,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber
        }, model.Password);

        if (result.Succeeded)
        {
            TempData["Message"] = "User created successfully!";
            return RedirectToAction("Signup");
        }
        
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
