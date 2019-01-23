using System.Collections.Generic;
using System.Linq;

namespace ConwaysGameOfLife
{
    public class WorldController
    {
        public IEnumerable<char> JudgeWorld(IEnumerable<char> world)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<char> GetNeighbouringCells(IEnumerable<char> world, Position cell)
        {
            var neighbouringCells = new List<char>();
            var positionsOfNeighbouringCells = GetPositionsOfNeighbouringCells(cell);

            foreach (var position in positionsOfNeighbouringCells)
            {
                neighbouringCells.Add(world.ElementAt(MapPositionToWorld(position)));
            }

            return neighbouringCells;
        }

        public IEnumerable<Position> GetPositionsOfNeighbouringCells(Position cell)
        {
            List<Position> positionsOfNeighbouringCells = new List<Position>();
            
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
            if (positionComponent < 0) return 5 + positionComponent;
            if (positionComponent > 4) return 5 - positionComponent;
            return positionComponent;
        }

        private int MapPositionToWorld(Position cell)
        {
            return cell.x + cell.y * 5;
        }
    }
}