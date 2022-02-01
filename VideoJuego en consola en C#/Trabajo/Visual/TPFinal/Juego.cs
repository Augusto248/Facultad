using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPFinal
{
    class Juego
    {


        static void Main(string[] args)
        {



            Console.WriteLine("1) New game");
            Console.WriteLine("2) Exit");
            string select = Console.ReadLine();

            if (select == "1")
            {
                Console.Clear();

            Game game = new Game();
            game.play();
            Console.ReadKey(true);
            }

            

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
