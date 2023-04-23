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
        public int CardsRemaining;
        public int CardsPlayed;

        public SinkBug()
        {
            Name = "Sink Bug";
            Number = 3;
            Catchphrase = "You've been sink bugged";
            Color = "Green";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(char x)
        {
            if (x == 'T' && this.Number != 3)
                return true;
            else if (x == 'F' && this.Number == 3)
                return true;
            else
                return false;
        }
    }
}
