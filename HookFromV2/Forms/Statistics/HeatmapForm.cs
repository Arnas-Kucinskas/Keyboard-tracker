using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace HookFromV2
{
    public partial class HeatmapForm : Form
    {


        public HeatmapForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;

            InitializeItems();
            comboBox1.SelectedIndex = 0;
            InitializeHoverOver();
        }
        public static Label[] itemArray;
        private static Label[] radioItems;
        public HeatMapController heatcontrl = new HeatMapController();
        bool left = true;
        ToolTip tlp;



        private void InitializeItems()
        {
            itemArray = new Label[] {
                /* Letters */
                h_Q, h_W, h_E, h_R, h_T, h_Y, h_U, h_I, h_O, h_P, h_A, h_S, h_D, h_F, h_G, h_H, h_J, h_K, h_L, h_Z, h_X, h_C, h_V, h_B, h_N, h_M,
                /* Oems */
                h_Oem1,h_Oem7, h_Oem7, h_OemOpenBrackets, h_Oem6, h_OemQuestion, h_OemPeriod, h_Oemcomma,
                /* Esc and F keys */
                h_F1,  h_F2,  h_F3,  h_F4,  h_F4,  h_F6,  h_F5,  h_F7,  h_F8,  h_F9,  h_F10,  h_F11,  h_F12,h_Escape,
                /* Tidle row */
                h_Oemtilde, h_D0, h_D1, h_D2, h_D3, h_D4, h_D5, h_D6, h_D7, h_D8, h_D9, h_OemMinus, h_Oemplus, h_Back,
                /* Numpad */
                h_NumPad0, h_NumPad1, h_NumPad2, h_NumPad3, h_NumPad4, h_NumPad5, h_NumPad6, h_NumPad7, h_NumPad8, h_NumPad9, h_Add, h_Subtract, h_Multiply, h_Divide, h_NumLock, h_Decimal,
                /* U section */
                h_Space, h_Tab, h_Capital, h_LShiftKey, h_LControlKey, h_LWin, h_LMenu, h_RMenu, h_RWin, h_Apps, h_RControlKey, h_RShiftKey,
                /* Arrow zone */
                h_Left, h_Right, h_Up, h_Down, h_Delete, h_End, h_Next, h_PageUp, h_Home, h_Insert, h_PrintScreen, h_Scroll, h_Pause
            };

            radioItems = new Label[]
            {
                h_NumPad0, h_NumPad1, h_NumPad2, h_NumPad3, h_NumPad4, h_NumPad5, h_NumPad6, h_NumPad7, h_NumPad8, h_NumPad9, h_Add, h_Subtract, h_Multiply, h_Divide, h_NumLock, h_Decimal,
                h_Left, h_Right, h_Up, h_Down, h_Delete, h_End, h_Next, h_PageUp, h_Home, h_Insert, h_PrintScreen, h_Scroll, h_Pause,h_Return

            };
        }

        public void HeatmapLoader()
        {
            foreach (var item in itemArray)
            {
                KeyboardItemLoader(item, item.Name.Substring(2));
            }
            KeyboardItemLoader(h_enter, "Return");
            KeyboardItemLoader(h_Return, "Return");
            KeyboardItemLoader(h_Oem5, "Oem5");
        }
        public void CallendarHeatmapLoader(Dictionary<string, int> dict, DataGridView grid, int highest)
        {
            string modfier = "";
            try
            {
                if (heatcontrl.selectedHeatMap == "delay")
                {
                    grid.Columns[1].HeaderText = "delay";
                    modfier = "ms";
                }
                else
                {
                    datagrid_weekly.Columns[1].HeaderText = "count";
                }

                grid.Rows.Clear();
                int i = 0;
                foreach (var item in dict)
                {
                    if (item.Value > 0)
                    {
                        grid.Rows.Add(item.Key, item.Value.ToString() + modfier);
                    }
                    else
                    {
                        grid.Rows.Add(item.Key, "-");
                    }
                    grid.Rows[i].Cells[0].Style.BackColor = ColorPicker(item.Value, highest);
                    grid.Rows[i].Cells[1].Style.BackColor = ColorPicker(item.Value, highest);
                    i++;
                }

            }
            catch (Exception)
            {
            }

        }

        private void KeyboardItemLoader(Label item, string key)
        {
            try
            {
                item.BackColor = ColorPicker(heatcontrl.heatDict[key], heatcontrl.highestValue);
            }
            catch (Exception)
            {
                MessageBox.Show("Ooops, something went wrong with loading heatmap");
            }
        }

        private Color ColorPicker(int value, int highest)
        {

            if (value == 0)
            {
                return Color.FromArgb(200, 200, 200);
            }
            else
            {
                double perc = (double)highest / (double)value;
                int rgbVal = 255 - (int)Math.Round((double)255 / (double)perc);
              
                return Color.FromArgb(255, rgbVal, rgbVal);
            }
        }

        private void btn_delay_Click(object sender, EventArgs e)
        {
            datagrid_weekly.Rows.Clear();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            FilterForm filter = new FilterForm(heatcontrl, this);
            filter.Show();
        }

        private void comboBox1_SelectedValueChanged_1(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem.ToString() == "Delay")
            {
                heatcontrl.selectedHeatMap = "delay";
            }
            else
            {
                heatcontrl.selectedHeatMap = "times_pressed";
            }

            AsyncRun();
        }

        public async void AsyncRun()
        {
            TextUtils.SetText(true, label_name, label_date, heatcontrl.selectedHeatMap, heatcontrl.where);
            int t = await Task.Run(() => heatcontrl.Run());
            //heatcontrl.Run();
            CallendarHeatmapLoader(heatcontrl.hourlyHeatmap, dataGridView_hours, heatcontrl.highestHourValue);
            CallendarHeatmapLoader(heatcontrl.weeklyHeatmap, datagrid_weekly, heatcontrl.highestWeekValue);
            HeatmapLoader();
            TextUtils.SetText(false, label_name, label_date, heatcontrl.selectedHeatMap, heatcontrl.where);
        }

        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            // Get the item text    
            string text = "Daytime";
            try
            {
                text = ((ComboBox)sender).Items[e.Index].ToString();
            }
            catch (Exception)
            {
            }
            e.Graphics.FillRectangle(new SolidBrush(Color.LightYellow), e.Bounds);
            e.Graphics.DrawString(text, ((Control)sender).Font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }

        private void InitializeHoverOver()
        {
            /*Hover over */
            try
            {
                foreach (var item in itemArray)
                {
                    item.MouseHover += (sender, e) =>
                    {
                        ShowToolTip(item, heatcontrl.heatDict[item.Name.Substring(2)]);
                    };
                }
                h_enter.MouseHover += (sender, e) => { ShowToolTip(h_enter, heatcontrl.heatDict["Return"]); };
                h_Return.MouseHover += (sender, e) => { ShowToolTip(h_Return, heatcontrl.heatDict["Return"]); };
                h_Oem5.MouseHover += (sender, e) => { ShowToolTip(h_Oem5, heatcontrl.heatDict["Oem5"]); };
            }
            catch (Exception)
            {
            }

            /* Leave */
            foreach (var item in itemArray)
            {
                item.MouseLeave += (sender, e) =>
                {
                    try
                    {
                        tlp.Dispose();
                    }
                    catch (Exception)
                    {
                    }
                };
            }
            h_enter.MouseLeave += (sender, e) => { try { tlp.Dispose(); } catch (Exception) { } };
            h_Return.MouseLeave += (sender, e) => { try { tlp.Dispose(); } catch (Exception) { } };
            h_Oem5.MouseLeave += (sender, e) => { try { tlp.Dispose(); } catch (Exception) { } };
        }

        private void ShowToolTip(Label item, int val)
        {
            left = false;
            tlp = new ToolTip();


            if (heatcontrl.selectedHeatMap == "delay")
            {
                tlp.Show(val.ToString() + "ms", item);
            }
            else
            {
                double percantage = Math.Round((double)val * 100 / (double)heatcontrl.totalValue, 2);
                tlp.Show(val.ToString() + " times" + "\n" + percantage.ToString() + "%", item);
            }
            tlp.InitialDelay = 0;
        }


        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsAction();
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsAction();
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            RadioButtonsAction();
        }

        private void RadioButtonsAction()
        {
            if (radio_kb.Checked)
            {
                SetRadioKBVisibility(true, false, false);
            }
            else if (radio_daily.Checked)
            {
                SetRadioKBVisibility(false, true, false);
            }
            else
            {
                SetRadioKBVisibility(false, false, true);
            }
        }

        private void SetRadioKBVisibility(bool kb, bool daily, bool weekly)
        {
            foreach (var item in radioItems)
            {
                item.Visible = kb;
            }
            dataGridView_hours.Visible = daily;
            datagrid_weekly.Visible = weekly;
        }
    }
}
