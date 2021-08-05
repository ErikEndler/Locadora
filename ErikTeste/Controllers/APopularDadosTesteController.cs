using Core.Domain;
using Manager.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ErikTeste.Controllers
{
    [Route("api/popularBanco")]
    [ApiController]
    public class APopularDadosTesteController : ControllerBase
    {
        private readonly IClienteManager _clienteManager;
        private readonly IFilmeManager _filmeManager;
        private readonly ILocacaoManager _locacaoManager;

        public APopularDadosTesteController(IClienteManager clienteManager, IFilmeManager filmeManager, ILocacaoManager locacaoManager)
        {
            _clienteManager = clienteManager;
            _filmeManager = filmeManager;
            _locacaoManager = locacaoManager;
        }

        [HttpGet]
        public async Task<IActionResult> PopularDados()
        {
            var cliente01 = new Cliente("Cliente 01", "01236985214");
            var cliente01Insert = await _clienteManager.InsertClienteAsync(cliente01);
            var filme01 = new Filme("Senhor dos aneis");
            var Filme01Insert = await _filmeManager.InsertFilmeAsync(filme01);
            await _locacaoManager.InsertLocacaoAsync(cliente01Insert.Id, Filme01Insert.Id);


            var cliente02 = new Cliente("Cliente 02", "89654712398");
            var cliente02Insert = await _clienteManager.InsertClienteAsync(cliente02);
            var filme02 = new Filme("As branquelas");
            var Filme02Insert = await _filmeManager.InsertFilmeAsync(filme02);
            await _locacaoManager.InsertLocacaoAsync(cliente02Insert.Id, Filme02Insert.Id);

            return Ok(new { resposta = "dados inseridos" });
        }
    }
}
