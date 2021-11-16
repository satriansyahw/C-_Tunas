using NetChallenge.Class;
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
        public Form1()
        {
            InitializeComponent();
            addTextboxBinding();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formid++;
            MainForm mform = new MainForm(formid.ToString());
            mform.Show();
            this.Hide();
        }

        private void clickTextBoxA_Click(object sender, EventArgs e)
        {
            //boxData.TextBoxB = boxData.TextBoxA;
        }

        private void clickTextBoxB_Click(object sender, EventArgs e)
        {
            //boxData.TextBoxA = boxData.TextBoxB;
        }
        private void addTextboxBinding()
        {
            textBoxA.DataBindings.Add("Text", boxData, "TextBoxA", false, DataSourceUpdateMode.OnPropertyChanged);
            textBoxB.DataBindings.Add("Text", boxData, "TextBoxB", false, DataSourceUpdateMode.OnPropertyChanged);
        }
    }
}
