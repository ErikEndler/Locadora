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
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var listaCliente = await _context.Clientes
                .Where(x => x.Ativo)
                .OrderBy(x => x.Id)
                .AsNoTracking().ToListAsync();
            return listaCliente;
        }
        public async Task<Cliente> GetClienteAsync(int id)
        {
            return await _context.Clientes
                .Where(x => x.Ativo)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            var verificacaoCpf = await GetByCpfAsync(cliente.Cpf);
            if (verificacaoCpf)
            {
                throw new Exception("Cliente ja existente para este CPF : " + cliente.Cpf);
            }
            var result = await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
            return result.Entity;

        }
        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var clienteConsult = await _context.Clientes.FindAsync(cliente.Id);
            if (clienteConsult == null)
            {
                throw new Exception("Cliente não existente");
            }
            var verificacaoCpf = await GetByCpfAsync(cliente.Cpf);
            if (verificacaoCpf && clienteConsult.Cpf != cliente.Cpf)
            {
                throw new Exception("Cliente ja existente para CPF : " + cliente.Cpf);
            }
            _context.Entry(clienteConsult).CurrentValues.SetValues(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        private async Task<Boolean> GetByCpfAsync(string cpf)
        {
            var result = await _context.Clientes.AnyAsync(p => p.Cpf == cpf);
            return result;
        }

    }
}
