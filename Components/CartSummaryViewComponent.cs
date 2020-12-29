using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models;

namespace PartsCatalog.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}