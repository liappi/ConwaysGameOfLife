using System;
using System.Collections.Generic;
using ConwaysGameOfLife;
using Xunit;

namespace ConwaysGameOfLifeTests
{
    public class Tests
    {
        [Theory]
        [InlineData("....." +
                    "....." +
                    "....." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        [InlineData("..X.." +
                    "....." +
                    "....." +
                    "....." +
                    ".....", "..X.." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        
        public void GivenWorldShouldSetGameWorld(IEnumerable<char> world, IEnumerable<char> expected)
        {
            var game = new Game();
            game.SetWorld(world);
            Assert.Equal(expected, game.world);
        }

        [Theory]
        [InlineData("....." +
                    "..X.." +
                    "..X.." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        [InlineData("....." +
                    "..XX." +
                    "....." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        [InlineData("....." +
                    "..X.." +
                    ".X..." +
                    "....." +
                    ".....", "....." +
                             "....." +
                             "....." +
                             "....." +
                             ".....")]
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> worldBeforeTick, IEnumerable<char> worldAfterTick)
        {
            var game = new Game();
            game.SetWorld(worldBeforeTick);
            game.Tick();
            Assert.Equal(worldAfterTick, game.world);
        }
    }
}