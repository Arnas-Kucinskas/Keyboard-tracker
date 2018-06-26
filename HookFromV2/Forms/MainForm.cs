using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using System.Management;
using MaterialSkin.Controls;
using ServiceStack.OrmLite;

namespace HookFromV2
{
    public partial class MainForm : MaterialForm
    {
        UserController user = new UserController();
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem menuItem1;


        public MainForm()
        {
            InitializeComponent();
            try
            {
                this.Icon = Properties.Resources.appicon;
                InitNotifyIcon();

            }
            catch (Exception )
            {
            }

            DBUtils.ReadWords("SELECT * FROM MISTAKES WHERE datetime BETWEEN '2018-05-15 00:00:00' AND '2018-06-21 23:59:59'");
           // Begginig(); ///////////////
           
                this.MaximizeBox = false;
            
            UserLevelCheck();
            CheckForAutoCalibration(autContrl.isOn);
        }

        private async void Begginig()
        {
            //TestAsync();
            //TestInsert();
            try
            {
               // int t = await Task.Run(() => Test1());
               // int p = await Task.Run(() => Test2());
            }
            catch (Exception ex)
            {

                throw;
            }

            string test = "qw";

        }

        private async void TestInsert()
        {
            string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);
          
            

            List<int> stList = new List<int>();
            Stopwatch st = new Stopwatch();

            Heatmap ht = new Heatmap();
            ht.date = "2018-06-20 10:06:14";
            ht.delay = 500;
            ht.program_id = 12;
            ht.input = "Return";

          

            using (IDbConnection db = dbFactory.OpenDbConnection())
            {
                using (IDbTransaction trans = db.OpenTransaction())
                {
                    st.Start();
                   // db.BeginTransaction();
                    for (int i = 0; i < 500000; i++)
                    {
                       db.Insert(ht);
                 
                    }
                    
                    trans.Commit();
                    st.Stop();

                    stList.Add((int)st.ElapsedMilliseconds);
                };
            };

      
           /* using (var db = dbFactory.Open())
            {
                for (int i = 0; i < 100; i++)
                {
                    db.ExecuteNonQuery("BEGIN");
                    db.Insert(new Heatmap { input = "Return", delay = 500, date = "2018-06-20 10:06:14", program_id = 12 });
                    db.ExecuteNonQuery("end");
                }
                st.Stop();
                stList.Add((int)st.ElapsedMilliseconds);
            }*/

           

            DBUtils.OpenConection();
            st.Restart();
            for (int i = 0; i < 500000; i++)
            {
                query = "INSERT INTO Heatmap (input,delay,date,program_id) " + "VALUES ('Return', 500, '2018-06-20 10:06:1', '12')";
                DBUtils.ExecuteQueries(query);
              
            }
            st.Stop();
            stList.Add((int)st.ElapsedMilliseconds);
            DBUtils.CloseConnection();

            string t = "";

            using (var db = dbFactory.Open())
            {
                
            }
        }
        private async void TestAsync()
        {
            string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

            using (var db = dbFactory.Open())
            {
                try
                {
                    var rowsC = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsB = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsD = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsQ = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsW = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsE = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsR = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsT = await db.SelectAsync<Programs>(x => x.filter == 1);
                    var rowsY = await db.SelectAsync<Programs>(x => x.filter == 1);
                }
                catch (Exception ex)
                {

                    throw;
                }
                
            }
            string qwe = "QWe";
        }

        private int Test1()
        {
            string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

            using (var db = dbFactory.Open())
            {
         
                for (int i = 0; i < 100000; i++)
                {
                    var rowsC = db.Select<Programs>(x => x.filter == 1);
                    
                    //debug_label.Text = rowsC.Count.ToString();
                }
            }
            return 0;
        }

        private int Test2()
        {
            string connectionString = "Data Source=DatabaseLite.sqlite;Version=3;PRAGMA journal_mode=WAL;";

            OrmLiteConnectionFactory dbFactory = new OrmLiteConnectionFactory(connectionString, SqliteDialect.Provider);

            using (var db = dbFactory.Open())
            {
                for (int i = 0; i < 100000; i++)
                {
                    var rowsC = db.Select<Programs>(x => x.filter == 1);
                   // debug_label.Text = rowsC.Count.ToString();
                }
            }
            return 0;
        }

