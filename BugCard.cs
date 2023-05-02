using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    public abstract class BugCard
    {
        public string Name;
        public int Number;
        public int CardsReceived;
        public int CardsToPlay;

        public BugCard() { }



        public virtual bool WinOrLose(string x, int card)
        {
            if (x == "T")
                return true;
            else
                return false;
        }

        public virtual void Speak()
        {
            Console.WriteLine("Hello");
        }

        public void ReceiveACard()
        {
            CardsReceived++;
        }

        public void PlayACard()
        {
            CardsToPlay--;
        }

        public string DetermineCard(int x)
        {
            switch (x)
            {
                case 1:
                    return "Cockroach";
                case 2:
                    return "Bat";
                case 3:
                    return "Sink Bug";
                case 4:
                    return "Rat";
                case 5:
                    return "Forg";
                case 6:
                    return "Fly";
                case 7:
                    return "Spider";
                case 8:
                    return "Scorpion";
            }
            return "Invalid";
        }
    }
}
