using System;

namespace Core.Domain
{
    public class Filme
    {
        public Filme(string nome)
        {
            Nome = nome;
            Locado = false;
            Ativo = true;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public Boolean Locado { get; private set; }
        public Boolean Ativo { get; private set; }

        public void AlterarEstadoLocacao(Boolean estado)
        {
            Locado = estado;
        }
        public void AlterarStatus(Boolean ativo)
        {
            Ativo = ativo;
        }
    }
}
