using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{[Serializable]
   public class Circle
    {
        public float Radius { get; set; }
        public Color Color { get; set; }
        public Point Position { get; set; }
        public int Direction { get; set; }

        public Circle(float radius, Color color, Point position, int direction)
        {
            Radius = radius;
            Color = color;
            Position = position;
            Direction = direction;
        }

        public Circle (Point p)
        {
            Position = p;
        }
        public Circle ()
        {

        }
        public Boolean HitsPlayer(Point p)
        {
            return distance(Position, new Point(p.X + 40, p.Y + 40)) <= Radius + 40;
        }


        public double distance(Point A, Point B)
            {
                return Math.Sqrt(Math.Pow(A.X - B.X, 2) + Math.Pow(A.Y - B.Y, 2));
            }
       


        public void Draw(Graphics g)
        {
            Brush b = new SolidBrush(Color);
            g.FillEllipse(b, Position.X - Radius, Position.Y - Radius, 2 * Radius, 2 * Radius);
            b.Dispose();
        }
    }
}
