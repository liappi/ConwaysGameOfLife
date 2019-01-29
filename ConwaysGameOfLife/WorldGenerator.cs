using System.Collections.Generic;
using System.Linq;
using static ConwaysGameOfLife.CellUpdater;

namespace ConwaysGameOfLife
{
    public class WorldGenerator
    {
        private readonly NeighbourFinder _neighbourFinder;
        
        public WorldGenerator(NeighbourFinder neighbourFinder)
        {
            _neighbourFinder = neighbourFinder;
        }
        
        public IEnumerable<char> GenerateNewWorld(IEnumerable<char> world)
        {
            var newWorld = new List<char>();
            
            for (var i = 0; i < world.Count(); i++)
            {
                var currentCell = world.ElementAt(i);
                var countOfLiveNeighbours = _neighbourFinder.GetCountOfLiveNeighbours(world, i);

                newWorld.Add(GetUpdatedCell(currentCell, countOfLiveNeighbours));
            }

            return newWorld;
        }
    }
}