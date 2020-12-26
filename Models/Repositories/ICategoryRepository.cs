using System.Linq;

namespace PartsCatalog.Models.Repositories
{
    public interface ICategoryRepository
    {
         IQueryable<Category> Categories {get;}
         void SaveCategory(Category category);
         Category DeleteCategory(int categoryId);
    }
}