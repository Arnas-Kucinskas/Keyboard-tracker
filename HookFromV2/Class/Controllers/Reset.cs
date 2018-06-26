using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HookFromV2
{ 
    class Reset
    {
        public void ResetProgram(MainForm mf)
        {
            DBUtils.OpenConection();
            string[] tables = { "Heatmap", "Inputs", "Mistakes", "Programs", };

            foreach (var table in tables)
            {
                DBUtils.ExecuteQueries("delete from " + table);
                DBUtils.ExecuteQueries(string.Format("UPDATE sqlite_sequence SET seq = 1 WHERE name = '{0}'", table));
            }


            DBUtils.ExecuteQueries(string.Format("UPDATE User_level SET user_speed = {0}  WHERE Id=1", 0));
            DBUtils.CloseConnection();

            string path = Application.StartupPath + "\\AuCal.json";
            File.WriteAllText(path, "");

            MessageBox.Show("Please restart the aplication");

            mf.Close();
        }
    }
}
