namespace BubbleTrouble
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBarTime = new System.Windows.Forms.ToolStripProgressBar();
            this.progressBarLives = new System.Windows.Forms.ToolStripProgressBar();
            this.labelPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this.money1 = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.pauseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.money1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // changeControlsToolStripMenuItem
            // 
            this.changeControlsToolStripMenuItem.Name = "changeControlsToolStripMenuItem";
            this.changeControlsToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.changeControlsToolStripMenuItem.Text = "Change controls";
            this.changeControlsToolStripMenuItem.Click += new System.EventHandler(this.changeControlsToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(719, 36);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            this.statusStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip1_Paint);
            // 
            // progressBarTime
            // 
            this.progressBarTime.AutoSize = false;
            this.progressBarTime.Maximum = 60;
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(300, 34);
            // 
            // progressBarLives
            // 
            this.progressBarLives.Maximum = 10;
            this.progressBarLives.Name = "progressBarLives";
            this.progressBarLives.Size = new System.Drawing.Size(100, 34);
            // 
            // labelPoints
            // 
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(52, 35);
            this.labelPoints.Text = "Points: 0";
            // 
            // money1
            // 
            this.money1.BackgroundImage = global::BubbleTrouble.Properties.Resources.money;
            this.money1.InitialImage = global::BubbleTrouble.Properties.Resources.money;
            this.money1.Location = new System.Drawing.Point(332, 12);
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(79, 54);
            this.money1.TabIndex = 5;
            this.money1.TabStop = false;
            // 
            // player
            // 
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.InitialImage = ((System.Drawing.Image)(resources.GetObject("player.InitialImage")));
            this.player.Location = new System.Drawing.Point(241, 291);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(80, 80);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            this.player.Click += new System.EventHandler(this.player_Click);
            // 
            // pauseToolStripMenuItem1
            // 
            this.pauseToolStripMenuItem1.Name = "pauseToolStripMenuItem1";
            this.pauseToolStripMenuItem1.Size = new System.Drawing.Size(50, 20);
            this.pauseToolStripMenuItem1.Text = "Pause";
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.stopToolStripMenuItem.Text = "Stop";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.gradient;
            this.ClientSize = new System.Drawing.Size(719, 424);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.player);
            this.Controls.Add(this.money1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.money1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeControlsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBarTime;
        private System.Windows.Forms.ToolStripProgressBar progressBarLives;
        private System.Windows.Forms.PictureBox money1;
        private System.Windows.Forms.ToolStripStatusLabel labelPoints;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
    }
}

