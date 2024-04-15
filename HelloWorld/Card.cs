using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        int suit;
        int rank;
        int value;

        public Card(int value, int rank, int suit)
        {
            this.value = value;
            this.rank = rank;
            this.suit = suit;
        }

        public int getSuit() {
            return suit;
        }

        public int getRank() { 
            return rank;    
        }

        public int getValue() {
            return value;
        }

    }
}
