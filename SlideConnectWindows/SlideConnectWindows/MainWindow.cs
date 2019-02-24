using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlideConnectWindows
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Shown += new EventHandler(window_Shown);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Saving game...";
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Loading game...";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            labelConsole.Text = "Resetting game...";
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
        }
    }
}
