using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleshipsMenu
    {        
        BattleBoard Gameboard1;
        BattleBoard Gameboard2;
        BattleBoard Gameboardshoot1;
        BattleBoard Gameboardshoot2;
        public bool player1;
        public bool shooting;
        public bool startednewgame;
        internal void Show()
        {
            string input = "";
            bool Running=true;
            while (Running)
            {

                Menu();

                input = Console.ReadLine();
                if (startednewgame != true)
                {
                    switch (input)
                    {
                        case "1": StartNew(); break;

                        //case "2": PlaceShips(); break;

                        case "0": Battleships = false; break;

                        default: ShowMenuSelectionError(); break;
                    }
                }
                else if (startednewgame == true) {
                    switch (input)
                    {
                        case "1": StartNew(); break;

                        case "2": PlaceShips(); break;

                        case "0": Battleships = false; break;

                        default: ShowMenuSelectionError(); break;
                    }
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
            if(startednewgame == true)
            {
                Console.WriteLine("---------[ MENU ]---------");
                Console.WriteLine();
                Console.WriteLine("Type 1 to start a new game");
                Console.WriteLine("Type 2 to palce ships");
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
            Gameboard1 = new BattleBoard();
            Gameboard2 = new BattleBoard();
            Gameboardshoot1 = new BattleBoard();
            Gameboardshoot2 = new BattleBoard();
            
        }

        internal void PlaceShips() {
            Console.WriteLine("You placed a ship");
            Console.ReadLine();
        }

        private void ShowMenuSelectionError()
        {
            
            Console.WriteLine("Invalid choice.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
