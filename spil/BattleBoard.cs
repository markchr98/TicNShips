using System;

namespace spil
{
    internal class BattleBoard
    {
        BattleShip carrier = new BattleShip(Type.Carrier, 1, '■', 5);
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

            int CarrierQuantity =  carrier.Quantity;
            int SubmarineQuantity = submarine.Quantity;
            int BattleshipQuantity = battleship.Quantity;
            int PatrolboatQuantity = patrolboat.Quantity;
            int DestroyerQuantity = destroyer.Quantity;

            string input = "";
            bool running = true;
            while (running)
            {
                Console.Clear();
                GetGameboardView();
                Console.WriteLine("Choose 1 for aircraftcarrier:" + CarrierQuantity + " Left");
                Console.WriteLine("Choose 2 for battleship: " + BattleshipQuantity + " Left");
                Console.WriteLine("Choose 3 for destroyer: " + DestroyerQuantity + " Left");
                Console.WriteLine("Choose 4 for patrolboat: " + PatrolboatQuantity + " Left");
                Console.WriteLine("Choose 5 for submarine: " + SubmarineQuantity + " Left");

                switch (input = Console.ReadLine())
                {

                    case "1":
                        if (CarrierQuantity != 0) { current = carrier; CarrierQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case "2":
                        if (BattleshipQuantity != 0) { current = battleship; BattleshipQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case "3":
                        if (DestroyerQuantity != 0) { current = destroyer; DestroyerQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case "4":
                        if (PatrolboatQuantity != 0) { current = patrolboat; PatrolboatQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    case "5":
                        if (SubmarineQuantity != 0) { current = submarine; SubmarineQuantity -= 1; }
                        else { current = notvalid; }
                        break;

                    default: current = notvalid; break;
                }


                if (current != notvalid)
                {
                    bool coordinate = true;
                    while (coordinate) {
                        Console.WriteLine("Choose v for Vertical or h for horizontal");
                        switch (input = Console.ReadLine())
                        {

                            case "h":
                                bool horizontal = true;
                                while (horizontal)
                                {
                                    Console.WriteLine("x between " + 0 + " & " + (10 - current.Length) + " & y between A & J");
                                    Console.WriteLine("Choose x coordinate");
                                    x = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Choose y coordinate");
                                    y = (int)Console.ReadLine().ToUpper()[0] - 65;
                                    if (x <= 10 - current.Length && x > -1 && y <= 10 && y > -1)
                                    {
                                        for (int i = 0; i < current.Length; i++)
                                        {
                                            GameBoard[y, x + i] = current.Symbol;
                                        }
                                        horizontal = false;
                                        coordinate = false;
                                    }
                                    else { Console.WriteLine("Out of Bounds"); }
                                }
                                break;


                            case "v":
                                bool vertical = true;
                                while (vertical)
                                {
                                    Console.WriteLine("x between " + 0 + " & " + 9 + " & y between A " + "& " + ((char)(75 - current.Length)).ToString());
                                    Console.WriteLine("Choose x coordinate");
                                    x = Convert.ToInt32(Console.ReadLine());
                                    Console.WriteLine("Choose y coordinate");
                                    y = (int)Console.ReadLine().ToUpper()[0] - 65;
                                    if (y <= 10 - current.Length && y > -1 && x <= 10 && x > -1)
                                    {
                                        for (int i = 0; i < current.Length; i++)
                                        {
                                            GameBoard[y + i, x] = current.Symbol;
                                        }
                                        vertical = false;
                                        coordinate = false;
                                    }
                                    else { Console.WriteLine("Out of bounds"); }
                                }
                                break;

                            default:
                                Console.WriteLine("Option not valid");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Option not valid");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }

                if (BattleshipQuantity == 0 && CarrierQuantity == 0 && DestroyerQuantity == 0 && PatrolboatQuantity == 0 && SubmarineQuantity == 0)
                {
                    running = false;
                    Console.Clear();
                    GetGameboardView();
                    Console.WriteLine("You have placed all of you ships");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }
        }
        public void Shoot(BattleBoard Enemy)
        {             
            bool running = true;
            
            while (running) {

                Console.Clear();
                GetGameboardView();

                Console.WriteLine("choose x coordinate");
                int x = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("choose y coordinate");
                int y = Convert.ToInt32((char)Console.ReadLine()[0]) - 65;

                if (x < 10 && x > -1 && y < 10 && y > -1 && GameBoard[y, x] =='•' && GameBoard[y, x]=='○')
                {

                    //if(hvis et skib er sunket) {Console.WriteLine("Sunk!");}
                    
                    /*else*/if (Enemy.GameBoard[y, x] != ' ')
                    {
                        GameBoard[y, x] = '•';
                        Console.WriteLine("HIT!");
                        running = false;
                    }
                    else
                    {
                        GameBoard[y, x] = '○';
                        Console.WriteLine("SPLASH!");
                        running = false;
                    }
                }
                else
                {
                    Console.WriteLine("That is not a valid position");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
            }


        }

    }

}
