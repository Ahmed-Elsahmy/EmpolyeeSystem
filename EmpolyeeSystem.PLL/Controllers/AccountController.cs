using EmpolyeeSystem.BLL.ModelVM.AccountVm;
using EmpolyeeSystem.DAl.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmpolyeeSystem.PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(UserManager<User> userManager , SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }



        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(RegestraionVM newUserVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = new User();
                userModel.UserName = newUserVM.Username;
                userModel.Email = newUserVM.Email;
                userModel.PasswordHash = newUserVM.Password;
                IdentityResult Result = await userManager.CreateAsync(userModel, newUserVM.Password);
                if (Result.Succeeded)
                {
                    await signInManager.SignInAsync(userModel, false);
                    return RedirectToAction("Index", "Home");


                }
                else
                {
                    foreach (var error in Result.Errors)
                    {
                        ModelState.AddModelError("Password", error.Description);
                    }
                }



            }
            return View(newUserVM);

        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUserVM userVM)
        {
            if (ModelState.IsValid)
            {
                User userModel = await userManager.FindByNameAsync(userVM.UserName);
                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, userVM.Password);
                    if (found == true)
                    {
                        await signInManager.SignInAsync(userModel, userVM.RememberMe);
                        return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "user name or password are wrong ");


            }
            return View(userVM);
        }
        [HttpGet]
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("login");
        }
    }

}
