using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class NeighbourFinder
    {
        private PositionMapper positionMapper;

        public NeighbourFinder(int dimension)
        {
            positionMapper = new PositionMapper(dimension);
        }
        
        public IEnumerable<char> GetNeighbours(IEnumerable<char> world, Position cell)
        {
            var positionsOfNeighbours = GetPositionsOfNeighbours(cell);
            return positionsOfNeighbours.Select(position => world.ElementAt(positionMapper.MapPositionToWorld(position))).ToList();
        }
        
        public IEnumerable<Position> GetPositionsOfNeighbours(Position cell)
        {
            var positionsOfNeighbours = new List<Position>();
            
            for (var x = cell.x - 1; x <= cell.x + 1; x++)
            {
                for (var y = cell.y - 1; y <= cell.y + 1; y++)
                {
                    if (!(x == cell.x && y == cell.y))
                    {
                        var remappedX = positionMapper.MapOverlappingPositionComponent(x);
                        var remappedY = positionMapper.MapOverlappingPositionComponent(y);
                        positionsOfNeighbours.Add(new Position(remappedX, remappedY));
                    }
                }               
            }
            
            return positionsOfNeighbours;
        }
    }
}