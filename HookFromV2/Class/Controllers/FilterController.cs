using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HookFromV2
{
    class FilterController
    {
        List<ProgramExe> programList = new List<ProgramExe>();
        StatsController statsController = new StatsController();

        public void FilterHubCharts(bool date_changed, bool programs_changed, string where, DataGridView programGrid, Graphs form, GraphsController graphController)
        {
            try
            {
                string whereAnd = string.Format("AND (datetime  {0})", where);
                string whereController = string.Format("WHERE datetime  {0}", where);
                if (programs_changed && !date_changed)
                {
                    CheckBoxFilter(programGrid);
                    ChartAction(form, graphController);
                }
                else if (date_changed && !programs_changed)
                {
                    graphController.whereAnd = whereAnd;
                    graphController.where = whereController;
                    ChartAction(form, graphController);
                }
                else if (date_changed && programs_changed)
                {
                    CheckBoxFilter(programGrid);
                    graphController.whereAnd = whereAnd;
                    graphController.where = whereController;
                    ChartAction(form, graphController);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void ChartAction(Graphs form, GraphsController graphController)
        {
            form.graphicsController = graphController;
            form.AsyncRun();
        }

        public void FilterHubHeatMap(bool date_changed, bool programs_changed, string where, DataGridView programGrid, HeatmapForm heatmapForm, HeatMapController heatControler)
        {
            try
            {
                if (programs_changed && !date_changed)
                {
                    CheckBoxFilter(programGrid);
                }
                else if (date_changed && !programs_changed)
                {
                   heatControler.where = string.Format("AND (date  {0})", where);
                }
                else if (date_changed && programs_changed)
                {
                    CheckBoxFilter(programGrid);
                    heatControler.where = string.Format("AND (date  {0})", where);
                   
                }
                heatmapForm.AsyncRun();
            }
            catch (Exception)
            {
            }

        }

        public void HeatmapAction(HeatmapForm heatmapForm, HeatMapController heatControler)
        {
            heatmapForm.AsyncRun();
        }

        public void FilterHubDataGrid(bool date_changed, bool programs_changed, string where, DataGridView programGrid, StatsController statsController, Statistics form)
        {
            try
            {
                string whereController = string.Format("WHERE datetime  {0}", where);

                if (programs_changed && !date_changed)
                {
                    CheckBoxFilter(programGrid);
                    
                }
                else if (date_changed && !programs_changed)
                {

                    statsController.where = whereController;
                }
                else if (date_changed && programs_changed)
                {
                    CheckBoxFilter(programGrid);
                    
                    statsController.where = whereController;
                }
                GridAction(statsController, form);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            } 
        }

        private void GridAction(StatsController sc, Statistics form)
        {
            form.statsController = sc;
            form.AsyncRun();
        }

        public void InitializePrograms()
        {
            DBUtils.OpenConection();
            programList = DBUtils.ReadPrograms();
            DBUtils.CloseConnection();
        }

        public void PopulateProgramGrid(DataGridView grid)
        {
            if (grid.Rows.Count > 0)
            {
                grid.Rows.Clear();
            }

            foreach (var item in programList)
            {
                grid.Rows.Add(item._name, item._exe, item._id, item._filter);
            }
        }

       
        

        public void CheckBoxFilter(DataGridView filterGrid )
        {
            List<ProgramExe> programList = new List<ProgramExe>();
            try
            {
                foreach (DataGridViewRow row in filterGrid.Rows)
                {
                    bool check = (bool)row.Cells["checkbox"].Value;
                    int id = (int)row.Cells["id"].Value;
                    ProgramExe program = new ProgramExe(id, check);
                    programList.Add(program);

                }
                DBUtils.OpenConection();
                foreach (var item in programList)
                {
                    string query = string.Format("UPDATE Programs SET filter={0} WHERE Id={1} ", Convert.ToInt16(item._filter), item._id);
                    DBUtils.ExecuteQueries(query);
                }
                DBUtils.CloseConnection();
                // mistakes.MistakesHub(); JEIGU MISTAKES FILTRAS NEVEKIA BRING THIS BACK

                string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

                OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

                //DateTime test = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                using (IDbConnection db = dbFactory.OpenDbConnection())
                {
                    //var filteredData = db.TABLE.Where(t => t.DATE > startDate && t.DATE < endDate);

                    //var rows = db.From<Heatmap>().Where(x => x.date.CompareTo("2018-05-05 00:00:00") >= 0 && x.date.CompareTo("2018-06-21 23:59:59") <= 0);
                    var rows = db.From<Heatmap>().Where<Heatmap>(x => x.program_id == 12);

                    //db.From<Program>().Insert()

                }



            }
            catch (Exception xe)
            {
                MessageBox.Show(xe.ToString());
            }
            
        }
    }
}
