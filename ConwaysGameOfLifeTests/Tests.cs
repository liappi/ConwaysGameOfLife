using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class Tests
    {
        [Theory]
        [InlineData("..." +
                    "..." +
                    "...",  "..." +
                            "..." +
                            "...")]
        [InlineData(".X." +
                    "..." +
                    "...",  ".X." +
                            "..." +
                            "...")]
        
        public void GivenInitialStateShouldSetBoardToInitialState(IEnumerable<char> expected, IEnumerable<char> initialState)
        {
            var game = new Game();
            game.SetInitialState(initialState);
            Assert.Equal(expected, game.board);
        }

        [Theory]
        [InlineData("..." +
                    ".XX" +
                    "...",  "..." +
                            "..." +
                            "...")]
        [InlineData("..." +
                    ".X." +
                    ".X.",  "..." +
                            "..." +
                            "...")]
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> expected, IEnumerable<char> actual)
        {
            
        }
    }
}