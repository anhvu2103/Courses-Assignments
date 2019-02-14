/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019
Revision 1: 14 Feb 2019

Course: Software Models

Description: UI for our Connect game (via console)

Both players want to make 4 in a row of their marker type on the board. 
The way to play is to choose which way the pieces fall (like the game 2048), 
but the objective is to get 4 in a row (like the game Connect 4).

The console requests a direction (UP,DOWN,LEFT,RIGHT) or a 
game setting (SAVE, LOAD, RESET, QUIT) from the user.
Direction is handled by the GameController and the game setting is handled by
the ConnectConsole. 
*/

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using ConnectGame.Model;

namespace ConnectGame
{
    /// <summary>
    /// GameController class
    /// </summary>
    class ConnectConsole 
    {
		static GameController gameController;
		private static readonly String CMD_RESET = "RESET";
		private static readonly String CMD_LOAD = "LOAD";
		private static readonly String CMD_SAVE = "SAVE";
        private static readonly String CMD_QUIT = "QUIT";
		private static readonly String configFile = "connect_config.txt";
		private static readonly String saveFile = "saved_game.xml";
		private static readonly String CONFIG_COMMENT = "#";
		
		/// <summary>
		/// Main entry point for game
		/// </summary>
		static void Main(string[] args) {
			Console.WriteLine("This is ConnectGame, by Owen, Brian, and Anh.");
            Console.WriteLine("\nTo reset the game at any point, type " + CMD_RESET + 
                                ".\nTo save the current game, type " + CMD_SAVE + 
                                ".\nTo load a saved game, type " + CMD_LOAD +
                                ".\nTo quit, type " + CMD_QUIT + 
                                ".\n");

            //initialize board and Board constants from config file
            Reset();
			
			bool play = true;
			bool shifted = false;
			String winner = null;
			
			while (play) {
				//place piece in random spot
				if (gameController.PlaceRandom()) {
					//draw board before shift
					DrawBoard();
				
					shifted = false;
					while (!shifted) {
						//request fall direction
						Console.Write("Player " + gameController.GetPlayer() + ", pick a fall direction (UP,RIGHT,DOWN,LEFT): ");
						String direction = Console.ReadLine().ToUpper();

	                    //check for reset,save,load
	                    if (direction == CMD_RESET) //load from connect_config.txt
	                    {
	                        Reset();
							shifted = true;
	                    }
	                    else if (direction == CMD_SAVE) //save to saved_game.xml
	                    {
	                        Save();
	                    }
	                    else if (direction == CMD_LOAD) //load from saved_game.xml
	                    {
	                        Load();
		                    //draw board
		                    DrawBoard();
	                    }
	                    else if (direction == CMD_QUIT) //quit game
	                    {
	                        Console.WriteLine("\nQuitting game...");
							shifted = true;
	                        play = false;
	                    }
	                    else //shift pieces
	                    {
							shifted = gameController.ShiftPieces(direction);
	                    }
					}
					
                    //draw board after shift
                    DrawBoard();

                    //check win
                    winner = gameController.CheckWin();
                    if (winner != null)
                    {
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
					
					//switch whose turn it is
                    gameController.SwitchPlayer();
				}
				else { //GameController.board could not find any more free spaces to place a new piece
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

        static void Reset() //load from connect_config.txt
        {
            Console.WriteLine("\nInitializing new game...\n");

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
                                    Console.WriteLine("Board size: " + size);
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
                                    Console.WriteLine("Win length: " + winLength);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine("Given win length " + line + " is invalid.");
                                }
                                break;

                            case 1: //player 1 char
                                char p1 = line.ToCharArray()[0];
                                gameController.SetP1(p1);
                                Console.WriteLine("Player 1: " + p1);
                                break;

                            case 2: //player 2 char
                                char p2 = line.ToCharArray()[0];
                                gameController.SetP2(p2);
                                Console.WriteLine("Player 2: " + p2);
                                break;

                            default:
                                Console.WriteLine("Extra data in configuration file will be ignored: " + line);
                                break;
                        }

                        i++;
                    }
                }

                Console.Write("\nCurrent game was begun: " + gameController.timeStamp + "\n");
                gameController.SetPlayer(true); //player1's turn
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("ERROR: could not find configuration file");
            }

        }

        static void Save() //save current GameController to saved_game.xml
        {
            Console.WriteLine("\nSaving game...");
            Stream saveStream = File.Create(saveFile);

            SoapFormatter serializer = new SoapFormatter();

            try
            {
                serializer.Serialize(saveStream, gameController);
                Console.WriteLine("Game saved to " + saveFile);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Game save failed: " + e.Message);
            }
            finally
            {
                saveStream.Close();
                Console.Write("\n");
            }
        }

        static void Load() //read in saved_game.xml if it exists and assign the object to gameController
        {
            Console.WriteLine("\nLoading saved game...");
			
			try {
	            FileStream loadStream = new FileStream(saveFile, FileMode.Open);

	            SoapFormatter deserializer = new SoapFormatter();

	            try
	            {
	                gameController = (GameController) deserializer.Deserialize(loadStream);
	                Console.WriteLine("Game loaded!");
	                Console.WriteLine("Current game was begun: " + gameController.timeStamp + "\n");
	            }
	            catch (SerializationException e)
	            {
	                Console.WriteLine("Game load failed: " + e.Message);
	            }
				
				loadStream.Close();
			}
			catch (FileNotFoundException e) {
				Console.WriteLine("Game load failed: no saved game found.");
			}
			
            Console.Write("\n");
        }
    }
}