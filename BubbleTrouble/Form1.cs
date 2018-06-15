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
        Keys left = Keys.Left, right = Keys.Right, up = Keys.Up, down = Keys.Down, shoot = Keys.Space;
        String FileName;
        Game game;
        List<PictureBox> money;
        Boolean goodieUnique;
        Boolean controlLock;
        PictureBox activeGoodie;
        int goodieStand;
        int livesLeft;
        int level;
        int totalPoints;
        List<PictureBox> goodies;
        int shieldTime;
        public Form1()
        {
            InitializeComponent();
            livesLeft = 5;
            level = 1;
            DoubleBuffered = true;
            goodies = new List<PictureBox>() { money1, pizza, coins, time, shield };
            newGame();
            player.BackColor = Color.Transparent;
            ladder.BackColor = Color.Transparent;

            totalPoints = 0;
            FileName = null;
        }
        public void resetGoodies()
        {
            foreach (PictureBox goodie in goodies)
            {
                goodie.BackColor = Color.Transparent;
                goodie.Location = new Point(0, 0);
                goodie.Visible = false;
            }
            shieldTime = 0;

        }



        public void newGame()
        {


            livesLeft = 5;
            lifeLost();




        }

        public void resetEnv()
        {
            if (level == 1)
            {
                platform.Visible = true;
                ladder.Visible = true;
                barrier1.Visible = false;
                barrier1_1.Visible = false;
                barrier2.Visible = false;
                barrier2_1.Visible = false;

            }
            if (level == 2)
            {
                platform.Visible = false;
                ladder.Visible = false;
                barrier1.Visible = true;
                barrier2.Visible = true;
                barrier2_1.Visible = true;
                barrier1_1.Visible = true;

            }
            resetGoodies();
            shieldTime = 0;
            controlLock = false;
            player.Image = Properties.Resources.minion;
            activeGoodie = null;
            timer1.Start();

            progressBarTime.Value = progressBarTime.Maximum;
            progressBarLives.Value = livesLeft;


            goodieUnique = true;
            goodieStand = 0;
            game.livesLeft = livesLeft;
        }



        public void lifeLost()
        {
            game = new Game(level);
            if (livesLeft > 0) resetEnv();
            else
            {
                if (MessageBox.Show("You have no more lives left. GAME OVER \n START NEW GAME?", "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newGame();
                }
            }
            player.Location = new Point(100, Height - 175);






        }
        public void WonGame()
        {
            timer1.Stop();


            game.points += progressBarTime.Value * 10;
            totalPoints += game.points;

            if (MessageBox.Show(String.Format("You won level {0} with a total of {1} points! Save score?", level, totalPoints), "You won", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HighScores form = new HighScores();

                form.AddPlayer(game.points);
                form.ShowDialog();
            }
            if (level == 1) level++;
            newGame();
        }

        public void endGame()
        {
            timer1.Stop();
            player.Image = Properties.Resources.minion_dead;
            livesLeft--;
            String msg = "";
            if (progressBarTime.Value > 0 && game.timeMili>10) msg = "Player killed.";
            else msg = "Time ran out.";


            if (MessageBox.Show(String.Format("{0} You got {1} points! Save score?", msg, game.points), "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HighScores form = new HighScores();

                form.AddPlayer(game.points);
                form.ShowDialog();
            }



            progressBarLives.Value = game.livesLeft;
            lifeLost();

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!controlLock)
            {
                if (e.KeyCode == shoot)
                {
                    game.AddBomb(player.Location);


                }

                if (level == 1)
                {
                    if (e.KeyCode == left && player.Location.X > 0)
                    {
                        player.Location = new Point(player.Location.X - 10, player.Location.Y);

                    }
                    if (e.KeyCode == right && player.Location.X < Width - 80)
                    {
                        player.Location = new Point(player.Location.X + 10, player.Location.Y);

                    }

                    if (player.Location.X - ladder.Location.X < 100 && player.Location.Y + 70 > platform.Location.Y)
                    {
                        if (e.KeyCode == up)
                        {
                            player.Location = new Point(player.Location.X, player.Location.Y - 10);
                        }


                    }
                    if (player.Location.X - ladder.Location.X < 100 && player.Location.Y + 70 < Height - 100)
                    {
                        if (e.KeyCode == down)
                        {
                            player.Location = new Point(player.Location.X, player.Location.Y + 10);
                        }


                    }

                    if ((player.Location.Y < platform.Location.Y && player.Location.X > 300)
                        || (player.Location.Y > platform.Location.Y && player.Location.Y < Height - 175 && player.Location.X > ladder.Location.X + ladder.Width - 30))


                    {
                        if (e.KeyCode == right)
                        {
                            controlLock = true;
                            player.Image = Properties.Resources.minion_screaming;



                        }


                    }
                }

                if (level == 2)
                {
                    if (e.KeyCode == left && player.Location.X > 0)
                    {
                        player.Location = new Point(player.Location.X - 10, player.Location.Y);

                    }
                    if (e.KeyCode == right && player.Location.X < Width - 80)
                    {
                        Boolean canMove = false;

                        if (player.Location.X < barrier1_1.Location.X - barrier1_1.Width - 40) canMove = true;

                        if ((!barrier1_1.Visible && !barrier2_1.Visible)) canMove = true;



                        if ((player.Location.X < barrier2_1.Location.X - barrier2_1.Width - 40 && !barrier1_1.Visible))
                            canMove = true;
                        if (canMove)
                            player.Location = new Point(player.Location.X + 10, player.Location.Y);

                    }








                }

            }


            Invalidate(true);
        }
        public void throwGoodie(double x, double y, int index)
        {
            activeGoodie = goodies.ElementAt(index);
            activeGoodie.Location = new Point((int)(x / 2 * Width), (int)y);
            activeGoodie.Visible = true;

            goodieUnique = false;

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            game.MoveBombs(platform.Width, platform.Location.Y);
            game.CheckHits();

            Random random = new Random();
            if (shieldTime <= 0 && game.PlayerHit(player.Location, Width, this.Height))
            {
                endGame();

            }
            if (controlLock)
            {


                if (player.Location.Y < Height - 175)
                    player.Location = new Point(player.Location.X, player.Location.Y + 20);
                else
                {
                    endGame();
                }
            }


            if (game.checkEnd() || progressBarTime.Value == 0)
            {
                if (game.obstacles.ObstacleList.Count == 0 && progressBarTime.Value > 0)
                {
                    if (level == 1)
                    {
                        if (game.specialObstaclePassed) WonGame();
                        else endGame();
                    }
                    else
                    {
                        WonGame();
                    }

                }
                else endGame();
            }

            game.decreaseTime();
            if (game.timeMili % 10 == 0 && progressBarTime.Value > 0)
            {
                progressBarTime.Value--;
                shieldTime--;


            }
            if (shieldTime <= 0) player.Image = Properties.Resources.minion;
            if (random.Next(10) == 1 && goodieUnique)
            { throwGoodie(random.NextDouble(), 0, random.Next(5)); }

            if (activeGoodie != null && activeGoodie.Location.Y < Height - 160)

            {
                activeGoodie.Location = new Point(activeGoodie.Location.X, activeGoodie.Location.Y + 10);
            }
            else
            {
                if (goodieStand > 30)
                { enableGoodie(); }
                goodieStand++;
            }


            if (activeGoodie != null && Math.Abs(player.Location.X - activeGoodie.Location.X) < 80 && Math.Abs(player.Location.Y - activeGoodie.Location.Y) < 80)
            {
                if (activeGoodie == shield)
                {
                    shieldTime = 10;
                    player.Image = Properties.Resources.minion_shield;
                }
                else if (activeGoodie == pizza)
                {
                    livesLeft++;
                }
                else if (activeGoodie == time)
                {
                    if (progressBarTime.Value > 19) { progressBarTime.Value = 30; game.timeMili = 300; }
                    else { progressBarTime.Value += 10; game.timeMili += 100; }
                }
                else if (activeGoodie == money1)
                {
                    game.points += 100;
                }
                else if (activeGoodie == coins)
                {
                    game.points += 30;
                }




                enableGoodie();
            }



            labelPoints.Text = String.Format("Points: {0} ", game.points);


            if (level == 1)
            { game.obstacles.Move(Width, Height, platform.Width, platform.Location.Y); }
            else
            {
                game.obstacles.Move(

                      Width, Height, new List<int>() { 0, barrier1.Location.X, barrier1.Location.X + barrier1.Width, barrier2.Location.X, barrier2.Location.X + barrier2.Width, Width });

                if (game.obstacles.eliminated(0))
                {
                    barrier1_1.Visible = false;
                }
                if (game.obstacles.eliminated(1))
                {
                    barrier2_1.Visible = false;
                }

            }


            Invalidate(true);
        }
        public void enableGoodie()
        {

            if (activeGoodie != null)
            {
                activeGoodie.Location = new Point(0, 0);
                activeGoodie.Visible = false;
                activeGoodie = null;
            }
            goodieUnique = true;
            goodieStand = 0;
            
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {


            game.updateBombs(e.Graphics, Height - 100);

        }



        private void player_Click(object sender, EventArgs e)
        {

        }

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Bubble Trouble File (*.btf)|*.btf";
                saveFileDialog.Title = "Save Bubble Trouble File";
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
                    game.playerPosition = player.Location;
                    game.livesLeft = livesLeft;
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
                openFileDialog.Filter = "Bubble Trouble File (*.btf)|*.btf";
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
                    player.Location = game.playerPosition;
                    livesLeft = game.livesLeft;
                    resetEnv();
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
            level = 1;
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
            //progressBarTime.Value--;
            progressBarLives.Value = livesLeft;
            labelPoints.Text = String.Format("Points: {0} ", game.points);
            labelTime.Text = String.Format("Time left: {0}s", progressBarTime.Value);
            labelLives.Text = String.Format("Lives left: {0}", livesLeft);
        }

        private void money1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            saveFile();
            timer1.Start();
        }

        private void openGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            openFile();
            timer1.Start();
        }

        private void level2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            endGame();
            level = 2;
            newGame();
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            HighScores form = new HighScores();
            form.Show();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls form = new Controls(left, right, up, down, shoot);
            if (form.ShowDialog() == DialogResult.OK)

            {
                left = form.keys.ElementAt(0);
                right = form.keys.ElementAt(1);
                up = form.keys.ElementAt(2);
                down = form.keys.ElementAt(3);
                shoot = form.keys.ElementAt(4);

            }



        }
    }
}
