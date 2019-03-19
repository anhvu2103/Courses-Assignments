using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ConnectGame.Control;
using ConnectGame.Model;

namespace ConnectGame
{
    public partial class MainWindow : Form
    {
        private GameController gameController;
        private Pen gridPen;
        private Graphics boardGraphics;
        private Pen p1Pen;
        private Pen p2Pen;
        private Pen highlightPen;

        public MainWindow()
        {
            InitializeComponent();

            gridPen = new Pen(Color.Black, 1);
            p1Pen = new Pen(Color.Red, 3);
            p2Pen = new Pen(Color.Blue, 3);
            highlightPen = new Pen(Color.MediumPurple, 4);

            gameController = new GameController(this);

            this.Shown += new EventHandler(window_Shown);
            this.Resize += new EventHandler(window_Resize);
            this.KeyUp += new KeyEventHandler(window_KeyUp);
        }

        private void DrawGrid(int size)
        {
            int w = panelBoard.Width;
            int h = panelBoard.Height;
            int ch = h / size;
            int cw = w / size;

            for (int r = 1; r < size; r++)
            {
                boardGraphics.DrawLine(gridPen, 0, r*ch, w, r*ch);
                boardGraphics.DrawLine(gridPen, r*cw, 0, r*cw, h);
            }
        }

        private void DrawP1(int x, int y, int size)
        {
            int cw = panelBoard.Width / size;
            int ch = panelBoard.Height / size;

            Pen pen = p1Pen;
            int[] lastPiece = gameController.GetLastPiece();
            if (lastPiece != null && lastPiece[0] == x && lastPiece[1] == y)
            {
                pen = highlightPen;
            }

            //draw X
            boardGraphics.DrawLine(pen, x * cw, y * ch, x * cw + cw, y * ch + ch);
            boardGraphics.DrawLine(pen, x * cw + cw, y * ch, x * cw, y * ch + ch);
        }

        private void DrawP2(int x, int y, int size)
        {
            int cw = panelBoard.Width / size;
            int ch = panelBoard.Height / size;

            Pen pen = p2Pen;
            int[] lastPiece = gameController.GetLastPiece();
            if (lastPiece != null && lastPiece[0] == x && lastPiece[1] == y)
            {
                pen = highlightPen;
            }

            //draw O
            boardGraphics.DrawArc(pen, new Rectangle(x * cw, y * ch, cw, ch), 0, 360);
        }

        public void ShowBoard()
        {
            char[,] board = gameController.GetBoard();
            int n = gameController.GetBoardSize();
            boardGraphics = panelBoard.CreateGraphics();
            boardGraphics.SmoothingMode = SmoothingMode.HighQuality;

            boardGraphics.Clear(panelBoard.BackColor);
            DrawGrid(n);

            for (int y = 0; y < n; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (board[y,x] == Board.P1) {
                        DrawP1(x,y,n);
                    }
                    else if (board[y,x] == Board.P2) {
                        DrawP2(x,y,n);
                    }
                    
                    Console.Write(board[y,x] + " ");
                }

                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public void ShowWin(string winner)
        {
			//show win dialog window
            string winMessage = "Player " + winner + " wins. Play again?";
            string winCaption = "Game Over: Win";
            MessageBoxButtons winButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(winMessage, winCaption, winButtons);

			//handle OK, ask to play again
            if (result == DialogResult.Yes)
            {
                gameController.Reset();
            }
            else
            {
                Close();
            }
		}
		
		public void ShowTie() {
			//show tie
            string winMessage = "Tie! Play again?";
            string winCaption = "Game Over: Tie";
            MessageBoxButtons winButtons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(winMessage, winCaption, winButtons);

			//handle OK, ask to play again
            if (result == DialogResult.Yes)
            {
                gameController.Reset();
            }
            else
            {
                Close();
            }
		}

        private void buttonSave_Click(object sender, EventArgs e)
        {
            //save game
            gameController.Save();
            //stay in idle state
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            //load saved game
            gameController.Load();
            //stay in idle state
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            //reset game
            gameController.Reset();
            //stay in idle state
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            //pass direction to controller
			gameController.EventShift(Board.UP);
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            //pass direction to controller
            gameController.EventShift(Board.RIGHT);
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            //pass direction to controller
			gameController.EventShift(Board.LEFT);
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            //pass direction to controller
			gameController.EventShift(Board.DOWN);
        }

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    gameController.EventShift(Board.UP);
                    break;

                case Keys.Right:
                    gameController.EventShift(Board.RIGHT);
                    break;

                case Keys.Down:
                    gameController.EventShift(Board.DOWN);
                    break;

                case Keys.Left:
                    gameController.EventShift(Board.LEFT);
                    break;
            }
        }

        private void window_Shown(object sender, EventArgs e)
        {
            labelConsole.Text = "Main window loaded";

            gameController.Reset();

            ActiveControl = null;
        }

        private void window_Resize(object sender, EventArgs e)
        {
            ShowBoard();
        }
    }
}
