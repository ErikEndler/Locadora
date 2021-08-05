using System;

namespace Core.Domain
{
    public class Locacao
    {
        public Locacao() { }
        public Locacao(Cliente cliente, Filme filme)
        {
            Cliente = cliente;
            Filme = filme;
            DataLocacao = DateTime.Now;
            DataDevolucaoPrevista = DateTime.Now.Date.AddDays(7);
        }
        public int Id { get; private set; }
        public DateTime DataLocacao { get; private set; }
        public DateTime? DataEntrega { get; private set; }
        public DateTime DataDevolucaoPrevista { get; private set; }

        public int FilmeID { get; private set; }
        public Filme Filme { get; private set; }

        public int ClienteID { get; private set; }
        public Cliente Cliente { get; private set; }

        public void AlterarEntrega(DateTime data)
        {
            DataEntrega = data;
        }
        public bool VerificaAtraso() => DataDevolucaoPrevista.Date < DataEntrega?.Date;

    }
}
