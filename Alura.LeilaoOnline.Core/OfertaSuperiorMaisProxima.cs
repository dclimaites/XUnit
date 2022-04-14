using Alura.LeilaoOnline.Core.Interfaces;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; }
        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public Lance Avaliar(Leilao leilao)
        {
            return leilao.Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(item => item.Valor > ValorDestino)
                .OrderBy(i => i.Valor)
                .FirstOrDefault();
        }
    }
}
