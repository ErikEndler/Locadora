using Core.Domain;
using ErikTeste.DTO;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ErikTeste.Controllers
{
    [Route("api/clientes")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;

        public ClienteController(IClienteManager clienteManager)
        {
            _clienteManager = clienteManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _clienteManager.GetClienteAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteManager.GetAllClientesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = new Cliente(clienteDTO.Nome, clienteDTO.Cpf);
                var clienteInserido = await _clienteManager.InsertClienteAsync(cliente);
                return CreatedAtAction(nameof(Get), new { id = clienteInserido.Id }, clienteInserido);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = new Cliente(clienteDTO.Nome, clienteDTO.Cpf);
                var clienteAtt = await _clienteManager.UpdateClienteAsync(cliente);
                return CreatedAtAction(nameof(Get), new { id = clienteAtt.Id }, clienteAtt);
            }
            catch (Exception e)
            {
                return NotFound(new { error = e.Message });
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteManager.SoftDelete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
