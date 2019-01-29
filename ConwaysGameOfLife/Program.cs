using System;

namespace ConwaysGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10);
            game.Play();
        }
    }
}