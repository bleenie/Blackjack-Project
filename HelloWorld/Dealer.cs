using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Blackjack
{
    internal class Dealer
    {
        Hand hand;

        public Dealer()
        {
            hand = new Hand();
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
