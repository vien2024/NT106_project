using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace NT106_project
{
    public partial class textfunction : Form
    {
        public textfunction()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            listView1.HideSelection = false;
            listView1.Columns.Clear();
        }
       
        private void guna2Button1_Click(object sender, EventArgs e)
        {
           
          

            listView1.Items.Add( guna2TextBox1.Text);

        }
    }
}
