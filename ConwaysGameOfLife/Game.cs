using System.Collections.Generic;

namespace ConwaysGameOfLife
{
    public class Game
    {
        public IEnumerable<char> board;

        public void SetInitialState(IEnumerable<char> initialState)
        {
            board = initialState;
        }
    }
}