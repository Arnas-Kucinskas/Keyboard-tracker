using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace HookFromV2
{
    class MainFormController
    {
        public Keys lastKeyPressed = Keys.F22;
        public List<InputObj> inputBuffer = new List<InputObj>();
        public bool writeInProgress = false;

        public void AddToInputBuffer(Keys vkCode, int stopWatchTime, int exeID, string type)
        {
            if (vkCode != lastKeyPressed)
            {
                InputObj inputRow = new InputObj();
                if (type == "normal")
                {
                     inputRow = new InputObj(vkCode, exeID, stopWatchTime); // changed heatmap row
                }
                else
                {
                    inputRow = new InputObj(vkCode.ToString(),  exeID, stopWatchTime);
                }
                
                inputBuffer.Add(inputRow);
            }

            lastKeyPressed = vkCode;
        }
        public void LastKeyPressed_LiftOff(Keys vkCode)
        {
            if (vkCode == lastKeyPressed)
            {
                lastKeyPressed = Keys.F22;
            }
        }
        public int  StoreHeatMapAndInputs() //TODO: make this thing async or something
        {
            
            if (inputBuffer.Any())
            {
                writeInProgress = true;
                List<InputObj> tempList = new List<InputObj>(inputBuffer);
                inputBuffer.Clear();
               
                DBUtils.OpenConection();
                string query;
                foreach (var item in tempList)
                {
                    query = string.Format("INSERT INTO Heatmap (input,delay,date,program_id) " + "VALUES ('{0}', {1}, '{2}', '{3}')", item._inputKey, item._delay, item._dateStamp.ToString(), item._programID);
                    DBUtils.ExecuteQueries(query);
                    if (item._inputASCI == "'")
                    {
                        item._inputASCI = "''";
                    }
                    query = string.Format("INSERT INTO Inputs ([input], [program_id], [datetime], [timestamp]) VALUES ('{0}', {1}, '{2}', {3})", item._inputASCI, item._programID, item._dateStamp, item._delay);
                    DBUtils.ExecuteQueries(query);
                }
                DBUtils.CloseConnection();
            }
            writeInProgress = false;
            return 1;
        }
    }
}
