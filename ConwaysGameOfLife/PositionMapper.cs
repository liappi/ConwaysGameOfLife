namespace ConwaysGameOfLife
{
    public class PositionMapper
    {
        private readonly int dimension;

        public PositionMapper(int dimension)
        {
            this.dimension = dimension;
        }

        public int MapPositionComponentForWrapAround(int positionComponent)
        {
            if (positionComponent < 0) return dimension + positionComponent;
            if (positionComponent > dimension - 1) return dimension - positionComponent;
            return positionComponent;
        }


        public int MapPositionToCellIndexInWorld(Position cell)
        {
            return cell.x + cell.y * dimension;
        }

        public Position MapCellIndexInWorldToPosition(int cellIndex)
        {
            var x = cellIndex % dimension;
            var y = cellIndex / dimension;
            return new Position(x, y);
        }
    }
}