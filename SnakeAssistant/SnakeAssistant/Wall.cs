using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SnakeAssistant
{
    class Wall:GameObject
    {
        public Wall (Point firstpoint, ConsoleColor color, char sign) : base(firstpoint, color, sign)
        {

        }
        public Wall() { }

        public void LoadLevel(GameLevel level)
        {
            string fname = "";

            switch (level)
            {
                case GameLevel.First:
                    fname = "Level1.txt";
                    break;
                case GameLevel.Second:
                    fname = "lvl1.txt";
                    break;
                default:
                    break;
            }

            FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string line;
            int y = 0;

            while ((line = sr.ReadLine()) != null)
            {
                for (int x = 0; x < line.Length; x++)
                {
                    if (line[x] == '#')
                    {
                        this.body.Add(new Point { X = x, Y = y });
                    }
                }
                y++;
            }
            sr.Close();
            fs.Close();
        }

    }
}
