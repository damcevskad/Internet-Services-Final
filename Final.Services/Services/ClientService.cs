using Final.Data.Entities;
using Final.Data.Interfaces;
using Final.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Services.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository; 

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public Client GetClientById(int id)
        {
            return _clientRepository.GetClientById(id);
        }

        public void CreateClient(Client client)
        {
            _clientRepository.CreateClient(client);
        }

        public void UpdateClient(int id, Client client)
        {
            _clientRepository.UpdateClient(id, client);
        }

        public void DeleteClient(int id)
        {
            _clientRepository.DeleteClient(id);
        }
    }
}
