using Core.Domain;
using Manager.Interfaces.Managers;
using Manager.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Implementation
{
    public class ClienteManager : IClienteManager
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteManager(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> GetClienteAsync(int id)
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
        {
            var clienteList = await _clienteRepository.GetAllClientesAsync();
            return clienteList;
        }

        public async Task<Cliente> InsertClienteAsync(Cliente cliente)
        {
            var resposta = await _clienteRepository.InsertClienteAsync(cliente);
            return resposta;
        }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
        {
            var resposta = await _clienteRepository.UpdateClienteAsync(cliente);
            return resposta;
        }
        public async Task SoftDelete(int id)
        {
            var cliente = await _clienteRepository.GetClienteAsync(id);
            if (cliente != null)
            {
                cliente.AlterarStatus(false);
                await _clienteRepository.UpdateClienteAsync(cliente);
            }
            else
                throw new Exception("Cliente não encontrado");

        }
    }
}
