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
        public int CardsRemaining;
        public int CardsPlayed;

        public Scorpion()
        {
            Name = "Scorpion";
            Number = 8;
            Catchphrase = "You think that stung?";
            Color = "Gray";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(char x)
        {
            if (x == 'T' && this.Number != 8)
                return true;
            else if (x == 'F' && this.Number == 8)
                return true;
            else
                return false;
        }
    }
}
