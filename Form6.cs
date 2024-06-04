using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace NT106_project
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private string Userid;
        private static Random random = new Random();
        private static System.Timers.Timer timer;
        int Vcode;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;

        private void GenerateVerificationCode()
        {
            Vcode = random.Next(1000, 10000);
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GenerateVerificationCode();
        }
        private async void senbtn_Click(object sender, EventArgs e)
        {
            bool a = await IsUserExistAsync(Your_email.Text, tbUsername.Text);
            if (a)
            {
                Userid = await GetUseridFromFirebaseAsync(Your_email.Text, tbUsername.Text);
                verified_code.Visible = true;
                lbVerify.Visible = true;
                confirmbtn.Visible = true;
                // Gửi verify code
                string to, from, pass, mail;
                to = Your_email.Text;
                from = "duyga1235789@gmail.com";
                mail = Vcode.ToString();
                pass = "msmz jwjf mxyz wnna";
                MailMessage message = new MailMessage();
                message.To.Add(to);
                message.From = new MailAddress(from);
                message.Body = mail;
                message.Subject = "Verification Code";
                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
                try
                {
                    smtp.Send(message);
                    MessageBox.Show("verification code sent successfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    verified_code.Enabled = true;
                    confirmbtn.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Username or Email do not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private async Task<bool> IsUserExistAsync(string email, string User)
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("User") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Check if there is a FileLogdatabase object that matches User1 and User2
            return data.Any(item => item.Object.email == email && item.Object.Username == User);
        }

        private async void confirmbtn_Click(object sender, EventArgs e)
        {
            if (verified_code.Text == Vcode.ToString())
            {
                // Hiện nhập password mới
                new_pass_label.Visible = true;
                Newpass_again.Visible = true;
                tbPassword.Visible = true;
                tbPassagain.Visible = true;
                btChangePass.Visible = true;


            }
            else
            {
                MessageBox.Show("Verification code is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async Task<string> GetUseridFromFirebaseAsync(string email, string Username)
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Users") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Find the first FileLogdatabase object that matches User1 and User2 and return its Name
            var User = data.FirstOrDefault(item => item.Object.email == email && item.Object.Username == Username)?.Object;

            return User?.Userid;
        }
        private async void btChangePass_Click(object sender, EventArgs e)
        {
            if (tbPassword.Text == tbPassagain.Text)
            {
                FirebaseResponse response = await client.GetTaskAsync("Users/" + Userid);
                Data obj = response.ResultAs<Data>();
                Data get = new Data();
                get.Userid = obj.Userid;
                get.Username = obj.Username;
                get.Password = tbPassagain.Text;
                get.email = obj.email;
                get.phone = obj.phone;
                get.desc = obj.desc;
                get.firstime = obj.firstime;
                get.image = obj.image;
                get.name = obj.name;
                get.verified = obj.verified;
                get.sex = obj.sex;

                FirebaseResponse update_response = await client.UpdateTaskAsync("Users/" + Userid, get);
                MessageBox.Show("Update sucess!!");
            }
        }

        private async void Form6_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            GenerateVerificationCode();
            timer = new System.Timers.Timer(60000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            new_pass_label.Visible = false;
            Newpass_again.Visible = false;
            tbPassagain.Visible = false;
            tbPassword.Visible = false;
            btChangePass.Visible = false;
        }
    }
}
