using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;


namespace HookFromV2
{
    public class StatsController
    {

        public string selectedStats
        { get; set; } = "del_rep";

        public string where
        { get; set; } = "WHERE datetime  > datetime('now','-30 day')";
        public List<KeyValuePair<string, int>> wordsList
        { get; private set; }

        private static string query
        { get; } = "SELECT * FROM MistakesView ";

        public List<MistakesObject> mistList = new List<MistakesObject>();

        public struct Data
        {
            public Data(int intValue, string strValue)
            {
                IntegerData = intValue;
                StringData = strValue;
            }
            public int IntegerData { get;  set; }
            public string StringData { get;  set; }
        }

        
        public int RunFirst()
        {
            DBUtils.OpenConection();
            if (selectedStats == "del_rep")
            {
                mistList = DBUtils.ReadMistakes(query + where);
            }
            else if (selectedStats == "words")
            {
                wordsList = DBUtils.ReadWords(query + where);
            }
            DBUtils.CloseConnection();
            return 1;
        }

        public int Run()
        {
            DBUtils.OpenConection();
            if (selectedStats != "del_rep")
            {
                mistList = DBUtils.ReadMistakes(query + where); 
            }
            if (selectedStats != "words")
            {
                wordsList = DBUtils.ReadWords(query + where);
            }
            DBUtils.CloseConnection();
            return 1;
        }

        public List<KeyValuePair<string, int>>  GetFinalWords(int id)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            

            foreach (var item in mistList[id].finalWord)
            {
                if (dict.ContainsKey(item))
                {
                    dict[item]++;
                }
                else
                {
                    dict.Add(item, 1);
                }
            }

            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            foreach (KeyValuePair<string, int> item in dict.OrderBy(key => key.Value))
            {
                list.Add(item);
            }

            list.Reverse();

            if (list.Count > 5)
            {
                list.RemoveRange(6, list.Count -6);
            }
            return list ;
        }

        public void PopulateDataGrid(DataGridView grid)
        {
            int i = 0;
            if (grid.RowCount > 0)
            {
                grid.Rows.Clear();
            }

            foreach (var item in mistList)
            {
                grid.Rows.Add(item.deletedValue, item.replacedValue, item.replacedTimes);
                if (i == 20)
                {
                    break;
                }
                i++;
            }
        }
    }
}
