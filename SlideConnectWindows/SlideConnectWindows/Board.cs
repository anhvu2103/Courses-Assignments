/*
 * Students: Owen G, Anh V, Brian P
 * Date: 5 Feb 2019
 Revision 1: 14 Feb 2019
 
 * Course: Software Models
 * 
 * Description: Board class for ConnectGame

Handles low-level processes related to the board and the markers.
GameController tells it to manipulate its 2d array at a higher level, while Board executes 
the particulars, sometimes returning boolean values denoting errors. It also has many internal
constants, like the characters for each player, the possible character strings for wins,
fall direction codes and the board dimensions.
 */

using System;
using System.Drawing;

namespace ConnectGame.Model
{
    /// <summary>
    /// Game board
    /// </summary>
    [Serializable]
    public class Board
    {
        public static char EMPTY = '.';
        public static char P1 = 'X';
        public static char P2 = 'O';
		
		public static String P1_WIN = "XXXX";
		public static String P2_WIN = "OOOO";

        public const int UP = 0;
        public const int RIGHT = 1;
        public const int DOWN = 2;
        public const int LEFT = 3;

        private char[,] board;
		private int boardSize;
        private int[] lastPiece = new int[2];

        public Color p1Color;
        public Color p2Color;

        public bool player;
        public readonly string timeStamp;
        public int gameTime; //time played, in ms

        public int BoardSize {
        	get {
        		return boardSize;
        	}
			set {
				if (value < 0) {
					value = 0;
				}
				boardSize = value;
			}
        }

        public int[] LastPiece
        {
            get
            {
                return lastPiece;
            }
            set
            {
                if (value == null || value.Length == 2 && value[0] > 0 && value[0] < boardSize && value[1] > 0 && value[1] < boardSize)
                {
                    lastPiece = value;
                }
            }
        }
        
        /// <summary>
        /// Build a board
        /// </summary>
        /// <param name="size">Board width</param>
        public Board(int size, String time)
        {
            boardSize = size;
            board = new char[size,size];

            for (int y=0; y<size; y++)
            {
                for (int x=0; x<size; x++)
                {
                    board[y, x] = EMPTY;
                }
            }
            ///X color
            p1Color = Color.Red;

            ///O color
            p2Color = Color.Blue;

            player = true;
            timeStamp = time;
            gameTime = 0;
        }

        public void SetWinLength(int length) //how many pieces in a row to win
        {
            if (length < 4)
            {
                length = 4;
            }

            P1_WIN = "";
            P2_WIN = "";
            for (int i=0; i<length; i++)
            {
                P1_WIN += P1;
                P2_WIN += P2;
            }
        }
		
        /// <summary>
        /// Finds the free space for next X or O.
        /// </summary>
        /// <returns>The free space.</returns>
        /// <param name="x0">Where to start searching (column)</param>
        /// <param name="y0">Where to start searching (row)</param>
		public int[] FindFreeSpace(int x0, int y0) {
            Console.WriteLine("Find free space from " + x0 + "," + y0);
			int[] space = new int[] {x0,y0};

            if (CheckCell(space[0], space[1]))
            {
                lastPiece = space;
                return space;
            }
            else
            {
                space[0]++; //move over one column to not recheck the same cell

                while (!(space[0] == x0 && space[1] == y0)) //for each row...
                {

                    for (int x=0; x<boardSize-1; x++) //for each column...
                    {
                        Console.WriteLine("\tCheck cell (" + space[0] + "," + space[1] + ")");
                        if (CheckCell(space[0], space[1]))
                        {
                            //found free space
                            lastPiece = space;
                            return space;
                        }

                        space[0]++;
                        if (space[0] > boardSize - 1)
                        {
                            space[0] = 0;
                        }
                    }

                    space[0] = x0;
                    space[1]++;
                    if (space[1] > boardSize - 1)
                    {
                        space[1] = 0;
                    }

                    Console.WriteLine("Next row: " + space[0] + "," + space[1]);
                }
            }

            //reached space (x0,y0) while searching; return impossible space
            space[0] = -1;
			space[1] = -1;
            lastPiece = null;
			return space;
		}

