using NetChallenge.Class;
using NetChallenge.ProcessManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetChallenge
{
    public partial class Form1 : Form
    {
        private int formid = 0;
        private TextBoxData boxData = new TextBoxData();
        private string processId = string.Empty;
        private string processId1 = string.Empty;
        private string processId2 = string.Empty;
        private NotepadProcessing notepadProcessing = new NotepadProcessing();
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
            processId = DateTime.Now.ToString("yyyyMMddhhmmss") + Guid.NewGuid();
            processId1 += notepadProcessing.generateProcessNotepad().Id.ToString();
            processId2 += notepadProcessing.generateProcessNotepad().Id.ToString();

        }
    }
}
