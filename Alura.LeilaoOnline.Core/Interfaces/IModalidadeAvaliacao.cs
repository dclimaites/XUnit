using System;
using System.Collections.Generic;
using System.Text;

namespace Alura.LeilaoOnline.Core.Interfaces
{
    public interface IModalidadeAvaliacao
    {
        Lance Avaliar(Leilao leilao);
    }
}
