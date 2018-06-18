namespace BubbleTrouble
{
    partial class HighScores
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
            this.playerList = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.playGroundBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playGroundBox)).BeginInit();
            this.SuspendLayout();
            // 
            // playerList
            // 
            this.playerList.BackColor = System.Drawing.Color.Black;
            this.playerList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playerList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.playerList.ForeColor = System.Drawing.Color.DarkCyan;
            this.playerList.FormattingEnabled = true;
            this.playerList.ItemHeight = 16;
            this.playerList.Location = new System.Drawing.Point(60, 78);
            this.playerList.Margin = new System.Windows.Forms.Padding(10);
            this.playerList.Name = "playerList";
            this.playerList.Size = new System.Drawing.Size(245, 208);
            this.playerList.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(141, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Go back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // playGroundBox
            // 
            this.playGroundBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.playGroundBox.Image = global::BubbleTrouble.Properties.Resources.old_town_background;
            this.playGroundBox.Location = new System.Drawing.Point(-349, -9);
            this.playGroundBox.Margin = new System.Windows.Forms.Padding(0);
            this.playGroundBox.Name = "playGroundBox";
            this.playGroundBox.Size = new System.Drawing.Size(930, 379);
            this.playGroundBox.TabIndex = 26;
            this.playGroundBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Black;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DeepPink;
            this.label2.Location = new System.Drawing.Point(60, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(245, 37);
            this.label2.TabIndex = 27;
            this.label2.Text = "TOP 10 SCORES";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.gradient1;
            this.ClientSize = new System.Drawing.Size(377, 359);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.playerList);
            this.Controls.Add(this.playGroundBox);
            this.Name = "HighScores";
            this.Text = "HighScores";
            ((System.ComponentModel.ISupportInitialize)(this.playGroundBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox playerList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox playGroundBox;
        private System.Windows.Forms.Label label2;
    }
}