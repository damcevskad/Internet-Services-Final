using Final.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Data.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetAllClients();
        Client GetClientById(int id);
        void CreateClient(Client client);
        void UpdateClient(int id, Client client);
        void DeleteClient(int id);
    }
}
