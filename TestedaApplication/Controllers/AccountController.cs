using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using TestedaApplication.Models;
using TestedaApplication.Data;

namespace TestedaApplication.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly AppDbContext db;
        public AccountController(UserManager<IdentityUser> userMngr, SignInManager<IdentityUser> signInMngr, AppDbContext context)
        {
            userManager = userMngr;
            signInManager = signInMngr;
            db = context;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginUser());
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginUser user, string ReturnUrl)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user1 = await userManager.FindByNameAsync(user.UserName);
                if(user1 != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user1, user.Password, false, false);
                    if (result.Succeeded)
                    {
                        if (userManager.IsInRoleAsync(user1, "user").Result)
                        {
                            return RedirectToAction("ListUs","Usera", new { area = "user" });
                        }
                        else if (userManager.IsInRoleAsync(user1, "admin").Result)
                        {
                            return RedirectToAction("ListAd", "Admin", new { area = "admin" });
                        }
                        return Redirect(ReturnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginUser.UserName), "Неверный логин или пароль");
                
            }
            return View(user);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser {UserName = model.UserName};
                // добавляем пользователя
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await signInManager.SignInAsync(user, false);
                    await userManager.AddToRoleAsync(user, "user");
                    db.SaveChanges();
                    return RedirectToAction("List", "Usera");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                
            }
            return View(model);
        }

        [Authorize]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("List","Car", new { area = "" });
        }
    }
}
