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
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NT106_project
{
    public partial class textfunction : Form
    {
        public textfunction()
        {

            InitializeComponent();

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new user control
                UserControl2 userControl2 = new UserControl2(guna2TextBox1.Text);

                // Set the location of the UserControl2
                userControl2.Location = new Point(guna2TextBox1.Location.X, guna2TextBox1.Bottom + 10); // Adjust the Y coordinate as needed
                flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
                // Add user control to form
                flowLayoutPanel1.Controls.Add(userControl2);

                // Optionally, remove the text from the textbox
                guna2TextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }
    }
}
