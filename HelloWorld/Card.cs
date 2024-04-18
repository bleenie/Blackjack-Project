using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack
{
    internal class Card
    {
        Suits suit;
        Ranks rank;
        int value;

        public Card(int suit, int rank, int value)
        {
            this.value = value;
            this.rank = (Ranks)rank;
            this.suit = (Suits)suit;
        }

        public Suits getSuit() {
            return suit;
        }

        public Ranks getRank() { 
            return rank;    
        }

        public int getValue() {
            return value;
        }

        public override string ToString()
        {
            return getRank() + " of " + getSuit();
        }
    }
}
