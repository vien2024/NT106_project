using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System;
using System.Timers;


namespace NT106_project
{
    public partial class verifyemailpage : Form
    {
        private static Random random = new Random();
        private static System.Timers.Timer timer;
        int Vcode;
        string currentuser;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        public verifyemailpage(string User_id)
        {
            InitializeComponent();
            currentuser = User_id;
        }

        private async void verifyemailpage_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            try
            {
                FirebaseResponse response = await client.GetTaskAsync("Users/" + currentuser);
                Data obj = response.ResultAs<Data>();
                Your_email.Text = obj.email;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
            GenerateVerificationCode();
            timer = new System.Timers.Timer(60000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;

        }
       
        private  void GenerateVerificationCode()
        {
           Vcode = random.Next(1000, 10000);
        }
        private  void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GenerateVerificationCode();
        }
        private void senbtn_Click(object sender, EventArgs e)
        {   
            
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
                MessageBox.Show("verification code sent successfull","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                verified_code.Enabled = true;
                confirmbtn.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void confirmbtn_Click(object sender, EventArgs e)
        {
            if (verified_code.Text == Vcode.ToString())
            {   
                FirebaseResponse response = await client.GetTaskAsync("Users/" + currentuser);
                Data obj2 = response.ResultAs<Data>();
                Data verifycode = new Data
                {   
                    Userid = obj2.Userid,
                    Username = obj2.Username,
                    Password = obj2.Password,
                    phone = obj2.phone,
                    email = obj2.email,
                    desc = obj2.desc,
                    name = obj2.name,
                    firstime = obj2.firstime,
                    verified = true,
                };
                FirebaseResponse response1 = await client.UpdateTaskAsync("Users/" + currentuser, verifycode);
                MessageBox.Show("Verification successfull", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                profilepage profile = new profilepage(currentuser);
                profile.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Verification code is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
