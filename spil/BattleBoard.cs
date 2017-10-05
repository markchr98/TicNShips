using System;

namespace spil
{
    internal class BattleBoard
    {
        BattleShip aircraftcarrier = new BattleShip(Type.Aircraftcarrier, 1, 5);
        BattleShip destroyer = new BattleShip(Type.Destroyer, 2, 3);
        BattleShip submarine = new BattleShip(Type.Submarine, 1, 3);
        BattleShip patrolboat = new BattleShip(Type.Patrolboat, 3, 2);
        BattleShip battleship = new BattleShip(Type.Battleship, 2, 4);
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
            string Output="";
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

                for (int i=LineLength; i>0; i--)
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
            
            switch (input = Console.ReadLine()) {

                case "1": current = aircraftcarrier; break;

                case "2": current = battleship; break;

                case "3": current = destroyer; break;

                case "4": current = patrolboat; break;

                case "5":current = submarine; break;

                default: current = submarine; break;
            }

            switch (input = Console.ReadLine())
            {

                case "v":
                    switch (current.Type)
                    {

                        case Type.Aircraftcarrier: for () { GameBoard[y, x] = '■'; }; break;

                        case Type.Battleship: break;

                        case Type.Destroyer: break;

                        case Type.Patrolboat: break;

                        case Type.Submarine: break;

                        default: break;
                    }
                    break;

                case "h": break;
                  
                default: break;
            }
            
        }

    }
}