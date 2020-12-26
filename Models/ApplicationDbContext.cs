using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace PartsCatalog.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        

        public DbSet<Category> Categories {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Client> Clients {get; set;}

    }

     
}
