using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldGenerator
    {
        private readonly NeighbourFinder _neighbourFinder;
        private readonly CellUpdater _cellUpdater;
        
        public WorldGenerator(NeighbourFinder neighbourFinder, CellUpdater cellUpdater)
        {
            _neighbourFinder = neighbourFinder;
            _cellUpdater = cellUpdater;
        }
        
        public IEnumerable<char> GenerateNewWorld(IEnumerable<char> world)
        {
            var newWorld = new List<char>();
            
            for (var i = 0; i < world.Count(); i++)
            {
                var currentCell = world.ElementAt(i);
                var countOfLiveNeighbours = _neighbourFinder.GetCountOfLiveNeighbours(world, i);

                newWorld.Add(_cellUpdater.GetUpdatedCell(currentCell, countOfLiveNeighbours));
            }

            return newWorld;
        }
    }
}