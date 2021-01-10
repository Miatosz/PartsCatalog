using System.Linq;
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PartsCatalog.Models;
using PartsCatalog.Models.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace PartsCatalog.Controllers
{
    [Authorize(Roles = "Admins")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;

        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IClientRepository clientRepository;
        private UserManager<AppUser> userManager;
        private IUserValidator<AppUser> userValidator;
        private IPasswordValidator<AppUser> passwordValidator;
        private IPasswordHasher<AppUser> passwordHasher;

        public AdminController(IPasswordHasher<AppUser> passwordHasher, IPasswordValidator<AppUser> passwordValidator,
                                IUserValidator<AppUser> userValidator, UserManager<AppUser> userManager, 
                                    ApplicationDbContext context, IClientRepository clientRepository, IProductRepository productRepository,
                                     ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
            this.productRepository = productRepository;
            this.clientRepository = clientRepository;
            this.userManager = userManager;
            this.passwordHasher = passwordHasher;
            this.passwordValidator = passwordValidator;
            this.userValidator = userValidator;
            this.context = context;
        }

        //Main Page

        public ViewResult AdminHomePage()
            => View(context.Products.Include(c => c.Category));

        //Products

        public ViewResult AddOrEditProduct(int productId)
        {
            IEnumerable<SelectListItem> categories = categoryRepository.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.Name
            });
            ViewBag.Categories = categories;

            return View(productRepository.Products.FirstOrDefault(p => p.ProductId == productId));
        }


        [HttpPost]
        public IActionResult AddOrEditProduct(Product product)
        {
            ModelState.Remove("ProductId");

            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);
                TempData["message"] = $"Zapisano {product.Name}.";
                return RedirectToAction("AdminHomePage");
            }
            else
            {
                IEnumerable<SelectListItem> categories = categoryRepository.Categories.Select(c => new SelectListItem
                {
                    Value = c.CategoryId.ToString(),
                    Text = c.Name
                });
                ViewBag.Categories = categories;

                return View(product);
            }
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            if (productRepository.Products
                .FirstOrDefault(p => p.ProductId == productId) != null)
            {
                productRepository.DeleteProduct(productId);
            }
            //Product deletedProduct = productRepository.DeleteProduct(productId);
            return RedirectToAction("AdminHomePage");
        }

        //Categories

        public ViewResult ListCategories()
            => View(context.Categories);

        public IActionResult AddOrEditCategory(int categoryId)
            => View(categoryRepository.Categories.FirstOrDefault(c => c.CategoryId == categoryId));
                                                    
        [HttpPost]
        public IActionResult AddOrEditCategory(Category category)
        {
            ModelState.Remove("CategoryId");

            if (ModelState.IsValid)
            {
                categoryRepository.SaveCategory(category);
                TempData["message"] = $"Zapisano {category.Name}.";
                return RedirectToAction("ListCategories");
            }
            else
            {
                TempData["message"] = $"Nie Zapisano.";
                return View(category);
            }
            
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            categoryRepository.DeleteCategory(categoryId);
            return RedirectToAction("ListCategories");
        }


        //Clients

        public ViewResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser
                {
                    UserName = model.Login,
                    Email = model.Email
                };

                IdentityResult result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListClients");
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
        public async Task<IActionResult> Delete(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListClients");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            else
            {
                ModelState.AddModelError("", "User not found");
            }
            return View("ListClients", userManager.Users);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }

        public async Task<IActionResult> Edit(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            
            if (user != null)
            {   

                return View(user);
            }
            else
            {
                return RedirectToAction("ListClients");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail = await userValidator.ValidateAsync(userManager, user);
                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }
                IdentityResult validPass = null;
                if (!string.IsNullOrEmpty(password))
                {
                    validPass = await passwordValidator.ValidateAsync(userManager, user, password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = passwordHasher.HashPassword(user, password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }
                if ((validEmail.Succeeded && validPass == null) || (validEmail.Succeeded && password != string.Empty && validPass.Succeeded))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("ListClients");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                
                ModelState.AddModelError("", "User not found");
            }
            return View(user);
        }

        public ViewResult ListClients()
            //=> View(context.Clients);
            => View(userManager.Users);

        public IActionResult AddOrEditClient(int clientId)
            => View(clientRepository.Clients.FirstOrDefault(c => c.ClientId == clientId));
                                                    
        [HttpPost]
        public IActionResult AddOrEditClient(Client client)
        {
            ModelState.Remove("ClientId");

            if (ModelState.IsValid)
            {
                clientRepository.SaveClient(client);
                TempData["message"] = $"Zapisano {client.Name}.";
                return RedirectToAction("ListClients");
            }
            else
            {
                TempData["message"] = $"Nie Zapisano.";
                return View(client);
            }
            
        }

        [HttpPost]
        public IActionResult DeleteClient(int clientId)
        {
            clientRepository.RemoveClient(clientId);
            return RedirectToAction("ListClients");
        }

        //Orders

        public ViewResult ListOrders()
            => View(context.Orders);
    
    }
}