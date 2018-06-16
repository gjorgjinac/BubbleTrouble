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
      String selectedPlayer;
        PictureBox playerPicture;

        Dictionary<String, Minion> minions;
        public Controls(Keys l, Keys r, Keys u, Keys d, Keys s, String player)
        {

        
            InitializeComponent();
            keys = new List<Keys>() { l, r, u, d, s };
            textBoxLeft.Text = l.ToString();
            textBoxRight.Text = r.ToString();
            textBoxUp.Text = u.ToString();
            textBoxDown.Text = d.ToString();
            textBoxShoot.Text = s.ToString();
            minions = new Dictionary<string, Minion>();
            minions.Add("John", new Minion("John", Properties.Resources.soldier, Properties.Resources.soldier_screaming, Properties.Resources.soldier_dead, Properties.Resources.soldier_with_shield, Properties.Resources.soldier_glow, Properties.Resources.soldier_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Mary", new Minion("Mary", Properties.Resources.soldier_female, Properties.Resources.soldier_female_screaming, Properties.Resources.soldier_female_dead, Properties.Resources.soldier_female_shield, Properties.Resources.soldier_female_glow, Properties.Resources.soldier_female_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Oliver", new Minion("Oliver", Properties.Resources.arrow, Properties.Resources.arrow_screaming, Properties.Resources.arrow_dead, Properties.Resources.arrow_shield, Properties.Resources.arrow_glow, Properties.Resources.arrow_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Dinah", new Minion("Dinah", Properties.Resources.canary, Properties.Resources.canary_screaming, Properties.Resources.canary_dead, Properties.Resources.canary_shield, Properties.Resources.canary_glow, Properties.Resources.canary_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Thor", new Minion("Thor", Properties.Resources.thor, Properties.Resources.thor_screaming, Properties.Resources.thor_dead, Properties.Resources.thor_shield, Properties.Resources.thor_glow, Properties.Resources.thor_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Natasha", new Minion("Natasha", Properties.Resources.blackwidow, Properties.Resources.blackwidow_screaming, Properties.Resources.blackwidow_dead, Properties.Resources.blackwidow_shield, Properties.Resources.blackwidow_glow, Properties.Resources.blackwidow_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Tony", new Minion("Tony", Properties.Resources.stark, Properties.Resources.stark_screaming, Properties.Resources.stark_dead, Properties.Resources.stark_shield, Properties.Resources.stark_glow, Properties.Resources.stark_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Wanda", new Minion("Wanda", Properties.Resources.scarlet, Properties.Resources.scarlet_screaming, Properties.Resources.scarlet_dead, Properties.Resources.scarlet_shield, Properties.Resources.scarlet_glow, Properties.Resources.scarlet_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Bruce", new Minion("Bruce", Properties.Resources.batman, Properties.Resources.batman_screaming, Properties.Resources.batman_dead, Properties.Resources.batman_shield, Properties.Resources.batman_glow, Properties.Resources.batman_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Diana", new Minion("Diana", Properties.Resources.diana, Properties.Resources.diana_screaming, Properties.Resources.diana_dead, Properties.Resources.diana_shield, Properties.Resources.diana_glow, Properties.Resources.diana_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Barry", new Minion("Barry", Properties.Resources.flash, Properties.Resources.flash_screaming, Properties.Resources.flash_dead, Properties.Resources.flash_shield, Properties.Resources.flash_glow, Properties.Resources.flash_selected, new List<Image>() { Properties.Resources.military_base }));
            minions.Add("Harley", new Minion("Harley", Properties.Resources.harley, Properties.Resources.harley_screaming, Properties.Resources.harley_dead, Properties.Resources.harley_shield, Properties.Resources.harley_glow, Properties.Resources.harley_selected, new List<Image>() { Properties.Resources.military_base }));
            pictures = new List<PictureBox>() { John, Mary, Oliver, Dinah, Thor, Natasha, Tony, Wanda, Bruce, Diana, Barry, Harley };
            selectedPlayer = player;
            playerPicture = new PictureBox();
            foreach (PictureBox p in pictures)
            {
                p.BackColor = Color.Transparent;
                if (p.Name.Equals(selectedPlayer))
                    playerPicture.Image = minions[selectedPlayer].selected;
              //  p.MouseHover += new EventHandler(hover(p));

            }
            
        }
    
     



        public int noDuplicates()
        {
            for (int i = 0; i < keys.Count;i++)
            {
                for (int j = i+1; j < keys.Count; j++)
                {
                    if (keys.ElementAt(i).Equals(keys.ElementAt(j))) return i;
                    
                }
            }
            return -1;

        }


        private void Save_Click(object sender, EventArgs e)
        {
           

           if (noDuplicates()==-1)
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
            DialogResult = DialogResult.OK;
        }

      
       


        public double distance(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
        }

        public void Choose (PictureBox picture)
        {
            playerPicture.Image = minions[selectedPlayer].normal;
            picture.Image = minions[picture.Name].selected;
            playerPicture = picture;
            selectedPlayer = picture.Name;
        }


        public void Enter (PictureBox picture )
        {
            if (!picture.Equals(playerPicture))
                picture.Image = minions[picture.Name].glow;
        }
        public void Leave(PictureBox picture)
        {  if (!picture.Equals(playerPicture))
            picture.Image = minions[picture.Name].normal;
        }


  private void John_MouseEnter(object sender, EventArgs e)
        {
 Enter(John);
        }

        private void John_MouseLeave(object sender, EventArgs e)
        {
            Leave(John);
        }

       
        

        private void Mary_MouseLeave(object sender, EventArgs e)
        {
            Leave(Mary);
        }

        private void Mary_MouseEnter(object sender, EventArgs e)
        {
          Enter(Mary);

        }

        private void Oliver_MouseEnter(object sender, EventArgs e)
        {
            Enter(Oliver);
        }

        private void Oliver_MouseLeave(object sender, EventArgs e)
        {
            Leave(Oliver);
        }

        private void Dinah_MouseLeave(object sender, EventArgs e)
        {
            Leave(Dinah);
        }

        private void Dinah_MouseEnter(object sender, EventArgs e)
        {
            Enter(Dinah);
        }

        private void Thor_MouseEnter(object sender, EventArgs e)
        {
            Enter(Thor);
        }

        private void Thor_MouseLeave(object sender, EventArgs e)
        {
            Leave(Thor);
        }

        private void Natasha_MouseEnter(object sender, EventArgs e)
        {
            Enter(Natasha);
        }

        private void Natasha_MouseLeave(object sender, EventArgs e)
        {
            Leave(Natasha);
        }

        private void Tony_MouseEnter(object sender, EventArgs e)
        {
            Enter(Tony);
        }

        private void Tony_MouseLeave(object sender, EventArgs e)
        {
            Leave(Tony);
        }

        private void Wanda_MouseEnter(object sender, EventArgs e)
        {
            Enter(Wanda);
        }

        private void Wanda_MouseLeave(object sender, EventArgs e)
        {
            Leave(Wanda);
        }

        private void Bruce_MouseEnter(object sender, EventArgs e)
        {
            Enter(Bruce);
        }

        private void Bruce_MouseLeave(object sender, EventArgs e)
        {
            Leave(Bruce);
        }

        private void Diana_MouseEnter(object sender, EventArgs e)
        {
            Enter(Diana);
        }

        private void Diana_MouseLeave(object sender, EventArgs e)
        {
            Leave(Diana);
        }

        private void Barry_MouseLeave(object sender, EventArgs e)
        {
            Leave(Barry);
        }

        private void Barry_MouseEnter(object sender, EventArgs e)
        {
            Enter(Barry);
        }

        private void Harley_MouseEnter(object sender, EventArgs e)
        {
            Enter(Harley);
        }

        private void Harley_MouseLeave(object sender, EventArgs e)
        {
            Leave(Harley);
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
