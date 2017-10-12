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

        public static bool player1 = true;
        public static bool shooting;
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
                                player1 = false;
                                Gameboard2.ChooseShip();
                                player1 = true;
                                placedships = true;
                                shooting = true;
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("Both players have already placed their ships.");
                                Console.WriteLine("Press enter to continue.");
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
                                if (player1)
                                {
                                    Gameboardshoot1.Shoot(Gameboard2);
                                    if (Gameboard1.winner())
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("PLAYER 1 IS THE WINNER!");
                                        Thread.Sleep(2000);
                                        startednewgame = false;
                                    }
                                    player1 = false;
                                }
                                else
                                {
                                    Gameboardshoot2.Shoot(Gameboard1);
                                    if (Gameboard2.winner())
                                    {
                                        Console.Clear();
                                        Console.WriteLine();
                                        Console.WriteLine("PLAYER 2 IS THE WINNER!");
                                        Thread.Sleep(2000);
                                        startednewgame = false;
                                    }
                                    player1 = true; }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.WriteLine("You still have ships to place!");
                                Console.WriteLine("Press enter to continue.");
                                Console.ReadLine();
                                break;
                            }
                            if (Gameboard1.winner())
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("PLAYER 1 IS THE LOSER!");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("PLAYER 2 IS THE WINNER!");
                                //song
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                Console.Beep(587, 320);
                                Console.Beep(523, 160);
                                Console.Beep(523, 320);
                                Console.Beep(392, 320);
                                //tact3
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                //tact 4
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                //tact 5
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 640);
                                //tact 6
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact7
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);//tact 8
                                Console.Beep(587, 320);
                                Console.Beep(523, 160);
                                Console.Beep(523, 320);
                                Console.Beep(392, 320);
                                //tact9
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact10
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact11
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                //tact12
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                //tact13
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                //tact14
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                //tact15
                                Console.Beep(587, 20);
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                startednewgame = false;
                                
                            }

                            if (Gameboard2.winner())
                            {
                                Console.Clear();
                                Console.WriteLine();
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("PLAYER 2 IS THE LOSER!");
                                Console.ResetColor();
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("PLAYER 1 IS THE WINNER!");
                                //song
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                Console.Beep(587, 320);
                                Console.Beep(523, 160);
                                Console.Beep(523, 320);
                                Console.Beep(392, 320);
                                //tact3
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                //tact 4
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);
                                //tact 5
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 640);
                                //tact 6
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact7
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 160);//tact 8
                                Console.Beep(587, 320);
                                Console.Beep(523, 160);
                                Console.Beep(523, 320);
                                Console.Beep(392, 320);
                                //tact9
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact10
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(587, 320);
                                //tact11
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                //tact12
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(440, 320);
                                Console.Beep(523, 320);
                                //tact13
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                //tact14
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                Console.Beep(440, 160);
                                Console.Beep(523, 320);
                                //tact15
                                Console.Beep(587, 20);
                                Console.ResetColor();
                                Thread.Sleep(2000);
                                startednewgame = false;
                                player1 = false;
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
            Console.WriteLine("\n-----[ BATTLE SHIPS ]-----");
            Console.WriteLine();
            if (Gameboard1 != null && Gameboard2 != null)
            {
                if (player1)
                {
                    if (!shooting)
                    {
                        Console.WriteLine("----[ PLAYER 1 SHIPS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboard1.GetGameboardView());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("----[ PLAYER 1 HITS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboardshoot1.GetGameboardView());
                        Console.ReadLine();
                        Console.WriteLine("----[ PLAYER 1 SHIPS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboard1.GetGameboardView());
                    }
                }
                else
                {
                    if (!shooting)
                    {
                        
                        Console.WriteLine("----[ PLAYER 2 SHIPS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboard2.GetGameboardView());
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("----[ PLAYER 2 HITS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboardshoot2.GetGameboardView());
                        Console.ReadLine();
                        Console.WriteLine("----[ PLAYER 2 SHIPS ]----");
                        Console.WriteLine();
                        Console.WriteLine(Gameboard2.GetGameboardView());
                    }
                }
            }

            if (startednewgame)
            {
                Console.WriteLine("---------[ MENU ]---------");
                Console.WriteLine();
                Console.WriteLine("1. Start new game");
                Console.WriteLine("2. Place ships");
                Console.WriteLine("3. Shoot mode");
                Console.WriteLine("0. Close application");
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("Please pick an option:");
            }
            else
            {
                Console.WriteLine("---------[ MENU ]---------");
                Console.WriteLine();
                Console.WriteLine("1. Start new game");
                Console.WriteLine("0. Close application");
                Console.WriteLine();
                Console.WriteLine("--------------------------");
                Console.WriteLine();
                Console.WriteLine("Please pick an option:");
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
            Console.WriteLine("Press enter to continue.");
            Console.ReadLine();
        }
    }
}
