using System;

namespace spil
{
    internal class BattleBoard
    {
        BattleShip aircraftcarrier = new BattleShip(Type.Aircraftcarrier, 1, '■', 5);
        BattleShip destroyer = new BattleShip(Type.Destroyer, 2, '⌂', 3);
        BattleShip submarine = new BattleShip(Type.Submarine, 1, '◙', 3);
        BattleShip patrolboat = new BattleShip(Type.Patrolboat, 3, '▼', 2);
        BattleShip battleship = new BattleShip(Type.Battleship, 2, '♥', 4);
        BattleShip notvalid = new BattleShip(Type.Battleship, 0, ' ', 0);
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
        internal void PlaceShips()
        {

            
            BattleShip current;
            int x = 0;
            int y = 0;
            string input = "";
            bool running = true;
            while (running)
            {
                Console.WriteLine("Choose 1 for aircraftcarrier");
                Console.WriteLine("Choose 2 for battleship");
                Console.WriteLine("Choose 3 for destroyer");
                Console.WriteLine("Choose 4 for patrolboat");
                Console.WriteLine("Choose 5 for submarine");
                switch (input = Console.ReadLine())
                {

                    case "1": current = aircraftcarrier; running = false; break;

                    case "2": current = battleship; running = false; break;

                    case "3": current = destroyer; running = false; break;

                    case "4": current = patrolboat; running = false; break;

                    case "5": current = submarine; running = false; break;

                    default: current = notvalid; break;
                }

                if (current != notvalid)
                {
                    Console.WriteLine("Choose v for Vertical or h for horizontal");
                    switch (input = Console.ReadLine())
                    {

                        case "h":

                            Console.WriteLine("Choose x coordinate");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Choose y coordinate");
                            y = (int)Console.ReadLine().ToUpper()[0] - 65;

                            for (int i = 0; i < current.Length; i++)
                            {
                                GameBoard[y, x + i] = current.Symbol;
                            }
                            break;

                        case "v":
                            Console.WriteLine("Choose x coordinate");
                            x = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Choose y coordinate");
                            y = (int)Console.ReadLine().ToUpper()[0]-65;

                            for (int i = 0; i < current.Length; i++)
                            {
                                GameBoard[y + i, x] = current.Symbol;
                            }
                            break;

                        default: break;
                    }
                }
                else { Console.WriteLine("Option not valid"); }
            }
        }

    }

}
