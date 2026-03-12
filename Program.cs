using System.Xml.Linq;

namespace blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //lista de cartas que sera la baraja.
            List<Card> Deck = new List<Card>();

            //lista de jugadores.
            List<Player> players = new List<Player>();

            //Creando croupier
            Croupier croupier = new Croupier();

            
            //Creando jugador.
            Player jugador = new Player("Nacho");

            //añadiendo jugador a la lista.
            players.Add(jugador);

            //inicializando partida.
            Game.InitGame(players, croupier ,Deck);

            //mostrando la partida.
            Game.UserInterface(croupier, players);

            while (true)
            {
                Console.WriteLine("¿quieres carta?");

                //respuesta del jugador a si quiere cartas.
                bool respuesta = players[0].AskForCards();

                //croupier reparte cartas.
                if (respuesta)
                {
                    players[0].cartas.Add(croupier.RepartirCarta(Deck));
                }
                //limpia consola.
                Console.Clear();

                //limpia consola.
                Game.UserInterface(croupier, players);

                //limpiando la consola.
                Console.ReadLine();
            }


        }
    }
}
