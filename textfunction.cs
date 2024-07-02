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
using Guna.UI2.WinForms;

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
                UserControl1 userControl1 = new UserControl1(guna2TextBox1.Text);
                Panel panel = new Panel();
                panel.Height = userControl1.Height;
                panel.Width = flowLayoutPanel1.ClientSize.Width;
                panel.Controls.Add(userControl1);
                MessageBox.Show(panel.Height.ToString());
                MessageBox.Show(panel.Width.ToString());
                userControl1.Location = new Point( 2, 0);
                flowLayoutPanel1.Controls.Add(panel);


                // Optionally, clear the text from the textbox
                guna2TextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }

        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                // Lấy vị trí con trỏ hiện tại
                int selectionStart = guna2TextBox1.SelectionStart;

                // Thêm ký tự xuống dòng tại vị trí con trỏ
                guna2TextBox1.Text += "\r\n";
                guna2TextBox1.SelectionStart = selectionStart + 2;

                // Đặt lại vị trí con trỏ sau khi chèn
                // Ngăn không cho ký tự Enter gốc được thêm vào

                e.SuppressKeyPress = true;
                guna2TextBox1.ScrollToCaret();

                // In ra vị trí của con trỏ và nội dung TextBox để kiểm tra
                // Điều chỉnh chiều cao của TextBox

                guna2TextBox1.Height += guna2TextBox1.Font.Height;

                // Dịch chuyển TextBox lên trên theo chiều dọc
                System.Drawing.Point currentLocation = guna2TextBox1.Location;
                System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y - guna2TextBox1.Font.Height);
                guna2TextBox1.Location = newLocation;



            }
            else if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                // Ngăn không cho sự kiện Enter gốc được xử lý
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                // Kiểm tra nếu Guna2TextBox không có ký tự nào
                if (guna2TextBox1.Text.Length == 0)
                {
                    return; // Không làm gì nếu không có ký tự để xóa
                }

                // Lấy vị trí của ký tự hiện tại đang được chọn
                int selectionStart = guna2TextBox1.SelectionStart;

                // Kiểm tra nếu vị trí con trỏ không phải là đầu chuỗi
                if (selectionStart > 0)
                {

                    // Lấy ký tự trước con trỏ
                    char charToDelete = guna2TextBox1.Text[selectionStart - 1];
                    if (charToDelete == '\n')
                    {
                        guna2TextBox1.Text = guna2TextBox1.Text.Remove(selectionStart - 1, 1);
                        guna2TextBox1.Text = guna2TextBox1.Text.Remove(selectionStart - 2, 1);
                        guna2TextBox1.SelectionStart = selectionStart - 2;
                        guna2TextBox1.Height -= guna2TextBox1.Font.Height;
                        System.Drawing.Point currentLocation = guna2TextBox1.Location;
                        System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y + guna2TextBox1.Font.Height);
                        guna2TextBox1.Location = newLocation;
                    }
                    else
                    {
                        guna2TextBox1.Text = guna2TextBox1.Text.Remove(selectionStart - 1, 1);

                        // Đặt lại vị trí con trỏ
                        guna2TextBox1.SelectionStart = selectionStart - 1;
                    }


                }

                // Ngăn không cho sự kiện Backspace gốc được xử lý
                e.SuppressKeyPress = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a new user control
                UserControl2 userControl2 = new UserControl2(guna2TextBox1.Text);
                Panel panel = new Panel();
                panel.Height = userControl2.Height;
                panel.Width = flowLayoutPanel1.ClientSize.Width;
                panel.Controls.Add(userControl2);
                MessageBox.Show(panel.Height.ToString());
                MessageBox.Show(panel.Width.ToString());
                userControl2.Location = new Point(panel.Width - userControl2.Width - 2, 0);
                flowLayoutPanel1.Controls.Add(panel);


                // Optionally, clear the text from the textbox
                guna2TextBox1.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
    }
}
