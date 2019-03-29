using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeW6
{
    class Food : GameObject
    {
        ///Gamestate gg = new Gamestate();
        public Food(char sign) : base(sign)
        {
           GenerateLocation();
        }

        public void GenerateLocation()
        {
            body.Clear();
            Random random = new Random(DateTime.Now.Second);

            Point p = new Point(random.Next(0, 39), random.Next(0, 39));

            body.Add(p);        
        }

        public bool IsGoodPoint(List<Point> points)
        {            
                bool res = false;

                foreach (Point p in points)
                {
                    if (p.X == body[0].X && p.Y == body[0].Y)
                    {
                        res = true;
                        break;
                    }
                }
                return res;
         
        }
      
    }

    
}
