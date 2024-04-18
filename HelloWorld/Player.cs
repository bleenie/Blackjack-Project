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
        Hand playerHand;
        Random random = new Random();

        public Player() {
        
        }

        public bool autoHitStand()
        {
            Random random = new Random();
            bool randomBoolean = random.Next(2) == 0;
            return randomBoolean;
        }



    }
}
