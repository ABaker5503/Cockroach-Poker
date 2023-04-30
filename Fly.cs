using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Fly : BugCard
    {
        private string Catchphrase;
        private string Color;
        public int CardsRemaining;
        public int CardsPlayed;

        public Fly()
        {
            Name = "Fly";
            Number = 6;
            Catchphrase = "You swat at me, I'll dive bomb you";
            Color = "Blue";
            CardsRemaining = 0;
            CardsPlayed = 0;
        }

        public void CardsinHand()
        {
            CardsRemaining++;
        }

        public override bool WinOrLose(string x, int card)
        {
            if (x == "T" && card == 6)
                return true;
            else if (x == "F" && card != 6)
                return true;
            else
                return false;
        }
    }
}
