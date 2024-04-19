using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        int coins;
        string name;
        Hand hand;
        Random random = new Random();

        public Player() {
            coins = 0;
            name = "";
            hand = new Hand();
        }

        public bool autoHitStand()
        {
            Random random = new Random();
            bool randomBoolean = random.Next(2) == 0;
            return randomBoolean;
        }

        public void setHand()
        {
            hand = new Hand();
        }

        public Hand getHand()
        {
            return hand;
        }


    }
}
