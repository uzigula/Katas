using NUnit.Framework;
using Tennis;

namespace TennisScore.Test
{
    [TestFixture]
    public class TestScoreTest
    {
        private TennisGame  tennis ;

        [SetUp]
        public void Setup()
        {
            tennis = new Tennis.TennisGame("Federer", "Nadal");
        }

        [TearDown]
        public void Teardown()
        {
            tennis = null;
        }

        [Test]
        public void CuandoSeIniciaElJuego_EntoncesElMarcado_DebeSerEmpateACero()
        {
            Assert.AreEqual("Federer: 0 Nadal: 0", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador1GanaUnPunto_EntoncesScore_15_A_0()
        {
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Federer: 15 Nadal: 0", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador2GanaUnPunto_EntoncesScore_0_A_15()
        {
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Federer: 0 Nadal: 15", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador1GanaDosPuntos_EntoncesScore_30_A_0()
        {
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Federer: 30 Nadal: 0", tennis.Score());
        }
        [Test]
        public void DadoJuegoIniciado_Jugador2GanaDosPuntos_EntoncesScore_0_A_30()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Federer: 0 Nadal: 30", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador1GanaTresPuntosYJugador2GanaDosPuntos_EntoncesScore_40_A_30()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Federer: 40 Nadal: 30", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador1GanaCuatroPuntosYJugador2GanaCuatroPuntos_EntoncesScore_Deuce()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Deuce", tennis.Score());
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Deuce", tennis.Score());
        }
        [Test]
        public void DadoJuegoIniciado_Jugador1GanaCuantroPuntosYJugador2GanaDosPuntos_EntoncesScore_GanaJugador1()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            var score = tennis.Score();
            Assert.AreEqual("Gana Federer", score);
        }
        [Test]
        public void DadoJuegoIniciado_Jugador1GanaCuatroPuntosYJugador2GanaTresPuntos_EntoncesScore_VentajaJugador1()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Deuce", tennis.Score());
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Ventaja Federer", tennis.Score());
        }

        [Test]
        public void DadoJuegoIniciado_Jugador1yJugadorVanADeuceDosVecesYJugador1AnotaDosPuntosSeguidos_EntoncesScore_Jugador1Gana()
        {
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            tennis.PuntoPara("Federer");
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Deuce", tennis.Score());
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Ventaja Federer", tennis.Score());
            tennis.PuntoPara("Nadal");
            Assert.AreEqual("Deuce", tennis.Score());
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Ventaja Federer", tennis.Score());
            tennis.PuntoPara("Federer");
            Assert.AreEqual("Gana Federer", tennis.Score());
        }


    }
}
