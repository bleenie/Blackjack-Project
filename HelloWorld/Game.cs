using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
                    Console.WriteLine("Blackjack!");
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
                        Console.WriteLine("Blackjack!!");
                        playing = false;
                    }
                }       
            }
        }

        public void compareHands(int dealerCount, int playerCount)
        {
            Console.WriteLine(" ");
            Console.WriteLine("Dealer total: " + dealerCount + "   Player total: " + playerCount);
            if (dealerCount > playerCount)
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealerCount == playerCount)
            {
                Console.WriteLine("Tie!");
            } else
            {
                Console.WriteLine("Player wins!");
            }
        }

        public void oneRound()
        {
            while (playing == true)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Player's cards:");
                firstCards(playerHand);
                if (playing == true) 
                { 
                    Console.WriteLine(" ");
                    Console.WriteLine("Dealer's cards:");
                    firstCards(dealerHand);
                    if (playing == true)
                    {
                        while (hitOrStand)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Player's turn: Hit or stand?");
                            bool choice = player.autoHitStand();
                            deck.hitStand(choice, playerHand);
                            if (choice)
                            {
                                Console.WriteLine("Hit!");
                                playerHand.logHand();
                                Console.WriteLine("Total: " + playerHand.countHand());
                            }
                            if (!choice)
                            {
                                Console.WriteLine("Stand!");
                                hitOrStand = false;
                            }
                            else if (playerHand.bust(playerHand.countHand()) == true)
                            {
                                Console.WriteLine("Bust! Dealer wins!");
                                hitOrStand = false;
                                playing = false;
                            }
                            else if (playerHand.countHand() == 21)
                            {
                                Console.WriteLine("Reached max points! End of turn");
                                hitOrStand = false;
                            }
                        }
                        if (playing == true)
                        {
                            Console.WriteLine(" ");
                            Console.WriteLine("Dealer's cards:");
                            if (!dealerHand.dealerCanCheck())
                            {
                                dealerHand.getFirstCard().switchFaceDirection();
                            }
                            dealerHand.logHand();
                            Console.WriteLine("Total: " + dealerHand.countHand());
                            
                            while (dealerHand.countHand() < 17)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Dealer's turn: Hit or stand?");
                                deck.hitStand(true, dealerHand);
                                Console.WriteLine("Hit!");
                                dealerHand.logHand();
                                Console.WriteLine("Total: " + dealerHand.countHand());
                            } 
                            if (dealerHand.bust(dealerHand.countHand()))
                            {
                                Console.WriteLine("Bust! Player wins!");
                            } else if (dealerHand.countHand() >= 17)
                            {
                                Console.WriteLine(" ");
                                Console.WriteLine("Dealer's turn: Hit or stand?");
                                Console.WriteLine("Stand!");
                                compareHands(dealerHand.countHand(), playerHand.countHand());
                            }
                        }
                    }

                }
                playing = false;
            }
        }
    }
}
