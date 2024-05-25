using SaaUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database;
using Firebase.Database.Query;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using FireSharp;
using Firebase.Auth;


namespace NT106_project
{
    
    public partial class newUIloginsiguppage1 : Form
    {
        bool a;
        string b;
        private int  checkreg = 0;
        private int checklog = 0;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        public newUIloginsiguppage1()
        {
            InitializeComponent();
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
        }
        private void showlogin()
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = true;
            guna2CustomGradientPanel3.Visible = false;
            guna2CustomGradientPanel4.Visible = false;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 2);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 0);
        }
        private void showSignup()
        {
            guna2CustomGradientPanel1.Visible = true;
            guna2CustomGradientPanel2.Visible = false;
            guna2CustomGradientPanel3.Visible = true;
            guna2CustomGradientPanel4.Visible = true;
            guna2Button2.CustomBorderThickness = new Padding(0, 0, 0, 0);
            guna2Button1.CustomBorderThickness = new Padding(0, 0, 0, 2);
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            showlogin();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
           showSignup();
        }

        public async Task<bool> IsUserRegisteredAsync(string Username)
        {
            Firebase.Database.FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");
            var users = await firebaseClient
                .Child("Users")
                .OrderBy("Username")
                .EqualTo(Username)
                .OnceAsync<Data>();
                
            return users.Any();
        }

        private async void guna2Button3_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Userid = tbEmailSign.Text + "_id",
                Username = tbEmailSign.Text,
                Password = tbPassSign.Text,
                name = "User",
                email = Email.Text,
                phone = "",
                desc = "",
                firstime = true,
                verified = false,
            };
            // Đăng ký
            if (string.IsNullOrEmpty(tbEmailSign.Text) || string.IsNullOrEmpty(tbPassSign.Text) || string.IsNullOrEmpty(tbPassConfirmSign.Text) || string.IsNullOrEmpty(Email.Text))
            {
                if (string.IsNullOrEmpty(tbEmailSign.Text))
                {
                    tbEmailSign.Text = "Please provide Username!";
                    tbEmailSign.BorderColor = System.Drawing.Color.Red;
                } 
                if (string.IsNullOrEmpty(tbPassSign.Text))
                {
                    tbPassSign.BorderColor = Color.Red;
                    tbPassSign.Text = "Please provide password!";
                }
                if (string.IsNullOrEmpty(tbPassConfirmSign.Text))
                {
                    tbPassConfirmSign.BorderColor = Color.Red;
                    tbPassConfirmSign.Text = "Please provide confirm password!";
                }
                if (string.IsNullOrEmpty(Email.Text))
                {
                    Email.BorderColor = Color.Red;
                    Email.Text = "Please provide email!";
                }
                checkreg = 1;
                return;
            }
            else
            {
                if ((tbPassSign.Text != tbPassConfirmSign.Text) && tbPassConfirmSign.Text != null)
                {
                    tbPassSign.BorderColor = Color.Red;
                    tbPassSign.Text = "Confirm password and password are not the same";
                    tbPassConfirmSign.BorderColor = Color.Red;
                    tbPassConfirmSign.Text = "Confirm password and password are not the same";
                    checkreg = 1;
                    return;
                }
                else
                {   
                    bool checksame = await IsUserRegisteredAsync(tbEmailSign.Text);
                    if( checksame)
                    {
                        checkreg = 1;
                        tbEmailSign.BorderColor = Color.Red;
                        tbEmailSign.Text = "Username is not available";
                        tbPassSign.Clear();
                        tbPassConfirmSign.Clear();
                    }
                    else checkreg = 0;
                }
            }
            if (checkreg == 0)
            {
                SetResponse response = await client.SetTaskAsync("Users/" + tbEmailSign.Text + "_id", data);
                Data result = response.ResultAs<Data>();
                tbEmailSign.Clear();
                tbPassSign.Clear();
                tbPassConfirmSign.Clear();
                MessageBox.Show("Sign Up Success"); // make notice for success
                showlogin();

            }
        }
        private async void btLogin_Click(object sender, EventArgs e)
        {
            bool checkfirsttime;
            string User_id;
            // Đăng nhập
            if (string.IsNullOrEmpty(tbEmaillog.Text) || string.IsNullOrEmpty(tbPasslog.Text))
            {
                if (string.IsNullOrEmpty(tbEmaillog.Text))
                {
                    tbEmaillog.BorderColor = Color.Red;
                    tbEmaillog.Text = "please provide username";
                }
                if (string.IsNullOrEmpty(tbPasslog.Text))
                {
                    tbPasslog.BorderColor = Color.Red;
                    tbPasslog.Text = "please provide password";
                }
                checklog = 1;
            }
            else 
            {
                bool checkexist = await IsUserRegisteredAsync(tbEmaillog.Text);
                if (!checkexist)
                {
                    checklog = 1;
                    tbEmaillog.BorderColor = Color.Red;
                    tbEmaillog.Text = "Username is not existed";
                    tbPasslog.BorderColor = Color.Red;
                    tbPasslog.Text = "";
                }
                else
                {
                    FirebaseResponse response = await client.GetTaskAsync("Users/" + tbEmaillog.Text + "_id");
                    Data obj = response.ResultAs<Data>();
                    Data get = new Data();
                    get.Userid = obj.Userid;
                    get.Username = obj.Username;
                    get.Password = obj.Password;
                    get.email = obj.email;
                    get.phone = obj.phone;
                    get.desc = obj.desc;
                    a = obj.firstime;
                    b= obj.Userid;
                    if (tbPasslog.Text != get.Password)
                    {
                        tbEmaillog.BorderColor = Color.Red;
                        tbEmaillog.Text = "Username or Password is incorrect";
                        tbPasslog.BorderColor = Color.Red;
                        tbPasslog.Text = "Username or Password is incorrect";
                        checklog = 1;
                    }
                    else { checklog = 0; }
                }
            } 
            if ( checklog == 0 )
            {   
                MessageBox.Show("Login successfull");  // make notice for success
                // rt to home page ( forum chat page only if first time != false )
                // else rt to profile page
                // 
                if (a == true)
                {   
                    // rt to profile page
                    profilepage profile = new profilepage(b);
                    profile.Show();
                    this.Hide();
                }
            }
            
        }

        private void tbEmailSign_Click(object sender, EventArgs e)
        {
            if (tbEmailSign.Text == "Please provide Username")
            {
                tbEmailSign.BorderColor = Color.White;
                tbEmailSign.Clear();
            }
        }

        private void tbPassSign_Click(object sender, EventArgs e)
        {
            if (tbPassSign.Text == "Please provide password!" || tbPassSign.Text == "Confirm password and password are not the same")
            {
                tbPassSign.BorderColor = Color.White;
                tbPassSign.Clear();
            }
        }
        private void tbPassConfirmSign_Click(object sender, EventArgs e)
        {
            if (tbPassConfirmSign.Text == "Please provide confirm password!" || tbPassConfirmSign.Text == "Confirm password and password are not the same")
            {
                tbPassConfirmSign.BorderColor = Color.White;
                tbPassConfirmSign.Clear();
            }
        }
        private void tbEmaillog_Click(object sender, EventArgs e)
        {
            if (tbEmaillog.Text == "please provide username")
            {
                tbEmaillog.BorderColor = Color.White;
                tbEmaillog.Clear();
            }
        }
        private void tbPasslog_Click(object sender, EventArgs e)
        {
            if (tbPasslog.Text == "please provide password")
            {
                tbPasslog.BorderColor = Color.White;
                tbPasslog.Clear();
            }
        }

        private void newUIloginsiguppage1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
        }
    }
}
