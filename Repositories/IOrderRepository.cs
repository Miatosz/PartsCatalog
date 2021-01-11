using System.Linq;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories{
    public interface IOrderRepository
    {
         IQueryable<Order> Orders {get;}
         void SaveOrder(Order order);
    }
}