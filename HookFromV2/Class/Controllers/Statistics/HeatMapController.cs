using System.Collections.Generic;

namespace HookFromV2
{
    public class HeatMapController
    {
        public Dictionary<string, int> heatDict = new Dictionary<string, int>()
        {   /* Letters */
            {"Q",0},{"W",0},{"E",0},{"R",0},{"T",0},{"Y",0},{"U",0},{"I",0},{"O",0},{"P",0},{"A",0},{"S",0},{"D",0},{"F",0},
            {"G",0},{"H",0},{"J",0},{"K",0},{"L",0},{"Z",0},{"X",0},{"C",0},{"V",0},{"B",0},{"N",0},{"M",0},
            /* NumPad */
            {"NumPad1",0},{"NumPad2",0},{"NumPad3",0},{"NumPad4",0},{"NumPad5",0},{"NumPad6",0},{"NumPad7",0},{"NumPad8",0},{"NumPad9",0},{"NumPad0",0},
            {"Decimal",0},{"Add",0},{"Subtract",0},{"Multiply",0},{"Divide",0},{"NumLock",0},{"Return",0},
            /* Arrows zone */
            {"Left",0},{"Down",0},{"Right",0},{"Up",0},
            {"Delete",0},{"End",0},{"Next",0},{"Insert",0},{"Home",0},{"PageUp",0},{"PrintScreen",0},{"Scroll",0},{"Pause",0},
            /* Esc and F keys */
            {"Escape",0},{"F1",0},{"F2",0},{"F3",0},{"F4",0},{"F5",0},{"F6",0},{"F7",0},{"F8",0},{"F9",0},{"F10",0},{"F11",0},{"F12",0},
            /* Tilde row */
            {"Oemtilde",0},{"D1",0},{"D2",0},{"D3",0},{"D4",0},{"D5",0},{"D6",0},{"D7",0},{"D8",0},{"D9",0},{"D0",0},{"OemMinus",0},{"Oemplus",0},{"Back",0},
            /* OemKeys */
            {"OemBackslash",0},{"OemQuestion",0},{"OemPeriod",0},{"Oemcomma",0},{"Oem5",0},{"Oem7",0},{"Oem1",0},{"Oem6",0},{"OemOpenBrackets",0},
            /* U kind of row keys TAB -> Enter */
            {"RShiftKey",0},{"RControlKey",0},{"Apps",0},{"RWin",0},{"RMenu",0},{"Space",0},{"LMenu",0},{"LWin",0},{"LControlKey",0},{"LShiftKey",0},{"Capital",0},{"Tab",0},

        };
        public Dictionary<string, int> weeklyHeatmap = new Dictionary<string, int>()
        {
            {"Monday",0},{"Tuesday",0},{"Wensday",0},{"Thursday",0},{"Friday",0},{"Saturday",0},{"Sunday",0},
        };
        public Dictionary<string, int> hourlyHeatmap = new Dictionary<string, int>();

        public int totalValue = 0;
        public int highestValue = 0;
        public int highestHourValue = 0;
        public int highestWeekValue = 0;
        public string selectedHeatMap = "delay";
        
        public string where = "AND (date  > datetime('now','-30 day'))";

        public int Run()
        {
            DBUtils.OpenConection();
            if (selectedHeatMap == "delay")
            {
                GetDelayHeatmap();
                GetDailyHeatmap("SELECT AVG(delay) FROM HeatmapView WHERE strftime('%H:%M:%S', date) BETWEEN '{0}' AND '{1}' {2} ");
                GetWeeklyHeatmap("SELECT AVG(delay) FROM HeatmapView WHERE strftime('%w', date) =  '{0}' {1}");
            }
            else if (selectedHeatMap == "times_pressed")
            {
                GetTimesPressedHeatmap();
                GetDailyHeatmap("SELECT COUNT(input) FROM HeatmapView WHERE strftime('%H:%M:%S', date) BETWEEN '{0}' AND '{1}' {2} ");
                GetWeeklyHeatmap("SELECT COUNT(input) FROM HeatmapView WHERE strftime('%w', date) =  '{0}' {1}");
            }
            DBUtils.CloseConnection();
            return 1;
        }

        public void GetTimesPressedHeatmap()
        {
            GetHeatmap("SELECT COUNT(input) FROM HeatmapView WHERE (input = '{0}' {1})");
        }
        public void GetDelayHeatmap()
        {
            GetHeatmap("SELECT AVG(delay) FROM HeatmapView WHERE (input = '{0}' {1})");
        }

        private void GetWeeklyHeatmap(string query)
        {
            highestWeekValue = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            int i = 1;
            foreach (var item in weeklyHeatmap)
            {
                if (i == 7)
                {
                    i = 0;
                }
                string querySend = string.Format(query, i, where);
                int avg = DBUtils.ExecuteScalar(querySend);
                dict.Add(item.Key, avg);
                if (avg > highestWeekValue)
                {
                    highestWeekValue = avg;
                }
                i++;
            }
            weeklyHeatmap = dict;
        }

        private void GetDailyHeatmap(string query)
        {
            highestHourValue = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < 24; i++)
            {
                string from;
                string to;
                string zero = "";

                if (i<10)
                {
                    zero = "0";  
                }
                    from = zero + i.ToString() + ":00:00";
                    to = zero + i.ToString() + ":59:59";
                
                string querySend = string.Format(query, from, to, where);
                int avg = DBUtils.ExecuteScalar(querySend);

                dict.Add(from, avg);
                if (avg > highestHourValue)
                {
                    highestHourValue = avg;
                }
            }
            hourlyHeatmap = dict;
        }

        private void GetHeatmap(string query)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            highestValue = 0;
            totalValue = 0;

            foreach (var item in heatDict)
            {
                string querySend = string.Format(query, item.Key, where);
                int avg = DBUtils.ExecuteScalar(querySend);
                dict.Add(item.Key, avg);

                totalValue += avg;
                if (avg > highestValue)
                {
                    highestValue = avg;
                }
            }
            heatDict = dict;
        }
    }
}
