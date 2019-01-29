using System.Collections.Generic;
using System.Threading;
using static ConwaysGameOfLife.Seed;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> World;
        private WorldGenerator _worldGenerator;
        private Renderer _renderer;

        public Game(int dimension)
        {
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
            var input = GetValidUserInput();
            var seed = Seeds[input];
            UpdateWorld(seed);

            while (true)
            {
                Tick();
                Thread.Sleep(1000);
                _renderer.PrintWorld(World);
            }
        }

        public string GetValidUserInput()
        {
            var input = _renderer.GetUserInput();
            
            while (!Seeds.ContainsKey(input))
            {
                _renderer.PrintInvalidInputMessage();
                input = _renderer.GetUserInput();
            }
            
            return input;
        }
    }
}