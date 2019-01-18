using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> world;

        public void SetWorld(IEnumerable<char> world)
        {
            this.world = world;
        }
    }
}