using System;

namespace Core.Domain
{
    public class Cliente
    {
        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf;
            Ativo = true;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Boolean Ativo { get; private set; }

        public void AlterarStatus(Boolean ativo)
        {
            Ativo = ativo;
        }
    }
}
