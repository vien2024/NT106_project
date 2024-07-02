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
using Guna.UI2.WinForms;

namespace NT106_project
{
    public partial class UserControl2 : UserControl
    {
        private const int MaxWidth = 387;
        private const int UppercaseWidth = 27;
        private const int LowercaseWidth = 17;
        string message;

        public UserControl2(string mess)
        {
            InitializeComponent();
            message = mess;
            UpdateTextBox();

        }

      
        private void UpdateTextBox()
        {
            string[] lines = message.Split(new[] { "\r\n" }, StringSplitOptions.None);
            List<string> adjustedLines = new List<string>();

            int len = 0;
            foreach (string line in lines)
            {
                int size = 0;
                int lastSpaceIndex = -1;
                string currentLine = line;

                for (int i = 0; i < currentLine.Length; i++)
                {
                    char c = currentLine[i];

                    if (char.IsUpper(c))
                    {
                        size += UppercaseWidth;
                    }
                    else
                    {
                        size += LowercaseWidth;
                    }

                    if (c == ' ')
                    {
                        lastSpaceIndex = i;
                    }

                    if (size > MaxWidth)
                    {
                        if (lastSpaceIndex != -1)
                        {
                            currentLine = currentLine.Remove(i, 1).Insert(i, "\r\n");
                            i = i + 2;
                        }
                        for ( int j= lastSpaceIndex; j<=i;j++ )
                        {
                            char d = currentLine[i];

                            if (char.IsUpper(d))
                            {
                                size -= UppercaseWidth;
                            }
                            else
                            {
                                size -= LowercaseWidth;
                            }
                        }    
                        
                    }
                }
                adjustedLines.Add(currentLine);


                if (size > len)
                {
                    len = size;
                }
            }

            guna2TextBox1.Text = string.Join("\r\n", adjustedLines);

            int lineCount = adjustedLines.Count;
            int fontHeight = guna2TextBox1.Font.Height;
            guna2TextBox1.AutoSize = false;
            int calculatedHeight = fontHeight * (lineCount+ 1);
            MessageBox.Show($"calculatedHeight: {calculatedHeight}");
            //guna2TextBox1.Width = Math.Max(len, 50);

            guna2TextBox1.Size = new Size(Math.Max(len, 50),Math.Max(calculatedHeight,50));
            this.Size = new Size(500, Math.Max(calculatedHeight, 50));

            MessageBox.Show($"tbWidth: {guna2TextBox1.Width}");
            MessageBox.Show($"tbHeight: {guna2TextBox1.Height}");
            MessageBox.Show($"Height: {this.Height}");
            MessageBox.Show($"Witdh: {this.Width}");
        }    
    }
}
