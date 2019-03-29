using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Game game = new Game();

            while (true)
            {
                //game.Status();
                menu.Process();
            }
        }
    }
}
