using System.Collections.Generic;
using static ConwaysGameOfLife.Seed;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> World;
        private WorldGenerator _worldGenerator;
        private Renderer _renderer;

        public Game(IEnumerable<char> world, int dimension)
        {
            World = world;
            _worldGenerator = new WorldGenerator(dimension);
            _renderer = new Renderer();
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

        public void Play()
        {
            _renderer.PrintWelcomeMessage();
            
        }

        public string GetValidUserInput()
        {
            var input = _renderer.GetUserInput();
            
            while (!Seeds.ContainsKey(input))
            {
                input = _renderer.GetUserInput();
            }

            return input;
        }
    }
}