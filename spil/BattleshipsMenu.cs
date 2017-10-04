﻿using System;
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
        bool player1;
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
                        break;
                }
            }
        }

        internal void Menu()
        {
            Console.Clear();
            Console.WriteLine("-----[ BATTLE SHIPS ]-----");
            Console.WriteLine();
            if (battleships != null)
            {
                Console.WriteLine(battleships.GetGameboardView());
                Console.WriteLine();
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
            Gameboard1 = new Battleships();
            Gameboard2 = new Battleships();
        }
    }
}
