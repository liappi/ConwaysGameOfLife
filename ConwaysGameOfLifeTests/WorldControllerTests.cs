using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using Xunit;
using Xunit.Abstractions;

namespace ConwaysGameOfLifeTests
{
    public class WorldControllerTests
    {
        [Theory]
        [InlineData("....." +
                    "..X.." +
                    "....." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....", 5)]
        [InlineData("....." +
                    "...X." +
                    "....." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....", 5)]
        [InlineData("....." +
                    "....." +
                    ".X..." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....", 5)]
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> worldBeforeTick,
            IEnumerable<char> expected, int dimension)
        {
            var worldController = new WorldController(dimension);
            var actual = new string(worldController.JudgeWorld(worldBeforeTick).ToArray());
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("........", 0, 5)]
        [InlineData("XX......", 2, 5)]
        [InlineData("XXXX....", 4, 5)]
        public void GivenNeighboursShouldReturnNumberOfLiveNeighbours(IEnumerable<char> neighbours, int expected, int dimension)
        {
            var worldController = new WorldController(dimension);
            var actual = worldController.GetCountOfLiveNeighbours(neighbours);
            
            Assert.Equal(expected, actual);
        }
    }
}