using System;
using System.Collections;
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
        public void GivenLiveCellWithLessThanTwoLiveNeighboursShouldBecomeDeadCell(IEnumerable<char> worldBeforeTick,
            IEnumerable<char> worldAfterTick)
        {
            var game = new Game();
            game.SetWorld(worldBeforeTick);
            game.Tick();
            Assert.Equal(worldAfterTick, game.world);
        }

        public static IEnumerable<object[]> PositionOfCellAndPositionsOfNeighbouringCells =>
            new List<object[]>
            {
                new object[]
                {
                    new Position(1, 1),
                    new List<Position>
                    {
                        new Position(0, 0),
                        new Position(1, 0),
                        new Position(2, 0),
                        new Position(0, 1),
                        new Position(2, 1),
                        new Position(0, 2),
                        new Position(1, 2),
                        new Position(2, 2)
                    }
                },
                new object[]
                {
                    new Position(0, 1),
                    new List<Position>
                    {
                        new Position(0, 0),
                        new Position(1, 0),
                        new Position(1, 1),
                        new Position(0, 2),
                        new Position(1, 2),
                        new Position(4, 0),
                        new Position(4, 1),
                        new Position(4, 2),
                    }
                },
                new object[]
                {
                    new Position(4, 1),
                    new List<Position>
                    {
                        new Position(4, 0),
                        new Position(3, 0),
                        new Position(3, 1),
                        new Position(3, 2),
                        new Position(4, 2),
                        new Position(0, 0),
                        new Position(0, 1),
                        new Position(0, 2)
                    }
                },
                new object[]
                {
                    new Position(1, 0),
                    new List<Position>
                    {
                        new Position(0, 0),
                        new Position(2, 0),
                        new Position(0, 1),
                        new Position(1, 1),
                        new Position(2, 1),
                        new Position(0, 4),
                        new Position(1, 4),
                        new Position(2, 4)
                    }
                },
                new object[]
                {
                    new Position(1, 4),
                    new List<Position>
                    {
                        new Position(0, 4),
                        new Position(2, 4),
                        new Position(0, 3),
                        new Position(1, 3),
                        new Position(2, 3),
                        new Position(0, 0),
                        new Position(1, 0),
                        new Position(2, 0)
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PositionOfCellAndPositionsOfNeighbouringCells))]
        public void GivenPositionOfCellShouldReturnPositionsOfNeighbouringCells(Position cell, IEnumerable<Position> neighbouringCells)
        {
            var worldController = new WorldController();
            var actual = worldController.GetPositionsOfNeighbouringCells(cell);
            Assert.Equal(neighbouringCells, actual);
        }
    }
}