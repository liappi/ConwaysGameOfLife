using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static ConwaysGameOfLife.Renderer;
using static ConwaysGameOfLife.Seed;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> World;
        private WorldGenerator _worldGenerator;

        public void InitialiseGame(IEnumerable<char> seed)
        {
            UpdateWorld(seed);

            var dimension = (int) Math.Sqrt(seed.Count());
            var positionMapper = new PositionMapper(dimension);
            var neighbourFinder = new NeighbourFinder(dimension);
            
            _worldGenerator = new WorldGenerator(neighbourFinder, positionMapper);
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
            PrintWelcomeMessage();
            var input = GetValidUserInput();
            var seed = Seeds[input];
            InitialiseGame(seed);

            while (true)
            {
                Tick();
                Thread.Sleep(1000);
                PrintWorld(World);
            }
        }

        private string GetValidUserInput()
        {
            var input = GetUserInput();
            
            while (!Seeds.ContainsKey(input))
            {
                PrintInvalidInputMessage();
                input = GetUserInput();
            }
            
            return input;
        }
    }
}