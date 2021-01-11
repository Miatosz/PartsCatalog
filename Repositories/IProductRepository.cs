using System.Linq;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories{
    public interface IProductRepository
    {
         IQueryable<Product> Products {get;}
         void SaveProduct(Product product);
         Product DeleteProduct(int Productid);
    }
}