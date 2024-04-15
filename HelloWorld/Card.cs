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
        Values value;

        public Card(int value, int rank, int suit)
        {
            this.value = (Values)value;
            this.rank = (Ranks)rank;
            this.suit = (Suits)suit;
        }

        public Suits getSuit() {
            return suit;
        }

        public Ranks getRank() { 
            return rank;    
        }

        public Values getValue() {
            return value;
        }

    }
}
