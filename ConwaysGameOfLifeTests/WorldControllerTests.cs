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
                             ".....")]
        [InlineData("....." +
                    "...X." +
                    "....." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        [InlineData("....." +
                    "....." +
                    ".X..." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> worldBeforeTick,
            IEnumerable<char> expected)
        {
            var worldController = new WorldController();
            var actual = new string(worldController.JudgeWorld(worldBeforeTick).ToArray());
            
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData("........", 0)]
        [InlineData("XX......", 2)]
        [InlineData("XXXX....", 4)]
        public void GivenNeighboursShouldReturnNumberOfLiveNeighbours(IEnumerable<char> neighbours, int expected)
        {
            var worldController = new WorldController();
            var actual = worldController.GetCountOfLiveNeighbours(neighbours);
            
            Assert.Equal(expected, actual);
        }
    }
}