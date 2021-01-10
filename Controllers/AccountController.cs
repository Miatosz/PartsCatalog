using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models.ViewModels;
using PartsCatalog.Models;
using System;
using NETCore.MailKit.Core;


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
        private IEmailService emailService;
        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userMgr, IUserValidator<AppUser> userValidator, 
                                    IPasswordValidator<AppUser> passwordValidator, SignInManager<AppUser> signInMgr, 
                                    IPasswordHasher<AppUser> passwordHasher, IEmailService emailService)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            this.roleManager = roleManager;
            this.passwordHasher = passwordHasher;
            this.passwordValidator = passwordValidator;
            this.userValidator = userValidator;
            this.emailService = emailService;

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
                    UserName = model.Login,
                    Email = model.Email,
                    City = model.City,
                    Country = model.Country,
                    Line1 = model.Line1,
                    Line2 = model.Line2,
                    Name = model.Name,
                    Surname = model.Surname,
                    PhoneNumber = model.PhoneNumber,
                    Zip = model.Zip,
                    Street = model.Street


                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    var link = Url.Action(nameof(VerifyEmail), "Account", new {userId = user.Id, code}, Request.Scheme, Request.Host.ToString());

                    await emailService.SendAsync(user.Email, "email verify", $"<a href=\"{link}\">verify</a>", true);

                    // emailService.Send("dzinzas12318@gmail.com", "ASP.NET Core mvc send email example", "Send from asp.net core mvc action");
                    TempData["SignedIn"]= "We sent you confirmation mail";
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

        [HttpGet]
        [AllowAnonymous]
        public ViewResult SendResetPassword() => View();
        

        //wysłanie emaila z linkiem do metody resetujacej hasło
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> SendResetPassword(CreateModel model)
        {
            var user = await userManager.FindByNameAsync(model.Login);
        
            if (user == null) return BadRequest();

            var x = await userManager.GeneratePasswordResetTokenAsync(user);

            var link = Url.Action(nameof(ChangePassword), "Account", new {userId = user.Id, token = x}, Request.Scheme, Request.Host.ToString());

            await emailService.SendAsync(user.Email, "password reset", $"<a href=\"{link}\">verify</a>", true);

            return RedirectToAction("Login");
            
        }

        [AllowAnonymous]
        public async Task<IActionResult> VerifyEmail(string userId, string code)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null) return BadRequest();

            var result = await userManager.ConfirmEmailAsync(user, code);

            if (result.Succeeded)
            {
                return View();
            }

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public ViewResult ChangePassword(string userId, string token)
        {
            var model = new ResetPasswordModel {Token = token, UserId = userId};
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ResetPasswordModel model)
        {
            // var user = await userManager.FindByIdAsync(model.UserId);

            // if (user == null) return BadRequest();

            // user.PasswordHash = passwordHasher.HashPassword(user, model.Password);

            // IdentityResult result = await userManager.UpdateAsync(user);

            // return RedirectToAction("Login");
             if (!ModelState.IsValid)
                return View(model);
            var user = await userManager.FindByIdAsync(model.UserId);
            if (user == null)
                RedirectToAction("Login");
            var resetPassResult = await userManager.ResetPasswordAsync(user, model.Token, model.Password);
            if(!resetPassResult.Succeeded)
            {
                foreach (var error in resetPassResult.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
            return View();
            }
            return RedirectToAction("Login");
            
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