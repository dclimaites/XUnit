using Alura.LeilaoOnline.Core;
using System;
using Xunit;

namespace Alura.LeilaoOnline.XUnitTestes
{
    public class LeilaoTerminaPregao
    {
        [Theory]
        [InlineData(757, new double[] { 600, 650, 700, 757 })]
        [InlineData(1200, new double[] { 900, 1000, 1200, 1100 })]
        [InlineData(700, new double[] { 700 })]
        public void RetornaLanceComMaiorValorDadoPeloMenosUmLance(double valorObtido, double[] lances)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if (i % 2 == 0)
                    leilao.RecebeLance(fulano, lances[i]);
                else
                    leilao.RecebeLance(maria, lances[i]);
            }

            //act
            leilao.TerminaPregao();
            //asset
            Assert.Equal(valorObtido, leilao.Ganhador.Valor);
        }

        [Theory]
        [InlineData(0, new double[] { })]
        public void RetornaZeroDadoLeilaoSemLances(double valorObtido, double[] lances)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var fulano = new Interessada("Fulano", leilao);
            leilao.IniciaPregao();
            foreach (var item in lances)
            {
                leilao.RecebeLance(fulano, item);
            }
            //act
            leilao.TerminaPregao();
            //asset
            Assert.Equal(valorObtido, leilao.Ganhador.Valor);
        }

        [Fact]
        public void LancaInvalidOperationExceptionDadoTerminaPregaoSemInicio()
        {
            //arrange
            var leilao = new Leilao("Auto da compadecida");
            //assert
            Assert.Throws<InvalidOperationException>(
                //act
                () => leilao.TerminaPregao());

        }
    }
}
