using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace spil
{
    class BattleshipsMenu
    {
        
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
                        break;
                    case "0":
                        break;
                }
            }
        }

        internal void Menu()
        {
            Console.WriteLine("Type 1 to start a new game");
            Console.WriteLine("Type 0 to quit");

        }
    }
}
