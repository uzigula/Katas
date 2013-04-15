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
            if (_jugador1.Score == _jugador2.Score && _jugador1.Score >= 40)
                return "Deuce";
            else
                return string.Format(_jugador1.Nombre + ": {0} " + _jugador2.Nombre + ": {1}", _jugador1.Score,
                                     _jugador2.Score);
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
            _score += 15;
            if (_score > 40)
                _score = 40;

        }


    }
}
