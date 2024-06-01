using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Collections.Specialized;



namespace NT106_project
{
    public partial class Privatechat : Form
    {

        IPEndPoint ipe;
        TcpClient tcpclient;
        Stream stream;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        string Username;
        string currentuser;
        public Privatechat(string UserID)
        {
            InitializeComponent();
            currentuser = UserID;
            userlist.ClearSelection();
            Connect();
            Thread.Sleep(5);
            byte[] data = Encoding.UTF32.GetBytes(UserID);
            stream.Write(data, 0, data.Length);
            stream.Flush();

        }

        private async void Privatechat_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            LoadData();

            FirebaseResponse response = await client.GetTaskAsync("Users/" + currentuser);
            Data obj = response.ResultAs<Data>();
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
           
        }


        private async void LoadData()
        {
            await LoadDataIntoDataGridView();
        }
        // tìm tên ()
        private async Task LoadDataIntoDataGridView()
        {
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
        private async Task<List<string>> GetNamesFromFirebaseAsync()
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Users") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Extract the names from the data
            return data.Where(item => item.Object.name != Username).Select(item => item.Object.name).ToList();
        }

        // 
        private void userlist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var cellValue = userlist.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            // notice.Hide();
            chater.Text = cellValue.ToString();
        }

        void Connect()
        {
            ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            tcpclient = new TcpClient();
            tcpclient.Connect(ipe);
            stream = tcpclient.GetStream();
            Thread recv = new Thread(Receive);
            recv.IsBackground = true;
            recv.Start();
        }
        private async void Receive()
        {
            while (true)
            {
                byte[] recv = new byte[2048];
                stream.Read(recv, 0, recv.Length);
                string s = Encoding.UTF32.GetString(recv);
                if (s == "You have not connected to anyone yet" || s == "You have connected to all users")
                {
                    //notice.show();
                }
                else
                {   
                    //notice.hide();
                    FirebaseResponse response = await client.GetTaskAsync("User_connect/" + currentuser);
                    User_connect obj = response.ResultAs<User_connect>();
                    string a = obj.Lastconnected;
                    FirebaseResponse response1 = await client.GetTaskAsync("Users/" + a);
                    Data obj1 = response1.ResultAs<Data>();
                    chater.Text = obj1.name;
                    SelectCellWithStringA(userlist, obj1.name);
                    reviewchatbox.Items.Add(new ListViewItem(s));
                }
            }
        }
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
    }
}
