using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace NT106_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.BringToFront();
        }
        string constring = "Data Source=LAPTOP-RECNFRML;Initial Catalog=Login;Integrated Security=True;Encrypt=False";
        
        private void btn_supanel_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void btn_lgnpanel_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_lgnpanel.PerformClick();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            // bấm nút đăng nhập
            if (string.IsNullOrEmpty(tbEmailSign.Text.Trim()))
            {
                errorProvider1.SetError(tbEmailSign, "username is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbEmailSign, string.Empty);
            }

            if (string.IsNullOrEmpty(tbPassSign.Text.Trim()))
            {
                errorProvider1.SetError(tbPassSign, "password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbPassSign, string.Empty);
            }

            SqlConnection conn = new SqlConnection(constring);
            string q = "SELECT * FROM Login_info WHERE email='" + tbEmailSign.Text.Trim() + "' AND password= '" + tbPassSign.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(q, conn);
            conn.Open();
            SqlDataReader datareader = cmd.ExecuteReader();
            if (datareader.HasRows == true)
            {
                var account_info = new Account_info();
                this.Hide();
                account_info.emailName = tbEmailSign.Text.Trim();
                account_info.Show();
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            // Bấm nút đăng ký
            if (string.IsNullOrEmpty(tbFirstName.Text.Trim()))
            {
                errorProvider1.SetError(tbFirstName, "firstname is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbFirstName, string.Empty);
            }

            if (string.IsNullOrEmpty(tbLastName.Text.Trim()))
            {
                errorProvider1.SetError(tbLastName, "last name is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbLastName, string.Empty);
            }

            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                errorProvider1.SetError(tbPassword, "password is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbPassword, string.Empty);
            }

            if (string.IsNullOrEmpty(tbEmail.Text.Trim()))
            {
                errorProvider1.SetError(tbEmail, "firstname is required");
                return;
            }
            else
            {
                errorProvider1.SetError(tbEmail, string.Empty);
            }

            SqlConnection conn = new SqlConnection(constring);
            string q = "INSERT INTO Login_info(firstname, lastname, password, email)values(@firstname,@lastname,@password,@email)";
            SqlCommand cmd = new SqlCommand(q, conn);
            cmd.Parameters.AddWithValue("firstname", tbFirstName.Text);
            cmd.Parameters.AddWithValue("lastname", tbLastName.Text);
            cmd.Parameters.AddWithValue("password", tbPassword.Text);
            cmd.Parameters.AddWithValue("email", tbEmail.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Register successfully");
            tbFirstName.Clear();
            tbLastName.Clear();
            tbPassword.Clear();
            tbEmail.Clear();
        }
    }
}
