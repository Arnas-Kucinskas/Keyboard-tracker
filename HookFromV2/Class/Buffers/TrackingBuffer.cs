using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;


namespace HookFromV2
{
    class TrackingBuffer
    {

        public List<InputForMistakes> buffer = new List<InputForMistakes>();
        private int _length
        { get; set; } = 500;
        public int pointer
        { get; set; } = -1;
        public bool ruleKeyPressed
        { get; set; } = false;

       


        public void SendRuleKeys(Keys vkCode)
        {
            switch (vkCode)
            {
                case Keys.Delete:
                    RuleDelte();
                    break;
                case Keys.Back:
                    RuleBackspace();
                    break;
                case Keys.Left:
                    PointerLeftArrow();
                    break;
                case Keys.Right:
                    PointerRightArrow();
                    break;
                default:
                    break;
            }
        }

        public void SendRuleKeys(Keys vkCode, bool ctrl)
        {
            switch (vkCode)
            {
                case Keys.Left:
                    PointerLeftArrow();
                    break;
                case Keys.Right:
                    PointerLeftArrow();
                    break;
                default:
                    break;
            }
        }


        public string GetDeleteValue()
        {
            return buffer[pointer + 1]._input;
        }

        public string GetBackSpaceValue()
        {

            return buffer[pointer]._input;
        }

        public string GetValue(int key)
        {

            return buffer[pointer + key]._input;
        }

        public InputForMistakes GetInputForMistakes(Keys vkCode)
        {
            if (vkCode == Keys.Delete)
            {
                return buffer[pointer + 1];
            }
            else
            {
                return buffer[pointer];
            }
        }

        public bool ValidateBounds(int key)
        {
            if (buffer.ElementAtOrDefault(pointer + key) == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void RemoveOldestBufferElement()
        {
            buffer.RemoveAt(0);
        }

        public int Count()
        {
            return buffer.Count();
        }

        public void Clear()
        {
            buffer.Clear();
            pointer = -1;
        }
        public void AddToBuffer(string vkCode, int delay)
        {
            if (buffer.Count == _length)
            {
                buffer.RemoveAt(0);
                InputForMistakes input = new InputForMistakes(vkCode, delay);
                buffer.Insert(pointer, input);

            }
            else
            {
                pointer++;
                InputForMistakes input = new InputForMistakes(vkCode, delay);
                buffer.Insert(pointer, input);
            }
        }


        public void PointerLeftArrow()
        {

            if (pointer < 0)
            {
                Clear();
            }
            else
            {
                pointer--;
            }

        }

        public void PointerRightArrow()
        {
            if (buffer.Count == _length || buffer.ElementAtOrDefault(pointer + 1) == null)
            {
                Clear();
            }
            else
            {
                pointer++;
            }

        }

        public void RuleDelte()
        {
            if (buffer.ElementAtOrDefault(pointer + 1) == null)
            {
                Clear();
            }
            else
            {
                buffer.RemoveAt(pointer + 1);
            }
        }

        public void RuleBackspace()
        {
            if (buffer.ElementAtOrDefault(pointer) == null)
            {
                Clear();
            }
            else
            {
                buffer.RemoveAt(pointer);
                pointer--;
            }
        }

        public string debug2()
        {
            StringBuilder builder = new StringBuilder();
            foreach (InputForMistakes var in buffer)
            {
                builder.Append(var._input);
            }
            return builder.ToString();
        }
        public string debug()
        {
            if (buffer.ElementAtOrDefault(pointer) == null)
            {
                return " index out of bounds";
            }
            else
            {
                return buffer[pointer].ToString();
            }

        }

    }
}
