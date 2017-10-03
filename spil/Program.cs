using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        private void Run()
        {
            
            Console.WriteLine("Please choose what gamemode to play");
            Console.WriteLine();
            Console.WriteLine("1: TicTacToe");
            Console.WriteLine("2: Battleship");

            string input = Console.ReadLine();
            switch(input)
            {

            case "1":
                    break;
            case "2":
                    break;
            }
}

            TicTacToeMenu ticTacToeMenu = new TicTacToeMenu();
            ticTacToeMenu.Show();
        }
    }
}

