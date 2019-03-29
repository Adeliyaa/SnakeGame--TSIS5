using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeW6
{
    enum GameLevel
    {
        First,
        Second
    }

    class Gamestate
    {
        bool gameOver = false;
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');
        int score = 0;

        GameLevel gameLevel;

        public Gamestate()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
        }

        public void Draw()
        {
            if(!gameOver)
            {
                wall.Score(score);
                worm.Draw();
                food.Draw();
                wall.Draw();
            }
        }

        public void ProcessKeyEvent(ConsoleKeyInfo consoleKeyInfo)
        {
            switch(consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    worm.Move(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    worm.Move(0, 1);
                    break;
                case ConsoleKey.RightArrow:
                    worm.Move(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    worm.Move(-1, 0);
                    break;
            }
            CheckCollision();
        }

        private void CheckCollision()
        {
            if (worm.IsIntersected(wall.body))
            {
                gameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Game Over!");
            }
            else if (worm.IsIntersected(food.body))
            {
                
                worm.Eat(food.body);
                score += 10;
                wall.Score(score);
                while (food.IsGoodPoint(worm.body) || food.IsGoodPoint(wall.body)) 
                {
                    food.GenerateLocation();
                }
            }
            else if (worm.CollisionWithItself())
            {
                gameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Game Over!");
            }
        }
        







        /*public bool FallWallWorm()
        {
            if(food.FallOnWall(wall.body) || food.FallOnWorm(worm.body))
            {
                return true;
            }
            return false; 
            
        }*/






    }
}
