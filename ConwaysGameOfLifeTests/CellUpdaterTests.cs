using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class CellUpdaterTests
    {
        [Theory]
        [InlineData(CellState.LiveCell, 1, CellState.DeadCell)]
        [InlineData(CellState.LiveCell, 0, CellState.DeadCell)]
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldReturnDeadCell(char cell, int countOfLiveNeighbours, char expected)
        {
            var cellUpdater = new CellUpdater();
            var actual = cellUpdater.GetUpdatedCell(cell, countOfLiveNeighbours);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(CellState.LiveCell, 4, CellState.DeadCell)]
        [InlineData(CellState.LiveCell, 8, CellState.DeadCell)]
        public void GivenLiveCellWithMoreThanThreeLiveNeighboursShouldReturnDeadCell(char cell, int countOfLiveNeighbours, char expected)
        {
            var cellUpdater = new CellUpdater();
            var actual = cellUpdater.GetUpdatedCell(cell, countOfLiveNeighbours);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(CellState.LiveCell, 2, CellState.LiveCell)]
        [InlineData(CellState.LiveCell, 3, CellState.LiveCell)]
        public void GivenLiveCellWithTwoOrThreeLiveNeighboursShouldReturnLiveCell(char cell, int countOfLiveNeighbours, char expected)
        {
            var cellUpdater = new CellUpdater();
            var actual = cellUpdater.GetUpdatedCell(cell, countOfLiveNeighbours);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(CellState.DeadCell, 3, CellState.LiveCell)]
        public void GivenDeadCellWithThreeLiveNeighboursShouldReturnLiveCell(char cell, int countOfLiveNeighbours, char expected)
        {
            var cellUpdater = new CellUpdater();
            var actual = cellUpdater.GetUpdatedCell(cell, countOfLiveNeighbours);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(CellState.DeadCell, 0, CellState.DeadCell)]
        [InlineData(CellState.DeadCell, 7, CellState.DeadCell)]
        public void GivenDeadCellWithAnyNumberOtherThanThreeLiveNeighboursShouldReturnDeadCell(char cell, int countOfLiveNeighbours, char expected)
        {
            var cellUpdater = new CellUpdater();
            var actual = cellUpdater.GetUpdatedCell(cell, countOfLiveNeighbours);
            Assert.Equal(expected, actual);
        }
    }
}