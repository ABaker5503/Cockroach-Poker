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

        public BugCard() { }



        public virtual bool WinOrLose(string x, int card)
        {
            if (x == "T")
                return true;
            else
                return false;
        }
    }
}
