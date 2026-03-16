using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack
{
    enum Palo
    {
        picas,
        rombos,
        corazones,
        treboles
    }
    internal class Card
    {
        public Palo palo;
        public int number;
        public string name;

        public Card(Palo _palo, int _number)//al inicializar las cartas.
        {
            palo = _palo;
            number = _number;
            if (_number > 0 && _number < 10)
            {
                name = $"{palo.ToString()} {number.ToString()}";
            }
            else
            {
                if(number == 10)
                {
                    name = $"{palo.ToString()} {"Jack"}";
                }else if(number == 11)
                {
                    name = $"{palo.ToString()} {"Queen"}";
                }else if(number == 12)
                {
                    name = $"{palo.ToString()} {"King"}";
                }else if(number == 0)
                {
                    name = $"{palo.ToString()} {"Joker"}";
                }
            }
        }
    }
}
