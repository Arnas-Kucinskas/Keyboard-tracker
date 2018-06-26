using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;

namespace HookFromV2
{
    public partial class Statistics : Form
    {
        Stopwatch stopwatch = new Stopwatch();
        ToolTip ToolTip1 = new ToolTip();
        public StatsController statsController = new StatsController();
        public Statistics()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.Icon = Properties.Resources.appicon;
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            FilterForm filterForm = new FilterForm(this, statsController);
            filterForm.Show();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            AsyncRun();
        }

        public async void AsyncRun()
        {
            TextUtils.SetText(true, label_name, label_date, statsController.selectedStats , statsController.where);
            int f = await Task.Run(() => statsController.RunFirst());
            TextUtils.SetText(false, label_name, label_date, statsController.selectedStats, statsController.where);

            SelectGridToLoad();
            int k = await Task.Run(() => statsController.Run());
        }


        private void SelectGridToLoad()
        {
            if (statsController.selectedStats == "del_rep")
            {
                MistakesLoader();
            }
            else if (statsController.selectedStats == "words")
            {
                WordsLoader();
            }
        }

        private void WordsLoader()
        {
            int i = 0;
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.Clear();
            }

            foreach (var item in statsController.wordsList)
            {
                dataGridView1.Rows.Add(item.Key, item.Value);
                if (i == 20)
                {
                    break;
                }
                i++;
            }
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[0].HeaderText = "Words";
            dataGridView1.Columns[1].HeaderText = "Times you made mistakes";

        }

        private void MistakesLoader()
        {
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[0].HeaderText = "Deleted";
            dataGridView1.Columns[1].HeaderText = "Replaced";
            int i = 0;
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.Clear();
            }

            foreach (var item in statsController.mistList)
            {
                dataGridView1.Rows.Add(item.deletedValue, item.replacedValue, item.replacedTimes);
                if (i == 20)
                {
                    break;
                }
                i++;
            }
        }
    
        private void dataGridView1_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.Lavender;
                dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.Lavender;
                dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.Lavender;
            }
            catch (Exception)
            {
                
            }
            
        }

        private void dataGridView1_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Cells[0].Style.BackColor = Color.White;
                dataGridView1.Rows[e.RowIndex].Cells[1].Style.BackColor = Color.White;
                dataGridView1.Rows[e.RowIndex].Cells[2].Style.BackColor = Color.White;
            }
            catch (Exception)
            { 
            }
            
        }

        private  void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (statsController.mistList.Count > 0 && statsController.selectedStats == "del_rep")
            {
                if (e.ColumnIndex == dataGridView1.Columns[e.ColumnIndex].Index)
                {
                    var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];

                    List<KeyValuePair<string, int>> finalWords = statsController.GetFinalWords(e.RowIndex);
                    cell.ToolTipText = "";
                    foreach (var item in finalWords)
                    {
                        cell.ToolTipText += item.Key + "   " + item.Value + "   times \n";
                    }

                }
            }  
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Deleted Symbols")
            {
                statsController.selectedStats = "del_rep";
            }
            else if (comboBox1.SelectedItem.ToString() == "Words with most mistakes")
            {
                statsController.selectedStats = "words";
            }
            SelectGridToLoad();
            TextUtils.SetText(false, label_name, label_date, statsController.selectedStats, statsController.where);
        }
    }
}
