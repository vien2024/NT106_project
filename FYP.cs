using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace NT106_project
{
    public partial class FYP : Form
    {
        string constring = "Data Source=DESKTOP-02P9IUP;Initial Catalog=LOGIN;Integrated Security=True;Encrypt=False";
        Random rnd = new Random();
        public int OTP;
        public DateTime timestamp;
        public FYP()
        {
            InitializeComponent();
        }

        private void bt_sendemail_Click(object sender, EventArgs e)
        {
            OTP = rnd.Next(123123, 999999);
            const string p = "jpwk hbbp tmta xnnb\r\n";
            timestamp = DateTime.Now;

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();

            message.From = new MailAddress("rapdizz185@gmail.com");
            message.To.Add(new MailAddress(tbEmailotp.Text.ToString().Trim()));
            message.Subject = "OTP Verification";
            message.Body = "Write this given OTP on text box\n" + OTP + "\nThank you!";

            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("rapdizz185@gmail.com", p);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(message);
            MessageBox.Show("Email has been sent");

        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if ((DateTime.Now - timestamp).TotalSeconds > 30)
            {

                MessageBox.Show("OTP has expired!");
            }
            else if (tbOTP.Text == OTP.ToString())
            {
                guna2CustomGradientPanel1.Visible = false;
                MessageBox.Show("Success!");
            }
            else
            {
                MessageBox.Show("Invalid OTP!");
            }
        }

        private void btn_showpw_Click(object sender, EventArgs e)
        {
            if (newpw.PasswordChar == '●')
            {
                btn_hidepw.BringToFront();
                newpw.PasswordChar = '\0';
            }
        }

        private void btn_showcf_Click(object sender, EventArgs e)
        {
            if (newpwcf.PasswordChar == '●')
            {
                btn_hidecf.BringToFront();
                newpwcf.PasswordChar = '\0';
            }
        }

        private void btn_hidepw_Click(object sender, EventArgs e)
        {
            if (newpw.PasswordChar == '\0')
            {
                btn_showpw.BringToFront();
                newpw.PasswordChar = '●';
            }
        }

        private void btn_hidecf_Click(object sender, EventArgs e)
        {
            if (newpwcf.PasswordChar == '\0')
            {
                btn_showcf.BringToFront();
                newpwcf.PasswordChar = '●';
            }
        }

        private void btn_submitpw_Click(object sender, EventArgs e)
        {
            if (newpw.Text == newpwcf.Text)
            {
                SqlConnection conn = new SqlConnection(constring);
                string q = "UPDATE Login_info SET password = '" + newpw.Text + "' WHERE email = '" + tbEmailotp.Text + "'";
                SqlCommand cmd = new SqlCommand(q, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Change password successfully!");
                Close();
            }
            else
            {
                MessageBox.Show("Password doesn't match!");
            }
        }
    }
}
