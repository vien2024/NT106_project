using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Reflection.Metadata;
using FireSharp.Response;
using System.Drawing.Imaging;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Guna.UI2.WinForms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using J3QQ4;
using System.Reflection;
namespace NT106_project
{


    public partial class Client : Form
    {
        private List<string> Smiles = new List<string>();
        public void AddEmojisToList()
        {
            // Get all public static fields of the Emoji class
            FieldInfo[] fields = typeof(Emoji).GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (var field in fields)
            {
                // Check if the field is a constant and of type string
                if (field.IsLiteral && !field.IsInitOnly && field.FieldType == typeof(string))
                {
                    // Add the value of the field to the Smiles list
                    Smiles.Add((string)field.GetValue(null));
                }
            }
        }
        // public value
        private bool isClickable = true;
        bool checkfirstime;
        string Username;
        int lastcheck = 9;
        int check = 0;
        bool checkchangepw;
        bool checksave;
        bool checkverify;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        string Currentuser;
        IPEndPoint iep;
        Socket clientdevice;

        //........................................................................................................................

        public Client(string UserID, bool a)
        {

            InitializeComponent();
            Currentuser = UserID;
            checkfirstime = a;
            connect();
        }

        private async void Client_Load(object sender, EventArgs e)
        {
            loadfunction();


        }

        //........................................................................................................................
        // private ui :
        // load data   
        private async void LoadData()
        {
            await LoadDataIntoDataGridView();
        }
        // tìm tên ()

        // load data to datagridview
        private async Task LoadDataIntoDataGridView()
        {
            MessageBox.Show("LoadDataIntoDataGridView");
            var names = await GetNamesFromFirebaseAsync();
            // Ensure we update the DataGridView on the UI thread
            if (userlist.InvokeRequired)
            {
                userlist.Invoke(new Action(() =>
                {
                    userlist.DataSource = names.Select(name => new { Name = name }).ToList();
                }));
            }
            else
            {
                userlist.DataSource = names.Select(name => new { Name = name }).ToList();
            }
        }
        // get name list from firebase
        private async Task<List<string>> GetNamesFromFirebaseAsync()
        {
            MessageBox.Show("GetNamesFromFirebaseAsync");
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Users") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Extract the names from the data
            return data.Where(item => item.Object.name != Username).Select(item => item.Object.name).ToList();
        }

