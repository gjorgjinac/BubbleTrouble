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
            this.player = new System.Windows.Forms.PictureBox();
            this.money1 = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelLives = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarLives = new System.Windows.Forms.ToolStripProgressBar();
            this.labelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarTime = new System.Windows.Forms.ToolStripProgressBar();
            this.labelPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.level2ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.level3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeControlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.muteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ladder = new System.Windows.Forms.PictureBox();
            this.platform = new System.Windows.Forms.PictureBox();
            this.barrier1 = new System.Windows.Forms.PictureBox();
            this.barrier2 = new System.Windows.Forms.PictureBox();
            this.barrier1_1 = new System.Windows.Forms.PictureBox();
            this.barrier2_1 = new System.Windows.Forms.PictureBox();
            this.pizza = new System.Windows.Forms.PictureBox();
            this.shield = new System.Windows.Forms.PictureBox();
            this.time = new System.Windows.Forms.PictureBox();
            this.coins = new System.Windows.Forms.PictureBox();
            this.tankStand = new System.Windows.Forms.PictureBox();
            this.tank = new System.Windows.Forms.PictureBox();
            this.brickWallUp = new System.Windows.Forms.PictureBox();
            this.brickWallDown = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.money1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ladder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shield)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coins)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankStand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brickWallUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brickWallDown)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Image = global::BubbleTrouble.Properties.Resources.soldier;
            this.player.InitialImage = ((System.Drawing.Image)(resources.GetObject("player.InitialImage")));
            this.player.Location = new System.Drawing.Point(126, 313);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(80, 80);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.player.TabIndex = 1;
            this.player.TabStop = false;
            // 
            // money1
            // 
            this.money1.BackgroundImage = global::BubbleTrouble.Properties.Resources.money;
            this.money1.InitialImage = global::BubbleTrouble.Properties.Resources.money;
            this.money1.Location = new System.Drawing.Point(287, 83);
            this.money1.Name = "money1";
            this.money1.Size = new System.Drawing.Size(79, 54);
            this.money1.TabIndex = 6;
            this.money1.TabStop = false;
            this.money1.Click += new System.EventHandler(this.money1_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelLives,
            this.progressBarLives,
            this.labelTime,
            this.progressBarTime,
            this.labelPoints});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(819, 36);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Paint += new System.Windows.Forms.PaintEventHandler(this.statusStrip1_Paint);
            // 
            // labelLives
            // 
            this.labelLives.Name = "labelLives";
            this.labelLives.Size = new System.Drawing.Size(65, 31);
            this.labelLives.Text = "Lives left: 5";
            // 
            // progressBarLives
            // 
            this.progressBarLives.Maximum = 10;
            this.progressBarLives.Name = "progressBarLives";
            this.progressBarLives.Size = new System.Drawing.Size(100, 30);
            // 
            // labelTime
            // 
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(65, 31);
            this.labelTime.Text = "Time left: s";
            // 
            // progressBarTime
            // 
            this.progressBarTime.Maximum = 30;
            this.progressBarTime.Name = "progressBarTime";
            this.progressBarTime.Size = new System.Drawing.Size(300, 30);
            // 
            // labelPoints
            // 
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(118, 31);
            this.labelPoints.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.level2ToolStripMenuItem,
            this.toolStripMenuItem2,
            this.highScoresToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(819, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openGameToolStripMenuItem1,
            this.saveGameToolStripMenuItem,
            this.newGameToolStripMenuItem1});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // openGameToolStripMenuItem1
            // 
            this.openGameToolStripMenuItem1.Name = "openGameToolStripMenuItem1";
            this.openGameToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.openGameToolStripMenuItem1.Text = "Open Game";
            this.openGameToolStripMenuItem1.Click += new System.EventHandler(this.openGameToolStripMenuItem1_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            this.saveGameToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.saveGameToolStripMenuItem.Text = "Save Game";
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // newGameToolStripMenuItem1
            // 
            this.newGameToolStripMenuItem1.Name = "newGameToolStripMenuItem1";
            this.newGameToolStripMenuItem1.Size = new System.Drawing.Size(137, 22);
            this.newGameToolStripMenuItem1.Text = "New Game";
            this.newGameToolStripMenuItem1.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // level2ToolStripMenuItem
            // 
            this.level2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.level1ToolStripMenuItem,
            this.level2ToolStripMenuItem1,
            this.level3ToolStripMenuItem});
            this.level2ToolStripMenuItem.Name = "level2ToolStripMenuItem";
            this.level2ToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.level2ToolStripMenuItem.Text = "Change level";
            // 
            // level1ToolStripMenuItem
            // 
            this.level1ToolStripMenuItem.Name = "level1ToolStripMenuItem";
            this.level1ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.level1ToolStripMenuItem.Text = "level 1";
            this.level1ToolStripMenuItem.Click += new System.EventHandler(this.level1ToolStripMenuItem_Click);
            // 
            // level2ToolStripMenuItem1
            // 
            this.level2ToolStripMenuItem1.Name = "level2ToolStripMenuItem1";
            this.level2ToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.level2ToolStripMenuItem1.Text = "level 2";
            this.level2ToolStripMenuItem1.Click += new System.EventHandler(this.level2ToolStripMenuItem1_Click);
            // 
            // level3ToolStripMenuItem
            // 
            this.level3ToolStripMenuItem.Name = "level3ToolStripMenuItem";
            this.level3ToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.level3ToolStripMenuItem.Text = "level 3";
            this.level3ToolStripMenuItem.Click += new System.EventHandler(this.level3ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(12, 20);
            // 
            // highScoresToolStripMenuItem
            // 
            this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
            this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.highScoresToolStripMenuItem.Text = "High scores";
            this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeControlsToolStripMenuItem,
            this.pauseToolStripMenuItem1,
            this.muteToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // changeControlsToolStripMenuItem
            // 
            this.changeControlsToolStripMenuItem.Name = "changeControlsToolStripMenuItem";
            this.changeControlsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.changeControlsToolStripMenuItem.Text = "Change controls";
            this.changeControlsToolStripMenuItem.Click += new System.EventHandler(this.controlsToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem1
            // 
            this.pauseToolStripMenuItem1.Name = "pauseToolStripMenuItem1";
            this.pauseToolStripMenuItem1.Size = new System.Drawing.Size(161, 22);
            this.pauseToolStripMenuItem1.Text = "Pause";
            this.pauseToolStripMenuItem1.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // muteToolStripMenuItem
            // 
            this.muteToolStripMenuItem.Name = "muteToolStripMenuItem";
            this.muteToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.muteToolStripMenuItem.Text = "Mute";
            this.muteToolStripMenuItem.Click += new System.EventHandler(this.muteToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ladder
            // 
            this.ladder.Image = global::BubbleTrouble.Properties.Resources.ladder;
            this.ladder.Location = new System.Drawing.Point(0, 183);
            this.ladder.Name = "ladder";
            this.ladder.Size = new System.Drawing.Size(145, 210);
            this.ladder.TabIndex = 9;
            this.ladder.TabStop = false;
            // 
            // platform
            // 
            this.platform.Image = global::BubbleTrouble.Properties.Resources.platform;
            this.platform.Location = new System.Drawing.Point(0, 161);
            this.platform.Name = "platform";
            this.platform.Size = new System.Drawing.Size(263, 36);
            this.platform.TabIndex = 10;
            this.platform.TabStop = false;
            // 
            // barrier1
            // 
            this.barrier1.Image = global::BubbleTrouble.Properties.Resources.barrier1;
            this.barrier1.Location = new System.Drawing.Point(269, 24);
            this.barrier1.Name = "barrier1";
            this.barrier1.Size = new System.Drawing.Size(38, 270);
            this.barrier1.TabIndex = 11;
            this.barrier1.TabStop = false;
            // 
            // barrier2
            // 
            this.barrier2.Image = global::BubbleTrouble.Properties.Resources.barrier1;
            this.barrier2.Location = new System.Drawing.Point(565, 24);
            this.barrier2.Name = "barrier2";
            this.barrier2.Size = new System.Drawing.Size(38, 270);
            this.barrier2.TabIndex = 13;
            this.barrier2.TabStop = false;
            // 
            // barrier1_1
            // 
            this.barrier1_1.Image = global::BubbleTrouble.Properties.Resources.barrier2;
            this.barrier1_1.Location = new System.Drawing.Point(269, 290);
            this.barrier1_1.Name = "barrier1_1";
            this.barrier1_1.Size = new System.Drawing.Size(38, 103);
            this.barrier1_1.TabIndex = 14;
            this.barrier1_1.TabStop = false;
            // 
            // barrier2_1
            // 
            this.barrier2_1.Image = global::BubbleTrouble.Properties.Resources.barrier2;
            this.barrier2_1.Location = new System.Drawing.Point(566, 290);
            this.barrier2_1.Name = "barrier2_1";
            this.barrier2_1.Size = new System.Drawing.Size(38, 103);
            this.barrier2_1.TabIndex = 15;
            this.barrier2_1.TabStop = false;
            // 
            // pizza
            // 
            this.pizza.Image = global::BubbleTrouble.Properties.Resources.pizza;
            this.pizza.Location = new System.Drawing.Point(420, 245);
            this.pizza.Name = "pizza";
            this.pizza.Size = new System.Drawing.Size(73, 74);
            this.pizza.TabIndex = 16;
            this.pizza.TabStop = false;
            // 
            // shield
            // 
            this.shield.Image = global::BubbleTrouble.Properties.Resources.shield;
            this.shield.Location = new System.Drawing.Point(366, 161);
            this.shield.Name = "shield";
            this.shield.Size = new System.Drawing.Size(67, 66);
            this.shield.TabIndex = 18;
            this.shield.TabStop = false;
            // 
            // time
            // 
            this.time.Image = global::BubbleTrouble.Properties.Resources.time;
            this.time.Location = new System.Drawing.Point(462, 96);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(71, 82);
            this.time.TabIndex = 19;
            this.time.TabStop = false;
            // 
            // coins
            // 
            this.coins.Image = global::BubbleTrouble.Properties.Resources.coins;
            this.coins.Location = new System.Drawing.Point(498, 176);
            this.coins.Name = "coins";
            this.coins.Size = new System.Drawing.Size(60, 69);
            this.coins.TabIndex = 20;
            this.coins.TabStop = false;
            // 
            // tankStand
            // 
            this.tankStand.Image = global::BubbleTrouble.Properties.Resources.platform;
            this.tankStand.Location = new System.Drawing.Point(708, 161);
            this.tankStand.Name = "tankStand";
            this.tankStand.Size = new System.Drawing.Size(100, 36);
            this.tankStand.TabIndex = 21;
            this.tankStand.TabStop = false;
            // 
            // tank
            // 
            this.tank.Image = global::BubbleTrouble.Properties.Resources.Tank;
            this.tank.Location = new System.Drawing.Point(708, 99);
            this.tank.Name = "tank";
            this.tank.Size = new System.Drawing.Size(100, 61);
            this.tank.TabIndex = 22;
            this.tank.TabStop = false;
            // 
            // brickWallUp
            // 
            this.brickWallUp.Image = global::BubbleTrouble.Properties.Resources.brick_wall;
            this.brickWallUp.Location = new System.Drawing.Point(-1, 24);
            this.brickWallUp.Name = "brickWallUp";
            this.brickWallUp.Size = new System.Drawing.Size(820, 41);
            this.brickWallUp.TabIndex = 23;
            this.brickWallUp.TabStop = false;
            // 
            // brickWallDown
            // 
            this.brickWallDown.Image = global::BubbleTrouble.Properties.Resources.brick_wall;
            this.brickWallDown.Location = new System.Drawing.Point(0, 415);
            this.brickWallDown.Name = "brickWallDown";
            this.brickWallDown.Size = new System.Drawing.Size(819, 37);
            this.brickWallDown.TabIndex = 24;
            this.brickWallDown.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.military_base;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(819, 467);
            this.Controls.Add(this.brickWallDown);
            this.Controls.Add(this.brickWallUp);
            this.Controls.Add(this.tank);
            this.Controls.Add(this.tankStand);
            this.Controls.Add(this.barrier2_1);
            this.Controls.Add(this.barrier1_1);
            this.Controls.Add(this.barrier2);
            this.Controls.Add(this.barrier1);
            this.Controls.Add(this.platform);
            this.Controls.Add(this.player);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.money1);
            this.Controls.Add(this.ladder);
            this.Controls.Add(this.time);
            this.Controls.Add(this.shield);
            this.Controls.Add(this.coins);
            this.Controls.Add(this.pizza);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Bubble trouble";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.money1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ladder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.platform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier1_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barrier2_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pizza)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shield)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.time)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coins)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tankStand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brickWallUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brickWallDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox money1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBarLives;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBarTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel labelPoints;
        private System.Windows.Forms.PictureBox ladder;
        private System.Windows.Forms.PictureBox platform;
        private System.Windows.Forms.PictureBox barrier1;
        private System.Windows.Forms.PictureBox barrier2;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem;
        private System.Windows.Forms.PictureBox barrier1_1;
        private System.Windows.Forms.PictureBox barrier2_1;
        private System.Windows.Forms.ToolStripStatusLabel labelTime;
        private System.Windows.Forms.ToolStripStatusLabel labelLives;
        private System.Windows.Forms.PictureBox pizza;
        private System.Windows.Forms.PictureBox shield;
        private System.Windows.Forms.PictureBox time;
        private System.Windows.Forms.PictureBox coins;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeControlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem muteToolStripMenuItem;
        private System.Windows.Forms.PictureBox tankStand;
        private System.Windows.Forms.PictureBox tank;
        private System.Windows.Forms.PictureBox brickWallUp;
        private System.Windows.Forms.PictureBox brickWallDown;
        private System.Windows.Forms.ToolStripMenuItem level1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem level2ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem level3ToolStripMenuItem;
    }
}