using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace HookFromV2
{
    public partial class FilterForm : MaterialForm
    {
        bool programs_changed = false;
        bool date_changed = false;
        FilterController filter = new FilterController();
        string type;
        Graphs graphForm;
        GraphsController graphController;
        HeatmapForm heatmapForm;
        HeatMapController heatController;
        StatsController statsController;
        Statistics statsForm;

        public FilterForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;

        }
        private string where = "";
        private string from = "";
        private string to= "";

        public FilterForm(HeatMapController hc, HeatmapForm form)
        {
            InitializeComponent();
            heatController = hc;
            heatmapForm = form;
            type = "heatmap";
        }

        public FilterForm(Graphs form_,  GraphsController gc)
        {
            InitializeComponent();
            graphForm = form_;
            type = "chart";
            graphController = gc;
        }

        public FilterForm(Statistics form, StatsController statsC)
        {
            InitializeComponent();
            statsForm = form;
            type = "grid";
            statsController = statsC;
        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            filter.InitializePrograms();
            filter.PopulateProgramGrid(this.dataGridView1);
        }

        private void dateTime_to_ValueChanged(object sender, EventArgs e)
        {
            DateTimeChanged();
        }

        private void dateTime_From_ValueChanged(object sender, EventArgs e)
        {
            DateTimeChanged();
        }

        private void DateTimeChanged()
        {
            date_changed = true;
            to = dateTime_to.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            from = dateTime_From.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            label_selected.Text = "From: " + dateTime_From.Value.ToString("yyyy-MM-dd") + " To: " + dateTime_to.Value.ToString("yyyy-MM-dd");
            where = string.Format("BETWEEN '{0}' and '{1}'", from, to);
        }


        private void dateTime_From_Enter(object sender, EventArgs e)
        {
            dateTime_From.MaxDate = dateTime_to.Value;
        }

        private void dateTime_to_Enter(object sender, EventArgs e)
        {
            dateTime_to.MinDate = dateTime_From.Value;
        }

        private void button_filter_Click(object sender, EventArgs e)
        {

            string toDate = dateTime_to.Value.ToString("yyyy-MM-dd") + " 23:59:59";
            string fromDate = dateTime_From.Value.ToString("yyyy-MM-dd") + " 00:00:00";

            if (type == "chart")
            {
                filter.FilterHubCharts(date_changed, programs_changed, where,  this.dataGridView1, graphForm, graphController);
            }
            else if(type == "grid")
            {
                filter.FilterHubDataGrid(date_changed, programs_changed, where, this.dataGridView1, statsController, statsForm );
            }
            else if (type == "heatmap")
            {
                filter.FilterHubHeatMap(date_changed, programs_changed, where, this.dataGridView1, heatmapForm, heatController);
            }
            this.Close();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            programs_changed = true;
            date_changed = true;
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            label_selected.Text = "Last week";
            date_changed = true;
            where = "> datetime('now','-7 day')";

        }

        private void materialFlatButton1_Click_1(object sender, EventArgs e)
        {
            label_selected.Text = "Last 24 hours";
            date_changed = true;
            where = "> datetime('now','-1 day')";
        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            label_selected.Text = "Today";
            
            date_changed = true;

    
            to = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";
            from = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            label_selected.Text = "Today";
            where = string.Format("BETWEEN '{0}' and '{1}'", from, to);

        }
    }
}
