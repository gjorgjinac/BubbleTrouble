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
        Dictionary<String, List<Bitmap>> minions;

        Keys left = Keys.Left, right = Keys.Right, up = Keys.Up, down = Keys.Down, shoot = Keys.Space;
        String FileName;
        Game game;
        String selectedPlayer;
        Boolean goodieUnique;
        Rectangle playground;


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
            minions = new Dictionary<string, List<Bitmap>>();
            minions.Add("soldierMale", new List<Bitmap> () { Properties.Resources.soldier, Properties.Resources.soldier_dead, Properties.Resources.soldier_with_shield, Properties.Resources.soldier_screaming , Properties.Resources.military_base});
            minions.Add("soldierFemale", new List<Bitmap>() { Properties.Resources.soldier_female, Properties.Resources.soldier_female_dead, Properties.Resources.soldier_female_shield, Properties.Resources.soldier_female_screaming, Properties.Resources.military_base });

            musicOn = true;
            this.Text = "Bubble Trouble";

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
            selectedPlayer = "soldierFemale";
            this.BackgroundImage = minions[selectedPlayer].ElementAt(4);
            player.Image = minions[selectedPlayer].ElementAt(0);
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
                tankStand.Visible = true;
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
                tankStand.Visible = false;
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
                tankStand.Visible = false;
                brickWallDown.Visible = true;
                brickWallUp.Visible = true;
                brickWallUp.Height = 50;
            }






            resetGoodies();
            shieldTime = 0;
            controlLock = false;
            player.Image = minions[selectedPlayer].ElementAt(0);
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
            if (musicOn) sad_violin.Play();

            timer1.Stop();
            player.Image = minions[selectedPlayer].ElementAt(1);
            livesLeft--;
            String msg = "";

            if (progressBarTime.Value > 0 && game.timeMili > 10) msg = "Player killed.";
            else msg = "Time ran out.";


            if (MessageBox.Show(String.Format("{0} You got {1} points! Save score?", msg, game.points), "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                HighScores form = new HighScores();

                form.AddPlayer(game.points);
                form.ShowDialog();

            }
            sad_violin.Stop();


            progressBarLives.Value = game.livesLeft;
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
                            player.Image = minions[selectedPlayer].ElementAt(3);

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
            { game.AddBullet(tank.Location.X, tank.Location.Y + 30); }
        //    if (shieldTime <= 0 && !controlLock) player.Image = Properties.Resources.minion;
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
                    player.Image = minions[selectedPlayer].ElementAt(2);
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
            {
                game.obstacles.Move(Width, Height, platform.Width, platform.Location.Y);
                game.MoveBombs(platform.Width, platform.Location.Y);

            }
            if (level==2)
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
                game.MoveBombs(Width,Height);
            }
            if (level == 3)
            {
                //   brickWallUp.Location = new Point(brickWallUp.Location.X, brickWallUp.Location.Y + 1);
                brickWallUp.Height++;
               game.obstacles.Move(Width, Height, 0, brickWallUp.Location.Y+brickWallUp.Height);
                game.MoveBombs(Width, brickWallUp.Location.Y + brickWallUp.Height);

            }
            //  game.MoveBombs(platform.Width, platform.Location.Y);
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

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {


        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void statusStrip1_Paint(object sender, PaintEventArgs e)
        {
           
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

        private void muteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            musicOn = !musicOn;
            if (muteToolStripMenuItem.Text.Equals("Mute")) { muteToolStripMenuItem.Text = "Unmute"; bgmusic.Stop(); }
            else { muteToolStripMenuItem.Text = "Mute"; bgmusic.Play(); }
        }

        private void level1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            level = 1;
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
            livesLeft = 5;
            lifeLost();

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
            Controls form = new Controls(left, right, up, down, shoot);
            if (form.ShowDialog() == DialogResult.OK)

            {
                left = form.keys.ElementAt(0);
                right = form.keys.ElementAt(1);
                up = form.keys.ElementAt(2);
                down = form.keys.ElementAt(3);
                shoot = form.keys.ElementAt(4);

            }

            timer1.Start();

        }
    }
}
