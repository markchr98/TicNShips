using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleshipsMenu
    {        
        Battleships Gameboard1;
        Battleships Gameboard2;
        Battleships Gameboardshoot1;
        Battleships Gameboardshoot2;
        public bool player1;
        public bool shooting;
        internal void Show()
        {
            string input = "";
            bool Battleships=true;
            while (Battleships)
            {
                Menu();                

                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        StartNew();
                        break;
                    case "0":
                        Battleships = false;
                        break;
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
                        shooting = true;
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
            Console.WriteLine("---------[ MENU ]---------");
            Console.WriteLine();
            Console.WriteLine("Type 1 to start a new game");
            Console.WriteLine("Type 0 to quit");
            Console.WriteLine();
            Console.WriteLine("--------------------------");
        }

        internal void StartNew()
        {
            player1 = true;
            shooting = false;
            Gameboard1 = new Battleships();
            Gameboard2 = new Battleships();
            Gameboardshoot1 = new Battleships();
            Gameboardshoot2 = new Battleships();
        }
        private void ShowMenuSelectionError()
        {
            Console.WriteLine("Invalid choice.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
