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
        private int _worldDimension;

        private void InitialiseGame(IEnumerable<char> seed)
        {
            UpdateWorld(seed);
            _worldDimension = (int) Math.Sqrt(seed.Count());
            
            var positionMapper = new PositionMapper(_worldDimension);
            var neighbourFinder = new NeighbourFinder(_worldDimension);
            
            _worldGenerator = new WorldGenerator(neighbourFinder, positionMapper);
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
                PrintWorld(World, _worldDimension);
                Thread.Sleep(1000);
            }
        }
        
        private void Tick()
        {
            var newWorld = _worldGenerator.GenerateNewWorld(World);
            UpdateWorld(newWorld);
        }
        
        public void UpdateWorld(IEnumerable<char> newWorld)
        {
            World = newWorld;
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