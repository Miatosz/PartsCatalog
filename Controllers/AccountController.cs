using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models.ViewModels;
using PartsCatalog.Models;
using System;


namespace PartsCatalog.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AccountController : Controller
    {
        private UserManager<AppUser> userManager;
        private RoleManager<IdentityRole> roleManager;
        private SignInManager<AppUser> signInManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userMgr, IUserValidator<AppUser> userValidator, 
                                    IPasswordValidator<AppUser> passwordValidator, SignInManager<AppUser> signInMgr, 
                                    IPasswordHasher<AppUser> passwordHasher)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            this.roleManager = roleManager;
            this.passwordHasher = passwordHasher;
            this.passwordValidator = passwordValidator;
            this.userValidator = userValidator;
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl) 
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ViewResult SignIn() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel details, string returnUrl) 
        {
            if (ModelState.IsValid) 
            {
                AppUser user = await userManager.FindByNameAsync(details.Login);
                if (user != null) 
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, details.Password, false, false);
                    if (result.Succeeded) 
                    {
                        if (await userManager.IsInRoleAsync(user, "Admins"))
                        {
                            return Redirect(returnUrl ?? "/Admin/AdminHomePage");
                        }
                        else 
                        {
                            return Redirect(returnUrl ?? "/User");
                        }
                    }
                }
                ModelState.AddModelError(nameof(LoginModel.Login), "Invalid user or password");
            }
            return View(details);
        }

        [AllowAnonymous]
        public async Task<RedirectResult> Logout(string returnUrl = "/User/ListProducts")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}