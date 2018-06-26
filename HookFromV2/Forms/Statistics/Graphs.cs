using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using System.Windows;


namespace HookFromV2
{
    public partial class Graphs : Form
    {

        public GraphsController graphicsController = new GraphsController();
        bool loadAccounted = true;
        public Graphs()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.Icon = Properties.Resources.appicon;
        }


        private void Graphs_Load(object sender, EventArgs e)
        {
            AsyncRun();

        }


        public void ChartTimeToFix_Loader()
        {
            chart1.Series.Clear();
            chart1.AxisY.Clear();
            chart1.AxisX.Clear();

  
            string[] speed = graphicsController.avgFixList.Select(x => x.cps.ToString()).ToArray();

            double[] count = null;
            if (loadAccounted)
            {
                count = graphicsController.avgFixList.Select(x => x.accountedForPrecentage).ToArray();
            }
            else
            {
                count = graphicsController.avgFixList.Select(x => x.percentage).ToArray();
            }

            Array.Reverse(speed);
            Array.Reverse(count);

            if (graphicsController.mistakesList.Count > 0)
            {
                chart1.Series = new SeriesCollection
                {
                  new LineSeries
                    {
                    Title = "Time it takes to fix %",
                    Values = new ChartValues<double>(count)
                    }
                 };

                chart1.AxisX.Add(new Axis
                {
                    Separator = new Separator { Step = (int)Math.Ceiling(graphicsController.mistakesList.Count / (double)5), IsEnabled = false },
                    ShowLabels = true,
                    Title = "Clicks per second",
                    Labels = speed
                });

                chart1.AxisY.Add(new Axis
                {
                    MinValue = 0,
                    Title = "Time it takes to fix %",

                });
            }
        }


        public void ChartMistakesCount_Loader()
        {
            chart1.Series.Clear();
            chart1.AxisY.Clear();
            chart1.AxisX.Clear();

            string[] speed = graphicsController.mistakesList.Select(x => x.speed.ToString()).ToArray();
            double[] count = graphicsController.mistakesList.Select(x => x.percentage).ToArray();
            Array.Reverse(speed);
            Array.Reverse(count);

            if (graphicsController.mistakesList.Count > 0)
            {
                chart1.Series = new SeriesCollection
                {
                  new LineSeries
                    {
                    Title = "Mistakes %",
                    Values = new ChartValues<double>(count)
                    }
                 };

                chart1.AxisX.Add(new Axis
                {
                    Separator = new Separator { Step = (int)Math.Ceiling(graphicsController.mistakesList.Count / (double)5), IsEnabled = false },
                    ShowLabels = true,
                    Title = "Clicks per second",
                    Labels = speed
                });

                chart1.AxisY.Add(new Axis
                {
                    MinValue = 0,
                    Title = "Mistakes %",

                });
            }
        }

        public void ChartTypingSpeed_Loader()
        {
            chart1.Series.Clear();
            chart1.AxisY.Clear();
            chart1.AxisX.Clear();

                string[] speed = graphicsController.doubleList.Select(x => x.ToString()).ToArray();

                chart1.Series = new SeriesCollection
            {
                  new LineSeries
                {
                    Title = "Clicks per second:",
                    Values = new ChartValues<double>(graphicsController.doubleList)
                }
             };

                chart1.AxisX.Add(new Axis
                {
                    Separator = new Separator { Step = 1, IsEnabled = true },
                    ShowLabels = true,
                    Title = "Time",
                    FontWeight = FontWeights.UltraBold,
                    Labels = graphicsController.SplitWhere() /* works fine with "speed" fix it */


                });

                chart1.AxisY.Add(new Axis
                {
                    MinValue = 0,
                    Title = "Clicks per second",

                });
        }

