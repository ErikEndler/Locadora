using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class LocacaoRepository : ILocacaoRepository
    {
        private readonly AppDbContext _context;

        public LocacaoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Locacao>> GetAllLocacoesAsync()
        {
            var listLocacao = await _context.Locacoes
                .AsNoTracking().ToListAsync();
            List<Locacao> SortedList = listLocacao.OrderBy(o => o.Id).ToList();
            return SortedList;
        }
        public async Task<Locacao> GetLocacaoAsync(int id)
        {
            return await _context.Locacoes
                                .Include(p => p.Cliente)
                                .Include(p => p.Filme)
                                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Locacao> InsertLocacaoAsync(Locacao locacao)
        {
            var result = await _context.Locacoes.AddAsync(locacao);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task UpdateLocacaoAsync(Locacao locacao)
        {
            _context.Entry(locacao);
            await _context.SaveChangesAsync();
        }
    }
}
