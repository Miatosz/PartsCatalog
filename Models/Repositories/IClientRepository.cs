using System.Linq;

namespace PartsCatalog.Models.Repositories
{
    public interface IClientRepository
    {
         IQueryable<Client> Clients {get; }
         void SaveClient(Client client);
         Client RemoveClient(int clientId);


    }
}