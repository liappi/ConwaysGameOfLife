using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> world;
        public WorldController worldController;

        public void SetWorld(IEnumerable<char> world)
        {
            this.world = world;
        }

        public void Tick()
        {
            IEnumerable<char> worldAfterTick = worldController.JudgeWorld(world);
            SetWorld(worldAfterTick);
        }
    }
}