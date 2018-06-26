using MaterialSkin.Controls;
using System;
using System.Windows.Forms;


namespace HookFromV2
{
    public partial class Calibration : MaterialForm
    {
        

        public Calibration(MainForm form, CalibrationMain cb )
        {
            mainForm = form;
            cabMain = cb;
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;

        }
        public MainForm mainForm;
        CalibrationController calibrationController;
        CalibrationMain cabMain;

        public Calibration()
        {
            InitializeComponent();
            type_textBox.Text = calibrationController.textToWrite;
        }

       
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
            Keys vkCode = (Keys)e.KeyCode;
            string last_char = InputUtils.GetCharsFromKeys(vkCode);
            string typeOfPressedKey = InputUtils.GetKeyType(vkCode);

            try
            {
                calibrationController.Main(vkCode, last_char, typeOfPressedKey);

            }
            catch (Exception)
            {
                newCal();
            }
        }

        private void Calibration_Load(object sender, EventArgs e)
        {
            calibrationController = new CalibrationController(mainForm);
            type_textBox.Text = calibrationController.textToWrite;
        }

        private void Calibration_FormClosing(object sender, FormClosingEventArgs e)
        {

            cabMain.LoadTex();
            mainForm.UserLevelCheck();

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            newCal();
        }

        public void newCal()
        {
            textBox1.Text = "";
            calibrationController = new CalibrationController(mainForm);
        }
    }
}
