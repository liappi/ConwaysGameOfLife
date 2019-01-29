using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> World;
        private WorldGenerator _worldGenerator;

        public Game(IEnumerable<char> world, int dimension)
        {
            World = world;
            _worldGenerator = new WorldGenerator(dimension);
        }

        public void UpdateWorld(IEnumerable<char> newWorld)
        {
            World = newWorld;
        }

        public void Tick()
        {
            var newWorld = _worldGenerator.GenerateNewWorld(World);
            UpdateWorld(newWorld);
        }
    }
}