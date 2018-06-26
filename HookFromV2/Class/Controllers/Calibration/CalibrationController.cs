using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace HookFromV2
{
    class CalibrationController
    {

        public string textToWrite
        { get; } = "This is a simple test! Was it Agent 47 or 007? Alexander The III, Zeus and Pontius pilate went to the bar.";

        
        private string[] userWords
        { get; set; }

        private int i
        { get; set; } = 0;

        private int inputsCounter
        { get; set; } = 0;

        private string[] systemWords
        { get; set; }

        private List<int> delayList = new List<int>();
        Stopwatch stopwatch = new Stopwatch();
        MainForm mainForm;

        public CalibrationController(MainForm form)
        {
            systemWords = textToWrite.Split(' ');
            userWords = new string[systemWords.Length + 1];
            mainForm = form;

        }


        public void Main(Keys vkCode, string last_char, string typeOfPressedKey)
        {
            if (typeOfPressedKey == "normal")
            {
                if (!stopwatch.IsRunning)
                {
                    stopwatch.Start();
                }

                if (last_char != " ")
                {
                    userWords[i] += last_char;
                }
                else// ==space
                {
                    i++;
                }

                delayList.Add((int)stopwatch.ElapsedMilliseconds);
                stopwatch.Restart();
                inputsCounter++;
            }
            else if (vkCode == Keys.Back)
            {
                try
                {
                    if (userWords[i] == null || userWords[i] == "")
                    {
                        if (i >= 0)
                        {
                            i--;
                        }
                    }
                    else
                    {
                        userWords[i] = userWords[i].Remove(userWords[i].Length - 1);
                    }
                    stopwatch.Restart();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                stopwatch.Restart();
            }

            if (i >= systemWords.Length - 1 && last_char == ".")
            {
                Resutls();
            }
            else if (i >= systemWords.Length)
            {
                Resutls();
            }
        }



        private void Resutls()
        {
            SortList();

            int mistakesCount = CompareArrays();
            int percentage = Percentage(mistakesCount);
            int average = ListSum();
            int ajustedAverage = CalculateAverage(mistakesCount, average, percentage);
            string userLevel = GetUserLevel(ajustedAverage);
            string message = "";


            if (ajustedAverage == 0)
            {
                message = string.Format("You've made too many mistakes. {0} words were written with mistakes \n Which is {1}% of whole written text", mistakesCount, percentage);
            }
            else
            {
                DBUtils.OpenConection();
                string query = string.Format("UPDATE User_level SET user_level = '{0}', user_speed = {1}  WHERE Id=1", userLevel, ajustedAverage+400);
                DBUtils.ExecuteQueries(query);
                DBUtils.CloseConnection();

                message = string.Format("Your level has been assigned:{0} \n Your average typing speed is {1}", userLevel, ajustedAverage+400);
            }

            mainForm.CheckForAutoCalibration(false);
            MessageBox.Show(message);

        }


        private string GetUserLevel(int ajustedAverage)
        {
            string userLevel = "";

            if (ajustedAverage <= 400)
            {
                userLevel = "Professional";
            }
            else if (ajustedAverage <= 800)
            {
                userLevel = "Advanced";
            }
            else if (ajustedAverage <= 1400)
            {
                userLevel = "Intermede";
            }
            else if (ajustedAverage <= 2400)
            {
                userLevel = "Begginer";
            }
            else if (ajustedAverage <= 5500)
            {
                userLevel = "5.5k";
            }
            else if (ajustedAverage > 5500)
            {
                userLevel = "lost cause";
            }
            return userLevel;

        }
        private int CalculateAverage(int mistakesCount, int average, int percentage)
        {
            double multiplier = GetMultiplier(percentage);
            double result = average * 2; 
            return (int)Math.Round((result * multiplier));
        }
        private int Percentage(int mistakesCount)
        {
            double percentage = ((double)mistakesCount / (double)systemWords.Length) * 100;
            return (int)percentage;
        }
        private double GetMultiplier(double percentage)
        {
            double multiplier = 0;
            if (percentage <= 10)
            {
                multiplier = 1;
            }
            else if (percentage <= 20)
            {
                multiplier = 1.15;
            }
            else if (percentage <= 30)
            {
                multiplier = 1.3;
            }
            else if (percentage <= 45)
            {
                multiplier = 1.5;
            }
            else if (percentage <= 100)
            {
                multiplier = 0;
            }
            else if (true)
            {
                multiplier = 9999999;
                MessageBox.Show("CaclulatePercentageMulti error");
            }
            return multiplier;
        }
        private int CompareArrays()
        {
            int y = 0;
            int mistakesCount = 0;
            foreach (var item in systemWords)
            {
                if (item != userWords[y])
                {
                    mistakesCount++;
                }
                y++;
            }
            return mistakesCount;
        }
        private void SortList()
        {
            delayList.Sort();
            delayList.RemoveRange(delayList.Count - 5, 5);
            delayList.RemoveRange(0, 5);
        }

        private int ListSum()
        {
            int sum = 0;
            int average = 0;
            foreach (var item in delayList)
            {
                sum += item;
            }
            return average = sum / delayList.Count();
        }
    }
}
