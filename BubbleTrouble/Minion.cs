using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BubbleTrouble
{
   public class Minion
    {
        public String name { get; set; }
        public Image normal { get; set; }
        public Image screaming { get; set; }
        public Image dead { get; set; }
        public Image shield { get; set; }
        public Image glow { get; set; }
        public Image selected { get; set; }
        public Image now { get; set; }
       public List<Image> backgrounds { get; set; }


        public Minion(string name, Image normal, Image screaming, Image dead, Image shield, Image glow, Image selected, List <Image> backgrounds)
        {
            this.name = name;
            this.normal = normal;
            this.screaming = screaming;
            this.dead = dead;
            this.shield = shield;
            this.glow = glow;
            this.selected = selected;
            this.now = normal;
            this.backgrounds = backgrounds;
        }

        public void Scream()
        {
            now = screaming;
        }
        public void Die ()
        {
            now = dead;
        }
        public void Shelter ()
        {
            now = shield;
        }

        public void Glow ()
        {
            now = glow;
        }
        public void Select ()
        {
            now = selected;
        }

        public Minion(string name)
        {
            this.name = name;
        }
    }
}
