using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BubbleTrouble
{
    [Serializable]
    class Game
    {

        public Point playerPosition;
      public  Obstacles obstacles;
       public int livesLeft;
        public int timeMili;
        public List<Bomb> bombs;
       
        public int points;
        public int level;
        public Boolean specialObstaclePassed;
      

        public Game(int level)
        {
            this.level = level;
            obstacles = new Obstacles(level);
            specialObstaclePassed = false;
           timeMili = 6000;
            
            bombs = new List<Bomb>();
            
            points = 0;
            
        }
        public void decreaseTime ()
        {
            timeMili-=1;
           
        }

        public void MoveBombs(int width, int height)
        {
            foreach (Bomb b in bombs)
            {
                if (level==1) b.Move(width, height);
                if (level == 2) b.Move();

            }
        }


        public Boolean checkEnd()
        {
            return obstacles.ObstacleList.Count == 0 || livesLeft == 0 || timeMili < 10;
        }
        
        public void AddBomb(Point p)
        {if (bombs.Count<=3)
            bombs.Add(new Bomb(new Point(p.X+40, p.Y)));
            
        }

        public Boolean PlayerHit(Point p, int width, int height)
        {
            foreach(Bomb b in bombs)
            {
                if (b.HitsPlayer(p)) return true;
            }
            return false || obstacles.isPlayerHit(p, width, height);

        }
        
        public void CheckHits()
        {
            for (int j = 0; j < bombs.Count; j++)
            {
                Boolean hit = false;
                Bomb b = bombs.ElementAt(j);
                for(int i = 0; i < obstacles.ObstacleList.Count; i++)
                {
                    Obstacle c = obstacles.ObstacleList.ElementAt(i);
                    if (c.Hits(b.Position))
                    {
                        if (c.Radius > 20)
                        {
                            if (level == 1)
                            {
                                obstacles.AddObstacle(new Obstacle(c.Radius / 2, c.Color, new Point(c.Position.X - 20, c.Position.Y - 20), -1, -1));
                                obstacles.AddObstacle(new Obstacle(c.Radius / 2, c.Color, new Point(c.Position.X + 20, c.Position.Y - 20), 1, -1));
                            }

                            if (level==2)
                            {
                                obstacles.AddObstacle(new Obstacle(c.Radius / 2, c.Color, new Point(c.Position.X - 20, c.Position.Y - 20), -1, -1, c.Parent));
                                obstacles.AddObstacle(new Obstacle(c.Radius / 2, c.Color, new Point(c.Position.X + 20, c.Position.Y - 20), 1, -1, c.Parent));
                            }

                        }
                        points += 50;
                        obstacles.ObstacleList.Remove(c);
                        hit = true;
                    }

                }
          if (hit)  bombs.Remove(b);
                if (level==1 && obstacles.specialObstacle.Hits(b.Position))
                { specialObstaclePassed = true; }
            }
            
        }

        public void updateBombs(Graphics g, int height)
        {
            for (int i = 0; i < bombs.Count; i++)
            { Bomb b = bombs.ElementAt(i);
                if (b.Position.Y < 0 || b.Position.Y>height)
                    bombs.RemoveAt(i);
                else b.Draw(g);
            }

            obstacles.Draw(g, (!specialObstaclePassed && level == 1));
            

           

           

        }


    }
}
