using System.Linq;

namespace PartsCatalog.Models.ViewModels
{
    public class CheckoutViewModel
    {
        public Order Order {get; set;}
        public AppUser User {get; set;}
    }
}