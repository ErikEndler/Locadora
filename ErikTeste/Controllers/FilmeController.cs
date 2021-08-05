using Core.Domain;
using ErikTeste.DTO;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ErikTeste.Controllers
{
    [Route("api/filmes")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeManager _filmeManager;

        public FilmeController(IFilmeManager filmeManager)
        {
            _filmeManager = filmeManager;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _filmeManager.GetFilmeAsync(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _filmeManager.GetAllFilmesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                var filme = new Filme(filmeDTO.Nome);
                var filmeInserido = await _filmeManager.InsertFilmeAsync(filme);
                return CreatedAtAction(nameof(Get), new { id = filmeInserido.Id }, filmeInserido);
            }
            catch (Exception e)
            {
                return NotFound(new { errors = e.Message });
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                var filme = new Filme(filmeDTO.Nome);
                var filmeAtt = await _filmeManager.UpdateFilmeAsync(filme);
                return CreatedAtAction(nameof(Get), new { id = filmeAtt.Id }, filmeAtt);
            }
            catch (Exception e)
            {
                return NotFound(new { errors = e.Message });
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _filmeManager.SoftDelete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(new { error = e.Message });
            }
        }
    }
}
