using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace spil
{
    public class BattleshipsMenu
    {
        BattleBoard Gameboard1;
        BattleBoard Gameboard2;
        BattleBoard Gameboardshoot1;
        BattleBoard Gameboardshoot2;

        public bool player1;
        public bool shooting;
        public bool startednewgame;
        public bool placedships;
        internal void Show()
        {
            string input = "";

            bool Running = true;
            while (Running)
            {

                Menu();

                input = Console.ReadLine();
                switch (input)
                {
                    case "1": StartNew(); break;


                    case "2":
                        if (startednewgame)
                        {
                            if (!placedships)
                            {
                                Gameboard1.ChooseShip();
                                Gameboard2.ChooseShip();
                                placedships = true;
                                shooting = true;
                            }
                            else
                            {
                                Console.WriteLine("Both players have already placed their ships");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            ShowMenuSelectionError();
                        }
                        break;
                    case "3":
                        if (startednewgame)
                        {
                            if (placedships)
                            {
                                if (player1) { Gameboardshoot1.Shoot(Gameboard2); player1 = false; }
                                else { Gameboardshoot2.Shoot(Gameboard1); player1 = true; }
                            }
                            else
                            {
                                Console.WriteLine("You have not yet placed your ships");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }
                            if (Gameboard1.winner())
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("PLAYER 1 IS THE WINNER!");
                                Thread.Sleep(2000);
                                startednewgame = false;
                            }
                            if (Gameboard2.winner())
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.WriteLine("PLAYER 2 IS THE WINNER!");
                                Thread.Sleep(2000);
                                startednewgame = false;
                            }
                        }
                        else
                        {
                            ShowMenuSelectionError();
                        }
                        break;

                    case "0": Running = false; break;

                    default: ShowMenuSelectionError(); break;
                }
            }
        }

        internal void Menu()
        {

            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("-----[ BATTLE SHIPS ]-----");
            Console.WriteLine();
            if (Gameboard1 != null && Gameboard2 != null)
            {
                if (player1)
                {
                    if (!shooting)
                    {
                        Console.WriteLine("-----[ PLAYER 1 SHIPS ]-----");
                        Console.WriteLine(Gameboard1.GetGameboardView());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("-----[ PLAYER 1 HITS ]-----");
                        Console.WriteLine(Gameboardshoot1.GetGameboardView());
                        Console.ReadLine();
                        Console.WriteLine("-----[ PLAYER 1 SHIPS ]-----");
                        Console.WriteLine(Gameboard1.GetGameboardView());
                    }
                }
                else
                {
                    if (!shooting)
                    {
                        
                        Console.WriteLine("-----[ PLAYER 2 SHIPS ]-----");
                        Console.WriteLine(Gameboard2.GetGameboardView());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("-----[ PLAYER 2 HITS ]-----");
                        Console.WriteLine(Gameboardshoot2.GetGameboardView());
                        Console.ReadLine();
                        Console.WriteLine("-----[ PLAYER 2 SHIPS ]-----");
                        Console.WriteLine(Gameboard2.GetGameboardView());
                    }
                }
            }

            if (startednewgame)
            {
                Console.WriteLine("---------[ MENU ]---------");
                Console.WriteLine();
                Console.WriteLine("Type 1 to start a new game");
                Console.WriteLine("Type 2 to place ships");
                Console.WriteLine("Type 3 to shoot at your enemy's ships");
                Console.WriteLine("Type 0 to quit");
                Console.WriteLine();
                Console.WriteLine("--------------------------");
            }
            else
            {
                Console.WriteLine("---------[ MENU ]---------");
                Console.WriteLine();
                Console.WriteLine("Type 1 to start a new game");
                Console.WriteLine("Type 0 to quit");
                Console.WriteLine();
                Console.WriteLine("--------------------------");
            }

        }

        internal void StartNew()
        {
            player1 = true;
            shooting = false;
            startednewgame = true;
            placedships = false;
            Gameboard1 = new BattleBoard();
            Gameboard2 = new BattleBoard();
            Gameboardshoot1 = new BattleBoard();
            Gameboardshoot2 = new BattleBoard();

        }


        public void ShowMenuSelectionError()
        {
            Console.WriteLine("Invalid choice.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
