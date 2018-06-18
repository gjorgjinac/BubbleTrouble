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
    public partial class Manual : Form
    {
        List<String> ManualPages = new List<string>()
        {
            "The aim of the game is to remove all of the bubbles from the screen and preserve your life. When popped, the bigger bubbles split into two until they are small enough to get destroyed. ",
            "A life is lost if:\n1) The player is hit by a bubble\n2) The player is hit by his own bombs\n3) The player falls off a ladder or platform \n4) The player is hit by the falling roof \n5) The player is hit by the tank\n6) Time runs out",
            "You can move the player using the arrow keys and shoot bombs using the space button. These are just default controls and you can change them at any time using the menu->Options->Settings. ",
               "You get 50 points for each popped bubble. Catching the falling cash gets you 100 points and the falling coins get you 30 points. You also get 10 points for each second left when you successfully finish a level",
               "Other 'goodies' incude a shield that provides protection from bubbles and tank bullets for 10 seconds, pizzas that give you an extra life, and a clock that gives you extra 10 seconds"


        };
        int currentPage;
        public Manual()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            left.BackColor = Color.Transparent;
            right.BackColor = Color.Transparent;
            currentPage = 0;
            manualText.Text = ManualPages.ElementAt(currentPage);
        }

        private void left_Click(object sender, EventArgs e)
        {
            if(currentPage > 0)
                manualText.Text = ManualPages.ElementAt(--currentPage);
        }

        private void left_MouseHover(object sender, EventArgs e)
        {
            if (currentPage > 0)
                left.Image = Properties.Resources.arrow_left2;
        }

        private void left_MouseLeave(object sender, EventArgs e)
        {
         
                left.Image = Properties.Resources.arrow_left1;
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (currentPage < ManualPages.Count - 1) 
                manualText.Text = ManualPages.ElementAt(++currentPage);
        }

        private void right_MouseHover(object sender, EventArgs e)
        {
            if (currentPage < ManualPages.Count - 1)
                right.Image = Properties.Resources.arrow_right2;
        }

        private void right_MouseLeave(object sender, EventArgs e)
        {
        
                right.Image = Properties.Resources.arrow_right1;

        }
    }
}
