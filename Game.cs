namespace blackjack
{
    internal static class Game
    {
        //primeraMano.
        public static bool fristhand = true;

        //cartas usadas.
        public static List<int> usedCards = new List<int>();

        //inicializando juego.
        public static void InitGame(List<Player> playerList, Croupier croupier, List<Card> cardsList)
        {
            //objeto rndom
            Random rnd = new Random();

            //array de palos.
            Palo[] palos = new Palo[] { Palo.picas, Palo.rombos, Palo.corazones, Palo.treboles };

            //rellenando la baraja.
            for (int i = 0; i < 4; i++)
            {
                for (int x = 1; x < 13; x++)
                {
                    //palo que recibe la carta.
                    Palo palo = palos[i];

                    //numero que recibe la carta.
                    int number = x;

                    //Baraja añadir carta numero.
                    cardsList.Add(new Card(palo, number));
                }
            }

            int index = 0;

            //repartiendo cartas a cada jugador.
            foreach (Player p in playerList)
            {

                //La primera carta para el jugador.
                index = rnd.Next(0, cardsList.Count);
                p.cartas.Add(cardsList[index]);
                usedCards.Add(index);

                //la segunda carta para el jugador. teniendo en cuenta que no se pase de 21.
                while (true)
                {
                    bool salir = true;
                    index = rnd.Next(0, cardsList.Count);
                    foreach (int ind in usedCards)
                    {
                        if (ind == index)
                        {

                            salir = false;
                            break;

                        }
                    }
                    if (salir)
                    {
                        if (cardsList[index].number + p.cartas[0].number <= 21)
                        {
                            p.cartas.Add(cardsList[index]);
                            break;
                        }


                    }
                }

                //añadiendo los indices de las cartas del jugador  a la lista de cartas usadas para no repartirlas de nuevo
                usedCards.Add(index);
            }

            //dando la primera carta al croupier.
            while (true)
            {
                bool exit = true;
                index = rnd.Next(0, cardsList.Count);
                foreach (int ind in usedCards)
                {
                    if (ind == index)
                    {
                        exit = false;
                        break;
                    }

                }
                if (exit == true)
                {
                        //añadiendo la carta a la mano.
                        croupier.cartas.Add(cardsList[index]);
                        
                        //añadiendo el indice al indice de cartas usadas.
                        usedCards.Add(index);
                        break;
                }

            }

            //dando la segunda carta al croupier.
            while (true)
            {
                bool exit = true;
                index = rnd.Next(0, cardsList.Count);
                foreach (int ind in usedCards)
                {
                    if (ind == index)
                    {
                        exit = false;
                        break;
                    }

                }
                if (exit == true)
                {

                    int cuenta = croupier.Cuenta();

                    //se añade la carta si no suman mas de 21 por ejemplo dos reyes sumarian mas y no se repartiria el segundo rey escogeria otra carta.
                    if(cuenta + cardsList[index].number <= 21)
                    {
                        //añadiendo la carta a la mano del croupier.
                        croupier.cartas.Add(cardsList[index]);

                        //añadiendo el indice a los ya usados.
                        usedCards.Add(index);
                        break;
                    }

                }

            }

            //añadiendo los indices de las cartas del croupier a la lista de cartas usadas para no repartirlas de nuevo


        }

        //cambiar turno.
        public static void ChangeTurn(List<Player> playerListList)
        {

            int idex = 0;

            foreach (Player p in playerListList)
            {
                if (p.turn == true)
                {
                   
                    idex += 1;
                    if (idex > playerListList.Count - 1)
                    {
                        idex = 0;
                    }
                    playerListList[idex].turn = true;
                    p.turn = false;
                    break;
                }
                idex++;



            }
        }//ChangeTurn

        //interfaz de usuario.
        public static void UserInterface(Croupier croupier, List<Player> players)
        {
            //suma de las cartas iniciales del cropier.
            int croupierSuma = croupier.Cuenta();

            //muestra cartas del croupier.
            string message = "";

            //muestra cartas del jugador y cuenta.
            if (fristhand)
            {
                for (int i = 0; i < croupier.cartas.Count; i++)
                {
                    if (i < 1)
                    {
                        message += $"{croupier.cartas[0].name}";
                    }
                    else
                    {
                        message += " ,carta boca abajo";
                    }
                }
                fristhand = false;
            }
            else
            {
                foreach (Card c in croupier.cartas)
                {
                    message += $"{c.name} ,";
                }
            }

            //cartas del croupier mostradas.
            Console.WriteLine($"CROUPIER->{message} cuenta: {croupierSuma}\n");


            //suma de cartas de los jugadores.
            foreach(Player p in players)
            {
                int playerSum = p.Cuenta();

                //muestra cartas del jugador y cuenta
                message = "";
                foreach (Card c in p.cartas)
                {
                    message += $"{c.name}, ";
                }
                Console.WriteLine($"{p.name.ToUpper()}->{message} cuenta: {playerSum} fichas:{p.Fichas}\n");
            }
            

        }//UserInterface.

    }
}
