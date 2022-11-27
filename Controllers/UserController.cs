using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ComGa.Models;
namespace ComGa.Controllers {
    public class UserController : Controller {
        public readonly UserManager<IdentityUser> _UserManager;
        public readonly SignInManager<IdentityUser> _SignInManager;
        //Con inject la doi con kho
        public UserController(UserManager<IdentityUser> userManager,
                                SignInManager<IdentityUser> signInManager ) {
            _UserManager = userManager;
            _SignInManager = signInManager;

        }
        public IActionResult Idex() {
            return View();
        }
        public IActionResult Register() {
            return View();
        }
        public IActionResult Welcome(string? name) {
            ViewBag.Username = name;
            return View();
        }
        public IActionResult Login () {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userResgisterModel) {
            if (ModelState.IsValid) {
                var user = new IdentityUser {
                    Email = userResgisterModel.Email,
                    UserName = userResgisterModel.Email,
                };
                var result = await _UserManager.CreateAsync(user, userResgisterModel.Password);
                if (result.Succeeded) {
                    await _SignInManager.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Welcome", "User");
                }
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin m_UserLogin) {
            var res = await _SignInManager.PasswordSignInAsync(m_UserLogin.Username, m_UserLogin.Password, true, true);
            if (res.Succeeded) {
                // ViewBag["Username"] = _UserManager.GetUserName();
                // var user = _UserManager.FindById(User.Identity.GetUserId())
                // _UserManager.GetUserNameAsync();
                var user = await _UserManager.GetUserAsync(HttpContext.User);
                ViewBag.Username = user.UserName;
                return View("Welcome");
            }
            return View();
        }
    }
}