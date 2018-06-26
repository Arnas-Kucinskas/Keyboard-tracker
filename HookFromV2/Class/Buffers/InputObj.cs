using System;
using System.Windows.Forms;



namespace HookFromV2
{
    public class InputObj
    {
        public string _inputASCI
        { get; set; }

        public string _inputKey
        { get; set; }
        public string _dateStamp
        { get; set; }

        public int _programID
        { get; set; }

        public int _delay
        { get; set; }
       
        public InputObj()
        {

        }

        public InputObj(Keys vkCode, int programID, int delay)
        {
            _inputASCI = InputUtils.GetCharsFromKeys(vkCode);
            _inputKey = vkCode.ToString();
            _programID = programID;
            _dateStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _delay = delay;

        }
        public InputObj(string input, int programID, int delay)
        {
            _inputASCI = input;
            _inputKey = input;
            _programID = programID;
            _dateStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            _delay = delay;

        }

    }
}
