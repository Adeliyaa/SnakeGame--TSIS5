using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeW6
{
    class Wall : GameObject
    {
        public Wall (char sign) : base (sign)
        {
            //LoadLevel(1);
        }                
           void LoadLevel(int level)
        {
            body.Clear();
            string name = string.Format("Levels/Level{0}.txt", level);
            using (StreamReader streamReader = new StreamReader(name))
            {
                int r = 0;
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    for (int c = 0; c < line.Length; ++c)
                    {
                        if (line[c] == '#')
                        {
                            body.Add(new Point(c, r));
                        }
                    }
                    r++;
                }
                
            }
             
        }

        public void Score(int score)
        {
            Console.SetCursorPosition(2, 38);
            Console.Write("Your score: " + score);

            if (score < 30)
            {

                LoadLevel(1);
                //Clear();
            } 
            if (score >= 30)
            {
                Clear();
                LoadLevel(2);
            }
        }

    }
}
