namespace BubbleTrouble
{
    partial class Controls
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
            this.textBoxLeft = new System.Windows.Forms.TextBox();
            this.textBoxRight = new System.Windows.Forms.TextBox();
            this.textBoxUp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.textBoxShoot = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLeft
            // 
            this.textBoxLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLeft.Location = new System.Drawing.Point(203, 37);
            this.textBoxLeft.Name = "textBoxLeft";
            this.textBoxLeft.Size = new System.Drawing.Size(74, 38);
            this.textBoxLeft.TabIndex = 0;
            this.textBoxLeft.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxLeft_KeyDown);
            // 
            // textBoxRight
            // 
            this.textBoxRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxRight.Location = new System.Drawing.Point(203, 97);
            this.textBoxRight.Name = "textBoxRight";
            this.textBoxRight.Size = new System.Drawing.Size(74, 38);
            this.textBoxRight.TabIndex = 2;
            this.textBoxRight.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxRight_KeyDown);
            // 
            // textBoxUp
            // 
            this.textBoxUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxUp.Location = new System.Drawing.Point(203, 155);
            this.textBoxUp.Name = "textBoxUp";
            this.textBoxUp.Size = new System.Drawing.Size(74, 38);
            this.textBoxUp.TabIndex = 4;
            this.textBoxUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxUp_KeyDown);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(97, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Move down";
            // 
            // textBoxDown
            // 
            this.textBoxDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxDown.Location = new System.Drawing.Point(203, 214);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.Size = new System.Drawing.Size(74, 38);
            this.textBoxDown.TabIndex = 6;
            this.textBoxDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxDown_KeyDown);
            // 
            // textBoxShoot
            // 
            this.textBoxShoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxShoot.Location = new System.Drawing.Point(203, 275);
            this.textBoxShoot.Name = "textBoxShoot";
            this.textBoxShoot.Size = new System.Drawing.Size(74, 38);
            this.textBoxShoot.TabIndex = 8;
            this.textBoxShoot.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxShoot_KeyDown);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(97, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Move up";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(97, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Move left";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(97, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Move right";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(97, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Shoot";
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(392, 214);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 13;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(392, 243);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 14;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(392, 272);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 15;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // Controls
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BubbleTrouble.Properties.Resources.gradient1;
            this.ClientSize = new System.Drawing.Size(572, 361);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxShoot);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDown);
            this.Controls.Add(this.textBoxUp);
            this.Controls.Add(this.textBoxRight);
            this.Controls.Add(this.textBoxLeft);
            this.Name = "Controls";
            this.Text = "Controls";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLeft;
        private System.Windows.Forms.TextBox textBoxRight;
        private System.Windows.Forms.TextBox textBoxUp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.TextBox textBoxShoot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button buttonReset;
    }
}