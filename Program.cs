using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Cockroach_Poker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int exitflag=0;
            int playerflag = 0;             //starts at 0 so mod+1 is first player
            string userInput;
            string fib;
            string choice;
            int playagainst;
            int cardagainst;
            int liecard = 0;
            int NumberofPlayers;
            string Name;
            Player Player1;
            Player Player2;
            Player Player3;
            Player Player4;
            List<Player> PlayerList=new List<Player>();

            #region Print Rules
            //still need to do this
            #endregion

            Console.WriteLine("How many players? (2 or 4)");
            userInput=Console.ReadLine();
            NumberofPlayers = int.Parse(userInput);

            #region Card Distribution Array
            //setting up array for card distribution
            int[] arr = new int[64];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    arr[j + i * 8] = i + 1;
                }
            }
            #endregion
            #region Two Player Set Up
            if (NumberofPlayers == 2)
            {
                Console.WriteLine("Player 1's Name: ");
                Name = Console.ReadLine();
                Player1 = new Player(Name, 2);

                Console.WriteLine("Player 2's Name: ");
                Name = Console.ReadLine();
                Player2 = new Player(Name, 2);

                //dividing out cards
                int end = 64;
                Random rnd = new Random();
                int x;
                while (end>0)
                {
                    x = rnd.Next(0, end);
                    Player1.CardsInHand(arr[x]);
                    for (int j = x; j < end-1; j++)
                        arr[j] = arr[j + 1];
                    end--;

                    x = rnd.Next(0, end);
                    Player2.CardsInHand(arr[x]);
                    for (int j = x; j < end; j++)
                        arr[j] = arr[j + 1];
                    end--;
                }

                PlayerList.Add(Player1);
                PlayerList.Add(Player2);
            }
            #endregion
            #region Four Player Set Up
            else if (NumberofPlayers == 4)
            {
                Console.WriteLine("Player 1's Name: ");
                Name = Console.ReadLine();
                Player1 = new Player(Name, 4);

                Console.WriteLine("Player 2's Name: ");
                Name = Console.ReadLine();
                Player2 = new Player(Name, 4);

                Console.WriteLine("Player 3's Name: ");
                Name = Console.ReadLine();
                Player3 = new Player(Name, 4);

                Console.WriteLine("Player 4's Name: ");
                Name = Console.ReadLine();
                Player4 = new Player(Name, 4);

                //dividing out cards
                int end = arr.Length;
                Random rnd = new Random();
                int x;
                while (end > 0)
                {
                    x = rnd.Next(0, end);
                    Player1.CardsInHand(arr[x]);
                    for (int j = x; j < end-1; j++)
                        arr[j] = arr[j + 1];
                    end--;

                    x = rnd.Next(0, end);
                    Player2.CardsInHand(arr[x]);
                    for (int j = x; j < end-1; j++)
                        arr[j] = arr[j + 1];
                    end--;

                    x = rnd.Next(0, end);
                    Player3.CardsInHand(arr[x]);
                    for (int j = x; j < end-1; j++)
                        arr[j] = arr[j + 1];
                    end--;

                    x = rnd.Next(0, end);
                    Player4.CardsInHand(arr[x]);
                    for (int j = x; j < end-1; j++)
                        arr[j] = arr[j + 1];
                    end--;
                }

                PlayerList.Add(Player1);
                PlayerList.Add(Player2);
                PlayerList.Add(Player3);
                PlayerList.Add(Player4);
            }
            #endregion

            #region Game Loop
            while (exitflag!=1)
            {
                //use player flag to indicate whose turn it is?
                //Prints cards in Opponent(s') hand
                int x = playerflag % NumberofPlayers + 1;
                Console.WriteLine(x);
                switch (x)
                {
                    case 1:
                        PlayerList[1].PrintCards();
                        if (NumberofPlayers == 4)
                        {
                            PlayerList[2].PrintCards();
                            PlayerList[3].PrintCards();
                        }
                        break;
                    case 2:
                        PlayerList[0].PrintCards();
                        if (NumberofPlayers == 4)
                        {
                            PlayerList[2].PrintCards();
                            PlayerList[3].PrintCards();
                        }
                        break;
                    case 3:
                        PlayerList[0].PrintCards();
                        PlayerList[1].PrintCards();
                        PlayerList[3].PrintCards();
                        break;
                    case 4:
                        PlayerList[0].PrintCards();
                        PlayerList[1].PrintCards();
                        PlayerList[3].PrintCards();
                        break;
                }

                //Print your cards
                PlayerList[playerflag].PrintPlayer();

                //Pick person to play against
                if (NumberofPlayers == 2)
                    Console.WriteLine("Player One (1) or Player Two (2)");
                else
                    Console.WriteLine("Player One (1), Player Two (2), Player Three (3), or Player Four (4)");
                Console.WriteLine("Player you want to play against: ");
                playagainst = int.Parse(Console.ReadLine());

                //Pick card to play
                Console.WriteLine("1-Cockroach  2-Bat  3-SinkBug  4-Rat  5-Forg  6-Fly  7-Spider  8-Scorpion");
                Console.WriteLine("Card you want to play (pick number): ");
                cardagainst = int.Parse(Console.ReadLine());
                liecard = cardagainst;

                //Pick truth or lie (if lie choose different name)
                Console.WriteLine("Truth (T) or Lie (F): ");
                fib = Console.ReadLine();

                if (fib=="F")
                {
                    Console.WriteLine("What bug: ");
                    liecard=Console.Read();
                }

                Console.WriteLine();
                Console.WriteLine();

                //Player against chooses truth, lie, or pass (T,L,P)
                Console.WriteLine(PlayerList[playagainst-1].Name + " what is your choice?");
                Console.WriteLine("Truth (T), Lie (F), or Pass (P)");
                choice=Console.ReadLine();
                PlayerList[playagainst - 1].CardChoice(playagainst, fib, liecard, choice);

                //Call receivecard method for specific player

                //chech if player against has 4 of any cards, set exitflag=1;

                //if player enters "x", set exitflag=1

                exitflag = 1;
            }
            Console.ReadLine();
            #endregion
        }
    }
}
