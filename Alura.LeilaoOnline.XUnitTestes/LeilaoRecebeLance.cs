using Xunit;
using Alura.LeilaoOnline.Core;
using System.Linq;

namespace Alura.LeilaoOnline.XUnitTestes
{
    public class LeilaoRecebeLance
    {
        [Theory]
        [InlineData(3, new double[] { 200, 300, 400 })]
        [InlineData(1, new double[] { 200})]
        [InlineData(0, new double[] { })]
        public void RetornaQuantidadeLancesDadoLeilaoFinalizado(int qtdLancesObtido, double[] lances)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var rajao = new Interessada("Rajão", leilao);
            var maria = new Interessada("Maria", leilao);
            leilao.IniciaPregao();

            for (int i = 0; i < lances.Length; i++)
            {
                if(i % 2 == 0)
                    leilao.RecebeLance(rajao, lances[i]);
                else
                    leilao.RecebeLance(maria, lances[i]);
            }

            leilao.TerminaPregao();
            //act
            leilao.RecebeLance(rajao, 1000);
            //assert
            Assert.Equal(qtdLancesObtido, leilao.Lances.Count());
        }

        [Theory]
        [InlineData(1, new double[] { 200, 300, 400 })]
        [InlineData(1, new double[] { 200 })]
        public void RetornaQuantidadeLancesDadoLancesConsecutivosDoMesmoCliente(int qtdLancesObtido, double[] lances)
        {
            //arrange
            var leilao = new Leilao("Van Gogh");
            var rajao = new Interessada("Rajão", leilao);
            leilao.IniciaPregao();
            //act
            foreach (var item in lances)
            {
                leilao.RecebeLance(rajao, item);
            }

            leilao.TerminaPregao();
            
            //assert
            Assert.Equal(qtdLancesObtido, leilao.Lances.Count());
        }
    }
}
