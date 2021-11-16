using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetChallenge.ProcessManagement
{
    public class NotepadProcessing
    {
        public Process generateProcessNotepad()
        {
            Process p = new Process();
            p.StartInfo.FileName = "Notepad";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            p.Start();
            p.WaitForInputIdle();
            return p;
        }
    }
}
