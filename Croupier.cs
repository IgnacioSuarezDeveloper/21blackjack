using System.Security.Cryptography;
namespace blackjack
{
    internal class Croupier
    {
        public List<Card> cartas;//croupier cartas;
        public bool turn;//croupier turno
        public int cuenta;//croupier cuenta

        //constuctor 
        public Croupier()
        {
            //cartas del croupier.
            cartas = new List<Card>();
            //turno del croupier.
            turn = false;
            //cuenta del croupier.
            cuenta = 0;
        }

        //devuelve la suma de cartas del croupier.
        public int Cuenta()
        {
            if (!Game.fristhand)
            {
                cuenta = 0;
                if (cartas != null)
                {
                    foreach (Card c in cartas)
                    {
                        cuenta += c.number;
                    }
                }

            }
            else
            {
                cuenta = cartas[0].number;
            }
            return cuenta;

        }

        //croupier reparte carta.
        public Card RepartirCarta(List<Card> cardList)
        {
            int ind = 0;
            while (true)
            {
                bool meter = true;
                ind = RandomNumberGenerator.GetInt32(0, cardList.Count);
                if (Game.usedCards != null)
                {
                    foreach (int index in Game.usedCards)
                    {
                        if (ind == index)
                        {
                            meter = false;
                            break;
                        }
                    }

                }
                if (meter == true)
                {
                    break;
                }
            }
            if (Game.usedCards != null)
            {
                Game.usedCards.Add(ind);
            }
            return cardList[ind];
        }

        //remove cards.
        public void RemoveCards()
        {
            cartas.Clear();
        }

        //vaciar baraja.
        public void DeckClear(List<Card> cardList)
        {
            cardList.Clear();
        }
    }
}
