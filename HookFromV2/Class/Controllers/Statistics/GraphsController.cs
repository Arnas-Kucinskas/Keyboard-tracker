using System;
using System.Collections.Generic;


namespace HookFromV2
{
    public class GraphsController
    {

        public List<double> doubleList = new List<double>();
        public List<TypingSpeed_MistakesCount> mistakesList = new List<TypingSpeed_MistakesCount>();
        public List<TypingSpeed_MistakesCount> mistakesSpeedList = new List<TypingSpeed_MistakesCount>();
        public List<TimeToFixMistakesObj> avgFixList = new List<TimeToFixMistakesObj>();
        /* Mistakes speed */
        public Dictionary<double, double> mistakesSpeedDict = new Dictionary<double, double>();
        public double[] avgTypingSpeed = null;

        public string whereAnd = "AND(datetime > datetime('now','-30 day'))";
        public string where = "WHERE datetime  > datetime('now','-30 day')";
        public TimeSpan time;

        public string selectedGraph = "mistakes";
        private bool isLoadedMistakes = false;
        private bool isLoaderTypingSpeed = false;
        private bool isLoadedMistakesSpeed = false;
        private bool isLoadedFixed = false;

        public int RunFirst()
        {
            

            DBUtils.OpenConection();
            AllInputsTypingSpeed();
            if (selectedGraph == "mistakes")
            {
                MistakesCountLoader();
            }
            else if (selectedGraph == "typing speed")
            {
                TypingSpeedLoader();
            }
            else if (selectedGraph == "mistakes/speed")
            {
                MistakesSpeedLoader();
            }
            else if (selectedGraph == "fixed")
            {
                TimeSpentFixingLoader();
            }


                DBUtils.CloseConnection();
            return 1;
        }

        public int Run()
        {
            isLoadedFixed = false;
            isLoadedMistakes = false;
            isLoadedMistakesSpeed = false;
            isLoaderTypingSpeed = false;
            DBUtils.OpenConection();
            if (!isLoadedMistakes)
            {
                MistakesCountLoader();
            }
            if (!isLoaderTypingSpeed)
            {
                TypingSpeedLoader();
            }
            if (!isLoadedMistakesSpeed)
            {
                MistakesSpeedLoader();
            }
            if (!isLoadedFixed)
            {
                TimeSpentFixingLoader(); 
            }
            DBUtils.CloseConnection();
            return 1;

        }

        private void MistakesSpeedLoader()
        {
            if (Validation("MistakesView") > 0)
            {
                MistakesSpeed();
            }
            else
            {
                mistakesSpeedList.Clear();
            }
        }

        private void TimeSpentFixingLoader()
        {
            if (Validation("MistakesView") > 0)
            {
                AverageTimeItTakesToFixMistakes();
            }
            else
            {
                avgFixList.Clear();
            }
        }

        private void MistakesCountLoader()
        {
            if (Validation("MistakesView") > 0)
            {
                TypingSpeed_MistakesCount();
            }
            else
            {
                mistakesList.Clear();
            }
        }

        private void TypingSpeedLoader()
        {
            if (Validation("InputsView") > 0)
            {
                Typing_Speed();
            }
            else
            {
                doubleList.Clear();
            }
        }


        public int Validation(string view)
        {
            string valiadtioQuery = string.Format("SELECT  COUNT(id) FROM {1}  {0}", where, view);
            int validation = DBUtils.ExecuteScalar(valiadtioQuery);
            return validation;
        }

        public void AllInputsTypingSpeed()
        {
            string query = string.Format("SELECT  SUM(timestamp) FROM InputsView {0}", where);
            int total_typing_speed = 0;
            total_typing_speed = DBUtils.ExecuteScalar(query);

            time = TimeSpan.FromMilliseconds(total_typing_speed);

        }

