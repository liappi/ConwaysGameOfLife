namespace ConwaysGameOfLife
{
    public static class CellUpdater
    {
        const char liveCell = 'X';
        const char deadCell = '.';

        public static char GetUpdatedCell(char cell, int countOfLiveNeighbours)
        {
            if (isLiveCell(cell))
                return GetUpdatedCellForLiveCell(countOfLiveNeighbours);
            
            return GetUpdatedCellForDeadCell(countOfLiveNeighbours);
            
        }

        private static char GetUpdatedCellForLiveCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours < 2 || countOfLiveNeighbours > 3)
                return deadCell;
            
            return liveCell;
        }

        private static char GetUpdatedCellForDeadCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours == 3)
                return liveCell;

            return deadCell;
        }

        private static bool isLiveCell(char cell)
        {
            return cell == liveCell;
        }
        
    }
}