using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class SinkBug : BugCard
    {
        private string Catchphrase;
        private string Color;

        public SinkBug()
        {
            Name = "Sink Bug";
            Number = 3;
            Catchphrase = "You've been sink bugged";
            Color = "Green";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 3)
                return true;
            else if (x == "F" && card != 3)
                return true;
            else
                return false;
        }
    }
}
