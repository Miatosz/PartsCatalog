using System.Linq;
using Microsoft.EntityFrameworkCore;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories{
    public class OrderRepository : IOrderRepository
    {
        private ApplicationDbContext context;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IQueryable<Order> Orders => context.Orders
                                                .Include(o => o.Lines)
                                                .ThenInclude(i => i.Product);
    
    
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(i => i.Product));

            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}