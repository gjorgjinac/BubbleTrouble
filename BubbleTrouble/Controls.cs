using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BubbleTrouble
{
    public partial class Controls : Form
    {
        public List<Keys> keys;
        public List<PictureBox> pictures;
        public String selectedPlayer;
        public PictureBox playerPicture;
        public int Difficulty { get; set; }
        
        Dictionary<String, Minion> minions;
        public Controls(Keys l, Keys r, Keys u, Keys d, Keys s, String player, Dictionary<String, Minion> mins)
        {


            InitializeComponent();
            
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            keys = new List<Keys>() { l, r, u, d, s };
            resetKeys();
            minions = mins;
            pictures = new List<PictureBox>() { John, Mary, Oliver, Dinah, Thor, Wanda, Tony, Natasha, Bruce, Diana, Barry, Harley };
            selectedPlayer = player;
            playerPicture = new PictureBox();

            foreach (PictureBox p in pictures)
            {
                p.BackColor = Color.Transparent;
                if (p.Name.Equals(selectedPlayer))
                {
                    playerPicture.Image = minions[selectedPlayer].selected;
                    p.Image = minions[selectedPlayer].selected;
                }


            }

        }

        public void resetKeys()
        {
            textBoxLeft.Text = keys.ElementAt(0).ToString();
            textBoxRight.Text = keys.ElementAt(1).ToString();
            textBoxUp.Text = keys.ElementAt(2).ToString();
            textBoxDown.Text = keys.ElementAt(3).ToString();
            textBoxShoot.Text = keys.ElementAt(4).ToString();

        }



        public int noDuplicates()
        {
            for (int i = 0; i < keys.Count; i++)
            {
                for (int j = i + 1; j < keys.Count; j++)
                {
                    if (keys.ElementAt(i).Equals(keys.ElementAt(j))) return i;

                }
            }
            return -1;

        }


        private void Save_Click(object sender, EventArgs e)
        {


            if (noDuplicates() == -1)
            {
                DialogResult = DialogResult.OK;
            }

            else
            {
                MessageBox.Show("Controls can't be repeated!");
            }
        }


        private void textBoxLeft_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Insert(0, e.KeyCode);

            keys.RemoveAt(1);
            textBoxLeft.Text = e.KeyCode.ToString();
        }

        private void textBoxRight_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Insert(1, e.KeyCode);
            keys.RemoveAt(2);
            textBoxRight.Text = e.KeyCode.ToString();
        }

        private void textBoxUp_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Insert(2, e.KeyCode);
            keys.RemoveAt(3);
            textBoxUp.Text = e.KeyCode.ToString();
        }

        private void textBoxDown_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Insert(3, e.KeyCode);
            keys.RemoveAt(4);
            textBoxDown.Text = e.KeyCode.ToString();
        }

        private void textBoxShoot_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Insert(4, e.KeyCode);
            keys.RemoveAt(5);

            textBoxShoot.Text = e.KeyCode.ToString();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            keys = new List<Keys>() { Keys.Left, Keys.Right, Keys.Up, Keys.Down, Keys.Space };
            resetKeys();
        }





        public double distance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }

        public void Choose(PictureBox picture)
        {
            playerPicture.Image = minions[selectedPlayer].normal;
            picture.Image = minions[picture.Name].selected;
            playerPicture = picture;
            selectedPlayer = picture.Name;
        }


        private new void MouseEntered(PictureBox picture)
        {
            if (!picture.Equals(playerPicture))
                picture.Image = minions[picture.Name].glow;
        }
        private new void MouseLeft(PictureBox picture)
        {
            if (!picture.Equals(playerPicture))
                picture.Image = minions[picture.Name].normal;
        }


        private void John_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(John);
        }

        private void John_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(John);
        }




        private void Mary_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Mary);
        }

        private void Mary_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Mary);

        }

        private void Oliver_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Oliver);
        }

        private void Oliver_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Oliver);
        }

        private void Dinah_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Dinah);
        }

        private void Dinah_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Dinah);
        }

        private void Thor_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Thor);
        }

        private void Thor_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Thor);
        }

        private void Natasha_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Natasha);
        }

        private void Natasha_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Natasha);
        }

        private void Tony_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Tony);
        }

        private void Tony_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Tony);
        }

        private void Wanda_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Wanda);
        }

        private void Wanda_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Wanda);
        }

        private void Bruce_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Bruce);
        }

        private void Bruce_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Bruce);
        }

        private void Diana_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Diana);
        }

        private void Diana_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Diana);
        }

        private void Barry_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Barry);
        }

        private void Barry_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Barry);
        }

        private void Harley_MouseEnter(object sender, EventArgs e)
        {
            MouseEntered(Harley);
        }

        private void Harley_MouseLeave(object sender, EventArgs e)
        {
            MouseLeft(Harley);
        }

        private void John_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(John);
        }

        private void Mary_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Mary);
        }

        private void Oliver_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Oliver);
        }

        private void Dinah_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Dinah);
        }

        private void Thor_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Thor);
        }

        private void Natasha_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Natasha);
        }

        private void Tony_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Tony);
        }

        private void Wanda_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Wanda);
        }

        private void Bruce_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Bruce);
        }

        private void Diana_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Diana);
        }

        private void Barry_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Barry);
        }

        private void Harley_MouseClick(object sender, MouseEventArgs e)
        {
            Choose(Harley);
        }
    }
}
