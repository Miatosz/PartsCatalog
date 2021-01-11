using System.Linq;
using System;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext context;

        public CategoryRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Category> Categories
            => context.Categories;

        public void SaveCategory(Category category)
         {
            if (category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category dbAdd = context.Categories
                                    .FirstOrDefault(c => c.CategoryId == category.CategoryId);

                if (dbAdd != null)
                {
                    dbAdd.Name = category.Name;
                }
            
            }
            
            context.SaveChanges();

         }

        public Category DeleteCategory(int categoryId)
         {
             var dbDel = context.Categories
                            .FirstOrDefault(c => c.CategoryId == categoryId);
             
             if (dbDel != null)
             {
                 context.Categories.Remove(dbDel);
                 context.SaveChanges();
             }

             return dbDel;
         }
    }
}