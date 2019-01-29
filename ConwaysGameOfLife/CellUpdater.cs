namespace ConwaysGameOfLife
{
    public class CellUpdater
    {
        public char GetUpdatedCell(char cell, int countOfLiveNeighbours)
        {
            if (isLiveCell(cell))
                return GetUpdatedCellForLiveCell(countOfLiveNeighbours);
            
            return GetUpdatedCellForDeadCell(countOfLiveNeighbours);
            
        }

        private char GetUpdatedCellForLiveCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours < 2 || countOfLiveNeighbours > 3)
                return CellState.DeadCell;
            
            return CellState.LiveCell;
        }

        private char GetUpdatedCellForDeadCell(int countOfLiveNeighbours)
        {
            if (countOfLiveNeighbours == 3)
                return CellState.LiveCell;

            return CellState.DeadCell;
        }

        private bool isLiveCell(char cell)
        {
            return cell == CellState.LiveCell;
        }
        
    }
}