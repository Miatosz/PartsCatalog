using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PartsCatalog.Models;
using PartsCatalog.Models.Repositories;
using PartsCatalog.Models.ViewModels;
using Microsoft.EntityFrameworkCore;




namespace PartsCatalog.Controllers
{
    public class UserController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly ICategoryRepository categoryRepository;

        public UserController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this.productRepository = productRepository;
            this.categoryRepository = categoryRepository;
        }


        public ViewResult index()
        {
            return View();
        }

        public ViewResult ListProducts() 
            => View(productRepository.Products.Include(c => c.Category));
            // {
            //     Products = productRepository.Products
            // });
        
    }
}