using System;

namespace spil
{
    internal class Battleships
    {
        public char[,] GameBoard { get; set; }
        public Battleships()
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
       
    }
}