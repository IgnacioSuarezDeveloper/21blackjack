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

        //dinero del jugador;
        private int fichas;

        //dinero apostado;
        private int apuesta;

        public bool harespondido = false;

        public int Apuesta
        {
            get { return apuesta; }
            set { apuesta = value; }
        }
        public int Fichas
        {
            get { return fichas; }
            set { }
        }

        //constructor.
        public Player(string _name)
        {
            //inicializando array de cartas.
            cartas = new List<Card>();

            //inicializando nombre jugador.
            name = _name;

            //inicializando turno a false.
            turn = false;

            //inicializando fichas
            fichas = 100;

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
            string? reader;
            do
            {
                Console.WriteLine("\nS / N");
                reader =  Console.ReadLine().ToUpper();
                if (reader == "S" || reader == "N" || reader == "" )
                {
                    break;
                }
            } while (true);

            if (reader == "S")
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

        //devuelve la apuesta del usuario.
        public int Bet()
        {
           
            while (true)
            {
                try
                {
                    Console.WriteLine("¿Cuantas fichas quieres apostar?");
                    string reader = Console.ReadLine();
                    int bet = int.Parse(reader);
                    if (bet > fichas || bet < 0)
                    {
                        Console.WriteLine("apuesta no valida caballero");
                    }
                    else
                    {
                        return bet;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("apuesta no valida caballero");
                }
            }

        }

        //actualizar las fichas del usuario
        public void UpdateChips(int fichas)
        {
            this.fichas += fichas;
        }



    }
}
