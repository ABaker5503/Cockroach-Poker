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
            string choice = null;
            int playagainst;
            int cardagainst;
            int liecard = 0;
            int NumberofPlayers;
            string Name;
            bool keeporgive;
            int cardsinhand;
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

            Console.WriteLine();
            #region Game Loop
            while (exitflag!=1)
            {
                //use player flag to indicate whose turn it is?
                //Prints cards in Opponent(s') hand
                do
                {
                    int x = playerflag % NumberofPlayers + 1;
                    playerflag = playerflag & NumberofPlayers + 1;
                    Console.WriteLine(playerflag);
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
                            PlayerList[2].PrintCards();
                            break;
                    }

                    //Print your cards
                    PlayerList[playerflag].PrintPlayer();

                    //Pick person to play against
                    playagainst = PlayerList[playerflag].ChooseOpponent(NumberofPlayers);

                    //Pick card to play
                    cardagainst = PlayerList[playerflag].ChooseCard();
                    liecard = cardagainst;

                    //Pick truth or lie (if lie choose different name)
                    fib = PlayerList[playerflag].TruthorLie();

                    if (fib == "F")
                        liecard = PlayerList[playerflag].ChooseCard();

                    Console.WriteLine();
                    Console.WriteLine();

                    //Opponent chooses truth, lie, or pass (T,L,P)
                    Console.WriteLine(PlayerList[playagainst - 1].Name + " what is your choice?");
                    Console.WriteLine("Truth (T), Lie (F), or Pass (P)");
                    choice = Console.ReadLine();


                    //Passing isn't working right now.  Fix later
                    if (choice == "P")
                        playerflag = playagainst;
                    //this math might need a +1

                } while (choice == "P");
                //This might work
                //the loop runs once to get first card
                //rerun the loop if the player chooses to pass
                //maybe...

                //playagainst(int) who you are playing card against
                //cardagainst(int) what the card actually is
                //lie card(int) what you say the card is
                //fib(string) truth or lie
                //choice(string) do you believe or not or pass

                keeporgive = PlayerList[playagainst - 1].CardChoice(choice, cardagainst, liecard);

                //Call receivecard method for specific player
                if (keeporgive) //is true
                    cardsinhand = PlayerList[playerflag].ReceiveCard(cardagainst);
                else
                    cardsinhand = PlayerList[playagainst].ReceiveCard(cardagainst);

                //chech if player against has 4 of any cards, set exitflag=1;
                if (cardsinhand == 4)
                    exitflag = 1;

                exitflag = 1;
            }
            Console.ReadLine();
            #endregion
        }
    }
}
