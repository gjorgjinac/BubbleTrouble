namespace BubbleTrouble
{
    partial class Manual
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
            this.label1 = new System.Windows.Forms.Label();
            this.right = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.left = new System.Windows.Forms.PictureBox();
            this.manualText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.right)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DeepPink;
            this.label1.Location = new System.Drawing.Point(217, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "HOW TO PLAY";
            // 
            // right
            // 
            this.right.Image = global::BubbleTrouble.Properties.Resources.arrow_right1;
            this.right.Location = new System.Drawing.Point(445, 173);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(74, 50);
            this.right.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right.TabIndex = 2;
            this.right.TabStop = false;
            this.right.Click += new System.EventHandler(this.right_Click);
            this.right.MouseLeave += new System.EventHandler(this.right_MouseLeave);
            this.right.MouseHover += new System.EventHandler(this.right_MouseHover);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BubbleTrouble.Properties.Resources.nightclub_background;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(650, 400);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // left
            // 
            this.left.Image = global::BubbleTrouble.Properties.Resources.arrow_left1;
            this.left.Location = new System.Drawing.Point(92, 173);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(74, 50);
            this.left.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left.TabIndex = 4;
            this.left.TabStop = false;
            this.left.Click += new System.EventHandler(this.left_Click);
            this.left.MouseLeave += new System.EventHandler(this.left_MouseLeave);
            this.left.MouseHover += new System.EventHandler(this.left_MouseHover);
            // 
            // manualText
            // 
            this.manualText.BackColor = System.Drawing.Color.Black;
            this.manualText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.manualText.ForeColor = System.Drawing.Color.White;
            this.manualText.Location = new System.Drawing.Point(183, 99);
            this.manualText.Name = "manualText";
            this.manualText.Padding = new System.Windows.Forms.Padding(10);
            this.manualText.Size = new System.Drawing.Size(245, 209);
            this.manualText.TabIndex = 5;
            this.manualText.Text = "label2";
            // 
            // Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.nightclub_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(634, 362);
            this.Controls.Add(this.manualText);
            this.Controls.Add(this.left);
            this.Controls.Add(this.right);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Manual";
            this.Text = "Manual";
            ((System.ComponentModel.ISupportInitialize)(this.right)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.left)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox right;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox left;
        private System.Windows.Forms.Label manualText;
    }
}