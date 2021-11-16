using NetChallenge.Class;
using NetChallenge.Helper;
using NetChallenge.ProcessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetChallenge
{
    public partial class Form1 : Form
    {
        private int formid = 0;
        private TextBoxData boxData = new TextBoxData();
        private NotepadProcessing notepadProcessing = new NotepadProcessing();
        private ProcessID processID = new ProcessID();
        private GenHelper genHelper = new GenHelper();
        public Form1()
        {
            InitializeComponent();
            addTextboxBinding();
            generateProcessIdAndNotepadInstances();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formid++;
            //MainForm mform = new MainForm(formid.ToString());
           // mform.Show();
            //his.Hide();
        }

        private void addTextboxBinding()
        {
            textBoxA.DataBindings.Add("Text", boxData, "TextBoxA", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxB.DataBindings.Add("Text", boxData, "TextBoxB", false, DataSourceUpdateMode.OnPropertyChanged);
        }
        private void generateProcessIdAndNotepadInstances()
        {           
            processID.ProcessA = notepadProcessing.generateProcessNotepad().Id.ToString();
            processID.ProcessB = notepadProcessing.generateProcessNotepad().Id.ToString();

        }

        private void btnKeySender_Click(object sender, EventArgs e)
        {
            Process pA = notepadProcessing.getCurrentProcessNotepad(this.processID.ProcessA);
            Process pB = notepadProcessing.getCurrentProcessNotepad(this.processID.ProcessB);
            if (pA!=null)
            {
                notepadProcessing.sendTextToNotepad(pA, boxData.TextBoxA);
                SendKeys.SendWait("^(s)");
                Thread.Sleep(200);
                notepadProcessing.killProcess(pA);
                genHelper.saveData("textBoxA-regular-" + DateTime.Now.ToString("yyyyMMddhhmmssmmm")+".txt",boxData.TextBoxA);

            }
            Thread.Sleep(50);
            if (pB !=null)
            {
                string myReverse = genHelper.reverseStringstring(boxData.TextBoxA);
                notepadProcessing.sendTextToNotepad(pB,myReverse);
                SendKeys.SendWait("^(s)");
                Thread.Sleep(200);
                notepadProcessing.killProcess(pB);
                genHelper.saveData("textBoxA-reverse-" + DateTime.Now.ToString("yyyyMMddhhmmssmmm") + ".txt", myReverse);
            }
            if (pA == null && pB==null)
            {
                MessageBox.Show("No available notepad instance for this form");
            }
        }

    }
}
