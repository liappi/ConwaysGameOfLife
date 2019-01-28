using System.Collections.Generic;
using ConwaysGameOfLife;
using Xunit;
using Xunit.Abstractions;

namespace ConwaysGameOfLifeTests
{
    public class GameTests
    {
        private readonly ITestOutputHelper output;

        public GameTests(ITestOutputHelper output)
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
                             ".....", 5)]
        [InlineData("..X.." +
                    "....." +
                    "....." +
                    "....." +
                    ".....", "..X.." +
                             "....." +
                             "....." +
                             "....." +
                             ".....", 5)]

        public void GivenWorldShouldSetGameWorld(IEnumerable<char> world, IEnumerable<char> expected, int dimension)
        {
            var game = new Game(world, dimension);
            var actual = game._world;
            
            Assert.Equal(expected, actual);
        }
    }
}