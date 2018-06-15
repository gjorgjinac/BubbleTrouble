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

        

        public Controls(Keys l, Keys r, Keys u, Keys d, Keys s)
        {

        
            InitializeComponent();
            keys = new List<Keys>() { l, r, u, d, s };
            textBoxLeft.Text = l.ToString();
            textBoxRight.Text = r.ToString();
            textBoxUp.Text = u.ToString();
            textBoxDown.Text = d.ToString();
            textBoxShoot.Text = s.ToString();



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
    }
}
