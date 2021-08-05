using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ErikTeste.Controllers
{
    [Route("api/locacoes")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoManager _locacaoManager;

        public LocacaoController(ILocacaoManager locacaoManager)
        {
            _locacaoManager = locacaoManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _locacaoManager.GetLocacaoAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _locacaoManager.GetAllLocacaosAsync());
        }
        [HttpPost("cliente/{clienteId}/filme/{filmeId}")]
        public async Task<IActionResult> Post(int clienteId, int filmeId)
        {
            try
            {
                var locacaoInserido = await _locacaoManager.InsertLocacaoAsync(clienteId, filmeId);
                return CreatedAtAction(nameof(Get), new { id = locacaoInserido.Id }, locacaoInserido);
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }

        [HttpPut("devolucao/{id}")]
        public async Task<IActionResult> Entrega(int id)
        {
            try
            {
                var resposta = await _locacaoManager.EntregaLocacaoAsync(id);
                return Ok(new { entrega = resposta });
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }

        }
    }
}
