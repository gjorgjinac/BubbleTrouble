using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BubbleTrouble
{
    [Serializable]
    class Bullet : Circle
    {
        public Bullet(float radius, Color color, Point position, int direction):base(radius, Color.OrangeRed, position, direction)
        {
            
        }
      
        public void Move ()
        {
            Position = new Point(Position.X - 10, Position.Y);
        }
 

        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Position.X - Radius, Position.Y - Radius, 2 * Radius,  Radius);
            b.Dispose();
        }


    }
}
