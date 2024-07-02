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
    public partial class UserControl1 : UserControl
    {

        private const int MaxWidth = 387;
        private const int UppercaseWidth = 27;
        private const int LowercaseWidth = 15;
        string message;
        public UserControl1(string Mess )
        {
            InitializeComponent();
            message = Mess;
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
                            currentLine = currentLine.Substring(0, lastSpaceIndex) + "\r\n" + currentLine.Substring(lastSpaceIndex + 1);
                            size = MaxWidth;
                            i = lastSpaceIndex + 1;
                            lastSpaceIndex = -1;
                        }
                        else
                        {
                            currentLine = currentLine.Insert(i, "\r\n");
                            size = MaxWidth;
                            i += 2;
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
            MessageBox.Show($"lineCount: {lineCount}");
            int fontHeight = guna2TextBox1.Font.Height;
            guna2TextBox1.AutoSize = false;
            int calculatedHeight = fontHeight * (lineCount + 1);
            //guna2TextBox1.Height = 28 * lineCount + 11;
            MessageBox.Show($"font: {guna2TextBox1.Font.Height}");

            //guna2TextBox1.Width = Math.Max(len, 50);
            guna2TextBox1.Size = new Size(Math.Max(len, 50), Math.Max(calculatedHeight, 50));
            this.Size = new Size(500, Math.Max(calculatedHeight, 50));

            MessageBox.Show($"tbWidth: {guna2TextBox1.Width}");
            MessageBox.Show($"tbHeight: {guna2TextBox1.Height}");
            MessageBox.Show($"Height: {this.Height}");
            MessageBox.Show($"Witdh: {this.Width}");
        }


    }
}
