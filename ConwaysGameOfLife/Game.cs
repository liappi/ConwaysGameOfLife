using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using static ConwaysGameOfLife.Seed;

namespace ConwaysGameOfLife
{
    public class Game
    {
        private readonly Renderer _renderer;
        private readonly InputValidator _inputValidator;

        private IEnumerable<char> World;
        private WorldGenerator _worldGenerator;
        private int _worldDimension;

        public Game()
        {
            _renderer = new Renderer();
            _inputValidator = new InputValidator(_renderer);
        }

        private void InitialiseGame(IEnumerable<char> seed)
        {
            World = seed;
            _worldDimension = (int) Math.Sqrt(seed.Count());
            
            var neighbourFinder = new NeighbourFinder(_worldDimension);
            var cellUpdater = new CellUpdater();
            
            _worldGenerator = new WorldGenerator(neighbourFinder, cellUpdater);
        }

        public void Play()
        {
            _renderer.PrintWelcomeMessage();
            var input = _inputValidator.GetValidUserInput();
            var seed = Seeds[input];
            InitialiseGame(seed);

            while (true)
            {
                World = _worldGenerator.GenerateNewWorld(World);
                _renderer.PrintWorld(World, _worldDimension);
                Thread.Sleep(1000);
            }
        }
    }
}