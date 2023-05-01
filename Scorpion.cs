using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Scorpion : BugCard
    {
        private string Catchphrase;
        private string Color;

        public Scorpion()
        {
            Name = "Scorpion";
            Number = 8;
            Catchphrase = "You think that stung?";
            Color = "Gray";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 8)
                return true;
            else if (x == "F" && card != 8)
                return true;
            else
                return false;
        }
    }
}
