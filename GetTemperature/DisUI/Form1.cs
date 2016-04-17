using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;

namespace DisUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ServiceHost host = new ServiceHost(typeof(PiService));
            host.Open();
        }

        static public string cpuTemp = "";
        static public string cpuFreq = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = cpuTemp;
            textBox2.Text = cpuFreq;
        }
    }
}
