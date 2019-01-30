using static ConwaysGameOfLife.Seed;

namespace ConwaysGameOfLife
{
    public class InputValidator
    {
        private readonly Renderer _renderer;

        public InputValidator(Renderer renderer)
        {
            _renderer = renderer;
        }

        public string GetValidUserInput()
        {
            var input = _renderer.GetUserInput();
            
            while (!Seeds.ContainsKey(input))
            {
                _renderer.PrintInvalidInputMessage();
                input = _renderer.GetUserInput();
            }
            
            return input;
        }
    }
}