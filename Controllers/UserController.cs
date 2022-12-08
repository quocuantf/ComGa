using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ComGa.Models;
using ComGa.Repository;
namespace ComGa.Controllers {
    public class UserController : Controller {
        public readonly UserManager<User> _UserManager;
        public readonly SignInManager<User> _SignInManager;
        public readonly IUserReposity _UserReposity;
        //Con inject la doi con kho
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, IUserReposity userReposity ) {
            _UserManager = userManager;
            _SignInManager = signInManager;
            _UserReposity = userReposity;
        }
        
        public IActionResult Index() {
            ViewBag.TuanDZ = _UserReposity.getUserID();
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
                var user = new User {
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