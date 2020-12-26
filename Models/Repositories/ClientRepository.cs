using System.Linq;


namespace PartsCatalog.Models.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext context;

        public ClientRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Client> Clients => context.Clients;

        public void SaveClient(Client client)
        {
            if (client.ClientId == 0)
            {
                context.Clients.Add(client);
            }
            else 
            {
                Client dbAdd = context.Clients
                                    .FirstOrDefault(c => c.ClientId == client.ClientId);
                
                if (dbAdd != null)
                {
                    dbAdd.City = client.City;
                    dbAdd.Country = client.Country;
                    dbAdd.Line1 = client.Line1;
                    dbAdd.Line2 = client.Line2;
                    dbAdd.Name = client.Name;
                    dbAdd.Street = client.Street;
                    dbAdd.Surname = client.Surname;
                    dbAdd.Telephone = client.Telephone;
                    dbAdd.Zip = client.Zip;
                }
            }
            context.SaveChanges();
        }

        public Client RemoveClient(int clientId)
        {
            Client dbDel = context.Clients
                                .FirstOrDefault(c => c.ClientId == clientId);
            if (dbDel != null)
            {
                context.Remove(dbDel);
                context.SaveChanges();
            }

            return dbDel;
        }

    }
}