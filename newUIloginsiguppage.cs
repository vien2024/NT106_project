using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT106_project
{
    public partial class newUIloginsiguppage : Form
    {
        string constring = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;Encrypt=False";
        public newUIloginsiguppage()
        {
            InitializeComponent();
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 2);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 0);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = false;
            guna2CustomGradientPanel3.Visible = true;
            guna2CustomGradientPanel4.Visible = true;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 0);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 2);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            // Đăng ký
            if (string.IsNullOrEmpty(tbEmailSign.Text.Trim()))
            {
                MessageBox.Show("Please provide Email!");
                return;

            }

            if (string.IsNullOrEmpty(tbPassSign.Text.Trim()))
            {
                MessageBox.Show("Please provide password!");
                return;
            }


            if (string.IsNullOrEmpty(tbPassConfirmSign.Text.Trim()))
            {
                MessageBox.Show("Please provide confirm password!");
                return;
            }

            if (tbPassSign.Text.Trim() != tbPassConfirmSign.Text.Trim())
            {
                MessageBox.Show("Confirm password does not equal to password!");
                return;
            }


            SqlConnection conn = new SqlConnection(constring);

            // Check if email already has account
            string t = "SELECT * FROM Login_info WHERE email='" + tbEmailSign.Text.Trim() + "'";
            SqlCommand check_cmd = new SqlCommand(t, conn);
            conn.Open();
            SqlDataReader datareader = check_cmd.ExecuteReader();
            if (datareader.HasRows == true)
            {
                MessageBox.Show("Email already has account");
                return;
            }
            conn.Close();
            string q = "INSERT INTO Login_info(password, email)values(@password,@email)";
            SqlCommand cmd = new SqlCommand(q, conn);
            conn.Open();
            cmd.Parameters.AddWithValue("password", tbPassConfirmSign.Text);
            cmd.Parameters.AddWithValue("email", tbEmailSign.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Register successfully");
            tbEmailSign.Clear();
            tbPassConfirmSign.Clear();
            tbPassSign.Clear();
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            // Đăng nhập
            if (string.IsNullOrEmpty(tbEmaillog.Text.Trim()))
            {
                MessageBox.Show("Please provide email");
                return;
            }

            if (string.IsNullOrEmpty(tbPasslog.Text.Trim()))
            {
                MessageBox.Show("Please provide password");
                return;
            }

            SqlConnection conn = new SqlConnection(constring);
            string q = "SELECT * FROM Login_info WHERE email='" + tbEmaillog.Text.Trim() + "' AND password= '" + tbPasslog.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            conn.Open();
            SqlDataReader datareader = cmd.ExecuteReader();
            if (datareader.HasRows == true)
            {
                var chat_ui = new Form3(tbEmaillog.Text.Trim());
                this.Hide();
                //MessageBox.Show(chat_ui.emailName);
                chat_ui.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}
