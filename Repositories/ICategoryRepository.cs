using System.Linq;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories{
    public interface ICategoryRepository
    {
         IQueryable<Category> Categories {get;}
         void SaveCategory(Category category);
         Category DeleteCategory(int categoryId);
    }
}