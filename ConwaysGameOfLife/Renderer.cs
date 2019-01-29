using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConwaysGameOfLife
{
    public static class Renderer
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!");
        }

        public static string GetUserInput()
        {
            Console.WriteLine("Please choose a seed from the following:");
            Console.WriteLine("BLINKER");
            return Console.ReadLine();
        }

        public static void PrintInvalidInputMessage()
        {
            Console.WriteLine("Your input was invalid");
        }

        public static void PrintWorld(IEnumerable<char> world, int dimension)
        {
            var formattedWorld = new StringBuilder("");
            
            for (var i = 0; i < world.Count(); i++)
            {
                if (i % dimension == 0) 
                    formattedWorld.Append("\n");
                
                formattedWorld.Append(world.ElementAt(i) + " ");
            }

            Console.WriteLine(formattedWorld);
        }
    }
    
}