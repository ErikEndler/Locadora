using Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers
{
    public interface ILocacaoManager
    {
        Task<String> EntregaLocacaoAsync(int id);
        Task<IEnumerable<Locacao>> GetAllLocacaosAsync();
        Task<Locacao> GetLocacaoAsync(int id);
        Task<Locacao> InsertLocacaoAsync(int clienteId, int filmeId);
    }
}
