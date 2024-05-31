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
            string Username;
            TcpClient _socket;
            string connectedfriend;

            // Constructor
            public User_connect(string name1, TcpClient socket, string name2)
            {
                Username = name1;
                _socket = socket;
                connectedfriend = name2;

            }

            public string Myname
            {
                get { return Username; }
                set { Username = value; }
            }

            public TcpClient Mysocket
            {
                get { return _socket; }
                set { _socket = value; }
            }
            public string connected
            {
                get { return connectedfriend; }
                set { connectedfriend = value; }
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
          
            User_connect user_Connect = new User_connect(substrings[0], client, substrings[1]);
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
                if (name.Contains("all"))
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
            lvMess.Items.Add(new ListViewItem("\"" + mess + "\""));
        }

        private void btSend_Click_1(object sender, EventArgs e)
        {
            //Send(client);
        }


        void Private_chat(string[] message_arr)
        {
            // If giá trị thứ 3 = false
           
        }
    }
}