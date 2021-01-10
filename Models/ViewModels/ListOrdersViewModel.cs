using System.Linq;

namespace PartsCatalog.Models.ViewModels
{
    public class ListOrdersViewModel
    {
        public IQueryable<Order> Orders {get; set;}
        public IQueryable<AppUser> Users {get; set;}
    }
}