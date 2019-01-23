using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConwaysGameOfLife;
using Xunit;
using Xunit.Abstractions;

namespace ConwaysGameOfLifeTests
{
    public class Tests
    {
        private readonly ITestOutputHelper output;

        public Tests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
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
            var actual = game.world;
            
            Assert.Equal(expected, actual);
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
            IEnumerable<char> expected)
        {
            var game = new Game();
            game.SetWorld(worldBeforeTick);
            game.Tick();
            var actual = game.world;
            
            Assert.Equal(expected, actual);
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
                        new Position(0, 1),
                        new Position(0, 2),
                        new Position(1, 0),
                        new Position(1, 2),
                        new Position(2, 0),
                        new Position(2, 1),
                        new Position(2, 2)
                    }
                },
                new object[]
                {
                    new Position(0, 1),
                    new List<Position>
                    {
                        new Position(4, 0),
                        new Position(4, 1),
                        new Position(4, 2),
                        new Position(0, 0),
                        new Position(0, 2),
                        new Position(1, 0),
                        new Position(1, 1),
                        new Position(1, 2),
                    }
                },
                new object[]
                {
                    new Position(4, 1),
                    new List<Position>
                    {
                        new Position(3, 0),
                        new Position(3, 1),
                        new Position(3, 2),
                        new Position(4, 0),
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
                        new Position(0, 4),
                        new Position(0, 0),
                        new Position(0, 1),
                        new Position(1, 4),
                        new Position(1, 1),
                        new Position(2, 4),
                        new Position(2, 0),
                        new Position(2, 1)
                    }
                },
                new object[]
                {
                    new Position(1, 4),
                    new List<Position>
                    {
                        new Position(0, 3),
                        new Position(0, 4),
                        new Position(0, 0),
                        new Position(1, 3),
                        new Position(1, 0),
                        new Position(2, 3),
                        new Position(2, 4),
                        new Position(2, 0)
                    }
                }
            };

        [Theory]
        [MemberData(nameof(PositionOfCellAndPositionsOfNeighbouringCells))]
        public void GivenPositionOfCellShouldReturnPositionsOfNeighbouringCells(Position cell, IEnumerable<Position> expected)
        {
            var worldController = new WorldController();
            var actual = worldController.GetPositionsOfNeighbours(cell);
            
            Assert.True(expected.SequenceEqual(actual));
        }

        public static IEnumerable<object[]> WorldAndCellPositionAndNeighbouringCells =>
            new List<object[]>
            {
                new object[]
                {
                    "....." +
                    "....." +
                    "....." +
                    "....." +
                    ".....",
                    new Position(1, 1),
                    "........"
                },
                new object[]
                {
                    ".X..." +
                    "X...." +
                    "X...." +
                    "....." +
                    ".....",
                    new Position(1, 1),
                    ".XXX...."
                },
                new object[]
                {
                    "X...." +
                    "X...." +
                    "....." +
                    "....." +
                    "X....",
                    new Position(1, 0),
                    "XXX....."
                }
            };
        
        [Theory]
        [MemberData(nameof(WorldAndCellPositionAndNeighbouringCells))]
        public void GivenPositionOfCellShouldReturnNeighbouringCells(IEnumerable<char> world, Position cell, IEnumerable<char> expected) 
        {
            var worldController = new WorldController();
            var actual = worldController.GetNeighbours(world, cell);
            
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