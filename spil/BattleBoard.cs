﻿using System;
using System.Threading;

namespace spil
{
    public class BattleBoard
    {
        int counter = 1;
        BattleshipsMenu battleshipsMenu = new BattleshipsMenu();
        BattleShip carrier = new BattleShip(Type.Carrier, 5);
        BattleShip destroyer = new BattleShip(Type.Destroyer, 3);
        BattleShip submarine = new BattleShip(Type.Submarine, 3);
        BattleShip patrolboat = new BattleShip(Type.Patrolboat, 2);
        BattleShip battleship = new BattleShip(Type.Battleship, 4);
        BattleShip notvalid = new BattleShip(Type.Battleship, 0);
        public char[,] GameBoard { get; set; }
        public BattleBoard()
        {
            GameBoard = new char[10, 10]
            {
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '},
                {' ', ' ', ' ',' ',' ',' ',' ',' ',' ',' '}
            };
        }
        internal string GetGameboardView()
        {
            char[,] gameboard = GameBoard;

            //Variables
            string Output = "";
            int LineLength = 0;
            int UniCounter = 65;
            string v = "";

            //Loop for Printing of array
            for (int j = 0; j < 10; j++)
            {
                int OGLength = Output.Length;
                Output += " " + (char)UniCounter + " ";

                for (int i = 0; i < 10; i++)
                {
                    Output += "| " + gameboard[j, i] + " ";
                }
                Output += "|";

                LineLength = Output.Length - OGLength;

                Output += "\n";

                for (int i = LineLength; i > 0; i--)
                {
                    Output += '-';
                }
                Output += "\n";
                UniCounter++;
            }

            //Loop for printing numbers
            Output += "  ";
            for (int i = 0; i < 10; i++)
            {
                for (int j = LineLength / 12; j > 0; j--)
                {
                    Output += " ";
                }
                Output += i;
            }

            //Print initial border
            for (int i = LineLength; i > 0; i--)
            {
                v += "-";
            }
            v += "\n";

            return v + Output;
        }
        internal void ChooseShip()
        {
            BattleShip current;

            int CarrierQuantity = 1;
            int SubmarineQuantity = 1;
            int BattleshipQuantity = 2;
            int PatrolboatQuantity = 3;
            int DestroyerQuantity = 2;

            //int CarrierQuantity = 0;
            //int SubmarineQuantity = 0;
            //int BattleshipQuantity = 0;
            //int PatrolboatQuantity = 1;
            //int DestroyerQuantity = 0;

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine(getplayerview());
                Console.WriteLine();
                Console.WriteLine("Choose 1 for Carrier. You have " + CarrierQuantity + " remaining.");
                Console.WriteLine("Choose 2 for Battleship. You have  " + BattleshipQuantity + " remaining.");
                Console.WriteLine("Choose 3 for Destroyer. You have " + DestroyerQuantity + " remaining.");
                Console.WriteLine("Choose 4 for Patrolboat. You have " + PatrolboatQuantity + " remaining.");
                Console.WriteLine("Choose 5 for Submarine. You have " + SubmarineQuantity + " remaining.");
                Console.WriteLine();
                Console.WriteLine("Please pick an option.");

                var input = Console.ReadKey(false).Key;

                switch (input)
                {
                    case ConsoleKey.D1:
                        if (CarrierQuantity != 0) { current = carrier; CarrierQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case ConsoleKey.D2:
                        if (BattleshipQuantity != 0) { current = battleship; BattleshipQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case ConsoleKey.D3:
                        if (DestroyerQuantity != 0) { current = destroyer; DestroyerQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case ConsoleKey.D4:
                        if (PatrolboatQuantity != 0) { current = patrolboat; PatrolboatQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case ConsoleKey.D5:
                        if (SubmarineQuantity != 0) { current = submarine; SubmarineQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    default: current = notvalid; break;
                }


                if (current != notvalid) // If ship choice is valid, do the following:
                {
                    // Show gameboard and menu
                    Console.Clear();
                    Console.WriteLine(getplayerview());
                    Console.WriteLine();
                    Console.WriteLine("Use arrows to move ship.");
                    Console.WriteLine("Press R to rotate ship.");
                    Console.WriteLine("Press ENTER to place ship.");

                    // Call the function for placing ships
                    bool placeMode = true;
                    placeShips(placeMode, current);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Option not valid.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }

                if (BattleshipQuantity == 0 && CarrierQuantity == 0 && DestroyerQuantity == 0 && PatrolboatQuantity == 0 && SubmarineQuantity == 0)
                {
                    running = false;
                    Console.Clear();
                    getplayerview();
                    Console.WriteLine();
                    Console.WriteLine("You have placed all of you ships.");
                    Console.WriteLine("Press enter to continue.");
                    Console.ReadLine();
                }
            }
        }

        private void placeShips(bool placeMode, BattleShip current) // Function which handles placement of ships
        {            
            BattleBoard Dummy = new BattleBoard();
            int y = 0, x = 0;
            bool vertical = true;
            while (placeMode)
            {
                Dummy.GameBoard = GameBoard.Clone() as char[,];

                for (int i = 0; i < current.Length; i++)
                {
                    if (vertical)
                    {
                        Dummy.GameBoard[y + i, x] = Convert.ToChar(counter + 48);
                    }
                    else
                    {
                        Dummy.GameBoard[y, x + i] = Convert.ToChar(counter + 48);
                    }
                }
                Console.Clear();
                Console.WriteLine(Dummy.getplayerview());
                Console.WriteLine();
                Console.WriteLine("Use arrows to move ship.");
                Console.WriteLine("Press R to rotate ship.");
                Console.WriteLine("Press ENTER to place ship.");

                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.R:
                        vertical = !vertical; // Switch between true and false
                        y = 0;
                        x = 0;
                        break;
                    case ConsoleKey.UpArrow:
                        if (y > 0)
                        {
                            y -= 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (vertical)
                        {
                            if (y < 10 - current.Length)
                            {
                                y += 1;
                            }
                        }
                        else
                        {
                            if (y < 9)
                            {
                                y += 1;
                            }
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x -= 1;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (vertical)
                        {
                            if (x < 9)
                            {
                                x += 1;
                            }
                        }
                        else
                        {
                            if (x < 10 - current.Length)
                            {
                                x += 1;
                            }
                        }
                        break;
                    case ConsoleKey.Enter:

                        bool valid = false;

                        for (int i = 0; i < current.Length; i++)
                        {
                            if (vertical)
                            {
                                if (GameBoard[y + i, x] == ' ')
                                {
                                    valid = true;
                                }
                                else
                                {
                                    valid = false;
                                    break;
                                }
                            }
                            else
                            {
                                if (GameBoard[y, x + i] == ' ')
                                {
                                    valid = true;
                                }
                                else
                                {
                                    valid = false;
                                    break;
                                }

                            }
                        }
                        if (valid)
                        {
                            for (int i = 0; i < current.Length; i++)
                            {
                                if (vertical)
                                {
                                    GameBoard[y + i, x] = Convert.ToChar(counter + 48);
                                }
                                else
                                {
                                    GameBoard[y, x + i] = Convert.ToChar(counter + 48);
                                }
                            }
                            counter++;
                            placeMode = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine();
                            Console.WriteLine("Placement not valid.");
                            Thread.Sleep(2000);
                        }
                        //Console.WriteLine(y.ToString() +", "+ x.ToString());
                        break;
                }
            }
        }
        public void Shoot(BattleBoard Enemy)
        {
            bool running = true;
            int y = 0;
            int x = 0;
            BattleBoard Dummy = new BattleBoard();

            while (running)
            {
                Dummy.GameBoard = GameBoard.Clone() as char[,];
                Dummy.GameBoard[y, x] = '+';

                Console.Clear();
                Console.WriteLine(Dummy.getplayerview());
                Console.WriteLine();
                Console.WriteLine("Use arrows to move marker.");
                Console.WriteLine("Use Enter to shoot at current position.");

                var ch = Console.ReadKey(false).Key;

                switch (ch)
                {
                    case ConsoleKey.UpArrow:
                        if (y > 0)
                        {
                            y -= 1;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (y < 9)
                        {
                            y += 1;
                        }
                        break;

                    case ConsoleKey.LeftArrow:
                        if (x > 0)
                        {
                            x -= 1;
                        }
                        break;

                    case ConsoleKey.RightArrow:
                        if (x < 9)
                        {
                            x += 1;
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (x < 10 && x > -1 && y < 10 && y > -1 && GameBoard[y, x] != 'X' && GameBoard[y, x] != 'O')
                        {
                            int counter = 0;
                            foreach (char c in Enemy.GameBoard)
                            {
                                if (c == Enemy.GameBoard[y, x])
                                {
                                    counter++;
                                }
                            }
                            if (Enemy.GameBoard[y, x] != ' ')
                            {
                                GameBoard[y, x] = 'X';
                                Enemy.GameBoard[y, x] = 'X';
                                if (counter <= 1)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine(getplayerview());
                                    Console.Beep(600, 150);
                                    Console.Beep(1000, 150);
                                    Console.WriteLine("SUNK!");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(getplayerview());
                                    Console.Beep(750, 300);
                                    Console.WriteLine("HIT!");
                                    Console.ResetColor();
                                }
                                running = false;
                            }
                            else
                            {
                                GameBoard[y, x] = 'O';
                                Enemy.GameBoard[y, x] = 'O';
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine(getplayerview());
                                Console.Beep(300, 300);
                                Console.WriteLine("SPLASH!");
                                Console.ResetColor();
                                running = false;
                            }
                            Thread.Sleep(2000);
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("That is not a valid position.");
                            Console.WriteLine("Press enter to continue.");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public bool winner()
        {
            int counter = 0;
            foreach (char c in GameBoard)
            {
                if (c != ' ' && c != 'X' && c != 'O')
                {
                    counter++;
                }
            }
            if (counter == 0)
                return true;

            else return false;

        }
        public string getplayerview()
        {
            string output = "";
            if (!BattleshipsMenu.shooting)
            {
                if (BattleshipsMenu.player1)
                {
                    output = "\n------[ BATTLE SHIPS ]------" + "\n\n" + "-----[ PLAYER 1 SHIPS ]-----\n\n" + GetGameboardView();
                }
                if (!BattleshipsMenu.player1)
                {
                    output = "\n------[ BATTLE SHIPS ]------" + "\n\n" + "-----[ PLAYER 2 SHIPS ]-----\n\n" + GetGameboardView();
                }
            }
            else
            {

                if (BattleshipsMenu.player1)
                {
                    output = "\n------[ BATTLE SHIPS ]------" + "\n\n" + "-----[ PLAYER 1 HITS ]-----\n\n" + GetGameboardView();
                }
                if (!BattleshipsMenu.player1)
                {
                    output = "\n------[ BATTLE SHIPS ]------" + "\n\n" + "-----[ PLAYER 2 HITS ]-----\n\n" + GetGameboardView();
                }
            }
            return output;
        }
    }
}
