using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public static class Seed
    {
        public static readonly Dictionary<string, IEnumerable<char>> Seeds = new Dictionary<string, IEnumerable<char>>
        {
            {"BLINKER", ".........." +
                        ".........." +
                        ".XXX..XXX." +
                        ".........." +
                        ".........." +
                        ".........." +
                        ".........." +
                        ".XXX..XXX." +
                        ".........." +
                        ".........."},
            {"PULSAR", "................." +
                       "................." +
                       "....XXX...XXX...." +
                       "................." +
                       "..X....X.X....X.." +
                       "..X....X.X....X.." +
                       "..X....X.X....X.." +
                       "....XXX...XXX...." +
                       "................." +
                       "....XXX...XXX...." +
                       "..X....X.X....X.." +
                       "..X....X.X....X.." +
                       "..X....X.X....X.." +
                       "................." +
                       "....XXX...XXX...." +
                       "................." +
                       "................."},
            {"GLIDER", "......" +
                       "...X.." +
                       "....X." +
                       "..XXX." +
                       "......" +
                       "......"}
        };
    }
}