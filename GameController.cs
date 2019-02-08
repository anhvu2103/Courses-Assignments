/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019

Course: Software Models

Description: Model for Connect game, which keeps track of the state of the game (where 
the pieces are, whose turn it is, who won, etc.)

*/

using System;

namespace ConnectGame.Model {
	/// <summary>
	/// GameController class
	/// </summary>
	class GameController {
		Random random = new Random();

		private Board board;
		private bool player; 

		public GameController(int size) 
		{
			board = new Board(size);

		}

		/// <summary>
        /// Generte random
        /// </summary>
		public bool PlaceRandom()
		{
			int[] space = board.FindFreeSpace(random.Next(board.BoardSize-1),random.Next(board.BoardSize-1));
			char playerPiece;
			if (player) {
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
			if(player) 
			{
				return "One";
			}
			else 
			{
				return "Two";
			} 
		}
		
		public void SwitchPlayer() {
			player = !player;
		}
		
		public void ShiftPieces(String direction)
		{
			direction = direction.ToUpper();
			int intDirection = -1;
			if(direction == "UP")
			{
				intDirection = Board.UP;
			}
			if(direction == "DOWN")
			{
				intDirection = Board.DOWN;
			}
			if(direction == "LEFT")
			{
				intDirection = Board.LEFT;
			}
			if(direction == "RIGHT")
			{
				intDirection = Board.RIGHT;
			}
			board.Shift(intDirection);
		}

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
                        Console.WriteLine("Checking win around " + x + "," + y);
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
                        //Console.WriteLine("h: " + horizontal);
                        //Console.WriteLine("v: " + vertical);
                        //Console.WriteLine("r: " + downRight);
                        //Console.WriteLine("l: " + downLeft);

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