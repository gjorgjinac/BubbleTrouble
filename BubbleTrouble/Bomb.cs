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
        int height;
        int width;
        public Bomb(Point position) : base (10, Color.Red, position, -1)
        {
            StartPosition = position;
        }
        public Boolean Hits(Point p)
        {


            return distance(Position, p) < Radius*2 ;


        }
        public Boolean HitsPlayer(Point p)
        {
            return distance(Position, new Point(p.X + 40, p.Y + 40)) <= Radius *2 && StartPosition.Y>height;
        }
        public void Move(int width,int height)
        {
            this.height = height; this.width = width;
            if (Position.X < width && Position.Y - 60 < height)
            {
                if (StartPosition.Y > height && Direction == -1) Direction = 1;
            }

Position = new Point(Position.X, Position.Y + 30 * Direction);
        }
        public void Move ()
        {
            Position = new Point(Position.X, Position.Y + 30 * Direction);
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
