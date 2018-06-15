using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{ [Serializable]
  public  class Player
    {
        public String Name { get; set; }
        public int Points { get; set; }

        public Player(string name, int points)
        {
            Name = name;
            Points = points;
           
        }

        public override string ToString()
        {
            return String.Format("Name: {0} \t Points: {1} \n", Name, Points);
        }
    }
}
