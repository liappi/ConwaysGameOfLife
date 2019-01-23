namespace ConwaysGameOfLife
{
    public class PositionMapper
    {
        private static int dimension = 5;

        public static int MapOverlappingPositionComponent(int positionComponent)
        {
            if (positionComponent < 0) return dimension + positionComponent;
            if (positionComponent > dimension - 1) return dimension - positionComponent;
            return positionComponent;
        }


        public static int MapPositionToWorld(Position cell)
        {
            return cell.x + cell.y * dimension;
        }

        public static Position MapCellIndexInWorldToPosition(int cellIndex)
        {
            var x = cellIndex % dimension;
            var y = cellIndex / dimension;
            return new Position(x, y);
        }
    }
}