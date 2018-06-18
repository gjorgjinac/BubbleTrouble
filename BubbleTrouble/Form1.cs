using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Form1 : Form
    {
        Dictionary<String, Minion> minions;
        List<PictureBox> lives;
        Keys left = Keys.Left, right = Keys.Right, up = Keys.Up, down = Keys.Down, shoot = Keys.Space;
        String FileName;
        Game game;
        String selectedPlayer;
        Boolean goodieUnique;
        Rectangle playground;
        int difficulty;

        Boolean controlLock;
        PictureBox activeGoodie;
        int goodieStand;
        int livesLeft;
        int level;
        int totalPoints;
        List<PictureBox> goodies;
        System.Media.SoundPlayer bgmusic = new System.Media.SoundPlayer(Properties.Resources.spongebob_bgmusc);
        System.Media.SoundPlayer bulletSound = new System.Media.SoundPlayer(Properties.Resources.bullet);
        System.Media.SoundPlayer sad_violin = new System.Media.SoundPlayer(Properties.Resources.sad_violin);
        Boolean musicOn;
        int shieldTime;
        public Form1()
        {

            InitializeComponent();
            playground = new Rectangle(10, 10, Width - 40, 380);
            lives = new List<PictureBox>() { life1, life2, life3, life4, life5, life6, life7, life8, life9, life10 };
            minions = new Dictionary<string, Minion>();
            minions.Add("John", new Minion("John", Properties.Resources.soldier, Properties.Resources.soldier_screaming, Properties.Resources.soldier_dead, Properties.Resources.soldier_with_shield, Properties.Resources.soldier_glow, Properties.Resources.soldier_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Mary", new Minion("Mary", Properties.Resources.soldier_female, Properties.Resources.soldier_female_screaming, Properties.Resources.soldier_female_dead, Properties.Resources.soldier_female_shield, Properties.Resources.soldier_female_glow, Properties.Resources.soldier_female_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Oliver", new Minion("Oliver", Properties.Resources.arrow, Properties.Resources.arrow_screaming, Properties.Resources.arrow_dead, Properties.Resources.arrow_shield, Properties.Resources.arrow_glow, Properties.Resources.arrow_selected, new List<Image>() { Properties.Resources.arrow_background }));
            minions.Add("Dinah", new Minion("Dinah", Properties.Resources.canary, Properties.Resources.canary_screaming, Properties.Resources.canary_dead, Properties.Resources.canary_shield, Properties.Resources.canary_glow, Properties.Resources.canary_selected, new List<Image>() { Properties.Resources.arrow_background }));
            minions.Add("Thor", new Minion("Thor", Properties.Resources.thor, Properties.Resources.thor_screaming, Properties.Resources.thor_dead, Properties.Resources.thor_shield, Properties.Resources.thor_glow, Properties.Resources.thor_selected, new List<Image>() { Properties.Resources.cave_background1 }));
            minions.Add("Natasha", new Minion("Natasha", Properties.Resources.blackwidow, Properties.Resources.blackwidow_screaming, Properties.Resources.blackwidow_dead, Properties.Resources.blackwidow_shield, Properties.Resources.blackwidow_glow, Properties.Resources.blackwidow_selected, new List<Image>() { Properties.Resources.old_town_background }));
            minions.Add("Tony", new Minion("Tony", Properties.Resources.stark, Properties.Resources.stark_screaming, Properties.Resources.stark_dead, Properties.Resources.stark_shield, Properties.Resources.stark_glow, Properties.Resources.stark_selected, new List<Image>() { Properties.Resources.stark_background }));
            minions.Add("Wanda", new Minion("Wanda", Properties.Resources.scarlet, Properties.Resources.scarlet_screaming, Properties.Resources.scarlet_dead, Properties.Resources.scarlet_shield, Properties.Resources.scarlet_glow, Properties.Resources.scarlet_selected, new List<Image>() { Properties.Resources.darkyard_background }));
            minions.Add("Bruce", new Minion("Bruce", Properties.Resources.batman, Properties.Resources.batman_screaming, Properties.Resources.batman_dead, Properties.Resources.batman_shield, Properties.Resources.batman_glow, Properties.Resources.batman_selected, new List<Image>() { Properties.Resources.bat1_background }));
            minions.Add("Diana", new Minion("Diana", Properties.Resources.diana, Properties.Resources.diana_screaming, Properties.Resources.diana_dead, Properties.Resources.diana_shield, Properties.Resources.diana_glow, Properties.Resources.diana_selected, new List<Image>() { Properties.Resources.waterfal_backgound }));
            minions.Add("Barry", new Minion("Barry", Properties.Resources.flash, Properties.Resources.flash_screaming, Properties.Resources.flash_dead, Properties.Resources.flash_shield, Properties.Resources.flash_glow, Properties.Resources.flash_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Harley", new Minion("Harley", Properties.Resources.harley, Properties.Resources.harley_screaming, Properties.Resources.harley_dead, Properties.Resources.harley_shield, Properties.Resources.harley_glow, Properties.Resources.harley_selected, new List<Image>() { Properties.Resources.nightclub_background, Properties.Resources.old_town_background }));

            musicOn = true;
            this.Text = "Bubble Trouble";
            difficulty = 2;
            livesLeft = 5;
            level = 1;
            DoubleBuffered = true;
            goodies = new List<PictureBox>() { money1, pizza, coins, time, shield };

            player.BackColor = Color.Transparent;
            ladder.BackColor = Color.Transparent;

            tank.BackColor = Color.Transparent;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            totalPoints = 0;
            FileName = null;
            selectedPlayer = "John";

            BackgroundImage = playGroundBox.Image = minions[selectedPlayer].backgrounds.ElementAt((level - 1) % (minions[selectedPlayer].backgrounds.Count));

            player.Image = minions[selectedPlayer].normal;
            player.BackColor = Color.Transparent;
            newGame();
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
            if (musicOn) bgmusic.Play();

            if (level == 1)
            {
                platform.Visible = true;
                ladder.Visible = true;
                barrier1.Visible = false;
                barrier1_1.Visible = false;
                barrier2.Visible = false;
                barrier2_1.Visible = false;
                tank.Visible = true;
              
                brickWallDown.Visible = false;
                brickWallUp.Visible = false;

            }
            if (level == 2)
            {
                platform.Visible = false;
                ladder.Visible = false;
                barrier1.Visible = true;
                barrier2.Visible = true;
                barrier2_1.Visible = true;
                barrier1_1.Visible = true;
                tank.Visible = false;
               
                brickWallDown.Visible = false;
                brickWallUp.Visible = false;

            }
            if (level == 3)
            {
                platform.Visible = false;
                ladder.Visible = false;
                barrier1.Visible = false;
                barrier2.Visible = false;
                barrier2_1.Visible = false;
                barrier1_1.Visible = false;
                tank.Visible = false;
             
                brickWallDown.Visible = true;
                brickWallUp.Visible = true;
                brickWallUp.Height = 50;

            }


            BackgroundImage = playGroundBox.Image = minions[selectedPlayer].backgrounds.ElementAt((level - 1) % (minions[selectedPlayer].backgrounds.Count));





            resetGoodies();
            shieldTime = 0;
            controlLock = false;
            player.Image = minions[selectedPlayer].now;
            activeGoodie = null;
            timer1.Start();
            pauseToolStripMenuItem1.Text = "Pause";
            progressBarTime.Value = progressBarTime.Maximum;



            goodieUnique = true;
            goodieStand = 0;
            game.livesLeft = livesLeft;
        }



        public void lifeLost()
        {


            game = new Game(level, difficulty);
            if (livesLeft > 0) resetEnv();
            else
            {
                if (MessageBox.Show("You have no more lives left. GAME OVER \n START NEW GAME?", "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    newGame();
                    level = 1;
                    totalPoints = 0;
                }
                else
                {
                    this.Close();
                }
            }
            player.Location = new Point(150, Height - 175);
            for (int i = 0; i < 10; i++)
            {
                if (i < livesLeft) lives.ElementAt(i).Visible = true;
                else lives.ElementAt(i).Visible = false;
            }





        }
        public void WonGame()
        {
            timer1.Stop();


            game.points += progressBarTime.Value * 10;
            totalPoints += game.points;

            if (MessageBox.Show(String.Format("You won level {0} with a total of {1} points! Save score?", level, totalPoints), "You won", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HighScores form = new HighScores();

                form.AddPlayer(totalPoints);
                form.ShowDialog();
            }
            if (level < 3) level++;
            newGame();
        }

        public void endGame()
        {
            if (musicOn) sad_violin.Play();

            timer1.Stop();
            player.Image = minions[selectedPlayer].dead;
            livesLeft--;
            String msg = "";

            if (progressBarTime.Value > 0 && game.timeMili > 10) msg = "Player killed.";
            else msg = "Time ran out.";


            if (MessageBox.Show(String.Format("{0} You got {1} points! Save score?", msg, game.points), "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HighScores form = new HighScores();

                form.AddPlayer(totalPoints + game.points);
                form.ShowDialog();

            }
            sad_violin.Stop();





            lifeLost();

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {// Ako na igracot mu e dozvoleno da go pomrdne coveceto 
         //(Pri paganje od skala ili od platforma mora da poceka da stigne do zemjata, ne moze da "leta",
         //togas controlLock se postavuva na true i se zaklucuvaat kontrolite)
            if (!controlLock)
            {
                //Ako pristisnatoto kopce e kopceto nameneto za pukanje, se dodava bomba
                if (e.KeyCode == shoot)
                {
                    if (game.AddBomb(player.Location))
                        bulletSound.Play();


                }
                //Postojat razlicini implementacii za prvo i vtoro nivo bidejki ima razlicni barieri
                if (level == 1)
                {
                    //Pri dvizenje levo ili desno na prvo nivo, samo treba da se onevozmozi izleguvanjeto na igracot od prozorecot
                    if (e.KeyCode == left && player.Location.X > 0)
                    {
                        player.Location = new Point(player.Location.X - 10, player.Location.Y);

                    }
                    if (e.KeyCode == right && player.Location.X < Width - 80)
                    {
                        player.Location = new Point(player.Location.X + 10, player.Location.Y);

                    }
                    /*Igracot e pictureBox so visina 80
                    Za dvizenje nagore se proveruva dali igracot se naogja pod ili na skalata (razlikata megju X koordinatite da bide pomala od 100)
                   Vtoriot del od uslovot (player.Location.Y + 70 > platform.Location.Y) go sprecuva igracot da se iskaci nad nivoto na platformata, da ne lebdi
                     
                     */

                    if (player.Location.X - ladder.Location.X < 100 && player.Location.Y + 70 > platform.Location.Y)
                    {
                        if (e.KeyCode == up)
                        {
                            player.Location = new Point(player.Location.X, player.Location.Y - 10);
                        }
                    }
                    /*
                     * Za dvizenje nadolu isto taka se proveruva dali igracot se naogja na skalata 
                     *  Vtoriot del od uslovot (player.Location.Y + 70 < Height - 100) go sprecuva igracot da se spusti premnogu nisko vo prozorecot
                     */

                    if (player.Location.X - ladder.Location.X < 100 && player.Location.Y + 70 < Height - 100)
                    {
                        if (e.KeyCode == down)
                        {
                            player.Location = new Point(player.Location.X, player.Location.Y + 10);
                        }
                    }
                    /*
                     * Sledniot uslov go ovozmozuva pagjaneto na igracot ako toj pri simnuvanjeto izleze od granicite na skalata
                     * ili pri dvizenjeto desno na platformata izleze od nejziniot rab 
                     * 
                  **/

                    // Coveceto se naogja nad platformata i negovata X koordianta e pogolema od sirinata na platformata
                    if ((player.Location.Y < platform.Location.Y && player.Location.X > platform.Width)
                    //Coveceto se naogja pod platformata, a nad zemjata, a X koordinatata mu e pogolema od krajnata tocka na skalata 
                    //Izlezeno e od rabot na skalata
                        || (player.Location.Y > platform.Location.Y && player.Location.Y < Height - 175 && player.Location.X > ladder.Location.X + ladder.Width - 30))
                    {
                        if (e.KeyCode == right)
                        {
                            //Se zaklucuvaat kontrolite se dodeka coveceto ne padne na zemjata
                            controlLock = true;
                            //Se menuva izgledot na coveceto so otvorena usta kako da vreska
                            player.Image = minions[selectedPlayer].screaming;

                        }


                    }
                }
                //Vtoro nivo
                if (level == 2)
                { //Na vtoroto nivo ima samo dvizenja na levo i desno, poradi toa sto nema skali
                    //Za dvizenja na levata strana nema ogranicuvanja poradi toa sto barierite se naogjaat na desnata strana
                    // i istite ne se zatvoraat otkako ednas ke se otvorat
                    //Edinstveno samo se onevozmozuva coveceto da izleze od leviot rab na prozorecot
                    //Igracot samo se pridvizuva za 10 tocki na levo
                    if (e.KeyCode == left && player.Location.X > 0)
                    {
                        player.Location = new Point(player.Location.X - 10, player.Location.Y);
                    }
                    //Za dvizenja na desnata strana treba da se razgleda sostojbata na preprekite
                    if (e.KeyCode == right && player.Location.X < Width - 80)
                    {
                        //Voveduvame boolean promenliva sto ke odluci dali coveceto moze da se pomrdne nadesno
                        //Ja inicijalizirame na false bidejki ima pomalku situacii koga coveceto moze da se dvizi
                        Boolean canMove = false;
                        //Ako coveceto se naogja pred prvata prepreka, ne ne interesira sostojbata na preprekite
                        //I coveceto moze da se pomrdne na desno
                        if (player.Location.X < barrier1_1.Location.X - barrier1_1.Width - 40) canMove = true;

                        //Ako dvete prepreki se otvoreni, coveceto moze da se pomrdne
                        if ((!barrier1_1.Visible && !barrier2_1.Visible)) canMove = true;

                        //Ako prvata prepreka e otvorena, a coveceto se naogja pomegju prvata i vtorata prepreka ili pred prvata prepreka
                        //Toa moze da se pomrdne, i ne ne interesira sostojbata na 
                        //barrier2_1.Location.X - barrier2_1.Width - 40 e pozicijata na vtorata prepreka (-40 poradi radiusot na coveceto)
                        if ((player.Location.X < barrier2_1.Location.X - barrier2_1.Width - 40 && !barrier1_1.Visible))
                            canMove = true;

                        //Coveceto se pomrdnuva na desno
                        if (canMove)
                            player.Location = new Point(player.Location.X + 10, player.Location.Y);

                    }

                }


                if (level == 3)
                {
                    //Pri dvizenje levo ili desno na prvo nivo, samo treba da se onevozmozi izleguvanjeto na igracot od prozorecot
                    if (e.KeyCode == left && player.Location.X > 0)
                    {
                        player.Location = new Point(player.Location.X - 10, player.Location.Y);

                    }
                    if (e.KeyCode == right && player.Location.X < Width - 80)
                    {
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
            if (game.timeMili % 20 == 0 && tank.Visible)
            {
                game.AddBullet(tank.Location.X, tank.Location.Y + 30);
            }
            if (shieldTime <= 0 && !controlLock)
            {
                player.Image = minions[selectedPlayer].normal;
            }

            if (random.Next(10) == 1 && goodieUnique)
            {
                throwGoodie(random.NextDouble(), 0, random.Next(5));
            }

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
                    player.Image = minions[selectedPlayer].shield;
                }
                else if (activeGoodie == pizza)
                {

                    lives.ElementAt(livesLeft).Visible = true;
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
            {
                game.obstacles.Move(Width, Height, platform.Width, platform.Location.Y);
                game.MoveBombs(platform.Width, platform.Location.Y);

            }
            if (level == 2)
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
                game.MoveBombs(Width, Height);
            }
            if (level == 3)
            {
                //   brickWallUp.Location = new Point(brickWallUp.Location.X, brickWallUp.Location.Y + 1);
                // if (game.timeMili%3==0)

                game.obstacles.Move(Width, Height, 0, brickWallUp.Location.Y + brickWallUp.Height);
                game.MoveBombs(Width, brickWallUp.Location.Y + brickWallUp.Height);
                brickWallUp.Height++;
                if (brickWallUp.Location.Y + brickWallUp.Height >= player.Location.Y)
                    endGame();

            }

            game.CheckHits();



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
                    game.selectedPlayer = selectedPlayer;
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
              
            }  try
                {
                    using (FileStream stream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formatter = new BinaryFormatter();
                        game = (Game)formatter.Deserialize(stream);
                        player.Location = game.playerPosition;
                        livesLeft = game.livesLeft;
                        level = game.level;
                    selectedPlayer = game.selectedPlayer;
                    resetEnv();
                        //lifeLost();
                        

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
            if (pauseToolStripMenuItem1.Text.Equals("Pause"))
                pauseToolStripMenuItem1.Text = "Start";
            else pauseToolStripMenuItem1.Text = "Pause";
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
            livesLeft = 5;
            lifeLost();

        }

        private void changeControlsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }



        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {

            labelPoints.Text = String.Format("Points: {0} ", game.points);
            labelTime.Text = String.Format("Time left: {0}s", progressBarTime.Value);
            labelLives.Text = String.Format("Lives left: {0}", livesLeft);
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

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicOn = !musicOn;
            if (muteToolStripMenuItem.Text.Equals("Mute")) { muteToolStripMenuItem.Text = "Unmute"; bgmusic.Stop(); }
            else { muteToolStripMenuItem.Text = "Mute"; bgmusic.Play(); }
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
            selectedPlayer = "John";
            livesLeft = 5;
            lifeLost();
        }

        private void level2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            level = 2;

            livesLeft = 5;
            lifeLost();
        }
        private void level3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 3;
            selectedPlayer = "Diana";
            livesLeft = 5;
            lifeLost();

        }
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {



            game.updateBombs(e.Graphics, Height - 100);

        }


        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Manual form = new Manual();
            DialogResult d = form.ShowDialog();
            if (d == DialogResult.OK || d == DialogResult.Cancel)
                timer1.Start();
        }



        private void openGameToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            openFile();
            timer1.Start();
        }




        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            HighScores form = new HighScores();
            DialogResult d = form.ShowDialog();
            if (d == DialogResult.OK || d == DialogResult.Cancel)
                timer1.Start();
        }

        private void controlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            Controls form = new Controls(left, right, up, down, shoot, selectedPlayer, minions, difficulty);
            if (form.ShowDialog() == DialogResult.OK)

            {
                left = form.keys.ElementAt(0);
                right = form.keys.ElementAt(1);
                up = form.keys.ElementAt(2);
                down = form.keys.ElementAt(3);
                shoot = form.keys.ElementAt(4);
                difficulty = form.Difficulty;
                selectedPlayer = form.selectedPlayer;
                player.Image = minions[selectedPlayer].normal;
                BackgroundImage = playGroundBox.Image = minions[selectedPlayer].backgrounds.ElementAt((level - 1) % minions[selectedPlayer].backgrounds.Count);
                lifeLost();
            }

            timer1.Start();

        }
    }
}
