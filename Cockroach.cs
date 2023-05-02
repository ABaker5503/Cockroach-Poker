using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    public class Cockroach : BugCard
    {
        private string Catchphrase { get; }
        public Cockroach()
        {
            Name = "Cockroach";
            Number = 1;
            Catchphrase = " I am Indestructible!";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
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

        public override void Speak()
        {
            Console.WriteLine("     That's too bad!" + Catchphrase);
        }
    }
}
