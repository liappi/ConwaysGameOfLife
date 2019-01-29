using System;
using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Renderer
    {
        public void PrintWelcomeMessage()
        {
            Console.WriteLine("Welcome to Conway's Game of Life!");
        }

        public string GetUserInput()
        {
            Console.WriteLine("Please choose a seed from the following:");
            Console.WriteLine("BLINKER");
            return Console.ReadLine();
        }

        public void PrintInvalidInputMessage()
        {
            Console.WriteLine("Your input was invalid");
        }
    }
}