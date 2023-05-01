using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Rat : BugCard
    {
        private string Catchphrase;
        private string Color;

        public Rat()
        {
            Name = "Rat";
            Number = 4;
            Catchphrase = "I'm not a hairless cat";
            Color = "Brown";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 4)
                return true;
            else if (x == "F" && card != 4)
                return true;
            else
                return false;
        }
    }
}
