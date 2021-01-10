using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models;
using System.Linq;
using PartsCatalog.Models.Repositories;
using PartsCatalog.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;


namespace PartsCatalog.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository orderRepository;
        private readonly AppIdentityDbContext context;
        private Cart cart;
        private UserManager<AppUser> userManager;
        // private readonly IAppUserRepository;

        public OrderController(IOrderRepository orderRepository, Cart cart, UserManager<AppUser> userManager, AppIdentityDbContext context)
        {
            this.orderRepository = orderRepository;
            this.cart = cart;
            this.userManager = userManager;
            this.context = context;
            
        }

        public ViewResult List()
        {
            return View(new ListOrdersViewModel
            {
                Orders = orderRepository.Orders.Where(o => !o.Shipped),
                Users = userManager.Users
            });
        }
            

        public ViewResult ListHistory() =>
            View(orderRepository.Orders);


        [HttpPost]
        public IActionResult MarkShipped(int orderId)
        {
            Order order = orderRepository.Orders  
                            .FirstOrDefault(o => o.OrderID == orderId);
            
            if (order != null)
            {
                order.Shipped = true;
                orderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

        public async Task<AppUser> GetCurrentUser()
        {
            var s = await userManager.GetUserAsync(HttpContext.User);
            return s;
        }
  
        [HttpGet]
        public ViewResult CheckoutWithOutAccount()
        { 
            
            string currentUser = userManager.GetUserName(HttpContext.User);
            var currentUserFiltred = userManager.Users.FirstOrDefault(p => p.UserName == currentUser);
            return View(new CheckoutViewModel
            {
                User = currentUserFiltred,
                Order = new Order()
            });
                
        }

        [HttpPost]
        public IActionResult CheckoutWithOutAccount(CheckoutViewModel checkoutViewModel, string returnUrl)
        {

            Order order = new Order();
            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your cart is empty");
                //tempdata pustykoszyk
                return RedirectToAction("ListProducts", "User");
            }
            
            if (ModelState.IsValid)
            {
                order.userId = null;
                order.Lines = cart.Lines.ToArray();
                orderRepository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }



        [HttpGet]
        public ViewResult Checkout()
        { 
            
            string currentUser = userManager.GetUserName(HttpContext.User);
            var currentUserFiltred = userManager.Users.FirstOrDefault(p => p.UserName == currentUser);
            return View(new CheckoutViewModel
            {
                User = currentUserFiltred,
                Order = new Order()
            });
                
        }

        [HttpPost]
        public IActionResult Checkout(CheckoutViewModel checkoutViewModel, string returnUrl)
        {
            string currentUser = userManager.GetUserName(HttpContext.User);
            var currentUserFiltred = userManager.Users.FirstOrDefault(p => p.UserName == currentUser);

            Order order = new Order();
            
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, Your cart is empty");
                //tempdata pustykoszyk
                return RedirectToAction("ListProducts", "User");
            }
            
            if (ModelState.IsValid)
            {
                order.userId = currentUserFiltred.Id;
                order.Lines = cart.Lines.ToArray();
                orderRepository.SaveOrder(order);
                
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }

        public ViewResult Completed()
        {
            cart.Clear();
            return View();
        }

    }
}