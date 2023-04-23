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
        public int CardsRemaining;
        public int CardsPlayed;

        public Rat()
        {
            Name = "Rat";
            Number = 4;
            Catchphrase = "I'm not a hairless cat";
            Color = "Brown";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(char x)
        {
            if (x == 'T' && this.Number != 4)
                return true;
            else if (x == 'F' && this.Number == 4)
                return true;
            else
                return false;
        }
    }
}
