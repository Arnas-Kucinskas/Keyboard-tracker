using System;
using System.Windows.Forms;

namespace HookFromV2
{
   public class UserController
    {
        public int userLevel
        { get; set; }
    
        public int UserLevelCheck()
        {
            try
            {
                DBUtils.OpenConection();
                userLevel = DBUtils.ExecuteScalar("SELECT user_speed FROM user_level WHERE Id = 1");
                DBUtils.CloseConnection();

                if (userLevel < 500)
                {
                    return -100;
                }
            }

            catch (Exception a)

            {
                MessageBox.Show(a.ToString());
                return -500;
            }

            if (userLevel >= 500)
            {
                return userLevel;
            }
            else
            {
                return -100;
            }

        }

    }
}
