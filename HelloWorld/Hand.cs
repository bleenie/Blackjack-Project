using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Hand
    {
        List<Card> hand;

        public Hand()
        {
            hand = new List<Card>();
        }

        public void addCard(Card card)
        {
            hand.Add(card);
        }

        /*Logs the hand List in the console*/
        public void logHand()
        {
            for (var i = 0; i < hand.Count; i++)
            {
                Console.Write(hand[i] + "   ");
            }
        }

        public int countHand()
        {
            int cardValue;
            List<int> valueList = new List<int>();
            int handCount;
            for (var i = 0; i < hand.Count; i++)
            {
                cardValue = hand[i].getValue();
                valueList.Add(cardValue);
            }
            handCount = valueList.Sum(Convert.ToInt32);
            return handCount;
        }

        public bool bust(int handCount)
        {
            if (handCount > 21)
            {
                Console.WriteLine("Bust!");
                return true;
            }
            return false;
        }

        /*public bool blackjack()
        {
           
        }*/
    }
}
