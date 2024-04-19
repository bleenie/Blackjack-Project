using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Game
    {
        Hand playerHand;
        Hand dealerHand;
        bool playing;
        bool hitOrStand;
        Player player;
        Dealer dealer;
        Deck deck;

        public Game(Player player, Dealer dealer, Deck deck) 
        {
            playing = true;
            hitOrStand = true;
            this.player = player;
            this.dealer = dealer;
            this.deck = deck;
            player.setHand();
            playerHand = player.getHand();
            dealer.setHand();
            dealerHand = dealer.getHand();
        }

        public void firstCards(Hand hand)
        {
            if ( hand == playerHand) { 
                deck.hitStand(true, hand);
                deck.hitStand(true, hand);
                hand.logHand();
                Console.WriteLine("Total: " + hand.countHand());
                if (hand.blackjack(hand.countHand()))
                {
                    Console.WriteLine("Blackjack! Player wins!");
                    playing = false;
                }
            } else
            {
                deck.hitStand(true, hand);
                deck.hitStand(true, hand);
                hand.getFirstCard().switchFaceDirection();
                hand.logHand();
                Console.WriteLine("Total: ?");
                if (hand.dealerCanCheck())
                {
                    Console.WriteLine("Dealer may check for Blackjack...");
                    hand.getFirstCard().switchFaceDirection();
                    hand.logHand();
                    Console.WriteLine("Total: " + hand.countHand());
                    if (hand.blackjack(hand.countHand()))
                    {
                        Console.WriteLine("Blackjack! Dealer wins!");
                        playing = false;
                    }
                }
               
            }
        }

        public void oneRound()
        {
            while (playing == true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Player 1's cards:");
                firstCards(playerHand);
                Console.WriteLine(" ");
                Console.WriteLine("Dealer's cards:");
                firstCards(dealerHand);
                while (hitOrStand)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("Hit or stand?");
                    bool choice = player.autoHitStand();
                    deck.hitStand(choice, playerHand);
                    if (choice)
                    {
                        playerHand.logHand();
                    }
                    Console.WriteLine("Total: " + playerHand.countHand());
                    if (choice == false)
                    {
                        hitOrStand = false;
                    }
                    else if (playerHand.bust(playerHand.countHand()) == true)
                    {
                        Console.WriteLine("Bust!");
                        hitOrStand = false;
                    }
                    else if (playerHand.countHand() == 21)
                    {
                        Console.WriteLine("Reached max points! End of turn");
                        hitOrStand = false;
                    }

                }
                playing = false;
            }
        }
    }
}
