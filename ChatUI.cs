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
using System.Data.SqlClient;

namespace NT106_project
{
    public partial class ChatUI : Form
    {
        IPEndPoint ipe;
        TcpClient tcpclient;
        Stream stream;
        public string emailName { get; set; }
        string constring = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;Encrypt=False";
        string chosen;
        public ChatUI()
        {
            InitializeComponent();
            MessageBox.Show(emailName);
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (pnUserprofile.Visible == false)
            {
                pnUserprofile.Visible = true;
            }
            else
            {
                pnUserprofile.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SettingProfile.Visible == false)
            {
                SettingProfile.Visible = true;
            }
            else
            {
                SettingProfile.Visible = false;
            }

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(constring);
            conn.Open();
            string q = "UPDATE Login_info SET password=@pass, firstname=@first, confirmpass=@confirm, lastname=@last WHERE email=@email_info";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("@first", tbSetFirst.Text);
            cmd.Parameters.AddWithValue("@last", tbSetLast.Text);
            cmd.Parameters.AddWithValue("@pass", tbSetpass.Text);
            cmd.Parameters.AddWithValue("@email_info", lbEmailname.Text);
            cmd.Parameters.AddWithValue("@confirm", tbSetpass.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Profile is update");
            showprofile();
        }

        public void showprofile()
        {
            SqlConnection con = new SqlConnection(constring);
            con.Open();
            string q = "SELECT * FROM Login_info WHERE email='" + lbEmailname.Text + "'";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();
            if (dataReader.HasRows)
            {
                lbEmailname.Text = dataReader["email"].ToString();
                tbProfileFirst.Text = dataReader["firstname"].ToString();
                tbProfileLast.Text = dataReader["lastname"].ToString();
                tbProfileEmail.Text = dataReader["email"].ToString();
                tbProfilePass.Text = dataReader["password"].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panelChat.Visible == false)
            {
                panelChat.Visible = true;
                Useritem();
            }
            else { panelChat.Visible = false; }
        }

        public void Newchat(object sender, EventArgs e)
        {
            lvMess.Items.Clear();

        }
        private void Useritem()
        {
            flowLayoutPanel1.Controls.Clear();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter("SELECT * FROM Login_info", constring);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table != null)
            {
                if (table.Rows.Count > 0)
                {
                    UserControl1[] userControls = new UserControl1[table.Rows.Count];
                    for (int i = 0; i < 1; i++)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            userControls[i] = new UserControl1();
                            userControls[i].Title = row["firstname"].ToString();
                            if (userControls[i].Title == lbEmailname.Text)
                            {
                                flowLayoutPanel1.Controls.Remove(userControls[i]);
                            }
                            else
                            {
                                flowLayoutPanel1.Controls.Add(userControls[i]);
                                userControls[i].Click += new System.EventHandler(this.Newchat);
                            }

                        }
                    }
                }
            }
        }

        void Connect()
        {
            ipe = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            tcpclient = new TcpClient();
            tcpclient.Connect(ipe);
            stream = tcpclient.GetStream();
            Thread recv = new Thread(Receive);
            recv.IsBackground = true;
            recv.Start();
        }

        void Send()
        {
            byte[] data = Encoding.UTF8.GetBytes(tbMess.Text);
            stream.Write(data, 0, data.Length);
            AddMessage(tbMess.Text);
        }

        void Receive()
        {
            while (true)
            {
                byte[] recv = new byte[1024];
                stream.Read(recv, 0, recv.Length);
                string s = Encoding.UTF8.GetString(recv);
                AddMessage(s);
            }
        }

        void AddMessage(string mess)
        {
            lvMess.Items.Add(new ListViewItem() { Text = mess });

        }


        private void button5_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
