using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Forg : BugCard
    {
        private string Catchphrase { get; }

        public Forg()
        {
            Name = "Forg";
            Number = 5;
            Catchphrase = "Not just one of the ten plagues anymore";
            CardsToPlay = 0;
            CardsReceived = 0;
        }

        public void CardsinHand()
        {
            CardsToPlay++;
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

        public override void Speak()
        {
            Console.WriteLine(Catchphrase);
        }
    }
}
