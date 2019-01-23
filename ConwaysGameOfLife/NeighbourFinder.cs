using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class NeighbourFinder
    {
        public IEnumerable<char> GetNeighbours(IEnumerable<char> world, Position cell)
        {
            var positionsOfNeighbours = GetPositionsOfNeighbours(cell);
            return positionsOfNeighbours.Select(position => world.ElementAt(PositionMapper.MapPositionToWorld(position))).ToList();
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
                        var remappedX = PositionMapper.MapOverlappingPositionComponent(x);
                        var remappedY = PositionMapper.MapOverlappingPositionComponent(y);
                        positionsOfNeighbours.Add(new Position(remappedX, remappedY));
                    }
                }               
            }
            
            return positionsOfNeighbours;
        }
    }
}