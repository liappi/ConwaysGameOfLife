using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldController
    {
        public NeighbourFinder neighbourFinder;
        private PositionMapper positionMapper;
        
        public WorldController(int dimension)
        {
            neighbourFinder = new NeighbourFinder(dimension);
            positionMapper = new PositionMapper(dimension);
        }
        
        public IEnumerable<char> JudgeWorld(IEnumerable<char> world)
        {
            var newWorld = new List<char>();
            for (var i = 0; i < world.Count(); i++)
            {
                var currentCellPosition = positionMapper.MapCellIndexInWorldToPosition(i);
                var neighbours = neighbourFinder.GetNeighbours(world, currentCellPosition);
                var countOfLiveNeighbours = GetCountOfLiveNeighbours(neighbours);
                
                newWorld.Add(countOfLiveNeighbours < 2 ? '.' : 'X');
            }

            return newWorld;
        }

        public int GetCountOfLiveNeighbours(IEnumerable<char> neighbours)
        {
            return neighbours.Count(neighbour => neighbour.Equals('X'));
        }
    }
}