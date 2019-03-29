using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace SnakeAssistant
{
    class GameObject
    {
        public List<Point> body { get; }
        public char sign { get; }
        public ConsoleColor color { get; }

        public GameObject() { }

        public GameObject(Point firstpoint, ConsoleColor color, char sign)
        {
            this.body = new List<Point>();
            if (firstpoint != null)
            {
                this.body.Add(firstpoint);
            }
            this.color = color;
            this.sign = sign;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach(Point p in body)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(sign);
            }
        }

        public void Save()
        {
            Type t = this.GetType();
            string fname = t.Name + ".xml";

            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(t);
                xs.Serialize(fs, this);
            }
        }

        public GameObject Load()
        {
            GameObject res = null;
            Type t = this.GetType();
            string fname = t.Name + ".xml";

            using (FileStream fs = new FileStream(fname, FileMode.OpenOrCreate, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(t);
                res = xs.Deserialize(fs) as GameObject;
            }

            return res;

        }

    }
}
