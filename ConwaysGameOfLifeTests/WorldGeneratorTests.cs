using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using Xunit;
using Xunit.Abstractions;

namespace ConwaysGameOfLifeTests
{
    public class WorldGeneratorTests
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
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> initialWorld,
            IEnumerable<char> expected, int dimension)
        {
            var worldGenerator = new WorldGenerator(new NeighbourFinder(dimension), new CellUpdater());
            var actual = new string(worldGenerator.GenerateNewWorld(initialWorld).ToArray());
            
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("......" +
                    "......" +
                    "..XXX." +
                    ".XXX.." +
                    "......" +
                    "......", "......" +
                              "...X.." +
                              ".X..X." +
                              ".X..X." +
                              "..X..." +
                              "......", 6)]
        public void GivenInitialWorldShouldReturnUpdatedWorld(IEnumerable<char> initialWorld, 
            IEnumerable<char> expected, int dimension)
        {
            var worldGenerator = new WorldGenerator(new NeighbourFinder(dimension), new CellUpdater());
            var actual = new string(worldGenerator.GenerateNewWorld(initialWorld).ToArray());
            
            Assert.Equal(expected, actual);
        }
        
    }
}