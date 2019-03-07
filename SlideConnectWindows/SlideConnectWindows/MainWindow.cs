using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public MainWindow()
        {
            InitializeComponent();

            this.Shown += new EventHandler(window_Shown);
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
            labelConsole.Text = "Shift direction = UP";
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Shift direction = RIGHT";
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Shift direction = LEFT";
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Shift direction = DOWN";
        }

        private void window_Shown(object sender, EventArgs e)
        {
            labelConsole.Text = "Main window loaded";

            gameController = new GameController(this);
            gameController.Reset();
        }
    }
}
