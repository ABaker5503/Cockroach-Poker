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
            #region Variables
            int exitflag =0;
            int playerflag = 0;             //starts at 0 so mod+1 is first player
            string userInput;
            string fib;
            string choice = null;
            int playagainst;
            int cardagainst = 0;
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
            #endregion

            #region Print Rules
            Console.WriteLine("Welcome to Cockroach Poker!  Your goal is to lie your way to victory");
            Console.WriteLine();
            Console.WriteLine("How to Play:");
            Console.WriteLine("On your turn, you select a card from your hand to play against another player of your choice.");
            Console.WriteLine("You can either say the card is what is it, or lie about what type of bug it is.");
            Console.WriteLine("Your opponent then chooses if they believe you (truth) or not (lie).");
            Console.WriteLine("If your opponent guesses truth or lie correctly, you receive the card and place it in front of youself.");
            Console.WriteLine("If they guess incorrectly, they receive the card and place it in front of themselves.");
            Console.WriteLine("Additionally, your opponent can choose to pass the card to another player.");
            Console.WriteLine("In this case, they look at the card, choose whether to tell the truth or lie, and pick their target.");
            Console.WriteLine("Passing can continue as long as there are players who have not received the card yet.");
            Console.WriteLine("The game continues until one player has four of the same card in front of them.");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue:");
            Console.ReadLine();
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

            Console.Clear();
            #region Game Loop
            while (exitflag!=1)
            {
                do
                {
                    int x = playerflag % NumberofPlayers + 1;
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

                    if (choice != "P")
                    {
                        //Pick card to play
                        cardagainst = PlayerList[playerflag].ChooseCard();
                        liecard = cardagainst;
                    }
                    else
                    {
                        //Find out what the card is and truth or lie
                        Console.WriteLine("The card is a " + PlayerList[playerflag].WhichCard(cardagainst));
                    }

                    //Pick truth or lie (if lie choose different name)
                    fib = PlayerList[playerflag].TruthorLie();

                    if (fib == "F")
                        liecard = PlayerList[playerflag].ChooseCard();

                    Console.Clear();

                    foreach (Player p in PlayerList)
                    {
                        if (p != PlayerList[playagainst-1])
                            p.PrintCards();
                    }

                    PlayerList[playagainst-1].PrintPlayer();



                    //Opponent chooses truth, lie, or pass (T,L,P)
                    //want to print out card name.  Do that later
                    choice = PlayerList[playagainst-1].TruthLiePass(liecard, PlayerList[playerflag].Name);

                    if (choice == "P")
                    {
                        playerflag = playagainst-1;
                        playerflag++;
                        if (playerflag >= NumberofPlayers)
                            playerflag = 0;
                    }

                } while (choice == "P");

                keeporgive = PlayerList[playagainst - 1].CardChoice(choice, cardagainst, liecard);

                //Call receivecard method for specific player
                if (keeporgive) //is true
                    cardsinhand = PlayerList[playerflag].ReceiveCard(cardagainst);
                else
                    cardsinhand = PlayerList[playagainst - 1].ReceiveCard(cardagainst);

                //chech if any player has 4 of any cards, set exitflag=1;
                if (cardsinhand == 4)
                    exitflag = 1;

                //Go to next player
                playerflag++;
                if (playerflag >= NumberofPlayers)
                    playerflag = 0;
            }

            //Prints out all player cards to that you can see why you lost
            foreach (Player p in PlayerList)
                p.PrintCards();

            Console.WriteLine(PlayerList[playerflag].Name + " loses!  Good Try!");
            Console.ReadLine();
            #endregion
        }
    }
}
