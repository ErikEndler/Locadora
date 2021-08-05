using Core.Domain;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementation
{
    public class LocacaoManager : ILocacaoManager
    {
        private readonly ILocacaoRepository _locacaoRepository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IClienteRepository _clienteRepository;


        public LocacaoManager(ILocacaoRepository locacaoRepository, IClienteRepository clienteRepository, IFilmeRepository filmeRepository)
        {
            _locacaoRepository = locacaoRepository;
            _clienteRepository = clienteRepository;
            _filmeRepository = filmeRepository;
        }

        public async Task<Locacao> GetLocacaoAsync(int id)
        {
            var Locacao = await _locacaoRepository.GetLocacaoAsync(id);
            return Locacao;
        }

        public async Task<IEnumerable<Locacao>> GetAllLocacaosAsync()
        {
            var LocacaoList = await _locacaoRepository.GetAllLocacoesAsync();
            return LocacaoList;
        }

        public async Task<Locacao> InsertLocacaoAsync(int clienteId, int filmeId)
        {
            var cliente = await _clienteRepository.GetClienteAsync(clienteId);
            var filme = await _filmeRepository.GetFilmeAsync(filmeId);

            if (filme != null && cliente != null)
            {
                if (!filme.Locado)
                {
                    var locacao = new Locacao(cliente, filme);
                    var resposta = await _locacaoRepository.InsertLocacaoAsync(locacao);
                    filme.AlterarEstadoLocacao(true);
                    await _filmeRepository.UpdateFilmeAsync(filme);
                    return resposta;
                }
                throw new Exception("Filme ja esta locado");
            }
            throw new Exception("Erro ao cadastrar locação");
        }

        public async Task<String> EntregaLocacaoAsync(int id)
        {
            var locacao = await GetLocacaoAsync(id);
            if (locacao != null)
            {
                locacao.Filme.AlterarEstadoLocacao(false);
                locacao.AlterarEntrega(DateTime.Now);
                await _locacaoRepository.UpdateLocacaoAsync(locacao);
                if (locacao.VerificaAtraso())
                {
                    return "Devolução feita com atraso!";
                }
                return "Devolução realizada!";

            }
            throw new Exception("Filme não encontrado");
        }
        
    }
}
