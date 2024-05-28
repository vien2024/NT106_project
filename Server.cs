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
using System.IO;

namespace NT106_project
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        public class User_connect
        {
            // Fields (variables)
            string _name;
            TcpClient _socket;

            // Constructor
            public User_connect(string name, TcpClient socket)
            {
                _name = name;
                _socket = socket;
            }

            public string Myname
            {
                get { return _name; }
                set { _name = value; }
            }

            public TcpClient Mysocket
            {
                get { return _socket; }
                set { _socket = value; }
            }


        }

        IPEndPoint ipe;
        TcpListener tcplisten;
        List<User_connect> myList = new List<User_connect>();


        void Connect()
        {
            IPAddress ipAddress = IPAddress.Any;
            TcpListener server = new TcpListener(ipAddress, 8080);
            server.Start();

            IPEndPoint localEndPoint = (IPEndPoint)server.LocalEndpoint;
            IPAddress serverIpAddress = localEndPoint.Address;
            int serverPort = localEndPoint.Port;
            AddMessage("Server running on " + serverIpAddress.ToString() + ":" + serverPort.ToString());
            Thread listen = new Thread(() =>
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread recv = new Thread(() => Receive(client));
                    recv.IsBackground = true;
                    recv.Start();
                }

            });
            listen.IsBackground = true;
            listen.Start();
        }

        void Send(Socket client)
        {
            byte[] data = Encoding.UTF32.GetBytes(tbMess.Text);
            client.Send(data);
            AddMessage(tbMess.Text);
        }

        void Receive(TcpClient client)
        {
            // Setup to save user
            string message = "";
            string name = "";
            string[] message_arr;
            // Get the name of user connect to
            byte[] recv = new byte[2048];
            NetworkStream stream = client.GetStream();
            NetworkStream ns_temp;
            stream.Read(recv, 0, recv.Length);
            string s = Encoding.UTF32.GetString(recv);
            string[] substrings = s.Split(':');
            User_connect user_Connect = new User_connect(substrings[1], client);
            myList.Add(user_Connect);
            //
            IPAddress clientIpAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
            int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
            AddMessage("New client connected from: " + clientIpAddress.ToString() + ":" + clientPort.ToString());
            // Start recv loop
            while (true)
            {
                // Clear string
                s = "";
                Array.Clear(recv, 0, recv.Length);
                // Start receiving
                stream.Read(recv, 0, recv.Length);
                s = Encoding.UTF32.GetString(recv);
                message_arr = s.Split(']');
                message = message_arr[1];
                name = message_arr[0];
                // Chat all
                if(name.Contains("all"))
                {
                    foreach (User_connect user in myList)
                    {
                        if (((IPEndPoint)user.Mysocket.Client.RemoteEndPoint).Port != clientPort)
                        {
                            ns_temp = user.Mysocket.GetStream();
                            string senderName = substrings[1]; // Rename the variable "sender" to "senderName"
                            string body = message;
                            recv = Encoding.UTF32.GetBytes(message);
                            ns_temp.Write(recv, 0, recv.Length);
                            AddMessage(senderName + ":" + body); // Update the message to include senderName and body
                          
                        }
                    }
                    continue;
                }

                // Private chat
                Private_chat(message_arr);
            }
        }

        void AddMessage(string mess)
        {
            lvMess.Items.Add(new ListViewItem("\""+mess+"\""));
        }

        private void btSend_Click_1(object sender, EventArgs e)
        {
            //Send(client);
        }

        private string Create_log_file(string logfile_name)
        {
            StreamWriter Filelog = new StreamWriter(logfile_name);
            Filelog.Close();
            return logfile_name;
        }

        private void Find_send(string[] message_arr, bool third, string log_chat = "")
        {
            // Nhớ kiểm tra độ dài log_chat
            NetworkStream ns_temp;
            string name = message_arr[1];
            string s;
            byte[] recv = new byte[2048];
            string chat = message_arr[3];
            // Nếu giá trị thứ 3 là false
            if (!third)
            {
                chat = String.Empty;
                chat = log_chat;
            }
            foreach (User_connect user in myList)
            {
                if (user.Myname.Contains(name))
                {
                    ns_temp = user.Mysocket.GetStream();
                    s = message_arr[0] + ":" + chat;
                    recv = Encoding.UTF32.GetBytes(s);
                    ns_temp.Write(recv, 0, recv.Length);
                }
            }
        }

        void Private_chat(string[] message_arr)
        {
            // If giá trị thứ 3 = false
            string logfile_name = "";
            string fileContents;

            if (!bool.Parse(message_arr[2]))
            {
                // Cần hàm check direct xem file log tồn tại
                // Cần return name file log lưu nó ở biến global

                // Read the contents of the file into a string
                using (StreamReader reader = new StreamReader(logfile_name))
                {
                    fileContents = reader.ReadToEnd();
                }
                Find_send(message_arr, false, fileContents);
            }

            else
            {
                using (StreamWriter writer = new StreamWriter(logfile_name, true))
                {
                    writer.WriteLine(logfile_name);
                }
                Find_send(message_arr, true);

            }
        }
    }

}
