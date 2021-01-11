using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models;
using System.Linq;
using PartsCatalog.Infrastructure;
using PartsCatalog.Models.ViewModels;
using PartsCatalog.Repositories;


namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository repo;
        private readonly Cart cart;

        public CartController(IProductRepository repo, Cart cartService)
        {
            cart = cartService;
            this.repo = repo;
        }


        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = repo.Products
                                .FirstOrDefault(p => p.ProductId == productId);
            
            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            
            return RedirectToAction("Index", new { returnUrl });
        }
        
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repo.Products
                                .FirstOrDefault(p => p.ProductId == productId);
            
            if (product != null)
            {
                cart.RemoveLine(product);
            }
            
            return RedirectToAction("Index", new { returnUrl });
        }           
        // public ViewResult Index(string returnUrl) => View(new CartIndexViewModel
        // {
        //     Cart = GetCart(),
        //     ReturnUrl = returnUrl
        // });
            

        // public RedirectToActionResult AddToCart(int productId, string returnUrl)
        // {
        //     Product product = repo.Products
        //         .FirstOrDefault(p => p.ProductId == productId);

        //     if (product != null)
        //     {
        //         cart.AddItem(product, 1);
        //     }

        //     return RedirectToAction("Index", new {returnUrl});
        // }

        // public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        // {
        //     Product product = repo.Products
        //         .FirstOrDefault(p => p.ProductId == productId);

        //     if (product != null)
        //     {
        //         cart.RemoveLine(product);
        //     }

        //     return RedirectToAction("Index", new {returnUrl});
        // }

        // private Cart GetCart()
        // {
        //     Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
        //     return cart;
        // }

        // private void SaveCart(Cart cart)
        // {
        //     HttpContext.Session.SetJson("Cart", cart);
        // }
    }
}