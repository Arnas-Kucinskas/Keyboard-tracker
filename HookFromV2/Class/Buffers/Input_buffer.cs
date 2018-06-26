using System.Collections.Generic;
using System.Windows.Forms;

namespace HookFromV2
{
    class Input_buffer
    {
        List<InputObj> inputList = new List<InputObj>();

        public void AddItem(Keys vkCode, int programID, int delay)
        {
            InputObj obj = new InputObj(vkCode, programID, delay);
            inputList.Add(obj);
        }
        public void AddItem(string input, int programID, int delay)
        {
            InputObj obj = new InputObj(input, programID, delay);
            inputList.Add(obj);
        }
    }
}
