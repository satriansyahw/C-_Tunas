using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.ProcessManagement
{
    public class NotepadProcessing
    {

        #region Imports
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        [DllImport("User32.dll")]
        private static extern Int32 SetForegroundWindow(int hnwd);

        //this is a constant indicating the window that we want to send a text message
        const int WM_SETTEXT = 0X000C;
        #endregion
        public Process generateProcessNotepad()
        {
            Process p = new Process();
            p.StartInfo.FileName = "Notepad";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            p.WaitForInputIdle();
            return p;
        }
        public Process getCurrentProcessNotepad(string processId)
        {
            Process[] local = Process.GetProcessesByName("notepad");
            Process p = local.Where(a => a.Id.ToString() == processId).FirstOrDefault();
            return p;
        }
        public void sendTextToNotepad(Process process,string text)
        {
            IntPtr notepadTextbox = FindWindowEx(process.MainWindowHandle, IntPtr.Zero, "Edit", null);
            process.WaitForInputIdle();
            var handle = process.MainWindowHandle;
            SetForegroundWindow((int)handle);
            SendMessage(notepadTextbox, WM_SETTEXT, 0, text);
        }
        public void killProcess(Process process)
        {
            process.Kill();
            process.WaitForExit();
            process.Dispose();
        }
    }
}
