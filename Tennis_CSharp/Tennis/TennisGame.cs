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
            return string.Format(_jugador1.Nombre + ": {0} " + _jugador2.Nombre + ": {1}", _jugador1.Score, _jugador2.Score);
        }

  
    }

    internal class Jugador
    {
        private int _score=0;
        public string Nombre { get; set; }

        public int Score
        {
            get { return _score; }
        }

        public void Anotacion()
        {
            
        }

    }
}
