﻿//Jason N'Guessan
//Software Engineer
using System;
namespace TicTacToe
{
    class Program
    {
        static char[] board = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int player = 1;
        static int aIRequest = 0;
        static bool gameOver = false;
        static int checkBoards;


        static void Main()
        {

            Console.WriteLine("AI goes first by Default X");
            Console.WriteLine("Player 2 is by the Default O\n");
            Console.WriteLine("This is Your Current Board ");

            updateBoard();

            Console.WriteLine("\nThis is my playground, you will play by my RULES - AI\n");

            do
            {
                try
                {
                    if (player % 2 != 0)
                    {
                        Console.WriteLine("Moved Played\n");

                        if (player % 2 != 0 && checkBoards < 1)
                        {
                            board[5] = 'X';
                            checkBoards++;
                            player++;
                        }

                        else if (board[8] != 'X' && board[8] != 'O' && board[9] == 'O' )
                        {
                            board[8] = 'X';
                            checkBoards++;
                            player++;
                        }
                        //WIN CONDITION 1 - EASY
                        else if (board[2] != 'O' && board[2] != 'X' && board[6] == 'O')
                        {
                            board[2] = 'X';
                            checkBoards++;
                            player++;
                        }

                        else if (board[4] != 'O' && board[6] != 'O' && board[4] != 'X' && board[6] != 'X')
                        {
                            board[4] = 'X';
                            checkBoards++;
                            player++;
                        }


                        else if (board[4] == 'O' && board[8] == 'O' && board[5] == 'O' && board[4] != 'X'
                            && board[8] != 'X')
                        {
                            //TIE CONDITION
                            board[6] = 'X';
                            checkBoards++;
                            player++;
                        }

                        else
                        {
                            Random rnd = new Random();
                            int input = rnd.Next(1, 10);
                            if (board[1] == 'O' && board[2] == 'O' && board[3] != 'X')
                            {
                                board[3] = 'X';
                            }

                            if (board[1] == 'O' && board[4] == 'O' && board[7] != 'X')
                            {
                                board[7] = 'X';
                            }
                                                       


                            else if (board[input] != 'X' && board[input] != 'O' && input > 0)
                            {
                                board[input] = 'X';
                                checkBoards++;
                                player++;
                            }
                            else
                            {
                                aIRequest++;
                                if (aIRequest > 60)
                                {
                                    gameChecker();
                                }
                                Console.WriteLine("AI is thinking!\n");
                                continue;

                            }

                        }

                    }
                    else
                    {
                        Console.Write("\nPlayer 2, please enter a slot: ");
                        int input = Int32.Parse(Console.ReadLine());
                        if (board[input] != 'X' && board[input] != 'O' && input > 0)
                        {
                            board[input] = 'O';
                            checkBoards++;
                            player++;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a different slot\n");
                            continue;
                        }
                    }
                    
                    updateBoard();


                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message + " - Numbers Only\n");
                    continue;

                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message + " - Enter Numbers 1 - 9\n");
                    continue;

                }
                                             



            } while (gameChecker() == false);

        }

        static bool gameChecker()
        {
            //Check if game is over
            for (int i = 0; i < board.Length; i++)
            {
                //Horizontal TOP Check P.1, P.2 
                if ((board[1] == 'X' && board[2] == 'X' && board[3] == 'X') || (board[1] == 'O' && board[2] == 'O' && board[3] == 'O'))
                {
                    if (board[1] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Diagnonal TOP Check P.1, P.2 
                if ((board[1] == 'X' && board[5] == 'X' && board[9] == 'X') || (board[1] == 'O' && board[5] == 'O' && board[9] == 'O'))
                {
                    if (board[1] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Vertical TOP Check P.1, P.2 
                if ((board[1] == 'X' && board[4] == 'X' && board[7] == 'X') || (board[1] == 'O' && board[4] == 'O' && board[7] == 'O'))
                {
                    if (board[1] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Middle TOP Check P.1, P.2 
                if ((board[2] == 'X' && board[5] == 'X' && board[8] == 'X') || (board[2] == 'O' && board[5] == 'O' && board[8] == 'O'))
                {
                    if (board[2] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }


                //Diagnonal FAR SIDE Check P.1, P.2 
                if ((board[3] == 'X' && board[5] == 'X' && board[7] == 'X') || (board[3] == 'O' && board[5] == 'O' && board[7] == 'O'))
                {

                    if (board[3] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Vertical FAR SIDE Check P.1, P.2 
                if ((board[3] == 'X' && board[6] == 'X' && board[9] == 'X') || (board[3] == 'O' && board[6] == 'O' && board[9] == 'O'))
                {
                    if (board[3] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Horizontal MIDDLE Check P.1, P.2 
                if ((board[4] == 'X' && board[5] == 'X' && board[6] == 'X') || (board[4] == 'O' && board[5] == 'O' && board[6] == 'O'))
                {
                    if (board[4] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }

                //Horizontal MIDDLE Check P.1, P.2
                if ((board[7] == 'X' && board[8] == 'X' && board[9] == 'X') || (board[7] == 'O' && board[8] == 'O' && board[9] == 'O'))
                {
                    if (board[7] == 'X')
                    {
                        Console.WriteLine("Player 1 Wins!");
                    }
                    else
                    {
                        Console.WriteLine("Player 2 Wins!");

                    }

                    return gameOver = true;
                }
                //check if all slots are checked
                if (checkBoards > 8)
                {
                    Console.WriteLine("Draw!!");
                    string val = Console.ReadLine();                     
                   
                    return gameOver = true;
                }

            }

            return gameOver = false;

        }

        static void updateBoard()
        {
            Console.WriteLine("|{0}|{1}|{2}|\n" +
               "|{3}|{4}|{5}|\n" +
               "|{6}|{7}|{8}|", board[1], board[2], board[3], board[4], board[5], board[6], board[7], board[8], board[9]);
        }
    }
}
