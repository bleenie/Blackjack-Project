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
            checkAceValue(valueList, bust(handCount));
            handCount = valueList.Sum(Convert.ToInt32);
            return handCount;
        }

        public bool bust(int handCount)
        {
            if (handCount > 21)
            {
                return true;
            }
            return false;
        }
        /*Checks if there is an ace in hand. If yes, checks if standard ace value results in bust and changes value of card accordingly*/
        public void checkAceValue(List<int> valueList, bool bust)
        {
            int aceIndex = valueList.IndexOf(11);
            if (aceIndex >= 0 && bust == true)
            {
                valueList[aceIndex] = 1;
            }
        }

        public bool blackjack(int handCount)
        {
            if (handCount == 21)
            {
                return true;
            }
            return false;
        }
    }
}
