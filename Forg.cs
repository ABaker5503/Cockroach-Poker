using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Forg : BugCard
    {
        private string Catchphrase;
        private string Color;
        public int CardsRemaining;
        public int CardsPlayed;

        public Forg()
        {
            Name = "Forg";
            Number = 5;
            Catchphrase = "Not just one of the ten plagues anymore";
            Color = "Seductive Green";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 5)
                return true;
            else if (x == "F" && card != 5)
                return true;
            else
                return false;
        }
    }
}
