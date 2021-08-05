using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Repositories
{
    public interface IFilmeRepository
    {
        Task<IEnumerable<Filme>> GetAllFilmesAsync();
        Task<Filme> GetFilmeAsync(int id);
        Task<Filme> InsertFilmeAsync(Filme Filme);
        Task<Filme> UpdateFilmeAsync(Filme Filme);
    }
}
