using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

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
                
                //Para cada jugador 2 cartas.
                for(int i = 0; i < 2; i++)
                {  
                    if(usedCards == null)
                    {
                            index = rnd.Next(0, cardsList.Count);
                            p.cartas.Add(cardsList[index]);
                            usedCards.Add(index);
                   
                    }else if (usedCards != null)
                    {
                        while (true)
                        {
                            bool salir = true;
                            index = rnd.Next(0, cardsList.Count);
                            foreach(int ind in usedCards)
                            {
                                if (ind == index)
                                {
                                    salir = false;
                                    break;
                                }
                            }
                            if (salir)
                            {
                                p.cartas.Add(cardsList[index]);
                                break;
                            }
                        }
                        

                    }


                        //añadiendo los indices de las cartas del jugador  a la lista de cartas usadas para no repartirlas de nuevo

                        usedCards.Add(index);
                }

            }
            
            //dando cartas al cropier.
            for(int i = 0; i < 2; i++)
            {
                while (true)
                {
                    bool exit = true;
                    index = rnd.Next(0, cardsList.Count);
                    foreach (int ind in usedCards)
                    {
                        if(ind == index)
                        {
                            exit = false;
                            break;
                        }
                        
                    }
                    if(exit == true)
                    {
                        croupier.cartas.Add(cardsList[index]);
                        usedCards.Add(index);
                        break;
                    }
                    

                    //añadiendo los indices de las cartas del croupier a la lista de cartas usadas para no repartirlas de nuevo
                    
                }
                
            }
        }
        
        //cambiar turno.
        public static void ChangeTurn(List<Player> playerListList)
        {
            
            int idex = 0;

            foreach(Player p in playerListList)
            {
                if (p.turn == true)
                {
                    p.turn = false;
                    idex += 1;
                    if (idex > playerListList.Count - 1) {
                        idex = 0;
                    }
                    playerListList[idex].turn = true;
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
                for(int i =0; i < croupier.cartas.Count; i++)
                {
                    if( i < 1)
                    {
                        message += $"{croupier.cartas[0].name}";
                    }
                    else
                    {
                        message += "carta boca abajo";
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
            Console.WriteLine($"{message} cuenta: {croupierSuma}\n");


            //suma de las cartas del jugador
            int playerSum = players[0].Cuenta();

            //muestra cartas del jugador y cuenta
            message = "";
            foreach (Card c in players[0].cartas)
            {
                message += $"{c.name}, ";
            }
            Console.WriteLine($"{message} cuenta: {playerSum}\n");

        }//UserInterface.

    }
}
