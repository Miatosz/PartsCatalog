using System.Linq;
using PartsCatalog.Data;
using PartsCatalog.Models;

namespace PartsCatalog.Repositories{
    public interface IClientRepository
    {
         IQueryable<Client> Clients {get; }
         void SaveClient(Client client);
         Client RemoveClient(int clientId);


    }
}