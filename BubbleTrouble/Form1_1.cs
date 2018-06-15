using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Form1 : Form
    {
        String FileName;
        Game game;
        List<PictureBox> money;
        Boolean moneyUnique;
     
        int moneyStand;
        int livesLeft;
        
        
        public Form1()
        {
            InitializeComponent();
            livesLeft = 5;
            DoubleBuffered = true;
            newGame();
            player.BackColor = Color.Transparent;
            money1.BackColor = Color.Transparent;
         

        }
        public void newGame()
        {

          
            livesLeft = 5;
            lifeLost();
        }

        public void lifeLost()
        {
              game = new Game();
            money1.Visible = false;
            timer1.Start();
            progressBarLives.Value = livesLeft;
            progressBarTime.Value = 60;
            money = new List<PictureBox>();
            moneyUnique = true;
            moneyStand = 0;
            game.livesLeft = livesLeft;
         
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && player.Location.X > 0)
            {
                player.Location = new Point(player.Location.X - 10, player.Location.Y);

            }
            if (e.KeyCode == Keys.Right && player.Location.X < Width - 80)
            {
                player.Location = new Point(player.Location.X + 10, player.Location.Y);

            }
            if (e.KeyCode == Keys.Up)
            {
                game.AddBomb(player.Location);


            }
            Invalidate(true);
        }
        public void throwMoney(double x, double y)
        {
           
            money1.Location = new Point((int) (x / 2 * Width), (int) y);
            money1.Visible = true;
            //money.Add(p);
            moneyUnique = false;
            //   catch (Exception ex) { }
        }
      
      

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.CheckHits();
            Random random = new Random();
            if (game.obstacles.isHit(player.Location, Width, this.Height))
            {
                timer1.Stop();
                livesLeft--;
                MessageBox.Show("Life lost. Chances left: " + livesLeft);
                
                progressBarLives.Value = game.livesLeft;
                lifeLost();

            }
            if (game.checkEnd())
            {
                timer1.Stop();
                MessageBox.Show("Game over!");
            }
            game.decreaseTime();

            if (game.timeMili % 100 == 0) { progressBarTime.Value--;



            }
            if (random.Next(10) == 1 && moneyUnique)
            { throwMoney(random.NextDouble(), 0); }
            
            if (money1.Location.Y< Height - 160)

            { money1.Location = new Point(money1.Location.X, money1.Location.Y + 10); }
            else
            {
                if (moneyStand > 300)
                { enableMoney(); }
                moneyStand++;
            }


            if (Math.Abs(player.Location.X - money1.Location.X) < 80 && Math.Abs(player.Location.Y  - money1.Location.Y) < 80)
            {
                game.points += 100;

                enableMoney();
            }

        

            labelPoints.Text = String.Format("Points: {0} ", game.points);



                game.obstacles.Move(Width,Height);
            Invalidate(true);
        }
        public void enableMoney()
        {
            moneyUnique = true; money1.Visible = false; moneyStand = 0;
            money1.Location = new Point(0, 0);

        }
      

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
            game.obstacles.Draw(e.Graphics);
            game.updateBombs(e.Graphics);

        }

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bubble Trouble (*.bbt)|*.bbt";
                saveFileDialog.Title = "Open Bubble Trouble File";
                saveFileDialog.FileName = FileName;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }


            try
            {
                using (FileStream stream = new FileStream(FileName, FileMode.Create))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, game);
                    FileName = null;
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to complete saving");
            }
            Invalidate(true);
        }

        private void openFile()
        {
            if (FileName == null)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Bubble Trouble (*.bbt)|*.bbt";
                openFileDialog.Title = "Open Bubble Trouble File";
            
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = openFileDialog.FileName;

                }
            }


            try
            {
                using (FileStream stream = new FileStream(FileName, FileMode.Open))
                {
                    IFormatter formatter = new BinaryFormatter();
                    game = (Game)formatter.Deserialize(stream);
                }

            }
            catch (Exception exception)
            {
                MessageBox.Show("Unable to complete opening");
            }
            FileName = null;
            Invalidate(true);

        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            if (pauseToolStripMenuItem.Text.Equals("Pause"))
                pauseToolStripMenuItem.Text = "Start";
            else pauseToolStripMenuItem.Text = "Pause";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newGame();

        }

        private void changeControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
           
            
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
            progressBarTime.Value--;

            labelPoints.Text = String.Format("Points: {0} ", game.points);
        }
    }
}
