using System.Linq;

namespace PartsCatalog.Models.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext context;


        public ProductRepository(ApplicationDbContext ctx) 
        {
            context = ctx;
        } 


        public IQueryable<Product> Products => context.Products;
        

         public void SaveProduct(Product product)
         {
             if (product.ProductId == 0)
             {
                 context.Products.Add(product);
             }
             else
             {
                 Product dbAdd = context.Products       
                                    .FirstOrDefault(p => p.ProductId == product.ProductId);
                if (dbAdd != null)
                {                    
                    dbAdd.Price = product.Price;
                    dbAdd.Name = product.Name;
                    dbAdd.Category = product.Category;
                    dbAdd.Description = product.Description;
                    dbAdd.categoryId = product.categoryId;
                }
             }
             context.SaveChanges();
         }

        public Product DeleteProduct(int Productid)
        {
            Product dbDel = context.Products
                                .FirstOrDefault(p => p.ProductId == Productid);
            if (dbDel != null)
            {
                context.Remove(dbDel);
                context.SaveChanges();
            }
            return dbDel;
        }
    }
}