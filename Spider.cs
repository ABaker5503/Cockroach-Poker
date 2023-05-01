using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Spider : BugCard
    {
        private string Catchphrase;
        private string Color;

        public Spider()
        {
            Name = "Spider";
            Number = 7;
            Catchphrase = "The things of nightmares";
            Color = "Black";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 7)
                return true;
            else if (x == "F" && card != 7)
                return true;
            else
                return false;
        }
    }
}
