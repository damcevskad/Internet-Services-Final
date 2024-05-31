using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Data;
using Final.Services;
using Xunit.Abstractions;
using Final.Data.Interfaces;
using Final.Services.Services;
using Final.Data.Entities;
using Final.Service.Interfaces;

namespace Final.Tests.UnitTests 
{
    public class ClientTests
    {
        private readonly Mock<IClientRepository> _mockClientRepository;
        private readonly ClientService _clientService;

        public ClientTests()
        {
            _mockClientRepository = new Mock<IClientRepository>();
            _clientService = new ClientService(_mockClientRepository.Object);
        }

        [Fact]
        public void GetAllClient_ShouldReturnAllClients()
        {
            var clients = new List<Client>
            {
                new Client { Id = 1 ,FirstName = "John", LastName = "Doe", Nationality = "EN", Address = "Ocean Blvd 2" }, 
                new Client {Id = 2, FirstName = "Jane", LastName = "Doe", Nationality = "MK", Address = "Ocean Blvd 1" } 
            };
            _mockClientRepository.Setup(repo => repo.GetAllClients()).Returns(clients);

            var result = _clientService.GetAllClients();

            Assert.Equal(clients, result);  
        }

        [Fact]
        public void GetClientById_ShouldReturnClient_WhenClientExists()
        {
            var client = new Client { Id = 1, FirstName = "John", LastName = "Doe", Nationality = "EN", Address = "Ocean Blvd 2" };
            _mockClientRepository.Setup(repo => repo.GetClientById(1)).Returns(client);

            var result = _clientService.GetClientById(1);

            Assert.Equal(client, result);
        }

        [Fact]
        public void CreateClient_ShouldCallRepositoryCreateClient()
        {
            var client = new Client { Id = 1, FirstName = "John", LastName = "Doe", Nationality = "EN", Address = "Ocean Blvd 2" };

            _clientService.CreateClient(client);

            _mockClientRepository.Verify(repo => repo.CreateClient(client), Times.Once);
        }
    }
}