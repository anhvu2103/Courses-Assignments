namespace ConnectGame
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table1 = new System.Windows.Forms.TableLayoutPanel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReset = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.table2 = new System.Windows.Forms.TableLayoutPanel();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.tableButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.tableArrows = new System.Windows.Forms.TableLayoutPanel();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.labelConsole = new System.Windows.Forms.Label();
            this.table1.SuspendLayout();
            this.menu.SuspendLayout();
            this.table2.SuspendLayout();
            this.tableButtons.SuspendLayout();
            this.tableArrows.SuspendLayout();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.ColumnCount = 1;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.Controls.Add(this.menu, 0, 0);
            this.table1.Controls.Add(this.table2, 0, 1);
            this.table1.Controls.Add(this.labelConsole, 0, 2);
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Location = new System.Drawing.Point(0, 0);
            this.table1.Margin = new System.Windows.Forms.Padding(0);
            this.table1.Name = "table1";
            this.table1.RowCount = 3;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table1.Size = new System.Drawing.Size(652, 364);
            this.table1.TabIndex = 0;
            // 
            // menu
            // 
            this.menu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.menu.BackColor = System.Drawing.SystemColors.ControlLight;
            this.menu.Dock = System.Windows.Forms.DockStyle.None;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuPlay});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(3, 5);
            this.menu.Margin = new System.Windows.Forms.Padding(3);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(646, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSave,
            this.menuReset,
            this.menuLoad});
            this.menuFile.Name = "menuFile";
            this.menuFile.Size = new System.Drawing.Size(35, 20);
            this.menuFile.Text = "file";
            // 
            // menuSave
            // 
            this.menuSave.Name = "menuSave";
            this.menuSave.Size = new System.Drawing.Size(152, 22);
            this.menuSave.Text = "save";
            this.menuSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // menuReset
            // 
            this.menuReset.Name = "menuReset";
            this.menuReset.Size = new System.Drawing.Size(152, 22);
            this.menuReset.Text = "reset";
            this.menuReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // menuLoad
            // 
            this.menuLoad.Name = "menuLoad";
            this.menuLoad.Size = new System.Drawing.Size(152, 22);
            this.menuLoad.Text = "load";
            this.menuLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // menuPlay
            // 
            this.menuPlay.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuUp,
            this.menuDown,
            this.menuRight,
            this.menuLeft});
            this.menuPlay.Name = "menuPlay";
            this.menuPlay.Size = new System.Drawing.Size(41, 20);
            this.menuPlay.Text = "play";
            // 
            // menuUp
            // 
            this.menuUp.Name = "menuUp";
            this.menuUp.Size = new System.Drawing.Size(104, 22);
            this.menuUp.Text = "up";
            this.menuUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // menuDown
            // 
            this.menuDown.Name = "menuDown";
            this.menuDown.Size = new System.Drawing.Size(104, 22);
            this.menuDown.Text = "down";
            this.menuDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // menuRight
            // 
            this.menuRight.Name = "menuRight";
            this.menuRight.Size = new System.Drawing.Size(104, 22);
            this.menuRight.Text = "right";
            this.menuRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // menuLeft
            // 
            this.menuLeft.Name = "menuLeft";
            this.menuLeft.Size = new System.Drawing.Size(104, 22);
            this.menuLeft.Text = "left";
            this.menuLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // table2
            // 
            this.table2.ColumnCount = 2;
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.96053F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.03947F));
            this.table2.Controls.Add(this.panelBoard, 0, 0);
            this.table2.Controls.Add(this.tableButtons, 1, 0);
            this.table2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table2.Location = new System.Drawing.Point(0, 35);
            this.table2.Margin = new System.Windows.Forms.Padding(0);
            this.table2.Name = "table2";
            this.table2.RowCount = 1;
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.table2.Size = new System.Drawing.Size(652, 289);
            this.table2.TabIndex = 0;
            // 
            // panelBoard
            // 
            this.panelBoard.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panelBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBoard.Location = new System.Drawing.Point(3, 3);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(502, 283);
            this.panelBoard.TabIndex = 0;
            // 
            // tableButtons
            // 
            this.tableButtons.ColumnCount = 1;
            this.tableButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableButtons.Controls.Add(this.buttonReset, 0, 2);
            this.tableButtons.Controls.Add(this.buttonSave, 0, 0);
            this.tableButtons.Controls.Add(this.buttonLoad, 0, 1);
            this.tableButtons.Controls.Add(this.tableArrows, 0, 3);
            this.tableButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableButtons.Location = new System.Drawing.Point(508, 0);
            this.tableButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tableButtons.Name = "tableButtons";
            this.tableButtons.RowCount = 4;
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.38461F));
            this.tableButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.84615F));
            this.tableButtons.Size = new System.Drawing.Size(144, 289);
            this.tableButtons.TabIndex = 1;
            // 
            // buttonReset
            // 
            this.buttonReset.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonReset.Location = new System.Drawing.Point(3, 91);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(138, 38);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "reset";
            this.buttonReset.UseVisualStyleBackColor = false;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSave.Location = new System.Drawing.Point(3, 3);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(138, 38);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLoad.Location = new System.Drawing.Point(3, 47);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(138, 38);
            this.buttonLoad.TabIndex = 1;
            this.buttonLoad.Text = "load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // tableArrows
            // 
            this.tableArrows.BackColor = System.Drawing.SystemColors.Control;
            this.tableArrows.ColumnCount = 3;
            this.tableArrows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.Controls.Add(this.buttonDown, 1, 2);
            this.tableArrows.Controls.Add(this.buttonRight, 2, 1);
            this.tableArrows.Controls.Add(this.buttonLeft, 0, 1);
            this.tableArrows.Controls.Add(this.buttonUp, 1, 0);
            this.tableArrows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableArrows.Location = new System.Drawing.Point(3, 135);
            this.tableArrows.Name = "tableArrows";
            this.tableArrows.RowCount = 3;
            this.tableArrows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableArrows.Size = new System.Drawing.Size(138, 151);
            this.tableArrows.TabIndex = 3;
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDown.BackgroundImage = global::SlideConnectWindows.Properties.Resources.arrowDown;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonDown.Location = new System.Drawing.Point(46, 100);
            this.buttonDown.Margin = new System.Windows.Forms.Padding(0);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(46, 51);
            this.buttonDown.TabIndex = 8;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonDown_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonRight.BackgroundImage = global::SlideConnectWindows.Properties.Resources.arrowRight;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRight.Location = new System.Drawing.Point(92, 50);
            this.buttonRight.Margin = new System.Windows.Forms.Padding(0);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(46, 50);
            this.buttonRight.TabIndex = 6;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLeft.BackgroundImage = global::SlideConnectWindows.Properties.Resources.arrowLeft;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.Location = new System.Drawing.Point(0, 50);
            this.buttonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(46, 50);
            this.buttonLeft.TabIndex = 4;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonUp.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonUp.BackgroundImage = global::SlideConnectWindows.Properties.Resources.arrowUp;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonUp.Location = new System.Drawing.Point(46, 0);
            this.buttonUp.Margin = new System.Windows.Forms.Padding(0);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(46, 50);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.UseVisualStyleBackColor = false;
            this.buttonUp.Click += new System.EventHandler(this.buttonUp_Click);
            // 
            // labelConsole
            // 
            this.labelConsole.BackColor = System.Drawing.SystemColors.ControlText;
            this.labelConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelConsole.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConsole.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelConsole.Location = new System.Drawing.Point(3, 327);
            this.labelConsole.Margin = new System.Windows.Forms.Padding(3);
            this.labelConsole.Name = "labelConsole";
            this.labelConsole.Size = new System.Drawing.Size(646, 34);
            this.labelConsole.TabIndex = 1;
            this.labelConsole.Text = "console";
            this.labelConsole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 364);
            this.Controls.Add(this.table1);
            this.MainMenuStrip = this.menu;
            this.Name = "MainWindow";
            this.Text = "Slide & Connect";
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.table2.ResumeLayout(false);
            this.tableButtons.ResumeLayout(false);
            this.tableArrows.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table1;
        private System.Windows.Forms.TableLayoutPanel table2;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.TableLayoutPanel tableButtons;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.TableLayoutPanel tableArrows;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonUp;
        public System.Windows.Forms.Label labelConsole;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuPlay;
        private System.Windows.Forms.ToolStripMenuItem menuSave;
        private System.Windows.Forms.ToolStripMenuItem menuReset;
        private System.Windows.Forms.ToolStripMenuItem menuUp;
        private System.Windows.Forms.ToolStripMenuItem menuDown;
        private System.Windows.Forms.ToolStripMenuItem menuRight;
        private System.Windows.Forms.ToolStripMenuItem menuLeft;
        private System.Windows.Forms.ToolStripMenuItem menuLoad;
    }
}

