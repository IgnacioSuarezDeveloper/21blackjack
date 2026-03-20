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

            //apuesta Jugadores.
            int apuestaJugadores = 0;

            //añadiendo jugador a la lista.
            players.Add(jugador);

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
                Console.WriteLine("¿quieres carta?");

                //respuesta del jugador a si quiere cartas.
                bool respuesta = players[0].AskForCards();

                //croupier reparte cartas.
                if (respuesta)
                {
                    //repartiendo carta al jugador.
                    players[0].cartas.Add(croupier.RepartirCarta(Deck));
                    int apuesta = players[0].Bet();
                    apuestaJugadores += apuesta;
                    players[0].UpdateChips(-apuesta);
                }
                else if (!respuesta)
                {
<<<<<<< HEAD
                    while(croupier.cuenta < 15)
                    {
                        croupier.cartas.Add(croupier.RepartirCarta(Deck));
                        croupier.Cuenta();
                    }
                    Console.Clear();
                    Game.UserInterface (croupier,players);   
                    Console.ReadLine();
=======
                    while (croupier.cuenta < 15)
                    {
                        Console.Clear();
                        croupier.cartas.Add(croupier.RepartirCarta(Deck));
                        croupier.Cuenta();
                        Game.UserInterface(croupier, players);
                        Thread.Sleep(1000);
                    }
>>>>>>> c933733520721a9cce4c6f5e012ae8ee79cd2ce1
                    //si la cuenta del jugador es mayor que la del croupier.
                    if (players[0].cuenta > croupier.cuenta && croupier.cuenta <= 21)
                    {
                        Console.WriteLine("as ganado \n");
                        Console.WriteLine($"fichas ganadas {apuestaJugadores * 2}");
                        players[0].UpdateChips(apuestaJugadores * 2);
                        apuestaJugadores = 0;
                        Console.WriteLine("reparto nuevas cartas\n");
                        Console.ReadLine();
                        Console.Clear();
                        players[0].RemoveCards();
                        croupier.RemoveCards();
                        croupier.DeckClear(Deck);
                        Game.InitGame(players, croupier, Deck);

                    }
                    else if (croupier.cuenta > players[0].cuenta && croupier.cuenta <= 21)
                    {
                        Console.WriteLine("as perdidio");
                        Console.WriteLine("reparto nuevas cartas\n");
                        Console.ReadLine();
                        Console.Clear();
                        Console.ReadLine();
                        players[0].RemoveCards();
                        croupier.RemoveCards();
                        croupier.DeckClear(Deck);
                        Game.InitGame(players, croupier, Deck);

                    }
                    else if (croupier.cuenta == players[0].cuenta && croupier.cuenta <= 21)
                    {
                        Console.WriteLine("Draw");
                        players[0].UpdateChips(apuestaJugadores);
                        apuestaJugadores = 0;
                        Console.WriteLine("reparto nuevas cartas\n");
                        Console.ReadLine();
                        Console.Clear();
                        Console.ReadLine();
                        players[0].RemoveCards();
                        croupier.RemoveCards();
                        croupier.DeckClear(Deck);
                        Game.InitGame(players, croupier, Deck);


                    }
                    else if (croupier.cuenta > 21)
                    {

                        Console.WriteLine("has ganado.");
                        players[0].UpdateChips(apuestaJugadores * 2);
                        apuestaJugadores = 0;
                        Console.WriteLine("reparto nuevas cartas\n");
                        Console.ReadLine();
                        Console.Clear();
                        Console.ReadLine();
                        players[0].RemoveCards();
                        croupier.RemoveCards();
                        croupier.DeckClear(Deck);
                        Game.InitGame(players, croupier, Deck);
                        Console.ReadLine();

                    }

                    //primera mano.
                    Game.fristhand = true;

                }

                //limpia consola.
                Console.Clear();

                //dibujando ui
                Game.UserInterface(croupier, players);
            }


        }
    }
}
