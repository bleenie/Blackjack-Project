using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        /*Deck deck;*/
        Hand hand;
        /*Player player;*/
        bool playing;
        bool hitOrStand;

        public Game() {
            /*deck = new Deck();*/
            hand = new Hand();
            /*player = new Player();*/
        }

        public void firstCards(Deck deck)
        {
            deck.hitStand(true, hand);
            deck.hitStand(true, hand);
            hand.logHand();
            Console.WriteLine("Total: " + hand.countHand());
            if (hand.blackjack(hand.countHand()))
            {
                Console.WriteLine("Blackjack!");
                hitOrStand = false;
            }
        }

        public void oneRound(Player player, Deck deck)
        {
            playing = true;
            hitOrStand = true;
            while (playing)
            {
                Console.WriteLine("Player's turn. Your cards:");
                firstCards(deck);
                while (hitOrStand)
                {
                    Console.WriteLine("Hit or stand?");
                    bool choice = player.autoHitStand();
                    deck.hitStand(choice, hand);
                    hand.logHand();
                    Console.WriteLine("Total: " + hand.countHand());
                    if (choice == false)
                    {
                        hitOrStand = false;
                    }
                    else if (hand.bust(hand.countHand()) == true)
                    {
                        Console.WriteLine("Bust!");
                        hitOrStand = false;
                    }
                    else if (hand.countHand() == 21)
                    {
                        Console.WriteLine("Can't pull any more cards! End of turn");
                        hitOrStand = false;
                    }

                }
                playing = false;
            }
        }
    }
}
