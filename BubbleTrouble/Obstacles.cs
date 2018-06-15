using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleTrouble
{
    [Serializable]
    class Obstacles
    {

      public  List<Obstacle> ObstacleList { get; set; }
        public Obstacle specialObstacle { get; set; }
        public int level;

        public void AddObstacle (Obstacle c)
        {
            ObstacleList.Add(c);
        }
        public Boolean eliminated (int parent)
        {
            foreach(Obstacle o in ObstacleList)
            {
                if (o.Parent == parent) return false;
            }
            return true;
        }



        public Obstacles(int level)
        {
            this.level = level;
            ObstacleList = new List<Obstacle>();
            if (level == 1)
            {
                ObstacleList.Add(new Obstacle(60, Color.Red, new Point(600, 300), -1, 1));
                ObstacleList.Add(new Obstacle(40, Color.Magenta, new Point(100, 100), 1, 1));
            specialObstacle = new Obstacle(20, Color.Aqua, new Point(40,40), 1, -1);
            }
            if (level == 2)
            {
                ObstacleList.Add(new Obstacle(40, Color.Blue, new Point(100, 100), 1, 1,0));
                ObstacleList.Add(new Obstacle(40, Color.Red, new Point(400,200), 1, 1,1));
                ObstacleList.Add(new Obstacle(40, Color.Green, new Point(700, 300), 1, 1,2));


            }


        }

        public void Move (int width, int height, List<int> barriers)
        {

            for(int i = 0; i < ObstacleList.Count; i++)
            {
                Obstacle obstacle = ObstacleList.ElementAt(i);
                
                obstacle.Move(barriers.ElementAt(2 * obstacle.Parent + 1), height-150, 10, barriers.ElementAt(2 * obstacle.Parent));

            }


        }









        public void Draw (Graphics g, Boolean drawSpecial)
        {
            foreach (Obstacle c in ObstacleList)
            {
                c.Draw(g);
            }
           if (drawSpecial) specialObstacle.Draw(g);
        }
     

        public Boolean isPlayerHit (Point x, int width, int height)
        {
            foreach (Obstacle c in ObstacleList)
            {
                if (c.HitsPlayer(x)) {
                    c.DirectionHorizontal *= -1;
                    c.DirectionVertical *= -1;
                    c.Move(width, height - 50, 10);
                    return true; }
            }
            if (level == 1)
            {
                if (specialObstacle.HitsPlayer(x))
                {
                    specialObstacle.DirectionHorizontal *= -1;
                    specialObstacle.DirectionVertical *= -1;
                    specialObstacle.Move(width, height - 50, 10);
                    return true;
                }
            }


            return false;
        }


        public void Move (int width, int height, int specialWidth, int specialHeight)
        {foreach (Obstacle c in ObstacleList)
            {
                c.Move(width, height-70,10);



            }
            if (level==1) specialObstacle.Move(specialWidth, specialHeight + 50 , 10);
        }
    }
}
