/*

Group: Owen G, Brian P, Anh V
Date: 1 Feb 2019

Course: Software Models

Description: UI for our Connect game (via console)

*/

using System;
using ConnectGame.Model;

namespace ConnectGame {
	/// <summary>
	/// GameController class
	/// </summary>
	class ConnectConsole {
		static GameController gameController;
		
		/// <summary>
		/// Main entry point for game
		/// </summary>
		static void Main(string[] args) {
			Console.WriteLine("This is ConnectGame, by Owen, Brian, and Anh.");
			
			//create 7x7 board
			gameController = new GameController(7);
			
			bool play = true;
			String winner = null;
			
			while (play) {
				//place piece in random spot
				if (gameController.PlaceRandom()) {
					//draw board
					DrawBoard();
				
					//request fall direction
					Console.Write("Player " + gameController.GetPlayer() + ", pick a fall direction (UP,RIGHT,DOWN,LEFT): ");
					String direction = Console.ReadLine();
				
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
	}
}