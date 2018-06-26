using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;


namespace HookFromV2
{
    public class CalibrationAutomaticController
    {
        public bool isOn
        { get;  set; } = false;

        public int begginingID
        { get; private set; } = 0;

        public string lastRowIDQuery
        { get; private set; } = "SELECT ID FROM InputsView ORDER BY Id DESC LIMIT 1";

        //string path = @"C:\Users\FrosTea\Documents\Visual Studio 2017\Projects\HookFromV2\HookFromV2\AuCal.json";
        string path = System.Windows.Forms.Application.StartupPath + "\\AuCal.json";


        public void IsOn()
        {
            string value = File.ReadAllText(path).ToString();
            int number;
            bool trypa = Int32.TryParse(value, out number);
            if (trypa)
            {
                begginingID = number;
                isOn = true;
            }
        }

        public void Hub()
        {
            DBUtils.OpenConection();
            try
            {
                //if ( DBUtils.ExecuteScalar("SELECT COUNT(ID) FROM InputsView" ) > 0 && !isOn)
              //  {
                     try
                     {
                        IsOn();
                    }
                    catch (Exception)
                    {
                    }
              
                    if (begginingID == 0)
                    {
                        if (!isOn)
                        {
                            File.WriteAllText(path, DBUtils.ExecuteScalar("SELECT ID FROM InputsView ORDER BY Id DESC LIMIT 1").ToString());
                            isOn = true;
                        }
                    }   
               // }  
            }
            catch (Exception)
            {
            }
            DBUtils.CloseConnection();
        }

        public void SetUserLevel(int level)
        {
            DBUtils.OpenConection();
            DBUtils.ExecuteQueries(string.Format("UPDATE User_level SET user_speed = {0}  WHERE Id=1", level));
            DBUtils.CloseConnection();
        }

        public int CalculateUserLevel()
        {

            Dictionary<int, int> dict = new Dictionary<int, int>();
            int totalVal = 0;


            for (int i = 0; i < 10000; i += 50)
            {
                string query = string.Format("SELECT  COUNT(timestamp) FROM InputsView WHERE timestamp between {0} and {1} AND ID > {2}", i + 1, i + 50, begginingID);
                int count = DBUtils.ExecuteScalar(query);
                totalVal += count;
                dict.Add(i + 50, count);
            }



            double required = ((double)totalVal * 95) / 100;
            int current = 0;
            int userLevel = 0;
            if (dict.Count > 300)
            {
                foreach (var item in dict)
                {
                    current += item.Value;
                    if (current > required)
                    {
                        double ul = item.Key + (item.Key * 0.2);
                        userLevel = (int)ul;
                        break;
                    }

                }
                DBUtils.ExecuteQueries(string.Format("DELETE FROM Inputs WHERE ID > {0} AND timestamp > {1} ", begginingID, userLevel));
                DBUtils.ExecuteQueries(string.Format("DELETE FROM Heatmap WHERE ID > {0} AND delay > {1} ", begginingID, userLevel));

                File.WriteAllText(path, "");
                DBUtils.ExecuteQueries(string.Format("UPDATE User_level SET user_speed = {0}  WHERE Id=1", userLevel));
                MessageBox.Show("Automatic calibration is done \n" + "Your user level has been set to: " + userLevel.ToString() + "ms");
                isOn = false;
            }
           return userLevel;
        }
    }
}
