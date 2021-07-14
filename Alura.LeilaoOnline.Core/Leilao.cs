using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public enum StatusLeilao
    {
        Aberto,
        EmAndamento,
        Finalizado
    }
    public class Leilao
    {
        private IList<Lance> _lances;
        public IEnumerable<Lance> Lances => _lances;
        public string Peca { get; }
        public Lance Ganhador { get; private set; }
        public StatusLeilao Status { get; private set; }
        public Interessada UltimoCliente { get; private set; }

        public Leilao(string peca)
        {
            Peca = peca;
            _lances = new List<Lance>();
            Status = StatusLeilao.Aberto;
        }

        public void RecebeLance(Interessada cliente, double valor)
        {
            if (ValidaLance(cliente))
            {
                UltimoCliente = cliente;
                _lances.Add(new Lance(cliente, valor));
            }
        }

        private bool ValidaLance(Interessada cliente)
        {
            return Status == StatusLeilao.EmAndamento && UltimoCliente != cliente;
        }

        public void IniciaPregao()
        {
            Status = StatusLeilao.EmAndamento;
        }

        public void TerminaPregao()
        {
            if (Status != StatusLeilao.EmAndamento)
                throw new InvalidOperationException();
            Status = StatusLeilao.Finalizado;
            Ganhador = Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .OrderBy(lance => lance.Valor)
                .Last();
        }
    }
}