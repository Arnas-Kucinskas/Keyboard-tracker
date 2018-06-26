using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HookFromV2
{
    public static class TextUtils
    {
        public static string[] SplitWhere(string where)
        {
            string[] result = null;
            List<string> datesList = new List<string>();

            if (where != "")
            {
                //string[] separators = { "'", " " };
                //string[] words = where.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> regex = new Dictionary<string, string>() {
                    /* YYYY-mm-dd */{"date", @"\d{4}-\d{2}-\d{2}" },
                    /* Day count */{"day", @"\'-[0-9] day\'" },
                    /* More than 9 days */ {"day9", @"\'-[0-9][0-9] day\'" }
                };
                bool isDay = false;


                try
                {
                    foreach (Match m in Regex.Matches(where, regex["date"]))
                    {
                        datesList.Add(m.Value);
                    }

                    foreach (Match m in Regex.Matches(where, regex["day"]))
                    {
                        datesList.Add(m.Value);
                        isDay = true;
                    }

                    foreach (Match m in Regex.Matches(where, regex["day9"]))
                    {
                        datesList.Add(m.Value);
                        isDay = true;
                    }

                }
                catch (Exception)
                {
                }

                if (datesList.Any())
                {
                    if (isDay)
                    {
                        List<string> temp = new List<string>();
                        foreach (var item in datesList)
                        {
                            //char test = item[2];
                            if (item[2] == '7')
                            {
                                temp.Add("Last 7 days");
                            }
                            else if(item[2] == '1')
                            {
                                temp.Add("Last 24 hours");
                            }
                            else if (item[2] == '3')
                            {
                                temp.Add("Last 30 days");
                            }
                        }
                        //datesList = temp;
                        return new string[] { temp[0] };
                    }
                    else
                    {
                        if (datesList[0] != datesList[1])
                        {
                            result = new string[] { datesList[0], datesList[1] };
                        }
                        else
                        {
                            result = new string[] { datesList[0] };
                        }
                    }

                }
                else
                {
                    result = new string[] { "No date filter selected" };
                }
            }
            return result;
        }


        public static void SetText(bool isLoading, MaterialLabel label_name, MaterialLabel label_date, string selected, string where)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>() {
               /* Charts */{ "mistakes","Mistakes Chart" },{ "typing speed","Typing Speed Chart" },{ "mistakes/speed","Otpimal typing speed chart" },{ "fixed","Time it takes to fix mistakes Chart" },
               /* HeatMap */ { "delay","Delays HeatMap" },{ "times_pressed","Times Pressed HeatMap" },
               /* Mistakes */ {"del_rep", "Deleted and replaced symbols"}, {"words", "Words where you make the most mistakes"}
            };


            if (isLoading)
            {
                label_name.Text = "Loading...";
            }
            else
            {
                /* Title */
                label_name.Text = dict[selected];

                /* Date */
                if (where != "")
                {
                    string[] dates = TextUtils.SplitWhere(where);
                    label_date.Text = "";

                    int i = 0;
                    foreach (var item in dates)
                    {
                        string prefix = "";
                        if (dates.Length > 1 && i == 0)
                        {
                            prefix = "From: ";
                        }
                        else if(dates.Length > 1 && i == 1)
                        {
                            prefix = "To: ";
                        }
                          label_date.Text += prefix + item + "\n";
                        i++;
                    }
                }
                else
                {
                    label_date.Text = "No date filter applied";
                }
            }
        }

    }
}
