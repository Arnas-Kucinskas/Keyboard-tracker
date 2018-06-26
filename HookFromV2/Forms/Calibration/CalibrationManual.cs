using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace HookFromV2
{
    public partial class CalibrationManual : MaterialForm
    {
        MainForm mainForm;
        CalibrationMain cbMain;
        public CalibrationManual(MainForm form, CalibrationMain mfc)
        {
            InitializeComponent();
            InNumeric();
            mainForm = form;
            cbMain = mfc;
            this.Icon = Properties.Resources.appicon;
        }
        private void InNumeric()
        {
            numeric.Value = 2000;
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if (numeric.Value < 200 || numeric.Value > 10000)
            {
                MessageBox.Show("Wrong values");
            }
            else
            {
                DBUtils.OpenConection();
                DBUtils.ExecuteQueries(string.Format("UPDATE User_level SET user_speed = {0}  WHERE Id=1", numeric.Value));
                DBUtils.CloseConnection();

                cbMain.LoadTex();
                mainForm.CheckForAutoCalibration(false);
                this.Close();
            }
          
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numeric_Leave(object sender, EventArgs e)
        {
            numeric.Refresh();
        }
    }
}
