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
                        ".........."}
        };
    }
}