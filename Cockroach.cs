using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    public class Cockroach : BugCard
    {
        private string Catchphrase;
        private string Color;
        public int CardsRemaining;
        public int CardsPlayed;
        public Cockroach()
        {
            Name = "Cockroach";
            Number = 1;
            Catchphrase = "Indestructible";
            Color = "Red";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card==1)
                return true;
            else if (x == "F" && card!=1)
                return true;
            else
                return false;
        }
    }
}
