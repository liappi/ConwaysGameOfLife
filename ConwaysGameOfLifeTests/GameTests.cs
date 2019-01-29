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

        public void GivenWorldShouldUpdateGameWorld(IEnumerable<char> world, IEnumerable<char> expected)
        {
            var game = new Game();
            game.UpdateWorld(expected);
            var actual = game.World;
            
            Assert.Equal(expected, actual);
        }
    }
}