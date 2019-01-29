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
    }
}