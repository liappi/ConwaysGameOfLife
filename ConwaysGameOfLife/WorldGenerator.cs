using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldGenerator
    {
        private NeighbourFinder _neighbourFinder;
        private PositionMapper _positionMapper;
        const char liveCell = 'X';
        const char deadCell = '.';
        
        
        public WorldGenerator(int dimension)
        {
            _neighbourFinder = new NeighbourFinder(dimension);
            _positionMapper = new PositionMapper(dimension);
        }
        
        public IEnumerable<char> GenerateNewWorld(IEnumerable<char> world)
        {
            var newWorld = new List<char>();
            
            for (var i = 0; i < world.Count(); i++)
            {
                var currentCell = world.ElementAt(i);
                var currentCellPosition = _positionMapper.MapCellIndexInWorldToPosition(i);
                var neighbours = _neighbourFinder.GetNeighbours(world, currentCellPosition);
                var countOfLiveNeighbours = GetCountOfLiveNeighbours(neighbours);

                if (isLiveCell(currentCell))
                    newWorld.Add(GetUpdatedCellForLiveCell(countOfLiveNeighbours));
                else
                    newWorld.Add(GetUpdatedCellForDeadCell(countOfLiveNeighbours));
            }

            return newWorld;
        }

        private char GetUpdatedCellForLiveCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours < 2 || countOfLiveNeighbours > 3)
                return deadCell;
            
            return liveCell;
        }

        private char GetUpdatedCellForDeadCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours == 3)
                return liveCell;

            return deadCell;
        }

        private bool isLiveCell(char cell)
        {
            return cell == liveCell;
        }

        public int GetCountOfLiveNeighbours(IEnumerable<char> neighbours)
        {
            return neighbours.Count(neighbour => neighbour.Equals(liveCell));
        }
    }
}