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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formid++;
            MainForm mform = new MainForm(formid.ToString());
            mform.Show();
           // mform.Focus();
            this.Hide();
        }
    }
}
