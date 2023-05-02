using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Fly : BugCard
    {
        private string Catchphrase { get; }

        public Fly()
        {
            Name = "Fly";
            Number = 6;
            Catchphrase = " You swat at me, I'll dive bomb you!";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
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

        public override void Speak()
        {
            Console.WriteLine("     That's too bad!" + Catchphrase);
        }
    }
}
