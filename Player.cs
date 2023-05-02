using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    public class Player
    {
        public string Name { get; set; }

        int CardsRemaining;                         //number of cards still in your hand
        int CardsReceived;                          //number of cards in front of you

        public Player(string Name, int totalPlayers)
        {
            this.Name = Name;
            this.CardsRemaining = 0;
            this.CardsReceived = 0;
        }

        Cockroach CockroachCard = new Cockroach();
        Bat BatCard = new Bat();
        SinkBug SinkBugCard = new SinkBug();
        Rat RatCard = new Rat();
        Forg ForgCard = new Forg();
        Fly FlyCard = new Fly();
        Spider SpiderCard = new Spider();
        Scorpion ScorpionCard = new Scorpion();

        #region Receiving First Hand
        public void CardsInHand(int x)
        {
            switch (x)
            {
                case 1:
                    CockroachCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 2:
                    BatCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 3:
                    SinkBugCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 4:
                    RatCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 5:
                    ForgCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 6:
                    FlyCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 7:
                    SpiderCard.CardsinHand();
                    CardsRemaining++;
                    break;
                case 8:
                    ScorpionCard.CardsinHand();
                    CardsRemaining++;
                    break;
            }
        }
        #endregion

        public int ReceiveCard(int card)
        {
            int result = 0;
            switch (card)
            {
                case 1:
                    CockroachCard.ReceiveACard();
                    CockroachCard.Speak();
                    result = CockroachCard.CardsReceived;
                    break;
                case 2:
                    BatCard.ReceiveACard();
                    BatCard.Speak();
                    result = BatCard.CardsReceived;
                    break;
                case 3:
                    SinkBugCard.ReceiveACard();
                    SinkBugCard.Speak();
                    result = SinkBugCard.CardsReceived;
                    break;
                case 4:
                    RatCard.ReceiveACard();
                    RatCard.Speak();
                    result = RatCard.CardsReceived;
                    break;
                case 5:
                    ForgCard.ReceiveACard();
                    result = ForgCard.CardsReceived;
                    break;
                case 6:
                    FlyCard.ReceiveACard();
                    FlyCard.Speak();
                    result = FlyCard.CardsReceived;
                    break;
                case 7:
                    SpiderCard.ReceiveACard();
                    SpiderCard.Speak();
                    result = SpiderCard.CardsReceived;
                    break;
                case 8:
                    ScorpionCard.ReceiveACard();
                    ScorpionCard.Speak();
                    result = ScorpionCard.CardsReceived;
                    break;
            }
            CardsReceived++;
            return result;
        }

        public int ChooseOpponent(int x)
        {
            if (x == 2)
                Console.WriteLine("Player One (1) or Player Two (2)");
            else
                Console.WriteLine("Player One (1), Player Two (2), Player Three (3), or Player Four (4)");
            Console.WriteLine("Player you want to play against: ");
            int result = int.Parse(Console.ReadLine());
            Console.WriteLine();
            return result;
        }

        public int ChooseCard()
        {
            Console.WriteLine("1-Cockroach  2-Bat  3-SinkBug  4-Rat  5-Forg  6-Fly  7-Spider  8-Scorpion");
            Console.WriteLine("Card you want to play (pick number): ");
            int result = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch(result)
            {
                case 1:
                    CockroachCard.PlayACard();
                    break;
                case 2:
                    BatCard.PlayACard();
                    break;
                case 3:
                    SinkBugCard.PlayACard();
                    break;
                case 4:
                    RatCard.PlayACard();
                    break;
                case 5:
                    ForgCard.PlayACard();
                    break;
                case 6:
                    FlyCard.PlayACard();
                    break;
                case 7:
                    SpiderCard.PlayACard();
                    break;
                case 8:
                    ScorpionCard.PlayACard();
                    break;
            }
            return result;
        }

        public string TruthorLie()
        {
            Console.WriteLine("Truth (T) or Lie (F): ");
            var result = Console.ReadLine();
            Console.WriteLine();
            return result;
        }

        public string TruthLiePass(int x, string opponent)
        {
            string cardname = CockroachCard.DetermineCard(x);
            Console.WriteLine(String.Format("{0} is offering you a {1}", opponent, cardname));
            Console.WriteLine(this.Name + " what is your choice?");
            Console.WriteLine("Truth (T), Lie (F), or Pass (P)");
            string choice = Console.ReadLine();
            return choice;
        }

        public bool CardChoice(string choice, int actualcard, int liecard)
        {
            bool truth = true;
            switch (actualcard)
            {
                case 1:
                    truth = CockroachCard.WinOrLose(choice, liecard);
                    break;
                case 2:
                    truth = BatCard.WinOrLose(choice, liecard);
                    break;
                case 3:
                    truth = SinkBugCard.WinOrLose(choice, liecard);
                    break;
                case 4:
                    truth = RatCard.WinOrLose(choice, liecard);
                    break;
                case 5:
                    truth = ForgCard.WinOrLose(choice, liecard);
                    break;
                case 6:
                    truth = FlyCard.WinOrLose(choice, liecard);
                    break;
                case 7:
                    truth = SpiderCard.WinOrLose(choice, liecard);
                    break;
                case 8:
                    truth = ScorpionCard.WinOrLose(choice, liecard);
                    break;
                }
            Console.WriteLine("--------------" + truth + "---------------");
            return truth;
        }

        public void PrintPlayer()
        {
            Console.WriteLine(String.Format("{0}:", Name));
            Console.WriteLine(String.Format("Cards In Front: Cockroach {0}  Bat {1}  Sink Bug {2}  Rat {3}  Forg {4}  Fly {5}  Spider {6}  Scorpion {7}", CockroachCard.CardsReceived, BatCard.CardsReceived, SinkBugCard.CardsReceived, RatCard.CardsReceived, ForgCard.CardsReceived, FlyCard.CardsReceived, SpiderCard.CardsReceived, ScorpionCard.CardsReceived));
            Console.WriteLine(String.Format("Cards in Your Hand: Cockroach {0}  Bat {1}  Sink Bug {2}  Rat {3}  Forg {4}  Fly {5}  Spider {6}  Scorpion {7}", CockroachCard.CardsToPlay, BatCard.CardsToPlay, SinkBugCard.CardsToPlay, RatCard.CardsToPlay, ForgCard.CardsToPlay, FlyCard.CardsToPlay, SpiderCard.CardsToPlay, ScorpionCard.CardsToPlay));
            Console.WriteLine();
        }

        public void PrintCards()
        {
            Console.WriteLine(String.Format("{0}:", Name));
            Console.WriteLine(String.Format("Cards In Front: Cockroach {0}  Bat {1}  Sink Bug {2}  Rat {3}  Forg {4}  Fly {5}  Spider {6}  Scorpion {7}", CockroachCard.CardsReceived, BatCard.CardsReceived, SinkBugCard.CardsReceived, RatCard.CardsReceived, ForgCard.CardsReceived, FlyCard.CardsReceived, SpiderCard.CardsReceived, ScorpionCard.CardsReceived));
            Console.WriteLine();
        }

        
    }
}
