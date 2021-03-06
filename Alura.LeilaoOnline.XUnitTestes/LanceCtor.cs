using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.XUnitTestes
{
    public class LanceCtor
    {
        [Fact]
        public void LanceArgumentExceptionDadoLanceComValorNegativo()
        {
            //arrange
            var avaliacao = new MaiorValor();
            var leilao = new Leilao("Pablo Picasso", avaliacao);
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            //Assert
            Assert.Throws<ArgumentException>(
                //Act
                () => leilao.RecebeLance(fulano, -100));
        }
    }
}
