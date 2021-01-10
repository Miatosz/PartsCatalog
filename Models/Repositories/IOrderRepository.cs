using System.Linq;

namespace PartsCatalog.Models.Repositories
{
    public interface IOrderRepository
    {
         IQueryable<Order> Orders {get;}
         void SaveOrder(Order order);
    }
}