        // function to click in list name ( friend list will be soon update for  )
        private async void userlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isClickable)
            {
                return;
            }
            isClickable = false; // Disable clicking
            timer1.Start(); // Start the timer
            var cellValue = userlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            chater.Text = cellValue.ToString();
            flowLayoutPanel2.Controls.Clear();
            // send message to server that client want to connect to this user and load message from filelog
            string Userid2 = await GetUserIDFromName(chater.Text);
            var Userconnect = new User_connect
            {
                Userid = Currentuser,
                Lastconnected = Userid2,
            };
            FirebaseResponse firebaseResponse3 = await client.SetTaskAsync("Userconnect/" + Currentuser, Userconnect);
            datasending data = new datasending(Currentuser, Userid2, true, true);
            SendMessage(data);

        }
        // function to take userid from Name
        private async Task<string> GetUserIDFromName(string name)
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Users") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Extract the names from the data
            return data.Where(item => item.Object.name == name).Select(item => item.Object.Userid).FirstOrDefault();
        }

        // make cell that we click selected ( Use in receive that)
        private void SelectCellWithStringA(DataGridView dataGridView, string a)
        {
            // Iterate through all rows in the DataGridView
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                // Iterate through all cells in the row
                foreach (DataGridViewCell cell in row.Cells)
                {
                    // Check if the cell's value is "string a"
                    if (cell.Value != null && cell.Value.ToString() == a)
                    {
                        // Select the cell
                        cell.Selected = true;

                        // Optionally, scroll to the cell
                        dataGridView.FirstDisplayedScrollingRowIndex = row.Index;

                        // Exit the loop after finding the first match
                        return;
                    }
                }
            }

            // If no cell is found with the value "string a", display a message or handle accordingly
            MessageBox.Show("Cell with value 'string a' not found.");
        }

        // function for writing chat
        private void chatbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                // Lấy vị trí con trỏ hiện tại
                int selectionStart = chatbox.SelectionStart;

                // Thêm ký tự xuống dòng tại vị trí con trỏ
                chatbox.Text += "\r\n";
                chatbox.SelectionStart = selectionStart + 2;

                // Đặt lại vị trí con trỏ sau khi chèn
                // Ngăn không cho ký tự Enter gốc được thêm vào

                e.SuppressKeyPress = true;
                chatbox.ScrollToCaret();

                // In ra vị trí của con trỏ và nội dung TextBox để kiểm tra
                // Điều chỉnh chiều cao của TextBox

                chatbox.Height += chatbox.Font.Height;

                // Dịch chuyển TextBox lên trên theo chiều dọc
                System.Drawing.Point currentLocation = chatbox.Location;
                System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y - chatbox.Font.Height);
                chatbox.Location = newLocation;



            }
            else if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                // Ngăn không cho sự kiện Enter gốc được xử lý
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                // Kiểm tra nếu Guna2TextBox không có ký tự nào
                if (chatbox.Text.Length == 0)
                {
                    return; // Không làm gì nếu không có ký tự để xóa
                }

                // Lấy vị trí của ký tự hiện tại đang được chọn
                int selectionStart = chatbox.SelectionStart;

                // Kiểm tra nếu vị trí con trỏ không phải là đầu chuỗi
                if (selectionStart > 0)
                {

                    // Lấy ký tự trước con trỏ
                    char charToDelete = chatbox.Text[selectionStart - 1];
                    if (charToDelete == '\n')
                    {
                        chatbox.Text = chatbox.Text.Remove(selectionStart - 1, 1);
                        chatbox.Text = chatbox.Text.Remove(selectionStart - 2, 1);
                        chatbox.SelectionStart = selectionStart - 2;
                        chatbox.Height -= chatbox.Font.Height;
                        System.Drawing.Point currentLocation = chatbox.Location;
                        System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, currentLocation.Y + chatbox.Font.Height);
                        chatbox.Location = newLocation;
                    }
                    else
                    {
                        chatbox.Text = chatbox.Text.Remove(selectionStart - 1, 1);

                        // Đặt lại vị trí con trỏ
                        chatbox.SelectionStart = selectionStart - 1;
                    }


                }

                // Ngăn không cho sự kiện Backspace gốc được xử lý
                e.SuppressKeyPress = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            isClickable = true; // Re-enable clicking
            timer1.Stop(); // Stop the timer
        }
        private async void sendbtn1_Click(object sender, EventArgs e)
        {
            FirebaseResponse firebaseResponse3 = await client.GetTaskAsync("Userconnect/" + Currentuser);
            User_connect obj = firebaseResponse3.ResultAs<User_connect>();
            datasending data = new datasending(Currentuser, obj.Lastconnected, chatbox.Text, true, false);
            SendMessage(data);
            UserControl2 userControl2 = new UserControl2(chatbox.Text);
            Panel panel = new Panel();
            panel.Height = userControl2.Height;
            panel.Width = flowLayoutPanel2.ClientSize.Width;
            panel.Controls.Add(userControl2);
            MessageBox.Show(panel.Height.ToString());
            MessageBox.Show(panel.Width.ToString());
            userControl2.Location = new Point(panel.Width - userControl2.Width - 2, 0);
            flowLayoutPanel2.Controls.Add(panel);

            chatbox.Clear();
            chatbox.Height = 30;
            System.Drawing.Point currentLocation = chatbox.Location;
            System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, 401);
            chatbox.Location = newLocation;

        }
        //........................................................................................................................
        // forum ui :
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

                guna2TextBox1.Height += chatbox.Font.Height;

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

        private void sendbtn_Click(object sender, EventArgs e)
        {
            datasending datasending = new datasending(Currentuser, "All", guna2TextBox1.Text, true, false);
            SendMessage(datasending);

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
            guna2TextBox1.Height = 48;
            System.Drawing.Point currentLocation = guna2TextBox1.Location;
            System.Drawing.Point newLocation = new System.Drawing.Point(currentLocation.X, 374);
            guna2TextBox1.Location = newLocation;
        }







        //........................................................................................................................
        // profile ui :


        // save button function to update user data
        private async void savebtn_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream();
            Userimage.Image.Save(ms, ImageFormat.Jpeg);
            byte[] img = ms.ToArray();
            string output = Convert.ToBase64String(img);

            FirebaseResponse response3 = await client.GetTaskAsync("Users/" + Currentuser);
            Data obj3 = response3.ResultAs<Data>();
            var data = new Data
            {
                image = output,
                name = UserName.Text,
                email = Email.Text,
                phone = Phone.Text,
                desc = Desc.Text,
                sex = Sex.Text,
                Username = obj3.Username,
                Password = obj3.Password,
                Userid = obj3.Userid,
                firstime = false,
                verified = obj3.verified
            };
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(Email.Text))
            {
                if (string.IsNullOrEmpty(UserName.Text))
                {
                    UserName.Text = "Please provide Username!";
                    UserName.BorderColor = System.Drawing.Color.Red;
                }
                if (string.IsNullOrEmpty(Email.Text))
                {
                    Email.Text = "Please provide Email!";
                    Email.BorderColor = System.Drawing.Color.Red;
                }
                checksave = false;
            }
            else
            {
                if (checkverify != true)
                {
                    MessageBox.Show("Please verify your email first!");
                }
                else
                {
                    checksave = true;
                }
            }
            if (checksave == true)
            {
                FirebaseResponse response = await client.UpdateTaskAsync("Users/" + Currentuser, data);
                MessageBox.Show("Data Updated Successfully");
            }

        }

        // change password button function
        private async void changepasswordbtn_Click(object sender, EventArgs e)
        {
            if (checkverify != true)
            {
                MessageBox.Show("Please verify your email first!");
            }
            else
            {
                if (string.IsNullOrEmpty(Current_Password.Text) || string.IsNullOrEmpty(New_Password.Text))
                {
                    if (string.IsNullOrEmpty(Current_Password.Text))
                    {
                        Current_Password.Text = "Please provide Current Password!";
                        Current_Password.BorderColor = System.Drawing.Color.Red;
                    }
                    if (string.IsNullOrEmpty(New_Password.Text))
                    {
                        New_Password.Text = "Please provide New Password!";
                        New_Password.BorderColor = System.Drawing.Color.Red;
                    }
                    checkchangepw = false;
                }
                else
                {
                    if (Current_Password.Text == New_Password.Text)
                    {
                        New_Password.Text = "Your new password is as same as current password!";
                        New_Password.BorderColor = System.Drawing.Color.Red;
                        checkchangepw = false;
                    }
                    else
                    {
                        checkchangepw = true;
                    }
                }
            }
            if (checkchangepw == true)
            {
                FirebaseResponse response = await client.GetTaskAsync("Users/" + Currentuser);
                Data obj2 = response.ResultAs<Data>();
                Data changepw = new Data();
                changepw.image = obj2.image;
                changepw.Userid = obj2.Userid;
                changepw.Password = New_Password.Text;
                changepw.firstime = false;
                changepw.verified = true;
                changepw.name = obj2.name;
                changepw.email = obj2.email;
                changepw.phone = obj2.phone;
                changepw.desc = obj2.desc;
                changepw.sex = obj2.sex;
                changepw.Username = obj2.Username;
                FirebaseResponse response2 = await client.UpdateTaskAsync("Users/" + Currentuser, changepw);
                MessageBox.Show("Data Updated Successfully");
            }
        }

        // verify email button function
        private void verifybtn_Click(object sender, EventArgs e)
        {
            verifyemailpage verifyemailpage = new verifyemailpage(Currentuser);
            verifyemailpage.Show();
            this.Hide();
        }
        //  upload image function
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image";
            ofd.Filter = "Choose Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Image img = new Bitmap(ofd.FileName);
                Userimage.Image = img.GetThumbnailImage(100, 100, null, new IntPtr());
            }

        }

        // function for writing in description
        private void Desc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                // Lấy vị trí con trỏ hiện tại
                int selectionStart = Desc.SelectionStart;

                // Thêm ký tự xuống dòng tại vị trí con trỏ
                Desc.Text += "\r\n";
                Desc.SelectionStart = selectionStart + 2;

                // Đặt lại vị trí con trỏ sau khi chèn
                // Ngăn không cho ký tự Enter gốc được thêm vào

                e.SuppressKeyPress = true;
                Desc.ScrollToCaret();

                // In ra vị trí của con trỏ và nội dung TextBox để kiểm tra
                // Điều chỉnh chiều cao của TextBox



            }
            else if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                // Ngăn không cho sự kiện Enter gốc được xử lý
                e.SuppressKeyPress = true;
            }
            if (e.KeyCode == Keys.Back)
            {
                // Kiểm tra nếu Guna2TextBox không có ký tự nào
                if (Desc.Text.Length == 0)
                {
                    return; // Không làm gì nếu không có ký tự để xóa
                }

                // Lấy vị trí của ký tự hiện tại đang được chọn
                int selectionStart = Desc.SelectionStart;

                // Kiểm tra nếu vị trí con trỏ không phải là đầu chuỗi
                if (selectionStart > 0)
                {

                    // Lấy ký tự trước con trỏ
                    char charToDelete = Desc.Text[selectionStart - 1];
                    if (charToDelete == '\n')
                    {
                        Desc.Text = Desc.Text.Remove(selectionStart - 1, 1);
                        Desc.Text = Desc.Text.Remove(selectionStart - 2, 1);
                        Desc.SelectionStart = selectionStart - 2;

                    }
                    else
                    {
                        Desc.Text = Desc.Text.Remove(selectionStart - 1, 1);

                        // Đặt lại vị trí con trỏ
                        Desc.SelectionStart = selectionStart - 1;
                    }


                }

                // Ngăn không cho sự kiện Backspace gốc được xử lý
                e.SuppressKeyPress = true;
            }
        }

        // .........................................................................................................................
        // logout fuction
        private void guna2Button8_Click(object sender, EventArgs e)
        {

            this.Hide();
            newUIloginsiguppage1 newUIloginsiguppage1 = new newUIloginsiguppage1();
            newUIloginsiguppage1.Show();
        }
        // .........................................................................................................................
        //connect function
        private void connect()
        {
            iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            clientdevice = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientdevice.Connect(iep);
                Thread listen = new Thread(receive);
                listen.IsBackground = true;
                listen.Start();

                datasending data = new datasending(Currentuser, false);

                string jsonString = JsonSerializer.Serialize(data);
                byte[] sendData = Encoding.UTF8.GetBytes(jsonString); ;

                clientdevice.Send(sendData);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        // .............................................................................................................................
        // public function :

        // receive data function
        private void receive()
        {
            StringBuilder buffer = new StringBuilder();

            while (true)
            {
                Byte[] data = new Byte[5120];
                int recv = clientdevice.Receive(data);
                if (recv == 0)
                {
                    throw new Exception("Server disconnected");
                }
                string jsonString = Encoding.UTF8.GetString(data, 0, recv);

                // Append received data to the buffer
                buffer.Append(jsonString);

                while (true)
                {
                    string bufferContent = buffer.ToString();
                    int startIndex = bufferContent.IndexOf('{');
                    int endIndex = bufferContent.IndexOf('}');

                    if (startIndex == -1 || endIndex == -1)
                    {
                        // No complete JSON object found, exit the inner loop
                        break;
                    }
                    // Find the actual end of the JSON object (consider nested objects)
                    int openBraces = 0;
                    int closeBraces = 0;
                    endIndex = -1;

                    for (int i = startIndex; i < bufferContent.Length; i++)
                    {
                        if (bufferContent[i] == '{')
                        {
                            openBraces++;
                        }
                        else if (bufferContent[i] == '}')
                        {
                            closeBraces++;
                        }

                        if (openBraces == closeBraces && openBraces != 0)
                        {
                            endIndex = i;
                            break;
                        }
                    }

                    if (endIndex == -1)
                    {
                        // No complete JSON object found, exit the inner loop
                        break;
                    }

                    // Extract the complete JSON object
                    string completeJson = bufferContent.Substring(startIndex, endIndex - startIndex + 1);

                    // Remove the processed JSON object from the buffer
                    buffer.Remove(0, endIndex + 1);

                    try
                    {

                        datasending msg = JsonSerializer.Deserialize<datasending>(completeJson);
                        handle_data(msg);
                    }
                    catch (JsonException jsonEx)
                    {
                        MessageBox.Show($"JSON Deserialization error: {jsonEx.Message}");
                    }
                }
            }


        }
        // handle data function
        private async void handle_data(datasending obj)
        {
            if (check == 2)  // private chat
            {
                if (obj.Type == "None" && obj.USerid1 == "None" && !obj.Checkload)
                {
                    if (obj.Message != "None")
                    {
                        FirebaseResponse response = await client.GetTaskAsync("Users/" + obj.Message);
                        Data data1 = response.ResultAs<Data>();
                        chater.Text = data1.name;
                        SelectCellWithStringA(userlist, data1.name);
                        flowLayoutPanel2.Controls.Clear();
                        datasending datasending = new datasending(Currentuser, obj.Message, true, true);
                        SendMessage(datasending);
                    }
                }
                else if (obj.Type == "Private" && obj.Checkload)
                {
                    isClickable = false;
                    timer1.Start();
                    string[] parts = (obj.Message).Split('|');
                    foreach (string part in parts)
                    {
                        if (part.Contains("&&"))
                        {
                            string[] arg = part.Split("&&");
                            if (arg[0].Trim() == Currentuser)
                            {
                                try // use for your mess
                                {
                                    Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        // Create a new user control
                                        UserControl2 userControl2 = new UserControl2(arg[1]);
                                        Panel panel = new Panel();
                                        panel.Height = userControl2.Height;
                                        panel.Width = flowLayoutPanel2.ClientSize.Width;
                                        panel.Controls.Add(userControl2);

                                        userControl2.Location = new Point(panel.Width - userControl2.Width - 2, 0);
                                        flowLayoutPanel2.Controls.Add(panel);
                                        flowLayoutPanel2.ScrollControlIntoView(panel);
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
                                }
                            }
                            else
                            {
                                try   // Use for your friend mess
                                {
                                    Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        UserControl1 userControl1 = new UserControl1(arg[1]);
                                        Panel panel = new Panel();
                                        panel.Height = userControl1.Height;
                                        panel.Width = flowLayoutPanel2.ClientSize.Width;
                                        panel.Controls.Add(userControl1);

                                        userControl1.Location = new Point(2, 0);
                                        flowLayoutPanel2.Controls.Add(panel);
                                        flowLayoutPanel2.ScrollControlIntoView(panel);
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
                                }
                            }



                        }
                    }
                }
            }
            else if (check == 3) // forum chat 
            {
                if (obj.Type == "All" && obj.Checkload)
                {
                    string[] parts = (obj.Message).Split('|');
                    foreach (string part in parts)
                    {
                        if (part.Contains("&&"))
                        {
                            string[] arg = part.Split("&&");
                            if (arg[0].Trim() == Currentuser)
                            {
                                try
                                {
                                    Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        // Create a new user control
                                        UserControl2 userControl2 = new UserControl2(arg[1]);
                                        Panel panel = new Panel();
                                        panel.Height = userControl2.Height;
                                        panel.Width = flowLayoutPanel1.ClientSize.Width;
                                        panel.Controls.Add(userControl2);
                                        userControl2.Location = new Point(panel.Width - userControl2.Width - 2, 0);
                                        flowLayoutPanel1.Controls.Add(panel);
                                        flowLayoutPanel1.ScrollControlIntoView(panel);
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
                                }
                            }
                            else
                            {
                                try
                                {
                                    Invoke((System.Windows.Forms.MethodInvoker)delegate
                                    {
                                        UserControl1 userControl1 = new UserControl1(arg[1]);
                                        Panel panel = new Panel();
                                        panel.Height = userControl1.Height;
                                        panel.Width = flowLayoutPanel1.ClientSize.Width;
                                        panel.Controls.Add(userControl1);

                                        userControl1.Location = new Point(2, 0);
                                        flowLayoutPanel1.Controls.Add(panel);
                                        flowLayoutPanel1.ScrollControlIntoView(panel);
                                    });
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"An error occurred: {ex.Message}");
                                }
                            }

                        }
                    }
                }
            }
        }

        // send data function
        private void SendMessage(datasending data)
        {
            string jsonString = JsonSerializer.Serialize(data);
            byte[] sendData = Encoding.UTF8.GetBytes(jsonString);
            if (client != null && clientdevice.Connected)
            {
                clientdevice.Send(sendData);
            }

        }



        // button to open profile
        private void guna2Button1_Click(object sender, EventArgs e)
        {

            check = 1;
            loadfunction();
            // clear all data in chat box
        }
        // button to open forum chat
        private void guna2Button4_Click(object sender, EventArgs e)
        {

            check = 3;
            loadfunction();
            // clear all data in chat box
        }
        // button to open chat private
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            check = 2;
            loadfunction();
            // clear all data in chat box
        }


        private async void loadfunction()
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }

            FirebaseResponse response = await client.GetTaskAsync("Users/" + Currentuser);
            Data obj = response.ResultAs<Data>();
            if (check != lastcheck)
            {
                if (check == 0)
                {
                    lastcheck = 0;
                    if (checkfirstime)
                    {
                        check = 1;


                    }
                    else
                    {
                        check = 3;
                    }
                }


                if (check == 1) // profile load
                {
                    lastcheck = 1;
                    // load UI
                    guna2CustomGradientPanel1.Show();
                    guna2CustomGradientPanel2.Hide();
                    guna2CustomGradientPanel3.Hide();
                    guna2Button1.Enabled = false;
                    guna2Button4.Enabled = true;
                    guna2Button3.Enabled = true;
                    guna2Button1.BackColor = Color.FromArgb(128, 128, 255);
                    guna2Button3.BackColor = Color.Transparent;
                    guna2Button4.BackColor = Color.Transparent;
                    guna2Button8.BackColor = Color.Transparent;
                    //  load data
                    if (string.IsNullOrEmpty(obj.image))
                    {
                        byte[] image = Convert.FromBase64String(obj.image);
                        MemoryStream ms = new MemoryStream();
                        ms.Write(image, 0, Convert.ToInt32(image.Length));
                        Bitmap bm = new Bitmap(ms, false);
                        ms.Dispose();
                        Userimage.Image = bm;
                    }




                    UserName.Text = obj.name;
                    Email.Text = obj.email;
                    Phone.Text = obj.phone;
                    Desc.Text = obj.desc;
                    Sex.Text = obj.sex;
                    checkverify = obj.verified;

                    FirebaseResponse firebaseResponse3 = await client.GetTaskAsync("Users/" + Currentuser);
                    Data data3 = firebaseResponse3.ResultAs<Data>();
                    var data = new Data
                    {
                        image = data3.image,
                        name = UserName.Text,
                        email = Email.Text,
                        phone = Phone.Text,
                        desc = Desc.Text,
                        sex = Sex.Text,
                        Username = data3.Username,
                        Password = data3.Password,
                        Userid = data3.Userid,
                        firstime = false,
                        verified = data3.verified
                    };
                    FirebaseResponse response2 = await client.UpdateTaskAsync("Users/" + Currentuser, data);
                    if (checkverify == true)
                    {
                        verifybtn.Hide();
                    }
                    else
                    {
                        verifybtn.Show();
                    }

                }
                else if (check == 2)  // private chat load
                {
                    lastcheck = 2;
                    // load UI
                    guna2CustomGradientPanel1.Show();
                    guna2CustomGradientPanel2.Show();
                    guna2CustomGradientPanel3.Hide();

                    guna2Button3.Enabled = false;
                    guna2Button4.Enabled = true;
                    guna2Button1.Enabled = true;
                    guna2Button3.BackColor = Color.FromArgb(128, 128, 255);
                    guna2Button1.BackColor = Color.Transparent;
                    guna2Button4.BackColor = Color.Transparent;
                    guna2Button8.BackColor = Color.Transparent;

                    // load data
                    LoadData();
                    User.Text = obj.name;
                    Username = obj.name;
                    userlist.ColumnHeadersVisible = false;
                    userlist.CellBorderStyle = DataGridViewCellBorderStyle.None;
                    userlist.GridColor = userlist.BackgroundColor;
                    userlist.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                    userlist.RowTemplate.Height = 50;
                    userlist.AllowUserToResizeRows = false;
                    userlist.ClearSelection();
                    userlist.DefaultCellStyle.SelectionBackColor = Color.White;
                    datasending data = new datasending(Currentuser, false);
                    SendMessage(data);
                }
                else if (check == 3) // forum chat load
                {
                    lastcheck = 3;
                    // load UI
                    guna2CustomGradientPanel1.Show();
                    guna2CustomGradientPanel2.Show();
                    guna2CustomGradientPanel3.Show();

                    guna2Button4.Enabled = false;
                    guna2Button1.Enabled = true;
                    guna2Button3.Enabled = true;
                    guna2Button4.BackColor = Color.FromArgb(128, 128, 255);
                    guna2Button3.BackColor = Color.Transparent;
                    guna2Button1.BackColor = Color.Transparent;
                    guna2Button8.BackColor = Color.Transparent;

                    datasending datasending = new datasending(Currentuser, "All", true, true);
                    SendMessage(datasending);
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddEmojisToList();
            var emojiPicker = new EmojiPickerForm(Smiles);

            emojiPicker.EmojiSelected += EmojiPicker_EmojiSelected;

            emojiPicker.Show();
        }

        private void EmojiPicker_EmojiSelected(object sender, string e)
        {
            guna2TextBox1.Text += e + " ";
        }







        //.............................................................................................................................
    }
}
