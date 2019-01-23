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
            throw new System.NotImplementedException();
        }

        public IEnumerable<char> GetNeighbouringCells(IEnumerable<char> world, Position cell)
        {
            var positionsOfNeighbouringCells = GetPositionsOfNeighbouringCells(cell);
            return positionsOfNeighbouringCells.Select(position => world.ElementAt(MapPositionToWorld(position))).ToList();
        }

        public IEnumerable<Position> GetPositionsOfNeighbouringCells(Position cell)
        {
            var positionsOfNeighbouringCells = new List<Position>();
            
            for (var x = cell.x - 1; x <= cell.x + 1; x++)
            {
                for (var y = cell.y - 1; y <= cell.y + 1; y++)
                {
                    if (!(x == cell.x && y == cell.y))
                    {
                        positionsOfNeighbouringCells.Add(new Position(MapOverlappingPositionComponent(x), MapOverlappingPositionComponent(y)));
                    }
                }               
            }
            
            return positionsOfNeighbouringCells;
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
    }
}