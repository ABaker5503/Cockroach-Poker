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
        public int CardsRemaining;
        public int CardsPlayed;

        public Spider()
        {
            Name = "Spider";
            Number = 7;
            Catchphrase = "The things of nightmares";
            Color = "Black";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(char x)
        {
            if (x == 'T' && this.Number != 7)
                return true;
            else if (x == 'F' && this.Number == 7)
                return true;
            else
                return false;
        }
    }
}
