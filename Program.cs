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
            string userInput;
            int NumberofPlayers;
            string Name;
            Player Player1;
            Player Player2;
            Player Player3;
            Player Player4;
            List<Player> PlayerList=new List<Player>();

            #region Print Rules

            #endregion

            Console.WriteLine("How many players? (2 or 4)");
            userInput=Console.ReadLine();
            NumberofPlayers = int.Parse(userInput);

            //setting up array for card distribution
            #region Card Distribution Array
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
                Player1.PrintPlayer();
                Console.WriteLine();
                Player2.PrintPlayer();
                Console.ReadLine();

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

                Player1.PrintPlayer();
                Console.WriteLine();
                Player2.PrintPlayer();
                Console.WriteLine();
                Player3.PrintPlayer();
                Console.WriteLine();
                Player4.PrintPlayer();
                Console.ReadLine();
                PlayerList.Add(Player1);
                PlayerList.Add(Player2);
                PlayerList.Add(Player3);
                PlayerList.Add(Player4);
            }
            #endregion

            #region Game Loop
            while (exitflag!=1)
            {
                //Prints cards in Opponent(s') hand
                foreach (Player p in PlayerList)
                {
                    Console.WriteLine(p.Name);
                }

                //Print cards in front of you

                //Print cards in your hand

                //Pick person to play against

                //Pick card to play

                //Pick truth or lie (if lie choose different name)

                //Player against chooses truth, lie, or pass (T,L,P)

                //Call receivecard method for specific player

                //chech if player against has 4 of any cards, set exitflag=1;

                //if player enters "x", set exitflag=1
            }
            Console.ReadLine();
            #endregion
        }
    }
}
