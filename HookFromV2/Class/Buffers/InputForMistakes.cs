

namespace HookFromV2
{
    class InputForMistakes
    {
        public string _input
        { get; set; }
        public int _delay
        { get; set; }

        public InputForMistakes(string vkCode, int delay)
        {
            _input = vkCode;
            _delay = delay;
        }
    }
}
