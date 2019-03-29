using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeW6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Your name : ");
            string username = Console.ReadLine();
            Console.Clear();

            Gamestate gamestate = new Gamestate();
            

                

                while (true)
                {
                Console.SetCursorPosition(2, 37);
                Console.Write("User : " + username);
                gamestate.Draw();
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                    gamestate.ProcessKeyEvent(consoleKeyInfo);
                }

            }

            
           
        }
    }
