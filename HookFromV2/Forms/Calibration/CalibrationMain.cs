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
    public partial class CalibrationMain : MaterialForm
    {
        MainForm mainForm;
        bool close = false;
        public CalibrationMain(MainForm form)
        {
            InitializeComponent();
            mainForm = form;
            this.Icon = Properties.Resources.appicon;
        }
        public CalibrationMain(MainForm form, bool cls)
        {
            InitializeComponent();
            mainForm = form;
            close = true;
        }


        private void btn_manual_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is CalibrationManual)
                {
                    isOpen = true;
                }
            }

            if (!isOpen)
            {
                DialogResult dialogResult = MessageBox.Show("Manual calibration is meant for advanced users. Do this on your own risk", "Application needs to be calibrated", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CalibrationManual calMan = new CalibrationManual(mainForm, this);
                    calMan.Show();
                }
                else if (dialogResult == DialogResult.No)
                {
      
                }
            }
           
        }

        private void btn_auto_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to turn on automatic system calibration?", "Automatic calibration", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                mainForm.TurnOnAutoCal();
                LoadTex();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }

        private void CalibrationMain_Load(object sender, EventArgs e)
        {
            LoadTex();  
        }

        public void LoadTex()
        {
            DBUtils.OpenConection();
            int userLevel = DBUtils.ExecuteScalar("SELECT user_speed FROM User_level WHERE id = 1");
            DBUtils.CloseConnection();
            if (userLevel > 200 && userLevel < 10000)
            {
                label_userLevel.Text = userLevel.ToString() + "ms";
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is Calibration)
                {
                    isOpen = true;
                }
            }

            if (!isOpen)
            {
                Calibration cab = new Calibration(mainForm, this);
                cab.Show();
            }
           
        }

        private void CalibrationMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                MessageBox.Show("Please restart the program");
                mainForm.Close();
            }
        }
    }
}
