/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019

Course: Software Models

Description: UI for our Connect game (via console)

*/

using System;
using System.IO;
using ConnectGame.Model;

namespace ConnectGame {
	/// <summary>
	/// GameController class
	/// </summary>
	class ConnectConsole {
		static GameController gameController;
		private static const String CMD_RESET = "RESET";
		private static const String CMD_LOAD = "LOAD";
		private static const String CMD_SAVE = "SAVE";
		private static const String configFile = "connect_config.txt";
		private static const String saveFile = "saved_game.xml";
		private String CONFIG_COMMENT = "";
		
		/// <summary>
		/// Main entry point for game
		/// </summary>
		static void Main(string[] args) {
			Console.WriteLine("This is ConnectGame, by Owen, Brian, and Anh.");
            Console.WriteLine("\nTo reset the game at any point, type " + CMD_RESET + ".\n To save the current game, type " + CMD_SAVE + ".\n To load a saved game, type" + CMD_LOAD + ".");

            //initialize board and Board constants from config file
            reset();
			
			bool play = true;
			String winner = null;
			
			while (play) {
				//place piece in random spot
				if (gameController.PlaceRandom()) {
					//draw board
					DrawBoard();
				
					//request fall direction
					Console.Write("Player " + gameController.GetPlayer() + ", pick a fall direction (UP,RIGHT,DOWN,LEFT): ");
					String direction = Console.ReadLine().ToUpper();

                    //check for reset,save,load
                    if (direction == CMD_RESET) //load from connect_config.txt
                    {
                        reset();
                    }
                    else if (direction == CMD_SAVE) //save to saved_game.xml
                    {

                    }
                    else if (direction == CMD_LOAD) //load from saved_game.xml
                    {

                    }

                    //shift pieces
                    gameController.ShiftPieces(direction);
				
					//draw board
					DrawBoard();

                    //check win
                    winner = gameController.CheckWin();
					if (winner != null) {
						play = false;

                        if (winner == Board.EMPTY.ToString())
                        {
                            Console.WriteLine("TIE!");
                        }
                        else
                        {
                            Console.WriteLine("Player " + winner + " wins!");
                        }
					}
					
					gameController.SwitchPlayer();
				}
				else {
					play = false;
					Console.WriteLine("No more available spaces.\nTIE!");
				}
			}
		}
		
		static void DrawBoard() {
			char[,] board = gameController.GetBoard();
			int boardSize = gameController.GetBoardSize();
			
			for (int y=0; y<boardSize; y++) {
				for (int x=0; x<boardSize; x++) {
					Console.Write(board[y,x] + " ");
				}
				
				Console.Write("\n");
			}
		}

        static void reset() //load from connect_config.txt
        {
            try
            {
                StreamReader configReader = File.OpenText(configFile);
                string line = null;
                int i = 0;
                while ((line = configReader.ReadLine()) != null)
                {
                    if (!line.StartsWith(CONFIG_COMMENT)) //is valid configuration info
                    {
                        switch (i)
                        {
                            case 0: //board size
                                try
                                {
                                    int size = int.Parse(line);
                                    gameController = new GameController(size);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Given board size " + line + " is invalid."); 
                                }
                                break;

                            case 3: //how many to win
                                try
                                {
                                    int winLength = int.Parse(line);
                                    gameController.SetWinLength(winLength);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Given win length " + line + " is invalid.");
                                }
                                break;

                            case 1: //player 1 char
                                char p1 = line.ToCharArray()[0];
                                gameController.SetP1(p1);
                                break;

                            case 2: //player 2 char
                                char p2 = line.ToCharArray()[0];
                                gameController.SetP2(p2);
                                break;

                            default:
                                Console.WriteLine("Extra data in configuration file will be ignored: " + line);
                                break;
                        }

                        i++;
                    }
                }

                gameController.SetPlayer(true); //player1's turn
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("ERROR: could not find configuration file");
            }

        }
    }
}