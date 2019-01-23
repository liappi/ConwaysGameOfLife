using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> world;
        public WorldController worldController;

        public Game(IEnumerable<char> world, int dimension)
        {
            this.world = world;
            worldController = new WorldController(dimension);
        }

        public void UpdateWorld(IEnumerable<char> world)
        {
            this.world = world;
        }

        public void Tick()
        {
            var worldAfterTick = worldController.JudgeWorld(world);
            UpdateWorld(worldAfterTick);
        }
    }
}