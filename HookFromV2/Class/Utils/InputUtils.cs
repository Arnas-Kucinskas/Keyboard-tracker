using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Linq;


namespace HookFromV2
{
   public static class InputUtils
    {


        public static string seperators = "!?/@#$%^&*()_+-,.<>;:|[]{}\\\"";

        public static Keys[] seperatorKeys = new Keys[]
        {
          Keys.Space,
          Keys.Oem1, Keys.Oem102, Keys.Oem2, Keys.Oem3, Keys.Oem4, Keys.Oem5, Keys.Oem6,
          Keys.Oem8, Keys.OemBackslash, Keys.OemClear, Keys.OemCloseBrackets,
          Keys.Oemcomma, Keys.OemMinus, Keys.OemOpenBrackets, Keys.OemPeriod, Keys.OemPipe,
          Keys.Oemplus, Keys.OemQuestion,  Keys.OemSemicolon, Keys.Oemtilde, Keys.Subtract, Keys.Add, Keys.Multiply, Keys.Divide
        };
        //Keys.Oem7 because "It's" Keys.OemQuotes

        public static Keys[] systemKeys = new Keys[]
        {
          Keys.LControlKey, Keys.RControlKey,
          Keys.LWin, Keys.RWin,
          Keys.LMenu, Keys.RMenu, 
        };

        private static Keys[] ruleKeys = new Keys[]
        {
            Keys.Delete, Keys.Back,
        };

        private static Keys[] panicKeys = new Keys[]
        {
          Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8,
          Keys.F9, Keys.F10, Keys.F11, Keys.F12,

          Keys.Escape, Keys.Enter, Keys.Return,

          Keys.Home, Keys.PageUp, Keys.PageDown, Keys.End, Keys.Apps, Keys.Tab,

          Keys.Up, Keys.Down,
        };

        private static Keys[] pointerModifierKeys = new Keys[]
         {
          Keys.Left, Keys.Right
         };

        private static List<Keys> normalKeys = new List<Keys>(
        new Keys[]
        {
          Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H,
          Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P,
          Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X,
          Keys.Y, Keys.Z,
          Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6,
          Keys.D7, Keys.D8, Keys.D9,

          Keys.Oem1,Keys.Oem102,Keys.Oem2,Keys.Oem3,Keys.Oem4,Keys.Oem5,Keys.Oem6,
          Keys.Oem7,Keys.Oem8,Keys.OemBackslash,Keys.OemClear,Keys.OemCloseBrackets,
          Keys.Oemcomma,Keys.OemMinus,Keys.OemOpenBrackets,Keys.OemPeriod,Keys.OemPipe,
          Keys.Oemplus,Keys.OemQuestion,Keys.OemQuotes,Keys.OemSemicolon,Keys.Oemtilde,

          Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4,
          Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9,
          Keys.Decimal, Keys.Divide, Keys.Multiply, Keys.Subtract, Keys.Add,

          Keys.Space,

      });

        //public static int systemKeysLength = SystemKeys.Length;

       

        public static Keys ReturnSystemKey(int i)
        {
            return systemKeys[i];
        }

        

        public static string GetKeyType(Keys vkCode)// validation
        {
            if (panicKeys.Contains(vkCode)) {
                return "panic";
            } else if (ruleKeys.Contains(vkCode)) {
                return "rule";
            } else if (pointerModifierKeys.Contains(vkCode)) {
                return "pointer";
            } else if (normalKeys.Contains(vkCode)) {
                return "normal";
            } else if (systemKeys.Contains(vkCode)) {
                return "system";
            }
            return "notyope";
        }

        /* Converts keyboard scan code to symbol */
        public static string GetCharsFromKeys(Keys keys)
        {
            IntPtr inputLocaleIdentifier = WindowsAPI.GetKeyboardLayout(WindowsAPI.GetWindowThreadProcessId(WindowsAPI.GetForegroundWindow(), IntPtr.Zero));
            bool shift = Control.ModifierKeys.HasFlag(Keys.Shift);
            bool caps = Control.IsKeyLocked(Keys.Capital);
            var buf = new StringBuilder(256);
            var keyboardState = new byte[256];
            if (shift)
                keyboardState[(int)Keys.ShiftKey] = 0xff;

            //WindowsAPI.ToUnicode((uint)keys, 0, keyboardState, buf, 256, 0);
            WindowsAPI.ToUnicodeEx((uint)keys, 0, keyboardState, buf, 256, 0, inputLocaleIdentifier);
            if (caps && !shift || !caps && shift)
            {
                return buf.ToString().ToUpper();
            }
            else
            {
                return buf.ToString().ToLower();
            }
        }
    }
}