        public void ChartMistakesSpeed_Loader()
        {
            chart1.Series.Clear();
            chart1.AxisY.Clear();
            chart1.AxisX.Clear();


            string[] speed = graphicsController.mistakesSpeedDict.Select(x => x.Key.ToString()).ToArray();
            double[] count = graphicsController.mistakesSpeedDict.Select(x => x.Value).ToArray();


            Array.Reverse(speed);
            Array.Reverse(count);



            if (graphicsController.mistakesList.Count > 0)
            {
                chart1.Series = new SeriesCollection
                {
                  new LineSeries
                    {
                    Title = "True typing speed",
                    Values = new ChartValues<double>(count),
                    ScalesYAt = 0
                    },
                  new LineSeries
                    {
                    Title = "Average typing speed",
                    Values = new ChartValues<double>(graphicsController.avgTypingSpeed) ,
                    IsEnabled = false,
                    ScalesYAt = 0,
                    },

            };
              
                chart1.AxisX.Add(new Axis
                {
                    Separator = new Separator { Step = (int)Math.Ceiling(graphicsController.mistakesList.Count / (double)5), IsEnabled = false },
                    ShowLabels = true,
                    Title = "Clicks per second",
                    Labels = speed
                });

                chart1.AxisY.Add(new Axis
                {
                    MinValue = 0,
                    Title = "True typing speed %",

                });
            }

         }


        private void TimeSpentLabel(TimeSpan time)
        {
            int minutes = (int)time.TotalMinutes % 60;
            int hours = (int)time.TotalMinutes / 60;
            string hourOrHours = "hours";
            string minuteOrMinutes = "minutes";
            if (hours == 1)
            {
                hourOrHours = "hour";
            }
            if (minutes == 1)
            {
                minuteOrMinutes = "minute";
            }
            if (hours == 0)
            {
                label_workTime.Text = string.Format("{0} {1}", minutes, minuteOrMinutes);
            }
            else
            {
                label_workTime.Text = string.Format("{0} {2} {1} {3}", hours, minutes, hourOrHours, minuteOrMinutes);
            }
        }


        private void button_filter_Click(object sender, EventArgs e)
        {
            FilterForm filter = new FilterForm(this, graphicsController);
            filter.Show();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Mistakes Count")
            {
                graphicsController.selectedGraph = "mistakes";
            }
            else if (comboBox1.SelectedItem.ToString() == "Typing Speed")
            {
                graphicsController.selectedGraph = "typing speed"; ;
            }
            else if (comboBox1.SelectedItem.ToString() == "Optimal typing speed")
            {
                graphicsController.selectedGraph = "mistakes/speed";
            }
            else if (comboBox1.SelectedItem.ToString() == "Time it takes to fix mistakes")
            {
                graphicsController.selectedGraph = "fixed";
            }
            SelectChartToLoad();

        }

        public async void AsyncRun()
        {
            TextUtils.SetText(true, label_name, label_date, graphicsController.selectedGraph, graphicsController.where);
            int f = await Task.Run(() => graphicsController.RunFirst());
            TimeSpentLabel(graphicsController.time);
            SelectChartToLoad();
            TextUtils.SetText(false, label_name, label_date, graphicsController.selectedGraph, graphicsController.where);
            int r = await Task.Run(() => graphicsController.Run());
        }

        private void SelectChartToLoad()
        {
            materialCheckBox1.Visible = false;
            if (graphicsController.selectedGraph == "mistakes")
            {
                ChartMistakesCount_Loader();
            }
            else if (graphicsController.selectedGraph == "typing speed")
            {
                ChartTypingSpeed_Loader();
            }
            else if (graphicsController.selectedGraph == "mistakes/speed")
            {
                ChartMistakesSpeed_Loader();
            }
            else if (graphicsController.selectedGraph == "fixed")
            {
                ChartTimeToFix_Loader();
                materialCheckBox1.Visible = true;

            }
            TextUtils.SetText(false, label_name, label_date, graphicsController.selectedGraph, graphicsController.where);
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialCheckBox1.Checked)
            {
                loadAccounted = true;
            }
            else
            {
                loadAccounted = false;
            }
            ChartTimeToFix_Loader();
        }
    }
}
