using MicrodevProject.Models;
using MicrodevProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MicrodevProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        public AccountController(
        SignInManager<User> signInManager,
        UserManager<User> userManager
        )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username,
                model.Password,
                model.RememberMe,
                false);
                if (result.Succeeded)
                {
                    var user = await _userManager.FindByEmailAsync(model.Username);

                    await _userManager.AddClaimAsync(user, new Claim("EmployeeNumber", "nothing"));

                    return RedirectToAction("Index", "Employee");
                }
            }
            ModelState.AddModelError("", "Failed to login");
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Username, Email = model.Username };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("EmployeeNumber", "nothing1"));
                    await _signInManager.SignInAsync(user, false);
                    //await _signInManager.PasswordSignInAsync(model.Username,
                    //   model.Password,
                    //   true,
                    //   false);
                    return RedirectToAction("Index", "Employee");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.TryAddModelError("", error.Description);
                    }
                    return View();
                }
            }
            return View();

        }
    }
}
