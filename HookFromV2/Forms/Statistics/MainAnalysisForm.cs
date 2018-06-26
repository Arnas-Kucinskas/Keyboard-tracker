using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookFromV2
{
    public partial class MainAnalysisForm : MaterialForm
    {

        public MainAnalysisForm()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;


        }


        private void MainAnalysisForm_Load(object sender, EventArgs e)
        {
            Statistics mistakes = new Statistics();
            mistakes.MdiParent = this;
            mistakes.TopLevel = false;
            mistakes.Visible = true;
            mistakes.FormBorderStyle = FormBorderStyle.None;
            mistakes.Dock = DockStyle.Fill;
            tabMistakes.Controls.Add(mistakes);

            LoadRest();
        }

        private  void LoadRest()
        {
           
            HeatmapForm heat = new HeatmapForm();
            Graphs graphs = new Graphs();

            List<Form> formList = new List<Form>()
            {
                 heat, graphs
            };

            int i = 1;
            foreach (var form in formList)
            {
                form.MdiParent = this;
                form.TopLevel = false;
                form.Visible = true;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                tabMain.TabPages[i].Controls.Add(form);
                i++;

            }
        }

        private List<Form> LoadForms()
        {
            HeatmapForm heat = new HeatmapForm();
            Graphs graphs = new Graphs();

            List<Form> formList = new List<Form>()
            {
                 heat, graphs
            };

            return formList;
        }


    }
}
