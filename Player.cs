namespace blackjack
{
    internal class Player
    {
        //lista de cartas del jugador
        public List<Card> cartas;

        //nombre del jugador.
        public string name;

        //turno del jugador.
        public bool turn;

        //cuenta de jugador.
        public int cuenta;

        //constructor.
        public Player(string _name)
        {
            //inicializando array de cartas.
            cartas = new List<Card>();

            //inicializando nombre jugador.
            name = _name;

            //inicializando turno a false.
            turn = false;

            //inicializando cuenta.
            cuenta = 0;
        }//Player

        //devuelve la cuenta de las cartas del jugador.
        public int Cuenta()
        {
            cuenta = 0;
            if (cartas != null)
            {
                foreach (Card c in cartas)
                {

                    cuenta += c.number;
                }
            }
            return cuenta;
        }//PlayerSum

        //pedir carta.
        public bool AskForCards()
        {
            string? reader = Console.ReadLine();
            do
            {
                if (reader == "s" || reader == "n")
                {
                    break;
                }
            } while (true);

            if (reader == "s")
            {
                return true;
            }
            else
            {
                return false;
            }
        }//PlayerAskForCards;

        //devolver las cartas a la baraja
        public void RemoveCards()
        {
            cartas.Clear();
        }//RemoveCards.


    }
}
