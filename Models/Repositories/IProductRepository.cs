using System.Linq;
namespace PartsCatalog.Models.Repositories
{
    public interface IProductRepository
    {
         IQueryable<Product> Products {get;}
         void SaveProduct(Product product);
         Product DeleteProduct(int Productid);
    }
}