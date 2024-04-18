using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blackjack.Enums;

namespace Blackjack
{
    internal class Deck
    {
        List<Card> cards;
        int[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        int index;

        public Deck()
        {
            cards = new List<Card>(52);
            setUpDeck();
        }

        public void setUpDeck()
        {
            foreach (int i in Enum.GetValues(typeof(Suits)))
            { 
                foreach (int j in Enum.GetValues(typeof(Ranks)))
                {
                    
                    Card card = new Card(i, j, values[j]);
                    cards.Add(card);
                }
            }
           
        }

        public void shuffle()
        {
            cards = cards.OrderBy(x => Random.Shared.Next()).ToList();
            Console.WriteLine("Deck shuffled!");

        }

        public Card drawCard()
        {
            if (index >= 52)
            {
                index = 0;
                shuffle();
                noCards();
            }
            index++;
            int cardsIndex = index - 1;
            return cards[cardsIndex];
        }

        public string noCards()
        {
            return "No cards remaining, reshuffling deck...";
        }

        public void hitStand(bool hit, Hand hand)
        {
            if (hit == true)
            {
                hand.addCard(drawCard());
               /* hand.logHand();
                Console.WriteLine(hand.countHand());*/
            }
            else
            {
                Console.WriteLine("Stand!");
                /*hand.logHand();
                Console.WriteLine(hand.countHand());*/
            }
        }
        
    }
}
