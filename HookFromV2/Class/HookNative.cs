﻿/******************************* Module Header **********************************\
* Module Name:	HookNative.cs
* Project:		CSWindowsHook
* Copyright (c) Microsoft Corporation.
* 
* This file wraps the hook APIs and the structs that are used by these APIs.
* 
* This source is subject to the Microsoft Public License.
* See http://www.microsoft.com/opensource/licenses.mspx#Ms-PL.
* All other rights reserved.
* 
* History:
* * 3/28/2009 11:04 PM Rongchun Zhang Created
* * 4/6/2009 1:26 PM Jialiang Ge Reviewed
\********************************************************************************/

#region Using directives
using System;
using System.Runtime.InteropServices;
#endregion


/// <summary>
/// The CallWndProc hook procedure is an application-defined or library-defined 
/// callback function used with the SetWindowsHookEx function. The HOOKPROC type 
/// defines a pointer to this callback function. CallWndProc is a placeholder for 
/// the application-defined or library-defined function name.
/// </summary>
/// <param name="nCode">
/// Specifies whether the hook procedure must process the message. 
/// </param>
/// <param name="wParam">
/// Specifies whether the message was sent by the current thread. 
/// </param>
/// <param name="lParam">
/// Pointer to a CWPSTRUCT structure that contains details about the message.
/// </param>
/// <returns>
/// If nCode is less than zero, the hook procedure must return the value returned 
/// by CallNextHookEx. If nCode is greater than or equal to zero, it is highly 
/// recommended that you call CallNextHookEx and return the value it returns; 
/// otherwise, other applications that have installed WH_CALLWNDPROC hooks will 
/// not receive hook notifications and may behave incorrectly as a result. If the 
/// hook procedure does not call CallNextHookEx, the return value should be zero. 
/// </returns>
internal delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

internal class NativeMethods
{
    
}



internal static class HookCodes
{
    public const int HC_ACTION = 0;
    public const int HC_GETNEXT = 1;
    public const int HC_SKIP = 2;
    public const int HC_NOREMOVE = 3;
    public const int HC_NOREM = HC_NOREMOVE;
    public const int HC_SYSMODALON = 4;
    public const int HC_SYSMODALOFF = 5;
}

internal enum HookType
{
    //WH_KEYBOARD = 2,
    //WH_MOUSE = 7,
    WH_KEYBOARD_LL = 13,
    WH_MOUSE_LL = 14
}

/// <summary>
/// The structure contains information about a low-level keyboard input event. 
/// </summary>
[StructLayout(LayoutKind.Sequential)]
internal struct KBDLLHOOKSTRUCT
{
    public int vkCode;      // Specifies a virtual-key code
    public int scanCode;    // Specifies a hardware scan code for the key
    public int flags;
    public int time;        // Specifies the time stamp for this message
    public int dwExtraInfo;
}

internal enum KeyboardMessage
{
    WM_KEYDOWN = 0x0100,
    WM_KEYUP = 0x0101,
    WM_SYSKEYDOWN = 0x0104,
    WM_SYSKEYUP = 0x0105
}





[StructLayout(LayoutKind.Sequential)]
internal struct MOUSEHOOKSTRUCT
{
    //public POINT pt;        // The x and y coordinates in screen coordinates
    //public int hwnd;        // Handle to the window that'll receive the mouse message
    //public int wHitTestCode;
    //public int dwExtraInfo;
}

[StructLayout(LayoutKind.Sequential)]
internal struct MSLLHOOKSTRUCT
{
    //public POINT pt;        // The x and y coordinates in screen coordinates. 
    public int mouseData;   // The mouse wheel and button info.
    public int flags;
    public int time;        // Specifies the time stamp for this message. 
    //public IntPtr dwExtraInfo;
}

internal enum MouseMessage
{

    WM_LBUTTONDOWN = 0x0201,
    WM_RBUTTONDOWN = 0x0204,

}


