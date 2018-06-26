using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace HookFromV2
{
    public partial class Web : MaterialForm
    {
        public Web()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.appicon;

            //string startupPath = System.IO.Path.GetFullPath("..\\..\\")+"usersomething\\index.html";
            string startupPath = Application.StartupPath + "\\Web\\index.html";
            webBrowser1.Navigate(startupPath);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
