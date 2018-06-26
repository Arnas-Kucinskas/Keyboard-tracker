using System;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;



namespace HookFromV2
{ 

    public static class ExeUtils
    {
        private static bool isWriting = false;

        public static int exeID
        { get; private set; } = 0;

        public static bool isTrackable
        { get; private set; } = true;


     
        public static async void AsyncGetExeID()
        {
            if (!isWriting)
            {
                isWriting = true;
                try
                {
                    int k = await Task.Run(() => GetExeID());

                }
                catch (Exception)
                {  
                }
                isWriting = false;
            }
        }

        private static int GetExeID()
        {
            IntPtr hwnd = WindowsAPI.GetForegroundWindow();
            uint pid;
            WindowsAPI.GetWindowThreadProcessId(hwnd, out pid);

            int processId = (int)pid;

            IntPtr hprocess = WindowsAPI.OpenProcess(ProcessAccessFlags.All,
                                  false, processId);
            var buffer = new StringBuilder(1024);
            int size = buffer.Capacity;
            if (WindowsAPI.QueryFullProcessImageName(hprocess, 0, buffer, out size))
            {
                 buffer.ToString();
            }

            Process p = Process.GetProcessById((int)pid);
            DBUtils.OpenConection();
            if (p != null)
            {
                try
                {
                    exeID = DBUtils.GetExeID(p);

                }
                catch (Exception ex)
                {

                }
            }
            else
            {

            }
            isTrackable = Convert.ToBoolean(DBUtils.ExecuteScalar(string.Format("SELECT filter FROM Programs WHERE Id = {0} ",exeID)));
            DBUtils.CloseConnection();
            return 1;
        }
    }
}
