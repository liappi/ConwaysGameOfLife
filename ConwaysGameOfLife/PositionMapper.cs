namespace ConwaysGameOfLife
{
    public class PositionMapper
    {
        private readonly int _dimension;

        public PositionMapper(int dimension)
        {
            _dimension = dimension;
        }

        public int MapPositionComponentForWrapAround(int positionComponent)
        {
            if (positionComponent < 0) return _dimension + positionComponent;
            if (positionComponent > _dimension - 1) return _dimension - positionComponent;
            return positionComponent;
        }

        public int MapPositionToCellIndexInWorld(Position cell)
        {
            return cell.X + cell.Y * _dimension;
        }

        public Position MapCellIndexInWorldToPosition(int cellIndex)
        {
            var x = cellIndex % _dimension;
            var y = cellIndex / _dimension;
            return new Position(x, y);
        }
    }
}