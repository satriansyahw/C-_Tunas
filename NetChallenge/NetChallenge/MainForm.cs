using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetChallenge
{
    public partial class MainForm : Form
    {
        private string formid = "form_id_";
        private string processid1 = "";
        private string processid2 = "";
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
        public MainForm(string formid)
        {
            InitializeComponent();
            this.formid = this.formid + formid;
            this.Text = this.formid;
            //this.processid1 = this.formid + "_1";
            ///this.processid2 = this.formid + "_2";
            Process p1 = new Process();
            p1.StartInfo.FileName = "Notepad";
              p1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p1.Start();
            this.processid1 = p1.Id.ToString();
            p1.WaitForInputIdle();



            Process p2 = new Process();
            p2.StartInfo.FileName = "Notepad";
             p2.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p2.Start();
            this.processid2 = p2.Id.ToString();

            p2.WaitForInputIdle();
            SetForegroundWindow((int)this.Handle);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process[] local = Process.GetProcessesByName("notepad");
            Process p = local.Where(a => a.Id.ToString() == this.processid1).FirstOrDefault();
            
            IntPtr notepadTextbox = FindWindowEx(p.MainWindowHandle, IntPtr.Zero, "Edit", null);
            p.WaitForInputIdle();
            var handle = p.MainWindowHandle;
            SetForegroundWindow((int)handle);
            SendMessage(notepadTextbox, WM_SETTEXT, 0, textBoxA.Text);


            SendKeys.SendWait("^(s)");
           
            //  string  output  = p.StandardOutput.ReadToEnd();
            // MessageBox.Show(output);
            //p.Kill();
            //p.WaitForExit();
            //p.Dispose();
       
        }

        private void textBoxA_TextChanged(object sender, EventArgs e)
        {
            textBoxB.Text = textBoxA.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textBoxA.Text = textBoxB.Text;
        }
    }
}
