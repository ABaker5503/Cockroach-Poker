using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    public class Player
    {
        string Name { get; set; }
        int CardsRemaining;
        int CardsReceived;
        int Forgs;
        int Rats;
        int Flys;
        int SinkBugs;
        int Bats;
        int Cockroaches;
        int Spiders;
        int Scorpions;

        public Player(string Name, int totalPlayers)
        {
            this.Name = Name;
            this.CardsRemaining = 0;
            this.CardsReceived = 0;
            Forgs = 0;
            Rats = 0;
            Flys = 0;
            SinkBugs = 0;
            Bats = 0;
            Cockroaches = 0;
            Spiders = 0;
            Scorpions = 0;
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

        public void ReceiveCard()
        {
            this.CardsReceived++;
        }

        public void PlayCard()
        {

        }

        public void PrintPlayer()
        {
            Console.WriteLine(String.Format("Cards In Front of You: Forg {0}  Rat {1}  Fly {2}  Sink Bug {3}  Bat {4}  Cockroach {5}  Spider {6}  Scorpion {7}", ForgCard.CardsPlayed, RatCard.CardsPlayed, FlyCard.CardsPlayed, SinkBugCard.CardsPlayed, BatCard.CardsPlayed, CockroachCard.CardsPlayed, SpiderCard.CardsPlayed, ScorpionCard.CardsPlayed));
            Console.WriteLine(String.Format("Cards in your hand: Forg {0}  Rat {1}  Fly {2}  Sink Bug {3}  Bat {4}  Cockroach {5}  Spider {6}  Scorpion {7}", ForgCard.CardsRemaining, RatCard.CardsRemaining, FlyCard.CardsRemaining, SinkBugCard.CardsRemaining, BatCard.CardsRemaining, CockroachCard.CardsRemaining, SpiderCard.CardsRemaining, ScorpionCard.CardsRemaining));
            Console.WriteLine(String.Format("Total cards in hand: {0}", CardsRemaining));
        }

        
    }
}
