using Core.Domain;
using Data.Context;
using Manager.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly AppDbContext _context;

        public FilmeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Filme>> GetAllFilmesAsync()
        {
            var listaFilme = await _context.Filmes
                .Where(x => x.Ativo)
                .OrderBy(x => x.Id)
                .AsNoTracking().ToListAsync();
            return listaFilme;
        }
        public async Task<Filme> GetFilmeAsync(int id)
        {
            return await _context.Filmes
                .Where(x => x.Ativo)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Filme> InsertFilmeAsync(Filme Filme)
        {
            var result = await _context.Filmes.AddAsync(Filme);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<Filme> UpdateFilmeAsync(Filme Filme)
        {
            var FilmeConsult = await _context.Filmes.FindAsync(Filme.Id);
            if (FilmeConsult == null)
            {
                throw new Exception("filme não existente");
            }
            _context.Entry(FilmeConsult).CurrentValues.SetValues(Filme);
            await _context.SaveChangesAsync();
            return Filme;
        }

    }
}
