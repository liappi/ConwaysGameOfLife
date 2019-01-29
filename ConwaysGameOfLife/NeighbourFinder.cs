using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class NeighbourFinder
    {
        private readonly PositionMapper _positionMapper;

        public NeighbourFinder(int dimension)
        {
            _positionMapper = new PositionMapper(dimension);
        }
        
        public int GetCountOfLiveNeighbours(IEnumerable<char> world, int cellIndex)
        {
            var cellPosition = _positionMapper.MapCellIndexInWorldToPosition(cellIndex);
            
            var positionsOfNeighbours = GetPositionsOfNeighbours(cellPosition);
            var neighbours = positionsOfNeighbours.Select(position => world.ElementAt(_positionMapper.MapPositionToCellIndexInWorld(position))).ToList(); 
            
            return neighbours.Count(neighbour => neighbour.Equals(CellState.LiveCell));
        }
        
        private IEnumerable<Position> GetPositionsOfNeighbours(Position cell)
        {
            var positionsOfNeighbours = new List<Position>();
            
            for (var x = cell.X - 1; x <= cell.X + 1; x++)
            {
                for (var y = cell.Y - 1; y <= cell.Y + 1; y++)
                {
                    if (!(x == cell.X && y == cell.Y))
                    {
                        var remappedX = _positionMapper.MapPositionComponentForWrapAround(x);
                        var remappedY = _positionMapper.MapPositionComponentForWrapAround(y);
                        positionsOfNeighbours.Add(new Position(remappedX, remappedY));
                    }
                }               
            }
            
            return positionsOfNeighbours;
        }
    }
}