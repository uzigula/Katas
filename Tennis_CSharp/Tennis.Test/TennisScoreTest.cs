using NUnit.Framework;
namespace TennisScore.Test
{
    [TestFixture]
    public class TestScoreTest
    {
        [Test]
        public void CuandoSeIniciaElJuego_EntoncesElMarcado_DebeSerEmpateACero()
        {
            var tennis = new Tennis.TennisGame("Federer", "Nadal");
            var score = tennis.Score();
            Assert.AreEqual("Federer: 0 Nadal: 0", score);
        }

      
}
}
