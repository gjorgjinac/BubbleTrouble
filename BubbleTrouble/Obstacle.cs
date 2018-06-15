using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BubbleTrouble
{
    [Serializable]
    class Obstacle : Circle
    {

        public int DirectionHorizontal { get; set; }
        public int DirectionVertical { get; set; }

        public int Parent { get; set; }

        public Obstacle(float radius, Color color, Point position, int directionHorizontal, int directionVertical, int parent = -1)
        {
            Radius = radius;
            Color = color;
            Position = position;
            DirectionHorizontal = directionHorizontal;
            DirectionVertical = directionVertical;
            Parent = parent;
        }

        
        public Boolean Hits(Point p)
        {


            return distance(Position, p) <  2*Radius ;


        }
        public void Draw (Graphics g)
        {
            base.Draw(g);
            Pen pen = new Pen(Color.White, 3);
            g.DrawLine(pen, new Point((int) (Position.X - Radius / 2), (int) (Position.Y - Radius / 2)), 
                new Point((int)(Position.X + Radius / 2), (int) ( Position.Y + Radius / 2)));
            g.DrawLine(pen, new Point((int)(Position.X + Radius / 2), (int)(Position.Y - Radius / 2)),
               new Point((int)(Position.X - Radius / 2), (int)(Position.Y + Radius / 2)));


            pen.Dispose();

        }
        



        public void Move(int width, int height, int speed)
        {
            height -= 70;
            width -= 70;
            int X = Position.X;
            int Y = Position.Y;

            if (DirectionHorizontal == 1)
            {
                if (X < width && X > 0) X += speed;
                else if (X >= width - 2 * Radius) { X -= speed; DirectionHorizontal *= -1; }


            }
            else if (DirectionHorizontal == -1)
            {
                if (X < width && X > 0) X -= speed;
                else if (X <= 0) { X += speed; DirectionHorizontal *= -1; }


            }

            if (DirectionVertical == 1)
            {
                if (Y < height && Y > 0) Y += speed;
                else if (Y >= height - 190) { Y -= speed; DirectionVertical *= -1; }


            }
            else if (DirectionVertical == -1)
            {
                if (Y < height && Y > 0) Y -= speed;
                else if (Y <= 200 + Radius) { Y += speed; DirectionVertical *= -1; }


            }
            Position = new Point(X, Y);

        }




        public void Move(int width, int height, int speed, int leftWidth)
        {
          // height -= 70;
            width -= (int)Radius;
            leftWidth += (int)Radius;
            int X = Position.X;
            int Y = Position.Y;

            if (DirectionHorizontal == 1)
            {
                if (X < width && X > leftWidth) X += speed;
                else if (X >= width - 2 * Radius) { X -= speed; DirectionHorizontal *= -1; }


            }
            else if (DirectionHorizontal == -1)
            {
                if (X < width && X > leftWidth) X -= speed;
                else if (X <= leftWidth) { X += speed; DirectionHorizontal *= -1; }


            }

            if (DirectionVertical == 1)
            {
                if (Y < height && Y > 0) Y += speed;
                else if (Y >= height - 190) { Y -= speed; DirectionVertical *= -1; }


            }
            else if (DirectionVertical == -1)
            {
                if (Y < height && Y > 0) Y -= speed;
                else if (Y <= 200 + Radius) { Y += speed; DirectionVertical *= -1; }


            }
            Position = new Point(X, Y);

        }


    }
}
