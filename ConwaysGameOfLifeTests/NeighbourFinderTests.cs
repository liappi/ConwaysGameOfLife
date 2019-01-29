using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class NeighbourFinderTests
    {
        [Theory]
        [InlineData("..." +
                    "..." +
                    "...", 0)]
        [InlineData("X.." +
                    "..." +
                    "...", 1)]
        [InlineData("XXX" +
                    "..X" +
                    "..X", 5)]
        [InlineData("XXX" +
                    "X.X" +
                    "XXX", 8)]
        public void GivenCellAndNeighboursShouldReturnCountOfLiveNeighbours(IEnumerable<char> cellAndNeighbours, int expected)
        {
            var indexOfCentreCell = 4;
            var dimension = 3;
            var neighbourFinder = new NeighbourFinder(dimension);
            var actual = neighbourFinder.GetCountOfLiveNeighbours(cellAndNeighbours, indexOfCentreCell);
            
            Assert.Equal(expected, actual);
        }
    }
}