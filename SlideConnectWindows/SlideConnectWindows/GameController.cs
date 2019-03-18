/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019
Revision 1: 14 Feb 2019

Course: Software Models

Description: Model for Connect game, which keeps track of the state of the game (where 
the pieces are, whose turn it is, who won, when the game was first started, etc.). It uses 
the Board class to handle low-level board and piece manipulation, and has its own method 
for determining who wins. 

*/

using System;
using System.Drawing;
using ConnectGame.Model;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace ConnectGame.Control {
	/// <summary>
	/// GameController class
	/// </summary>
	class GameController {
        private static readonly String configFile = "connect_config.txt";
        private static readonly String saveFile = "saved_game.xml";
        private static readonly String CONFIG_COMMENT = "#";
        private static readonly char CONFIG_DELIM = ',';

		Random random = new Random();

		private Board board = null;

        public MainWindow gui;
		
		//state variables
		public const int STATE_PLAY = 1;
		public const int STATE_PROMPT = 2;
		public const int STATE_IDLE = 3;
		public const int STATE_SHIFT = 4;
		public const int STATE_PUT = 5;
		public const int STATE_WIN = 6;
		public const int STATE_TIE = 7;
		public const int STATE_AGAIN = 8;
			
		public int gameState; //play, prompt
		public int playState; //idle, shift, put
		public int promptState; //win, tie, again

		public GameController(MainWindow gui) 
		{
			board = new Board(7,DateTime.Now.ToString());
            this.gui = gui;
			
			GoState(ref gameState, STATE_PLAY);
			GoState(ref playState, STATE_PUT);
		}
		
		public void GoState(ref int var, int state) 
		{
            switch (state)
            {
                case STATE_PLAY: //start new game
                    break;

                case STATE_PUT: //place current player's piece type in a random spot on the board
                    bool foundSpot = PlaceRandom();

				    if (foundSpot) {
					    GoState(ref playState, STATE_IDLE);
				    }
				    else { //tie
					    GoState(ref gameState, STATE_PROMPT);
					    GoState(ref promptState, STATE_TIE);
					    gui.ShowTie();
				    }
                    break;

                case STATE_SHIFT: //actual shifting done prior
                    string winner = CheckWin();

			        if (winner != null) { //win
				        GoState(ref gameState, STATE_WIN);
				        gui.ShowWin(winner);
			        }
			        else { //no win
				        GoState(ref playState, STATE_PUT);
                        gui.ShowBoard();
			        }
                    break;

                case STATE_PROMPT:
                    break;
            }

			var = state;
		}
		
		public void EventShift(int direction) 
		{
            board.player = !board.player;
            board.Shift(direction);

			GoState(ref playState, STATE_SHIFT);
		}

        public void Reset()
        {
            gui.labelConsole.Text = "Initializing new game...";

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
                                    gui.labelConsole.Text = "Board size: " + size;
                                    Reset(size);
                                }
                                catch (Exception)
                                {
                                    gui.labelConsole.Text = "Given board size " + line + " is invalid.";
                                }
                                break;

                            case 3: //how many to win
                                try
                                {
                                    int winLength = int.Parse(line);
                                    SetWinLength(winLength);
                                    gui.labelConsole.Text = "Win length: " + winLength;
                                }
                                catch (Exception)
                                {
                                    gui.labelConsole.Text = "Given win length " + line + " is invalid.";
                                }
                                break;

                            case 1: //player 1 char
                                string[] c1 = line.Split(CONFIG_DELIM);

                                try
                                {
                                    Color color1 = Color.FromArgb(int.Parse(c1[0]), int.Parse(c1[1]), int.Parse(c1[3]));
                                    SetP1(color1);
                                    gui.labelConsole.Text = "Player 1: " + color1;
                                }
                                catch (FormatException)
                                {
                                    gui.labelConsole.Text = "Bad color info given for player 1";
                                    SetP1(Color.Red);
                                }
                                break;

                            case 2: //player 2 char
                                string[] c2 = line.Split(CONFIG_DELIM);

                                try
                                {
                                    Color color2 = Color.FromArgb(int.Parse(c2[0]), int.Parse(c2[1]), int.Parse(c2[3]));
                                    SetP1(color2);
                                    gui.labelConsole.Text = "Player 2: " + color2;
                                }
                                catch (FormatException)
                                {
                                    gui.labelConsole.Text = "Bad color info given for player 2";
                                    SetP1(Color.Blue);
                                }
                                break;

                            default:
                                gui.labelConsole.Text = "Extra data in configuration file will be ignored: " + line;
                                break;
                        }

                        i++;
                    }
                }

                gui.labelConsole.Text = "Current game was begun: " + board.timeStamp;
            }
            catch (FileNotFoundException)
            {
                gui.labelConsole.Text = "ERROR: could not find configuration file";
            }
        }

        public void Save() //save current GameController to saved_game.xml
        {
            Console.WriteLine("\nSaving game...");
            Stream saveStream = File.Create(saveFile);

            SoapFormatter serializer = new SoapFormatter();

            try
            {
                serializer.Serialize(saveStream, board);
                gui.labelConsole.Text = "Game saved to " + saveFile;
            }
            catch (SerializationException e)
            {
                gui.labelConsole.Text = "Game save failed: " + e.Message;
            }
            finally
            {
                saveStream.Close();
            }
        }

        public void Load() //read in saved_game.xml if it exists and assign the object to gameController
        {
            gui.labelConsole.Text = "\nLoading saved game...";

            try
            {
                FileStream loadStream = new FileStream(saveFile, FileMode.Open);

                SoapFormatter deserializer = new SoapFormatter();

                try
                {
                    board = (Board)deserializer.Deserialize(loadStream);
                    gui.labelConsole.Text = "Game loaded!";
                    gui.labelConsole.Text = "Current game was begun: " + board.timeStamp;
                }
                catch (SerializationException e)
                {
                    gui.labelConsole.Text = "Game load failed: " + e.Message;
                }

                loadStream.Close();
            }
            catch (FileNotFoundException e)
            {
                gui.labelConsole.Text = "Game load failed: no saved game found.";
            }
        }

        public void Reset(int size)
        {
            board = new Board(7,DateTime.Now.ToString());
        }

        public void Reset(int size, int length, Color p1, Color p2)
        {
            Reset(size);
            SetWinLength(length);
            SetP1(p1);
            SetP2(p2);
        }

        public void SetWinLength(int length)
		{
			board.SetWinLength(length);
		}

		public void SetP1(Color c)
		{
            board.p1Color = c;
		}

		public void SetP2(Color c)
		{
            board.p2Color = c;
		}

		/// <summary>
        /// Generte random
        /// </summary>
		public bool PlaceRandom()
		{
            //Place X or O randomly on the board
			int[] space = board.FindFreeSpace(random.Next(board.BoardSize-1),random.Next(board.BoardSize-1));
			char playerPiece;
			if (board.player) {
				playerPiece = Board.P1;
			}
			else {
				playerPiece = Board.P2;
			}
			if (board.Place(space[0],space[1],playerPiece)) {
				return true;
			}
			else {
				return false;
			}
		}

        /// <summary>
        /// This gives you current board stage
        /// </summary>
        /// <returns>The board.</returns>
		public char[,] GetBoard()
		{
			return board.GetBoard();
		}

		public int GetBoardSize() 
		{
			return board.BoardSize;
		}
		public String GetPlayer()
		{
			if(board.player) 
			{
				return "One";
			}
			else 
			{
				return "Two";
			} 
		}

        //TODO: change GameController.CheckWin() to change based on win length from config file
        /// <summary>
        /// Check the string connections to find winner
        /// </summary>
        /// <returns>One, Two, or NULL</returns>
		public String CheckWin()
		{
			char[,] boardGrid = board.GetBoard();
			String horizontal = "";
			String vertical = "";
			String downRight = "";
			String downLeft = "";
			
			bool checkX;
			bool checkY;
            char winner = '?';
			
			for(int y = 0; y < board.BoardSize; y++) 
			{
				for(int x = 0; x < board.BoardSize; x++)
				{
					if(boardGrid[y,x] != Board.EMPTY)
					{
						horizontal = "";
						vertical = "";
						downRight = "";
						downLeft = "";

                        for (int i = -3; i < 4; i++)
						{
							checkX = x+i >= 0 && x+i < board.BoardSize;
							checkY = y+i >= 0 && y+i < board.BoardSize;
							
							//horizontal
							if (checkX) {
								horizontal += boardGrid[y,x+i];
							}
							else {
								horizontal += Board.EMPTY;
							}
							
							//vertical
							if (checkY) {
								vertical += boardGrid[y+i,x];
							}
							else {
								vertical += Board.EMPTY;
							}
							
							//downRight
							if (checkX && checkY) {
								downRight += boardGrid[y+i,x+i];
							}
							else {
								downRight += Board.EMPTY;
							}
							
							//downLeft
							checkY = y-i >= 0 && y-i < board.BoardSize;
							if (checkX && checkY) {
								downLeft += boardGrid[y-i,x+i];
							}
							else {
								downLeft += Board.EMPTY;
							}
						}

                        //check wins
                        if (horizontal.IndexOf(Board.P1_WIN) > -1 || 
							vertical.IndexOf(Board.P1_WIN) > -1 ||
							downRight.IndexOf(Board.P1_WIN) > -1 || 
							downLeft.IndexOf(Board.P1_WIN) > -1) 
						{
                            Console.WriteLine("Found win for " + Board.P1);

                            if (winner != Board.P2)
                            {
                                winner = Board.P1;
                            }
                            else
                            {
                                return Board.EMPTY.ToString();
                            }
                        }
                        if (horizontal.IndexOf(Board.P2_WIN) > -1 || 
								 vertical.IndexOf(Board.P2_WIN) > -1 ||
								 downRight.IndexOf(Board.P2_WIN) > -1 || 
								 downLeft.IndexOf(Board.P2_WIN) > -1) 
						{
                            Console.WriteLine("Found win for " + Board.P2);

                            if (winner != Board.P1)
                            {
                                winner = Board.P2;
                            }
                            else
                            {
                                return Board.EMPTY.ToString();
                            }
                        }
					}
				}
			}
            /// Get the winner and print it out
            if (winner == Board.P1)
            {
                return "One";
            }
            else if (winner == Board.P2)
            {
                return "Two";
            }
            else
            {
                return null;
            }
        }
	}
}