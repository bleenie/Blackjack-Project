using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;

namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            Player player = new Player();
            Dealer dealer = new Dealer();
            Game game;
            bool endApplication = false;


            while (!endApplication) {
                Console.WriteLine(" ");
                Console.WriteLine("Press enter to start new game");
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    game = new Game(player, dealer, deck);
                    game.oneRound();
                }
            }
        }
    }
}
