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
    public partial class AddPlayer : Form
    {

      public  Player newPlayer;
        int points;
       
        public AddPlayer(int points)
        {
            InitializeComponent();
            this.points = points;
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.Text == "") errorProvider1.SetError(textBox1, "Name can't be empty");
            else errorProvider1.SetError(textBox1, null);
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            newPlayer = new Player(textBox1.Text,points);
            DialogResult = DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
