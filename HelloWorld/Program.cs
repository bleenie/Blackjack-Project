using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Blackjack
{
    internal class Program
    {
        public static Deck deck = new Deck();
        public static Hand hand = new Hand();
        public static Player player = new Player();
        public static bool playing;
        public static bool hitOrStand;

        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to start new game");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                playing = true;
                hitOrStand = true;
                oneRound();
            }

           /* hand.addCard(deck.drawCard());
            hand.addCard(deck.drawCard());
            hand.addCard(deck.drawCard());
            hand.addCard(deck.drawCard());
            hand.logHand();
            hand.countHand();*/

        }
        public static void oneRound()
        {
            while (playing)
            {
                deck.shuffle();
                Console.WriteLine("Player's turn. Your cards:");
                /*hand.addCard(deck.drawCard());*/
                deck.hitStand(true, hand);
                deck.hitStand(true, hand);
                hand.logHand();
                Console.WriteLine("Total: " + hand.countHand());
                while (hitOrStand) {
                    Console.WriteLine("Hit or stand?");
                    bool choice = player.autoHitStand();
                    deck.hitStand(choice, hand);
                    hand.logHand();
                    Console.WriteLine("Total: " + hand.countHand());
                    if (choice == false || hand.bust(hand.countHand()) == true)  
                    {
                        hitOrStand = false;
                    }
            
                }
                /*while (hitOrStand) 
                {
                    Console.WriteLine("Hit or stand?");
                    if (hand.bust(hand.countHand()) == true)
                    { 
                        if (player.autoHitStand() == true) { 
                     
                        deck.hitStand(player.autoHitStand(), hand);
                        }
                        else
                        {
                            hitOrStand = false;
                        }
                    }
                    else
                    {
                        hitOrStand = false;
                    }
                }*/


                playing = false;
            }
        }
    }
}
