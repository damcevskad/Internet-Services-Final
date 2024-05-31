using Final.Data.Entities;
using Final.Service.Interfaces;
using Final.Service.Services;
using Final.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final.WebApi.Controllers 
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService; 

        public ClientController(IClientService clientService) 
        {
            _clientService = clientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            var clients = _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            var client = _clientService.GetClientById(id);

            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        [HttpPost]
        public ActionResult<Client> PostClient([FromBody] Client client)
        {
            _clientService.CreateClient(client);
            return CreatedAtAction("GetClient", new { id = client.Id }, client);
        }

        [HttpPut("{id}")]
        public IActionResult PutClient(int id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _clientService.UpdateClient(id, client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound();
            }

            _clientService.DeleteClient(id);
            return NoContent();
        }
    }
}