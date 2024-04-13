using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_supanel_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void btn_lgnpanel_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_lgnpanel.PerformClick();
        }

    }
}