        private void AverageTimeItTakesToFixMistakes()
        {
            avgFixList.Clear();
            int total = 0;
            int totalAccountedFor = 0;
            for (int i = 0; i < 10000; i += 50)
            {
                int typS = DBUtils.ExecuteScalar(string.Format("SELECT typing_speed FROM MistakesView WHERE typing_speed between {0} and {1} {2} ", i + 1, i + 50, whereAnd));
                int trueTypS = DBUtils.ExecuteScalar(string.Format("SELECT true_typing_speed FROM MistakesView WHERE typing_speed between {0} and {1} {2} ", i + 1, i + 50, whereAnd));
                int count = DBUtils.ExecuteScalar(string.Format("SELECT count(ID) FROM MistakesView WHERE typing_speed between {0} and {1} {2} ", i + 1, i + 50, whereAnd));
                int avg = trueTypS - typS;
                if (avg > 0)
                {
                    total += avg;
                    totalAccountedFor += avg * count;
                    TimeToFixMistakesObj ttf = new TimeToFixMistakesObj(i, count, trueTypS - typS);
                    avgFixList.Add(ttf);
                }
            }

            List<TimeToFixMistakesObj> tempList = new List<TimeToFixMistakesObj>();
            foreach (var item in avgFixList)
            {
                item.CalcPercentages(total, totalAccountedFor);
            }
            isLoadedFixed = true;
        }

        public void Typing_Speed()
        {
            doubleList.Clear();
            string query;

            query = "SELECT  COUNT(Id) FROM InputsView " + where;
            int sumOfRows = DBUtils.ExecuteScalar(query);
            double multiplier = Math.Floor((double)sumOfRows / 40);

            if (multiplier > 1)
            {
               doubleList = DBUtils.AllInputsTypingSpeed(("SELECT timestamp FROM InputsView " + where), (int)multiplier);
            }
            else
            {
                doubleList.Clear();
            }
            SplitWhere();
            isLoaderTypingSpeed = true;
        }


        public string[] SplitWhere()
        {
            string [] result = new string[] { "" };
            return result;
        }

        private void MistakesSpeed()
        {
            mistakesSpeedDict.Clear();
            int average = DBUtils.ExecuteScalar(string.Format("SELECT AVG(timestamp) FROM InputsView WHERE timestamp > 5 {0}", whereAnd));
           
            for (int i = 0; i < 10000; i += 50)
            {
                string query = string.Format("SELECT  AVG(true_typing_speed) FROM MistakesView WHERE typing_speed between {0} and {1} {2}", i + 1, i + 50, whereAnd);
                int trueTypSpeedAvg = DBUtils.ExecuteScalar(query);
                if (trueTypSpeedAvg > 9)
                {
                    mistakesSpeedDict.Add(Math.Round(1000 / (double)(i+50), 2), Math.Round(1000 / (double)trueTypSpeedAvg, 2));
                }
            }
            avgTypingSpeed = new double[mistakesSpeedDict.Count];
            int k = 0;
            foreach (var item in mistakesSpeedDict)
            {
                avgTypingSpeed[k] = Math.Round(1000 / (double)average * 0.8,2);
                k++;
            }
            isLoadedMistakesSpeed = true;
        }

        private void TypingSpeed_MistakesCount()
        {
            mistakesList.Clear();
            for (int i = 0; i < 10000; i += 50)
            {
                string query = string.Format("SELECT  COUNT(id) FROM MistakesView WHERE typing_speed between {0} and {1} {2}", i + 1, i + 50, whereAnd);
                int mistakes_count = DBUtils.ExecuteScalar(query);
                //double speed = (double)(i + 50) / (double)1000;

                if (mistakes_count != 0)
                {
                    double speed = (double)1000 / (double)(i+50);
                    TypingSpeed_MistakesCount typS = new TypingSpeed_MistakesCount(Math.Round(speed, 2), mistakes_count);
                    mistakesList.Add(typS);
                }
            }
            PercentageCalc();
            isLoadedMistakes = true;
        }

        private void PercentageCalc()
        {
            int totalCount = 0;
            foreach (var item in mistakesList)
            {
                totalCount += item.mistakesCount;
            }

            List<TypingSpeed_MistakesCount> tempList = new List<TypingSpeed_MistakesCount>();
            foreach (var item in mistakesList)
            {
                double percentage = (item.mistakesCount / (double)totalCount) * 100;
                if (percentage >= 0.5)
                {
                    TypingSpeed_MistakesCount newItem = new TypingSpeed_MistakesCount(Math.Round(item.speed, 1), item.mistakesCount, Math.Round(percentage, 1));
                    tempList.Add(newItem);

                }
            }
            mistakesList = tempList;
        }

    }
}
