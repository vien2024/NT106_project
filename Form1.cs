using FireSharp.Extensions;

namespace NT106_project
{
    public partial class Form1 : Form
    {
        int height = 0;
        public Form1()
        {

            InitializeComponent();
            height = guna2TextBox1.Height;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            String[] a = guna2TextBox2.Text.Split("\r\n");
            int len = 0;
            List<string> adjustedLines = new List<string>();
            int uppercase = 18;
            int lowercase = 11;
            MessageBox.Show(uppercase.ToString());
            MessageBox.Show(lowercase.ToString());
            foreach (string line in a)
            {
                int size = 0;
                int lastSpaceIndex = -1;
                string currentLine = line;
               for ( int i=0; i<line.Length; i++ )
                {
                    char c = currentLine[i];

                    if (char.IsUpper(c))
                    {
                        size += uppercase;
                    }
                    else
                    {
                        size += lowercase;
                    }

                    if (c == ' ')
                    {
                        lastSpaceIndex = i;
                    }

                    if (size > 387)
                    {
                        if (lastSpaceIndex != -1)
                        {
                            // Thay thế dấu cách gần nhất bằng "\r\n"
                            currentLine = currentLine.Substring(0, lastSpaceIndex) + "\r\n" + currentLine.Substring(lastSpaceIndex + 1);
                            // Reset các chỉ số để tiếp tục kiểm tra phần còn lại của chuỗi
                            size = 0;
                            i = lastSpaceIndex + 1; // Đặt lại chỉ số i để kiểm tra phần còn lại của chuỗi
                            lastSpaceIndex = -1;
                        }
                        else
                        {
                            // Nếu không có dấu cách nào, chỉ cần chèn "\r\n" tại vị trí hiện tại
                            currentLine = currentLine.Insert(i, "\r\n");
                            size = 0;
                            i += 2; // Bỏ qua ký tự "\r\n" mới chèn
                        }
                    }
                }
                adjustedLines.Add(currentLine);
                if (size > len)
                {
                    len = size;
                }
            }
            guna2TextBox2.Text = string.Join("\r\n", adjustedLines);
            int b = adjustedLines.Count;

            guna2TextBox1.Height = guna2TextBox1.Font.Height * (b + 1);
            Point currentLocation = guna2TextBox1.Location;

            // Tạo một vị trí mới với giá trị X giảm đi
            Point newLocation = new Point(486 - len + 50, currentLocation.Y);

            // Thiết lập vị trí mới
            guna2TextBox1.Location = newLocation;
            guna2TextBox1.Width = len;
            MessageBox.Show(guna2TextBox1.Width.ToString());
           

        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {

            // Kiểm tra nếu người dùng nhấn Shift + Enter
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                // Lấy vị trí con trỏ hiện tại
                int selectionStart = guna2TextBox2.SelectionStart;

                // Thêm ký tự xuống dòng tại vị trí con trỏ
                guna2TextBox2.Text += "\r\n";
                guna2TextBox2.SelectionStart = selectionStart + 2;

                // Đặt lại vị trí con trỏ sau khi chèn
                // Ngăn không cho ký tự Enter gốc được thêm vào

                e.SuppressKeyPress = true;
                guna2TextBox2.ScrollToCaret();

                // In ra vị trí của con trỏ và nội dung TextBox để kiểm tra
                // Điều chỉnh chiều cao của TextBox

                guna2TextBox2.Height += guna2TextBox2.Font.Height;

                // Dịch chuyển TextBox lên trên theo chiều dọc
                System.Drawing.Point currentLocation = guna2TextBox2.Location;
                System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y - guna2TextBox2.Font.Height);
                guna2TextBox2.Location = newLocation;



            }
            else if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                // Ngăn không cho sự kiện Enter gốc được xử lý
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                // Kiểm tra nếu Guna2TextBox không có ký tự nào
                if (guna2TextBox2.Text.Length == 0)
                {
                    return; // Không làm gì nếu không có ký tự để xóa
                }

                // Lấy vị trí của ký tự hiện tại đang được chọn
                int selectionStart = guna2TextBox2.SelectionStart;

                // Kiểm tra nếu vị trí con trỏ không phải là đầu chuỗi
                if (selectionStart > 0)
                {

                    // Lấy ký tự trước con trỏ
                    char charToDelete = guna2TextBox2.Text[selectionStart - 1];
                    if (charToDelete == '\n')
                    {
                        guna2TextBox2.Text = guna2TextBox2.Text.Remove(selectionStart - 1, 1);
                        guna2TextBox2.Text = guna2TextBox2.Text.Remove(selectionStart - 2, 1);
                        guna2TextBox2.SelectionStart = selectionStart - 2;
                        guna2TextBox2.Height -= guna2TextBox2.Font.Height;
                        System.Drawing.Point currentLocation = guna2TextBox2.Location;
                        System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y + guna2TextBox2.Font.Height);
                        guna2TextBox2.Location = newLocation;
                    }
                    else
                    {
                        guna2TextBox2.Text = guna2TextBox2.Text.Remove(selectionStart - 1, 1);

                        // Đặt lại vị trí con trỏ
                        guna2TextBox2.SelectionStart = selectionStart - 1;
                    }


                }

                // Ngăn không cho sự kiện Backspace gốc được xử lý
                e.SuppressKeyPress = true;
            }

        }
        

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

       
    }
}
