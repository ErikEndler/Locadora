using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Interfaces.Managers
{
    public interface IFilmeManager
    {
        Task<IEnumerable<Filme>> GetAllFilmesAsync();
        Task<Filme> GetFilmeAsync(int id);
        Task<Filme> InsertFilmeAsync(Filme Filme);
        Task SoftDelete(int id);
        Task<Filme> UpdateFilmeAsync(Filme Filme);
    }
}
