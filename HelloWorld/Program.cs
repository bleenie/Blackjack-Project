using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Blackjack
{
    internal class Program
    {
        /*   public static Deck deck = new Deck();
           public static Hand hand = new Hand();
           public static Player player = new Player();
           public static bool playing;
           public static bool hitOrStand;*/
        public static Deck deck = new Deck();
        public static Player player = new Player();
        public static Game game;
        public static bool endApplication = false;

        static void Main(string[] args)
        {
            
            while (!endApplication) {
                Console.WriteLine("Press enter to start new game");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    game = new Game();
                    game.oneRound(player, deck);
                }
            }


        }
        /*public static void oneRound()
        {
            while (playing)
            {
                deck.shuffle();
                Console.WriteLine("Player's turn. Your cards:");
                *//*hand.addCard(deck.drawCard());*//*
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
                    if (choice == false) 
                    {
                        hitOrStand = false;
                    } 
                    else if (hand.bust(hand.countHand()) == true) 
                    {
                        Console.WriteLine("Bust!");
                        hitOrStand = false;
                    } 
                    else if ( hand.countHand() == 21)  
                    {
                        Console.WriteLine("Can't pull any more cards! End of turn");
                        hitOrStand = false;
                    }
            
                }
                playing = false;
            }
        }*/
    }
}
