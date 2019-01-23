using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldController
    {
        private int dimension;

        public WorldController()
        {
            dimension = 5;
        }
        
        public IEnumerable<char> JudgeWorld(IEnumerable<char> world)
        {
            var newWorld = new List<char>();
            for (var i = 0; i < world.Count(); i++)
            {
                var position = MapCellIndexInWorldToPosition(i);
                var neighbours = GetNeighbours(world, position);
                var countOfLiveNeighbours = GetCountOfLiveNeighbours(neighbours);
                
                newWorld.Add(countOfLiveNeighbours < 2 ? '.' : 'X');
            }

            return newWorld;
        }

        public int GetCountOfLiveNeighbours(IEnumerable<char> neighbours)
        {
            return neighbours.Count(neighbour => neighbour.Equals('X'));
        }

        public IEnumerable<char> GetNeighbours(IEnumerable<char> world, Position cell)
        {
            var positionsOfNeighbours = GetPositionsOfNeighbours(cell);
            return positionsOfNeighbours.Select(position => world.ElementAt(MapPositionToWorld(position))).ToList();
        }

        public IEnumerable<Position> GetPositionsOfNeighbours(Position cell)
        {
            var positionsOfNeighbours = new List<Position>();
            
            for (var x = cell.x - 1; x <= cell.x + 1; x++)
            {
                for (var y = cell.y - 1; y <= cell.y + 1; y++)
                {
                    if (!(x == cell.x && y == cell.y))
                        positionsOfNeighbours.Add(new Position(MapOverlappingPositionComponent(x), MapOverlappingPositionComponent(y)));
                }               
            }
            
            return positionsOfNeighbours;
        }

        private int MapOverlappingPositionComponent(int positionComponent)
        {
            if (positionComponent < 0) return dimension + positionComponent;
            if (positionComponent > dimension - 1) return dimension - positionComponent;
            return positionComponent;
        }

        private int MapPositionToWorld(Position cell)
        {
            return cell.x + cell.y * dimension;
        }

        private Position MapCellIndexInWorldToPosition(int cellIndex)
        {
            var x = cellIndex % 5;
            var y = cellIndex / 5;
            return new Position(x, y);
        }
    }
}