        int userLevel = 0;
        ////////////////////Objects
        List<RuleObj> tupleBuffer = new List<RuleObj>();
      
        Stopwatch sw = new Stopwatch();
        Stopwatch normalInputSW = new Stopwatch();
        Stopwatch inputStopWatch = new Stopwatch();
        
        Rules rules = new Rules();
        TrackingBuffer bufferObj = new TrackingBuffer();
        Input_buffer inputBuffer = new Input_buffer();
        CalibrationAutomaticController autContrl = new CalibrationAutomaticController();
        //BufferForMistakes preDeleteBuffer = new BufferForMistakes();
        //BufferForMistakes postDeleteBuffer = new BufferForMistakes();

        List<InputForMistakes> preDeleteBuffer = new List<InputForMistakes>();
        List<InputForMistakes> postDeleteBuffer = new List<InputForMistakes>();

        MainFormController mainController = new MainFormController();

        /////////////////////


        ////////////////////Weird stuff
        private IntPtr hGlobalLLKeyboardHook = IntPtr.Zero;
        private HookProc globalLLKeyboardHookCallback = null;

        private IntPtr hGlobalLLMouseHook = IntPtr.Zero;
        private HookProc globalLLMouseHookCallback = null;


        /* */
        private const int WM_KEYDOWN = 0x100;
        private const int WM_SYSKEYDOWN = 0x104;
        KeyboardMessage keyDown = KeyboardMessage.WM_KEYDOWN;
        KeyboardMessage keyUp = KeyboardMessage.WM_KEYUP;
        KeyboardMessage keyDownSys = KeyboardMessage.WM_SYSKEYDOWN;
        KeyboardMessage keyUpSys = KeyboardMessage.WM_SYSKEYUP;
        /////////////////////

        ////////////////////Standard variables
        bool[] flagArray = new bool[] { false, false, false, false, false, false };
        string query;
        public int sysKeyPressed = 0;
        double keyCount = 0;
        string typeOfPressedKey;
        string[] arr;
        int typingSpeed = 0;
        int trueTypingSpeed = 0;
        List<InputObj> heatmapRowList = new List<InputObj>();
        bool mustCalibrate = false;
        /////////////////////




            private void InitNotifyIcon()
        {
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);

            notifyIcon1.Icon = new Icon("appicon.ico");
            notifyIcon1.ContextMenu = this.contextMenu1;
            notifyIcon1.Text = "Form1 (NotifyIcon example)";
            notifyIcon1.Visible = true;

            notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
        }
        private void notifyIcon1_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.ShowInTaskbar = true;
            this.Activate();
        }

      

        #region Global Low-level Mouse Hook


        /// <summary>
        /// Set global low-level mouse hook
        /// </summary>
        /// <returns></returns>
        private bool SetGlobalLLMouseHook()
        {
            // Create an instance of HookProc.
            globalLLMouseHookCallback = new HookProc(this.LowLevelMouseProc);

            hGlobalLLMouseHook = WindowsAPI.SetWindowsHookEx(
                HookType.WH_MOUSE_LL,  // Must be LL for the global hook
                globalLLMouseHookCallback,
                // Get the handle of the current module
                Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]),
                // The hook procedure is associated with all existing threads running 
                // in the same desktop as the calling thread.
                0);
            return hGlobalLLMouseHook != IntPtr.Zero;
        }

        /// <summary>
        /// Remove the global low-level mouse hook
        /// </summary>
        /// <returns></returns>
        private bool RemoveGlobalLLMouseHook()
        {
            if (hGlobalLLMouseHook != IntPtr.Zero)
            {
                // Unhook the low-level mouse hook
                if (!WindowsAPI.UnhookWindowsHookEx(hGlobalLLMouseHook))
                    return false;

                hGlobalLLMouseHook = IntPtr.Zero;
            }
            return true;
        }

        /// <summary>
        /// Low-level mouse hook procedure
        /// The system call this function every time a new mouse input event is 
        /// about to be posted into a thread input queue. The mouse input can come 
        /// from the local mouse driver or from calls to the mouse_event function. 
        /// If the input comes from a call to mouse_event, the input was 
        /// "injected". However, the WH_MOUSE_LL hook is not injected into another 
        /// process. Instead, the context switches back to the process that 
        /// installed the hook and it is called in its original context. Then the 
        /// context switches back to the application that generated the event. 
        /// </summary>
        /// <param name="nCode">
        /// The hook code passed to the current hook procedure.
        /// When nCode equals HC_ACTION, the wParam and lParam parameters contain 
        /// information about a mouse message.
        /// </param>
        /// <param name="wParam">
        /// This parameter can be one of the following messages: 
        /// WM_LBUTTONDOWN, WM_LBUTTONUP, WM_MOUSEMOVE, WM_MOUSEWHEEL, 
        /// WM_MOUSEHWHEEL, WM_RBUTTONDOWN, or WM_RBUTTONUP. 
        /// </param>
        /// <param name="lParam">Pointer to an MSLLHOOKSTRUCT structure.</param>
        /// <returns></returns>
        /// <see cref="http://msdn.microsoft.com/en-us/library/ms644986.aspx"/>
        public int LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                // Marshal the MSLLHOOKSTRUCT data from the callback lParam
                MSLLHOOKSTRUCT mouseLLHookStruct = (MSLLHOOKSTRUCT)
                    Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));

                // Get the mouse WM from the wParam parameter
                MouseMessage wmMouse = (MouseMessage)wParam;
     
                MouseMessage left = (MouseMessage)WM_LBUTTONDOWN;
                MouseMessage right = (MouseMessage)WM_RBUTTONDOWN;
                if (wmMouse == left || wmMouse == right)/* It does the same thing as a panic they does */
                {
                    bufferObj.Clear();
                    WriteAndClearTuple_nTimer();

                }


            }

            // Pass the hook information to the next hook procedure in chain
            return WindowsAPI.CallNextHookEx(hGlobalLLMouseHook, nCode, wParam, lParam);
        }

        #endregion

        #region Global Low-level Keyboard Hook







        /// <summary>
        /// Low-level keyboard hook procedure.
        /// The system calls this function every time a new keyboard input event 
        /// is about to be posted into a thread input queue. The keyboard input 
        /// can come from the local keyboard driver or from calls to the 
        /// keybd_event function. If the input comes from a call to keybd_event, 
        /// the input was "injected". However, the WH_KEYBOARD_LL hook is not 
        /// injected into another process. Instead, the context switches back 
        /// to the process that installed the hook and it is called in its 
        /// original context. Then the context switches back to the application 
        /// that generated the event. 
        /// </summary>
        /// <param name="nCode">
        /// The hook code passed to the current hook procedure.
        /// When nCode equals HC_ACTION, it means that the wParam and lParam 
        /// parameters contain information about a keyboard message.
        /// </param>
        /// <param name="wParam">
        /// The parameter can be one of the following messages: 
        /// WM_KEYDOWN, WM_KEYUP, WM_SYSKEYDOWN, or WM_SYSKEYUP.
        /// </param>
        /// <param name="lParam">Pointer to a KBDLLHOOKSTRUCT structure.</param>
        /// <returns></returns>
        /// <see cref="http://msdn.microsoft.com/en-us/library/ms644985.aspx"/>
        /// 
        private bool SetGlobalLLKeyboardHook()
        {
            // Create an instance of HookProc.
            globalLLKeyboardHookCallback = new HookProc(this.LowLevelKeyboardProc);

            hGlobalLLKeyboardHook = WindowsAPI.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, globalLLKeyboardHookCallback, Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);
            return hGlobalLLKeyboardHook != IntPtr.Zero;
        }
        private bool RemoveGlobalLLKeyboardHook()
        {
            if (hGlobalLLKeyboardHook != IntPtr.Zero)
            {
                if (!WindowsAPI.UnhookWindowsHookEx(hGlobalLLKeyboardHook))
                    return false;

                hGlobalLLKeyboardHook = IntPtr.Zero;
            }
            return true;
        }





        
        public int LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam)
       {
            if (nCode >= 0)
            {
                // Marshal the KeyboardHookStruct data from the callback lParam
                KBDLLHOOKSTRUCT keyboardLLHookStruct = (KBDLLHOOKSTRUCT)
                    Marshal.PtrToStructure(lParam, typeof(KBDLLHOOKSTRUCT));


                Keys vkCode = (Keys)keyboardLLHookStruct.vkCode;
                KeyboardMessage wmKeyboard = (KeyboardMessage)wParam; // Get the keyboard WM from the wParam parameter

              
                typeOfPressedKey = InputUtils.GetKeyType(vkCode);//Gets a type of pressed key

                TriggerFlagsInitialization(typeOfPressedKey, vkCode, wmKeyboard);

                if (typeOfPressedKey == "system")
                {
                    for (int i = 0; i < InputUtils.systemKeys.Length; i++)// Have to check every possible trigger key
                    {
                        TriggerFlags(vkCode, InputUtils.ReturnSystemKey(i), wmKeyboard, i);
                    }
                }

         
                if (wmKeyboard == keyUp || wmKeyboard == keyUpSys)
                {
                    mainController.LastKeyPressed_LiftOff(vkCode);
                }

                if (wmKeyboard == keyDown || wmKeyboard == keyDownSys)
                {
                    try
                    {
                        ExeUtils.AsyncGetExeID();

                    }
                    catch (Exception)
                    {
                        /* In case of failure keeps old one */
                    }

                    /* Sets up timer and stopwatch. Can't time timer */
                    if (!userLevelTimer.Enabled)
                    {
                        userLevelTimer.Enabled = true;
                        userLevelTimer.Start();
                        timer2.Start();
                    }

                    if (!inputStopWatch.IsRunning)
                    {
                        inputStopWatch.Start();
                    }
                    int timePassed = (int)inputStopWatch.ElapsedMilliseconds;

                    if (ExeUtils.isTrackable)
                    {
                        mainController.AddToInputBuffer(vkCode, timePassed, ExeUtils.exeID, typeOfPressedKey);
                    }

                    switch (typeOfPressedKey)
                    {
                        case "system":
                            /* in case there's stuff to do */
                            break;
                        case "panic":
                            bufferObj.Clear();
                            WriteAndClearTuple_nTimer();
                            break;
                        case "rule":
                            if (bufferObj.Count() > 0)
                            {
                                int key = 0; /* WHEN BACKSPACE */
                                if (vkCode == Keys.Delete)
                                {
                                    key = 1; /* WHEN DELETE */
                                }

                                if (rules.OneWordValidation(vkCode, bufferObj)) /* Checks if space wasn't deleted. If it was just save to db */
                                {
                                    SortTupleList();
                                    WriteAndClearTuple_nTimer();
                                }

                                if (bufferObj.ValidateBounds(key)) /*  */
                                {
                                    preDeleteBuffer.Add(bufferObj.GetInputForMistakes(vkCode));
                                    tupleBuffer = rules.RuleKey(vkCode, tupleBuffer, bufferObj, (int)normalInputSW.ElapsedMilliseconds);
                                    bufferObj.SendRuleKeys(vkCode);
                                    bufferObj.ruleKeyPressed = true;
                                }
                                else
                                {
                                    WriteAndClearTuple_nTimer();
                                }
                            }
                            break;
                        case "pointer":
                            string triggerFlag = TriggerFlags_Enabled_Keys();
                            if (triggerFlag != "Sys")
                            {
                                if (triggerFlag == "None")
                                {
                                    bufferObj.SendRuleKeys(vkCode);
                                }
                                else if (triggerFlag == "Ctrl")
                                {
                                    bufferObj.SendRuleKeys(vkCode, true);
                                }
                                WriteAndClearTuple();
                            }
                            break;
                        case "normal":

                            if (!flagArray.Contains(true))
                            {
                                if (bufferObj.ruleKeyPressed == true)
                                {
                                    SortTupleList();
                                
                                    if (InputUtils.seperatorKeys.Contains(vkCode))//space and rest of the buch
                                    {
                                        WriteAndClearTuple_nTimer();
                                        Action(vkCode, wmKeyboard);
                                    }
                                    else
                                    {
                                        string replaceWith = InputUtils.GetCharsFromKeys(vkCode);

                                        rules.NormalKey(tupleBuffer, replaceWith, (int)normalInputSW.ElapsedMilliseconds);
                                        Action(vkCode, wmKeyboard);
                                    }
                                }
                                else
                                {
                                    Action(vkCode, wmKeyboard);
                                }
                            }
                            else
                            {
                                WriteAndClearTuple_nTimer();
                            }
                            if (normalInputSW.IsRunning)
                            {
                                normalInputSW.Restart();
                            }
                            else
                            {
                                normalInputSW.Start();
                            }
                            break;
                        default:

                            break;

                    }
                    userLevelTimer.Stop();
                    userLevelTimer.Start();
                    inputStopWatch.Restart();
                }
            }
            return WindowsAPI.CallNextHookEx(hGlobalLLKeyboardHook, nCode, wParam, lParam);
        }





        private void Action(Keys vkCode, KeyboardMessage wmKeyboard)
        {
            if (wmKeyboard == keyDown || wmKeyboard == keyDownSys)
            {
                long timer = sw.ElapsedMilliseconds;
                string character = InputUtils.GetCharsFromKeys(vkCode);
                bufferObj.AddToBuffer(character, (int)normalInputSW.ElapsedMilliseconds);
                sw.Restart();
                userLevelTimer.Stop();
                userLevelTimer.Start();
                keyCount++;

            }
        }





        #endregion

        #region Form Event Handlers


        private void btnGlobalLLKeyboardHook_Click_1(object sender, EventArgs e)
        {


        }




        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteAndClearTuple_nTimer();

        }



        #endregion


        private void TriggerFlags(Keys vkCode, Keys triggerKey, KeyboardMessage wmKeyboard, int i) // Sets flag for trigger keys.
        {
            if (vkCode == triggerKey && (wmKeyboard == keyDownSys || wmKeyboard == keyDown))
            {
                flagArray[i] = true;
            }
            else if (vkCode == triggerKey && (wmKeyboard == keyUp || wmKeyboard == keyUpSys))
            {
                flagArray[i] = false;
            }
        }
        private void TriggerFlagsInitialization(string typeOfPressedKey, Keys vkCode, KeyboardMessage wmKeyboard)
        {
            if (typeOfPressedKey == "system")
            {
                for (int i = 0; i < InputUtils.systemKeys.Length; i++)// Have to check every possible trigger key
                {
                    TriggerFlags(vkCode, InputUtils.systemKeys[i], wmKeyboard, i);

                }
            }
        }

        private bool TriggerFlags_Control_Enabled()
        {
            bool result = false;
            if (flagArray[0] || flagArray[1] == true)
            {
                for (int i = 2; i < flagArray.Length - 1; i++)
                {
                    if (flagArray[i] == true)
                    {
                        result = false;
                        break;
                    }
                    result = true;
                }
            }
            return result;
        }
        private string TriggerFlags_Enabled_Keys()
        {
            string result = "";
            if (flagArray.Contains(true))
            {
                if (flagArray[0] || flagArray[1] == true)
                {
                    for (int i = 2; i < flagArray.Length; i++)
                    {
                        if (flagArray[i] == true)
                        {
                            result = "Sys";
                            break;
                        }
                        result = "Ctrl";
                    }
                }
                else
                {
                    result = "Sys";
                }
            }
            else
            {
                result = "None";
            }
            return result;
        }

        public string[] ConvertToArray()
        {
            StringBuilder builder = new StringBuilder();
            StringBuilder builder2 = new StringBuilder();
            string delEscape = "";
            string replacedEscape = "";
            foreach (RuleObj tupbleObject in tupleBuffer)
            {
                if (tupbleObject.deltedKey == "'") /* Escapes ' */
                {
                    delEscape = "'";
                }
                if (tupbleObject.replacedWithKey == "'")
                {
                    replacedEscape = "'";
                }
                builder.Append(tupbleObject.deltedKey + delEscape);
                builder2.Append(tupbleObject.replacedWithKey + replacedEscape);

                delEscape = "";
                replacedEscape = "";

            }
            string deleted = builder.ToString();
            string replaced = builder2.ToString();
            

            //string[] arr1 = new string[] { deleted, replaced};
            return new string[] { deleted, replaced, FinalWord() };
        }

        public void TypingSpeeds(string finalWord)
        {
            int deletedCount = preDeleteBuffer.Count();
            int totalInputs = postDeleteBuffer.Count + deletedCount;
            int totalDelay = 0;
            int finalWordCount = finalWord.Count();
            int slowBonus = 0;

            int i = 0;
            foreach (var item in preDeleteBuffer)
            {
                if (item._delay == 0 && i > 0)
                {
                    slowBonus += (int)(userLevel * 0.8);
                }
                totalDelay += item._delay;
                i++;
            }
            
            foreach (var item in postDeleteBuffer)
            {
                if (item._delay == 0 && i > 0)
                {
                    slowBonus += (int)(userLevel * 0.8);
                }
                totalDelay += item._delay;
                i++;
            }

            if (totalInputs == finalWordCount)
            {
                slowBonus = userLevel;
            }

            if (finalWordCount == 0)
            {
                finalWordCount = 1;
            }

            typingSpeed = 0;
            trueTypingSpeed = 0;
            try
            {
                typingSpeed = (totalDelay + slowBonus) / totalInputs;
                trueTypingSpeed = (totalDelay + slowBonus) / finalWordCount;
            }
            catch (Exception)
            {
            }
       
                
        
        }

        public string FinalWord()
        {
            List<string> finalWord = new List<string>();

            for (int i = bufferObj.pointer; i >= 0; i--)
            {
                if (bufferObj.buffer[i]._input == " " || InputUtils.seperators.Contains(bufferObj.buffer[i]._input))
                {
                    break;
                }
                string escape = "";
                if (bufferObj.buffer[i]._input == "'")
                {
                    escape = "'";
                }
                finalWord.Insert(0, bufferObj.buffer[i]._input + escape);
                postDeleteBuffer.Add(bufferObj.buffer[i]);//

                escape = "";

            }
            return string.Join("", finalWord.ToArray());
        }


        private void SortTupleList()
        {

            if (tupleBuffer.Count > 0) 
            {
                List<RuleObj> temp = new List<RuleObj>();

                for (int i = tupleBuffer.Count - 1; i >= 0; i--)
                {
                    if (tupleBuffer[i].ruleKeyUsed == Keys.Back)
                    {
                        RuleObj tupleObject = tupleBuffer[i];
                        tupleObject.ruleKeyUsed = Keys.Delete;
                        temp.Add(tupleObject);
                    }
                }
                if (temp.Any())
                {
                    tupleBuffer = temp;
                }

            }
        }

        private string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        // mo.Properties.ToString();
                        return (string)mo["ExecutablePath"];

                    }
                }
            }
            return null;
        }

        public void UserLevelCheck()
        {
            if (!autContrl.isOn)
            {
                userLevel = user.UserLevelCheck();

                if (userLevel >= 500)
                {
                    userLevelTimer.Interval = userLevel;
                }
                else if (userLevel == -100)
                {
                    autContrl.IsOn();
                    if (autContrl.isOn)
                    {
                        MessageBox.Show("Automatic calibration is ON. \nTurn ON tracking and keep working :)");
                    }
                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Would you like Application to calibrate on its own(reccomended)?", "Application needs to be calibrated", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {

                            autContrl.Hub();
                            userLevelTimer.Interval = (10000);
                            MessageBox.Show("Automatic system calibration is ON");

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                             mustCalibrate = true;
                          
                        }
                    }
                }
                else if (userLevel == -500)
                {
                    MessageBox.Show("couldn't conect to db!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Something went wrong with user levels");
                }
            }

        }

        public void WriteAndClearTuple_nTimer()
        {

     
            arr = ConvertToArray();// store buffer with rules to DB. If rulekeypressed = 

            if (arr[0].Length < 50 && arr[0] != "" && arr[0] != " " && arr[2] != "" && ExeUtils.isTrackable)
            {
                if (arr[0].Length < 50 && arr[1].Length < 50 && arr[2].Length < 50)
                {
                    TypingSpeeds(arr[2]);
                    query = string.Format("INSERT INTO Mistakes ([deleted],[replaced_with],[datetime],[program_id],[final_word], [typing_speed], [true_typing_speed]) VALUES  ('{0}', '{1}', '{6}', '{2}', '{3}', {4}, {5})", arr[0], arr[1], ExeUtils.exeID, arr[2], typingSpeed, trueTypingSpeed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                     WriteToDB(query);
                    
                }
            }
            tupleBuffer.Clear();
            bufferObj.ruleKeyPressed = false;
            typingSpeed = 0;
            trueTypingSpeed = 0;
            preDeleteBuffer.Clear();
            postDeleteBuffer.Clear();
        }

        public void WriteAndClearTuple()
        {
            arr = ConvertToArray();// store buffer with rules to DB. If rulekeypressed = true

            if (arr[0].Length < 50 && arr[0] != "" && arr[0] != " " && arr[2] != "" && ExeUtils.isTrackable)
            {
                if (arr[0].Length < 50 && arr[1].Length < 50 && arr[2].Length < 50)
                {
                    TypingSpeeds(arr[2]);
                    query = string.Format("INSERT INTO Mistakes ([deleted],[replaced_with],[datetime],[program_id],[final_word], [typing_speed], [true_typing_speed]) VALUES  ('{0}', '{1}', '{6}', '{2}', '{3}', {4}, {5})", arr[0], arr[1], ExeUtils.exeID, arr[2], typingSpeed, trueTypingSpeed, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    WriteToDB(query);
                }
            }

            typingSpeed = 0;
            trueTypingSpeed = 0;
            preDeleteBuffer.Clear();
            postDeleteBuffer.Clear();
        }

        public void WriteToDB(string query)
        {

            DBUtils.OpenConection();
            DBUtils.ExecuteQueries(query);
            DBUtils.CloseConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (mustCalibrate)
            {
                MessageBox.Show("You must calibrate a program");
                CalibrationMain cbMaain = new CalibrationMain(this, true);
                cbMaain.ShowDialog();
            }

        }


        private void mistakesBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
        }


        private void timer2_Tick(object sender, EventArgs e) 
        {
            AsyncStoreHeatnInput();
        }

        private void userLevelTimer_Tick(object sender, EventArgs e)
        {
            AsyncStoreHeatnInput();

            userLevelTimer.Enabled = false;
            sw.Reset();
            inputStopWatch.Reset();
            timer2.Stop();

            normalInputSW.Reset();

            if (autContrl.isOn)
            {
               
                DBUtils.OpenConection();
                int test = DBUtils.ExecuteScalar(autContrl.lastRowIDQuery);
                int test2 = autContrl.begginingID;
                if (DBUtils.ExecuteScalar(autContrl.lastRowIDQuery) - autContrl.begginingID > 2500)
                {
                    timer2.Interval = autContrl.CalculateUserLevel();
                    //autContrl.isOn = false;

                }
                DBUtils.CloseConnection();


            }

        }

        /* ASYNC */



        private async void AsyncStoreHeatnInput()
        {
            if (!mainController.writeInProgress)
            {
                int t = await Task.Run(() => StoreHeatnInputTask());
            }
        }

        int StoreHeatnInputTask()
        {
            mainController.StoreHeatMapAndInputs();
            return 1;
        }

        private void btn_help_Click(object sender, EventArgs e)
        {

            bool isOpen = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is Web)
                {
                    isOpen = true;
                }
            }

            if (!isOpen)
            {
                Web web = new Web();
                web.Show();
            }
           
        }

        private void btn_tracking_Click(object sender, EventArgs e)
        {
            if (hGlobalLLKeyboardHook == IntPtr.Zero)
            {
                if (SetGlobalLLKeyboardHook() && SetGlobalLLMouseHook()
                    )
                {
                    btn_tracking.Text = "Stop tracking";
                    //btn_tracking.ForeColor = Color.Red;
                    label_tracking.Text = "TRACKING ✓";
                    label_tracking.ForeColor = Color.FromArgb(009900);
                }
                else
                {
                    MessageBox.Show("SetWindowsHookEx(LL KeyBoard) failed");
                }
            }
            else
            {
                if (RemoveGlobalLLKeyboardHook() && RemoveGlobalLLMouseHook()
                    )
                {
                    btn_tracking.Text = "Start tracking";
         
                    label_tracking.Text = "NOT TRACKING ✘";
                    label_tracking.ForeColor = Color.FromArgb(204, 0, 0);
                }
                else
                {
                    MessageBox.Show("UnhookWindowsHookEx(LL Keyboard) failed");
                }
            }
        }

        

        private void btn_heatMap_Click(object sender, EventArgs e)
        {
            HeatmapForm heatmap = new HeatmapForm();
            heatmap.Show();
        }

        private void btn_lineGraphs_Click(object sender, EventArgs e)
        {
            Graphs graphs = new Graphs();
            graphs.Show();
        }

        private void btn_Mistakes_Click(object sender, EventArgs e)
        {
            Statistics stats = new Statistics();
            stats.Show();
        }

        private void btn_calibrate_Click(object sender, EventArgs e)
        {

            bool isOpen = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is CalibrationMain)
                {
                    isOpen = true;
                }
            }

            if (!isOpen)
            {
                CalibrationMain calibration = new CalibrationMain(this);
                calibration.Show();
            }
        }

       

        bool left = true;
        ToolTip tlp;
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (left)
            {
                ShowToolTip();
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {

            if (!left)
            {
                tlp.Dispose();
                left = true;
            }
            
        }
        
        public void TurnOnAutoCal()
        {
            autContrl.SetUserLevel(0);
            autContrl.Hub();
            CheckForAutoCalibration(autContrl.isOn);
            
        }

        public void CheckForAutoCalibration(bool setTo)
        {
            autContrl.isOn = setTo;
            if (autContrl.isOn)
            {
                pictureBox1.Visible = true;
                label_analysis.Visible = false;
            }
            else
            {
                pictureBox1.Visible = false;
                label_analysis.Visible = true;
            }
        }

        private void ShowToolTip()
        {
            left = false;
            tlp = new ToolTip();

            tlp.InitialDelay = 0;
            tlp.ShowAlways = true;
            tlp.Show("Because automatic calibration is on \n statistics might not be correct. \n It will be fixed once automatic calibration ends", pictureBox1, 20000);
            
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (var item in Application.OpenForms)
            {
                if (item is MainAnalysisForm)
                {
                    isOpen = true;
                }
            }

            if (!isOpen)
            {
                MainAnalysisForm ma = new MainAnalysisForm();
                ma.Show();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                //notifyIcon.Visible = true;
                //notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }

            /* Closes all open forms.*/
            List<Form> openForms = new List<Form>();

            foreach (Form f in Application.OpenForms)
                openForms.Add(f);

            foreach (Form f in openForms)
            {
                if (!(f is MainForm))
                    f.Close();
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            RemoveGlobalLLKeyboardHook();
            notifyIcon1.Dispose();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure youw ant to reset all of your statistics and user level?", "Reset", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DialogResult dial2 = MessageBox.Show("All of colected data will be lost, are you sure?", "Reset", MessageBoxButtons.YesNo);

                if (dial2 == DialogResult.Yes)
                {
                    Reset restet = new Reset();
                    restet.ResetProgram(this);
                }
                else if (dial2 == DialogResult.No)
                {


                }

            }
            else if (dialogResult == DialogResult.No)
            {


            }
        }
    }
}