        /// <summary>
        /// Puts a piece in the board.
        /// Checks if it's a valid location, if the spot is free, etc.
        /// </summary>
        public bool Place(int x, int y, char type)
        {
            Console.WriteLine("Try placing @" + x + "," + y);
            if (x >= 0 && x < boardSize && y >= 0 && y < boardSize)
            {
                //inside the board
                if (CheckCell(x,y))
                {
                    //is free
                    board[y, x] = type;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks to see if given cell is empty. Called in Place().
        /// </summary>
        /// <returns><c>true</c>, if cell was checked, <c>false</c> otherwise.</returns>
        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public bool CheckCell(int x, int y)
        {
            if (x < boardSize && y < boardSize && board[y, x] == EMPTY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Shift pieces the specified direction.
        /// </summary>
        /// <param name="direction">Direction to make the pieces fall.</param>
        public void Shift(int direction)
        {
            switch(direction)
            {
                case UP:
                    for (int y=1; y<boardSize; y++)
                    {
                        for (int x=0; x<boardSize; x++)
                        {
                            char piece = board[y, x];
                            if (piece != EMPTY)
                            {
                                board[y, x] = EMPTY;
                                board[FindDestination(x, y, direction), x] = piece;
                            }
                        }
                    }
                    break;

                case RIGHT:
                    for (int x = boardSize-2; x >= 0; x--)
                    {
                        for (int y = 0; y < boardSize; y++)
                        {
                            char piece = board[y, x];
                            if (piece != EMPTY)
                            {
                                board[y, x] = EMPTY;
                                board[y, FindDestination(x, y, direction)] = piece;
                            }
                        }
                    }
                    break;

                case DOWN:
                    for (int y = boardSize-2; y >= 0; y--)
                    {
                        for (int x = 0; x < boardSize; x++)
                        {
                            char piece = board[y, x];
                            if (piece != EMPTY)
                            {
                                board[y, x] = EMPTY;
                                board[FindDestination(x, y, direction), x] = piece;
                            }
                        }
                    }
                    break;

                case LEFT:
                    for (int x = 0; x < boardSize; x++)
                    {
                        for (int y = 0; y < boardSize; y++)
                        {
                            char piece = board[y, x];
                            if (piece != EMPTY)
                            {
                                board[y, x] = EMPTY;
                                board[y, FindDestination(x, y, direction)] = piece;
                            }
                        }
                    }
                    break;
            }
        }

        // Find the destination for Shift(direction)
        private int FindDestination(int xPiece, int yPiece, int direction)
        {
            bool found = false;
            int destination = 0;

            switch(direction)
            {
                case UP:
                    destination = 0;
                    while (!found && destination < yPiece)
                    {
                        if (board[destination, xPiece] == EMPTY)
                        {
                            found = true;
                        }
                        else
                        {
                            destination++;
                        }
                    }
                    break;

                case DOWN:
                    destination = boardSize - 1;
                    while (!found && destination > yPiece)
                    {
                        if (board[destination, xPiece] == EMPTY)
                        {
                            found = true;
                        }
                        else
                        {
                            destination--;
                        }
                    }
                    break;

                case RIGHT:
                    destination = boardSize - 1;
                    while (!found && destination > xPiece)
                    {
                        if (board[yPiece, destination] == EMPTY)
                        {
                            found = true;
                        }
                        else
                        {
                            destination--;
                        }
                    }
                    break;

                case LEFT:
                    destination = 0;
                    while (!found && destination < xPiece)
                    {
                        if (board[yPiece, destination] == EMPTY)
                        {
                            found = true;
                        }
                        else
                        {
                            destination++;
                        }
                    }
                    break;
            }

            return destination;
        }
		
        //Expose the board grid to higher level classes
		public char[,] GetBoard() {
			return board;
		}
    }
}
