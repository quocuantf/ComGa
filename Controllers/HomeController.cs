using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ComGa.Models;
using Microsoft.AspNetCore.Identity;
namespace ComGa.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _UserManager;
    public HomeController(ILogger<HomeController> logger,UserManager<IdentityUser> userManager)
    {
        _logger = logger;
        _UserManager = userManager;
    }

    public async Task<IActionResult> testAction() {
        var user = await _UserManager.GetUserAsync(HttpContext.User);
        var name = user.UserName;
        return RedirectToAction("Welcome","User", name);
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
