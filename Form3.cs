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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            chatbox.Visible = true;
            Menubox.Visible = true;
            profilebox.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Menubox.Visible = true;
            profilebox.Visible = true;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button2.ShadowDecoration.Enabled = false;
            guna2Button3.ShadowDecoration.Enabled = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Menubox.Visible = true;
            profilebox.Visible = false;
            chatbox.Visible = true;
            guna2Button3.ShadowDecoration.Enabled = true;
            guna2Button1.ShadowDecoration.Enabled = false;
            guna2Button2.ShadowDecoration.Enabled = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Form1 pacman = new Form1();
            pacman.Show();
        }
    }
}
