using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> _world;
        public WorldGenerator _worldGenerator;

        public Game(IEnumerable<char> world, int dimension)
        {
            _world = world;
            _worldGenerator = new WorldGenerator(dimension);
        }

        public void UpdateWorld(IEnumerable<char> newWorld)
        {
            _world = newWorld;
        }

        public void Tick()
        {
            var newWorld = _worldGenerator.GenerateNewWorld(_world);
            UpdateWorld(newWorld);
        }
    }
}