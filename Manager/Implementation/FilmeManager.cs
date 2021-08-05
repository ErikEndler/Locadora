using Core.Domain;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementation
{
    public class FilmeManager : IFilmeManager
    {
        private readonly IFilmeRepository _filmeRepository;
        public FilmeManager(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Filme> GetFilmeAsync(int id)
        {
            var Filme = await _filmeRepository.GetFilmeAsync(id);
            return Filme;
        }

        public async Task<IEnumerable<Filme>> GetAllFilmesAsync()
        {
            var FilmeList = await _filmeRepository.GetAllFilmesAsync();
            return FilmeList;
        }

        public async Task<Filme> InsertFilmeAsync(Filme Filme)
        {
            var resposta = await _filmeRepository.InsertFilmeAsync(Filme);
            return resposta;
        }

        public async Task<Filme> UpdateFilmeAsync(Filme Filme)
        {
            var resposta = await _filmeRepository.UpdateFilmeAsync(Filme);
            return resposta;
        }
        public async Task SoftDelete(int id)
        {
            var filme = await _filmeRepository.GetFilmeAsync(id);
            if (filme != null)
            {
                filme.AlterarStatus(false);
                await _filmeRepository.UpdateFilmeAsync(filme);
            }
            else
                throw new Exception("Filme não encontrado");
        }
    }
}
