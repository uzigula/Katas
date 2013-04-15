using System;

namespace Tennis
{
    public class TennisGame
    {
        private Jugador _jugador1 = new Jugador();
        private Jugador _jugador2 = new Jugador();

        public TennisGame(string jugador1, string jugador2)
        {
            _jugador1.Nombre = jugador1;
            _jugador2.Nombre = jugador2;
        }

        public string Score()
        {
            if (EsEmpate())
                return "Deuce";

            if (TerminoElJuego())
                return "Gana " + JugadorGanador().Nombre;

            if (EnVentaja())
                return "Ventaja " + JugadorGanador().Nombre;

            return string.Format(_jugador1.Nombre + ": {0} " + _jugador2.Nombre + ": {1}", PuntajeParaPizarra(_jugador1.Score),
                                 PuntajeParaPizarra(_jugador2.Score));
        }

        private bool EnVentaja()
        {
            return ((_jugador1.Score >= 4 || _jugador2.Score >= 4) && (Math.Abs(_jugador1.Score - _jugador2.Score) == 1));
        }

        private bool TerminoElJuego()
        {
            return ((_jugador1.Score >= 4 || _jugador2.Score >= 4) && (Math.Abs(_jugador1.Score - _jugador2.Score) == 2));

        }

        private Jugador JugadorGanador()
        {
            return (_jugador1.Score > _jugador2.Score) ? _jugador1 : _jugador2;
        }

        private bool EsEmpate()
        {
            return (_jugador1.Score == _jugador2.Score && _jugador1.Score >= 3);
        }

        public void PuntoPara(string nombreJugador)
        {
            var jugador = ObtieneJugador(nombreJugador);
            jugador.Anotacion();
        }

        private Jugador ObtieneJugador(string nombreJugador)
        {
            if (_jugador1.Nombre == nombreJugador)
                return _jugador1;
            else if (_jugador2.Nombre == nombreJugador)
                return _jugador2;
            else
                return null;
        }

        private int PuntajeParaPizarra(int score)
        {
            var puntaje = score * 15;
            return puntaje > 40 ? 40 : puntaje;
        }

    }

    internal class Jugador
    {
        private int _score = 0;
        public string Nombre { get; set; }

        public int Score
        {
            get
            {
                return _score;
            }
        }


        public void Anotacion()
        {
            _score += 1;
        }


    }
}
