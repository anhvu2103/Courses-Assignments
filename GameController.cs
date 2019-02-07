/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019

Course: Software Models

Description:

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
			int[] space = board.FindFreeSpace(random.Next(board.BoardSize),random.Next(board.BoardSize));
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
			return board.getBoard();
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
		public void ShiftPieces(String direction)
		{
			direction = direction.ToUpper();
			int intDirection;
			if(UP)
			{
				intDirection = board.UP;
			}
			if(DOWN)
			{
				intDirection = board.DOWN;
			}
			if(LEFT)
			{
				intDirection = board.LEFT;
			}
			if(RIGHT)
			{
				intDirection = board.RIGHT;
			}
			board.Shift(intDirection);
		}

		public String CheckWin()
		{
			char[,] board = board.GetBoard();
			String horizontal = "";
			String vertical = "";
			String downRight = "";
			String downLeft = "";
			for(int y = 0; y < board.BoardSize; y++) 
			{
				for(int x = 0; x < board.BoardSize; x++)
				{
					if(board[y,x] != board.EMPTY)
					{
						horizontal = "";
						vertical = "";
						downRight = "";
						downLeft = "";
						for(int i = -3; i < 4; i++)
						{
							//TO-DO
						}
					}
					
				}
			}
			
		}
	}
}