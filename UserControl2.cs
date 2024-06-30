using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Text;

namespace NT106_project
{
    public partial class UserControl2 : UserControl
    {
        public UserControl2(string a)
        {
            InitializeComponent();
            guna2TextBox1.Multiline = true;
            guna2TextBox1.WordWrap = false;
            guna2TextBox1.AutoSize = false;
            guna2TextBox1.Text = WrapText(a, 30); // Call custom method to wrap text
            guna2TextBox1.ReadOnly = true;

            guna2TextBox1.Text = a;
            guna2TextBox1.MaximumSize = new System.Drawing.Size(400, 600);
            guna2TextBox1.MinimumSize = new System.Drawing.Size(50, 50);
            Size preferredSize = TextRenderer.MeasureText(a, guna2TextBox1.Font, new Size(guna2TextBox1.Width, int.MaxValue), TextFormatFlags.WordBreak);
            guna2TextBox1.Height = preferredSize.Height;
            
        }
        private string WrapText(string text, int maxLength)
        {
            StringBuilder sb = new StringBuilder();
            int lineLength = 0;

            foreach (char c in text)
            {
                sb.Append(c);
                lineLength++;

                if (lineLength == maxLength) // Insert line break after maxLength characters
                {
                    sb.AppendLine();
                    lineLength = 0; // Reset line length
                }
            }

            return sb.ToString();
        }

    }
}
