using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeW6
{
    class Worm : GameObject
    {
        public Worm(char sign) : base (sign)
        {
            body.Add(new Point(20, 20)); 
        }

        public void Move(int dx, int dy)
        {
            Clear();
            for (int i = body.Count - 1; i > 0; --i)
                // 3--2--1--0
            {
                body[i].X = body[i - 1].X;
                body[i].Y = body[i - 1].Y;
            }
            body[0].X += dx;
            body[0].Y += dy;
        }

        public bool IsIntersected(List<Point> points)
        {
            bool res = false;

            foreach(Point p in points)
            {
                if(p.X == body[0].X && p.Y == body[0].Y)
                {
                    res = true;
                    break;
                }
            }
            return res;
        }

        public void Eat(List<Point> foodbody)
        {
            body.Add(new Point(body[0].X, body[0].Y));
        }  
        
        public bool CollisionWithItself()
        {
            
            for (int i=1; i<body.Count; i++)
            {
                if (body[i].X == body[0].X && body[i].Y == body[0].Y)
                {
                    return true;
                }
            }
            return false; 
        }
    }
}
