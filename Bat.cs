using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Bat : BugCard
    {
        private string Catchphrase;
        private string Color;
        public int CardsRemaining;
        public int CardsPlayed;

        public Bat()
        {
            Name = "Bat";
            Number = 2;
            Catchphrase = "Alfred, where's the BatMobile?";
            Color = "Purple";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }
        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 2)
                return true;
            else if (x == "F" && card != 2)
                return true;
            else
                return false;
        }
    }
}
