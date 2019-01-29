using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Seed
    {
        public static Dictionary<string, IEnumerable<char>> Seeds = new Dictionary<string, IEnumerable<char>>
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