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
            Player jugador1 = new Player("Pedro");

            //apuesta Jugadores.
            int apuestaJugadores = 0;
            int playerTurn = 0;
            //añadiendo jugador a la lista.
            players.Add(jugador);
            players.Add(jugador1);


            //inicializando partida.
            Game.InitGame(players, croupier, Deck);

            //mostrando la partida.
            Game.UserInterface(croupier, players);

            while (true)
            {
                //comprabando si la cuenta de player se ha pasado 
                if (players[0].cuenta > 21)
                {

                    Console.WriteLine("te pasaste");
                    Console.ReadLine();
                    Console.Clear();
                    players[0].RemoveCards();
                    croupier.RemoveCards();
                    croupier.DeckClear(Deck);
                    Game.InitGame(players, croupier, Deck);
                    Game.UserInterface(croupier, players);

                }
                
                //preguntar al user
                foreach (Player p in players) 
                {
                    Console.WriteLine("¿quieres carta?");
                    
                    //respuesta del jugador a si quiere cartas.
                    bool respuesta = p.AskForCards();
                    if (respuesta)
                    {

                        Console.WriteLine("¿Cuanto quieres apostar?");
                        int apuesta = p.Bet();
                        p.Apuesta += apuesta;
                        p.UpdateChips(-apuesta);
                        p.cartas.Add(croupier.RepartirCarta(Deck));
                        Console.Clear();
                        Game.UserInterface(croupier, players);
                    }
                    p.harespondido = true;
                    bool todoshanRespondido  = true;
                    foreach(Player pla in players)
                    {
                        if(pla.harespondido == false)
                        {
                            todoshanRespondido = false;
                            break;
                        }

                    }
                    Console.Clear();
                    Game.UserInterface(croupier, players);
                    //croupier reparte cartas si la respuesta es no.

                }
                

                    //primera mano.
                    Game.fristhand = true;

                    //limpia consola.
                    Console.Clear();

                    //dibujando ui
                    Game.UserInterface(croupier, players);
            }


        }
    }
}
