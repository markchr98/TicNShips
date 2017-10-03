using System;

namespace spil
{
    public class TicTacToeMenu
    {
        TicTacToe ticTacToe { get; set; }
        bool player1;
        bool currentgame = false;
        bool variation;

        int brickcount;
        public void Show()
        {
            bool running = true;            
            string choice = "";

            do
            {
                ShowMenu();
                choice = GetUserChoise();
                switch (choice)
                {
                    case "1": DoActionFor1(); break;

                    case "2":
                        if (currentgame)
                        {
                            if (variation)
                            {
                                if(player1)
                                {
                                    if (brickcount > 2)
                                    {
                                        Console.WriteLine("You have reached the max of placeable bricks");
                                        Console.WriteLine("You must now move a brick instead");
                                        Console.WriteLine("Press enter to continue");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        DoActionFor2();
                                    }
                                }
                                else if (brickcount > 3)
                                {
                                    Console.WriteLine("You have reached the max of placeable bricks");
                                    Console.WriteLine("You must now move a brick instead");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    DoActionFor2();
                                }
                            }
                            else
                            {
                                DoActionFor2();
                            }
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid option.");
                            Console.WriteLine("The game is over or has not yet started.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                        }
                        break;

                    case "3":
                        if (currentgame)
                        {
                            if (variation)
                            {
                                if (player1)
                                {
                                    if (brickcount > 2)
                                    {
                                        DoActionFor3();
                                    }
                                    else
                                    {
                                        Console.WriteLine("You must place 3 bricks before moving");
                                        Console.WriteLine("Press enter to continue");
                                        Console.ReadLine();
                                    }
                                }
                                else if (brickcount > 3)
                                {
                                    DoActionFor3();
                                }
                                else
                                {
                                    Console.WriteLine("You must place 3 bricks before moving");
                                    Console.WriteLine("Press enter to continue");
                                    Console.ReadLine();
                                }

                            }
                            else
                            {
                                Console.WriteLine("That is not a valid option.");
                                Console.WriteLine("You're playing standard");
                                Console.WriteLine("Press enter to continue");
                                Console.ReadLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("That is not a valid option.");
                            Console.WriteLine("The game is over or has not yet started.");
                            Console.WriteLine("Press enter to continue");
                            Console.ReadLine();
                        }
                        break;

                    case "0": running = false; break;

                    default : ShowMenuSelectionError(); break;
                }

                if (currentgame)
                {
                    if (ticTacToe.Validate() != ' ')
                    {
                        currentgame = false;
                        Console.Clear();
                        Console.WriteLine(ticTacToe.GetGameBoardView());
                        Console.WriteLine("The winner is: " + ticTacToe.Validate());
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }
            } while (running);
        }

        private void ShowMenu()
        {
            Console.Clear();
            if (ticTacToe != null)
            {
                Console.WriteLine(ticTacToe.GetGameBoardView());
            }
            Console.WriteLine("----------------------");
            Console.WriteLine();
            Console.WriteLine("tic tac toe");
            Console.WriteLine();
            Console.WriteLine("1. Start a new game");            
            Console.WriteLine("2. Place a brick");
            Console.WriteLine("3. Move a brick");            
            Console.WriteLine();
            Console.WriteLine("0. exit");
            Console.WriteLine();
            Console.WriteLine("----------------------");
        }

        private string GetUserChoise()
        {
            Console.WriteLine();
            Console.Write("Pick your choice: ");
            return Console.ReadLine();
        }

        private void ShowMenuSelectionError()
        {           
            Console.WriteLine("Invalid choice.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        private void DoActionFor1()
        {
            Console.Clear();            
            Console.WriteLine("Which gamemode would you like to play?");
            Console.WriteLine();
            Console.WriteLine("Type 1 For standard");
            Console.WriteLine("Type 2 For Variation, with a max of 3 bricks");
            Console.WriteLine();

            switch (Console.ReadLine())
            {
                case "1":
                    ticTacToe = new TicTacToe();
                    currentgame = true;
                    player1 = true;
                    variation = false;
                    Console.WriteLine("You chose standard");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;

                case "2":
                    ticTacToe = new TicTacToe();
                    currentgame = true;
                    player1 = true;
                    variation = true;
                    brickcount = 0;
                    Console.WriteLine("You chose variation");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                    break;

                default:
                    ShowMenuSelectionError();
                    break;
            }
        }
        private void DoActionFor2()
        {
            //placering a brik            
            bool Turn = true;
            int x, y;
            string input;

            while (Turn)
            {
                if (player1)
                {
                    Console.WriteLine("Player 1's turn");
                }
                else
                {
                    Console.WriteLine("Player 2's turn");
                }
                
                Console.WriteLine("Choose Row (y)");
                switch (input=Console.ReadLine())
                {
                    case "1":
                        y = Convert.ToInt32(input);
                        break;
                    case "2":
                        y = Convert.ToInt32(input);
                        break;
                    case "3":
                        y = Convert.ToInt32(input);
                        break;
                    default:
                        y = 4;
                        break;                            
                }
                Console.WriteLine("Choose Coloumn (x)");
                switch (input = Console.ReadLine())
                {
                    case "1":
                        x = Convert.ToInt32(input);
                        break;
                    case "2":
                        x = Convert.ToInt32(input);
                        break;
                    case "3":
                        x = Convert.ToInt32(input);
                        break;
                    default:
                        x = 4;                        
                        break;
                }               

                if (y < 4 && x < 4 && ticTacToe.GameBoard[x - 1, y - 1] == ' ')
                {
                    if (player1)
                    {
                        ticTacToe.GameBoard[x - 1, y - 1] = 'X';
                        Turn = false;
                        player1 = false;
                        brickcount = brickcount + 1;
                    }
                    else
                    {
                        ticTacToe.GameBoard[x - 1, y - 1] = 'O';
                        Turn = false;
                        player1 = true;
                    }
                }
                else
                {
                    Console.WriteLine("Value out of range or position was already taken");
                }
            }
            Console.Clear();
            Console.WriteLine(ticTacToe.GetGameBoardView());
            Console.WriteLine("Your turn is over");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            
        }
        private void DoActionFor3()
        {
            bool Turn = true;
            int x1, y1 , x2 , y2;
            string input;
            bool Validmove;

            while (Turn)
            {
                Console.Clear();
                Console.WriteLine(ticTacToe.GetGameBoardView());

                if (player1)
                {
                    Console.WriteLine("Player 1's turn");
                }
                else
                {
                    Console.WriteLine("Player 2's turn");
                }

                Console.WriteLine("Choose Row (y) of brick to move");
                switch (input = Console.ReadLine())
                {
                    case "1":
                        y1 = Convert.ToInt32(input);
                        break;
                    case "2":
                        y1 = Convert.ToInt32(input);
                        break;
                    case "3":
                        y1 = Convert.ToInt32(input);
                        break;
                    default:
                        y1 = 4;
                        break;
                }
                Console.WriteLine("Choose Coloumn (x) of brick to move");
                switch (input = Console.ReadLine())
                {
                    case "1":
                        x1 = Convert.ToInt32(input);
                        break;
                    case "2":
                        x1 = Convert.ToInt32(input);
                        break;
                    case "3":
                        x1 = Convert.ToInt32(input);
                        break;
                    default:
                        x1 = 4;
                        break;
                }
                if (y1 < 4 && x1 < 4 && ticTacToe.GameBoard[x1 - 1, y1 - 1] != ' ')
                {
                    if (player1&&ticTacToe.GameBoard[x1 - 1, y1 - 1]=='X')
                    {
                        Validmove = true;
                    }
                    else if(!player1&&ticTacToe.GameBoard[x1 -1, y1 - 1] == 'O')
                    {
                        Validmove = true;
                    }
                    else
                    {
                        Validmove = false;
                        Console.WriteLine("That is not your brick");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Validmove = false;
                    Console.WriteLine("Value out of range or position was empty");
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();                    
                }               

                if (Validmove)
                {
                    Console.WriteLine("Choose Row (y) to move brick to");
                    switch (input = Console.ReadLine())
                    {
                        case "1":
                            y2 = Convert.ToInt32(input);
                            break;
                        case "2":
                            y2 = Convert.ToInt32(input);
                            break;
                        case "3":
                            y2 = Convert.ToInt32(input);
                            break;
                        default:
                            y2 = 4;
                            break;
                    }
                    Console.WriteLine("Choose Coloumn (x) to move brick to");
                    switch (input = Console.ReadLine())
                    {
                        case "1":
                            x2 = Convert.ToInt32(input);
                            break;
                        case "2":
                            x2 = Convert.ToInt32(input);
                            break;
                        case "3":
                            x2 = Convert.ToInt32(input);
                            break;
                        default:
                            x2 = 4;
                            break;
                    }
                    if (y2 < 4 && x2 < 4 && ticTacToe.GameBoard[x2 - 1, y2 - 1] == ' ')
                    {
                        ticTacToe.GameBoard[x1 - 1, y1 - 1] =' ';
                        if (player1)
                        {
                            ticTacToe.GameBoard[x2 - 1, y2 - 1] = 'X';
                            Turn = false;
                            player1 = false;
                            ++brickcount;
                        }
                        else
                        {
                            ticTacToe.GameBoard[x2 - 1, y2 - 1] = 'O';
                            Turn = false;
                            player1 = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Value out of range or position was already taken");
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                    }
                }               
            }
            Console.Clear();
            Console.WriteLine(ticTacToe.GetGameBoardView());
            Console.WriteLine("Your turn is over");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}