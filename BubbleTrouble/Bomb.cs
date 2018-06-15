using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BubbleTrouble
{
    [Serializable]
    public class Bomb : Circle
    {
        Point StartPosition;

        public Bomb(Point position) : base (10, Color.Black, position, -1)
        {
            StartPosition = position;
        }
        public Boolean Hits(Point p)
        {


            return distance(Position, p) < Radius ;


        }

        public void Move(int width,int height)
        {

            if (Position.X < width && Position.Y - 60 < height)
            {
                if (StartPosition.Y > height && Direction == -1) Direction = 1;
            }

Position = new Point(Position.X, Position.Y + 20 * Direction);
        }
        public void Move ()
        {
            Position = new Point(Position.X, Position.Y + 20 * Direction);
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
