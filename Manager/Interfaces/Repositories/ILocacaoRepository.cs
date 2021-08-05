using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories
{
    public interface ILocacaoRepository
    {
        Task<IEnumerable<Locacao>> GetAllLocacoesAsync();
        Task<Locacao> GetLocacaoAsync(int id);
        Task<Locacao> InsertLocacaoAsync(Locacao locacao);
        Task UpdateLocacaoAsync(Locacao locacao);
    }
}
