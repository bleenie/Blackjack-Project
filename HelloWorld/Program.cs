﻿namespace Blackjack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Deck deck = new Deck();
            deck.shuffle();
            Console.WriteLine(deck.drawCard());

        }
    }
}
