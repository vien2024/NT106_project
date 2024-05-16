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
    public partial class newUIloginsiguppage : Form
    {
        public newUIloginsiguppage()
        {
            InitializeComponent();
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
        }
        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 2);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = false;
            guna2CustomGradientPanel3.Visible = true;
            guna2CustomGradientPanel4.Visible = true;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 0);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 2);
        }
    }
}
