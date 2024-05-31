using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NT106_project
{
    public partial class Form3 : Form
    {

        IPEndPoint ipe;
        TcpClient tcpclient;
        Stream stream;
        public string emailName { get; set; }
        public Form3(string email)
        {
            InitializeComponent();
            chatbox.Visible = true;
            Menubox.Visible = true;
            profilebox.Visible = false;
            Control.CheckForIllegalCrossThreadCalls = false;
            this.emailName = email;
            Connect();
            Thread.Sleep(5);
            
            
            //
            byte[] data = Encoding.UTF32.GetBytes("username:" + emailName);
            stream.Write(data, 0, data.Length);
            //


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Menubox.Visible = true;
            profilebox.Visible = true;
            guna2Button1.ShadowDecoration.Enabled = true;
            guna2Button2.ShadowDecoration.Enabled = false;
            guna2Button3.ShadowDecoration.Enabled = false;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Menubox.Visible = true;
            profilebox.Visible = false;
            chatbox.Visible = true;
            guna2Button3.ShadowDecoration.Enabled = true;
            guna2Button1.ShadowDecoration.Enabled = false;
            guna2Button2.ShadowDecoration.Enabled = false;
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Người nhận
        string receiver = "none";
        private void btForumChat_Click(object sender, EventArgs e)
        {
            receiver = "all";
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

        void Send()
        {
            byte[] data_buf = new byte[1024];
            data_buf = Encoding.UTF32.GetBytes( receiver + "] " +emailName+ ": " + tbMess.Text);
            stream.Write(data_buf, 0, data_buf.Length);
            AddMessage("You: "+tbMess.Text);
        }

        void Receive()
        {
            while (true)
            {
                byte[] recv = new byte[2048];
                stream.Read(recv, 0, recv.Length);
                string s = Encoding.UTF32.GetString(recv);
                AddMessage(s);
            }
        }

        void AddMessage(string mess)
        {
            lvMess.Items.Add(new ListViewItem(new string[] { mess }));
        }

        private void SendBut_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
