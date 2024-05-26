﻿using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NT106_project
{
    public partial class profilepage : Form
    {
        bool checkchangepw;
        bool checksave;
        bool checkverify;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        string Currentuser;
        public profilepage(string UserID)
        {
            InitializeComponent();
            Currentuser = UserID;
        }

        private async void profile_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            FirebaseResponse response = await client.GetTaskAsync("Users/" + Currentuser);
            Data obj = response.ResultAs<Data>();
            Userimage.ImageLocation = "";
            UserName.Text = obj.name;
            Email.Text = obj.email;
            Phone.Text = obj.phone;
            Desc.Text = obj.desc;
            Sex.Text = obj.sex;
            checkverify = obj.verified;


            if (checkverify == true)
            {
                verifybtn.Hide();
            }
            else
            {
                verifybtn.Show();
            }
        }

        private async void savebtn_Click(object sender, EventArgs e)
        {   
            FirebaseResponse response3 = await client.GetTaskAsync("Users/" + Currentuser);
            Data obj3 = response3.ResultAs<Data>();
            var data = new Data
            {
                name = UserName.Text,
                email = Email.Text,
                phone = Phone.Text,
                desc = Desc.Text,
                sex = Sex.Text,
                Username = obj3.Username,
                Password = obj3.Password,
                Userid = obj3.Userid,
                firstime = false,
                verified = obj3.verified
            };
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(Email.Text))
            {
                if (string.IsNullOrEmpty(UserName.Text))
                {
                    UserName.Text = "Please provide Username!";
                    UserName.BorderColor = System.Drawing.Color.Red;
                }
                if (string.IsNullOrEmpty(Email.Text))
                {
                    Email.Text = "Please provide Email!";
                    Email.BorderColor = System.Drawing.Color.Red;
                }
                checksave = false;
            }
            else
            {
                if (checkverify != true)
                {
                    MessageBox.Show("Please verify your email first!");
                }
                else
                {
                    checksave = true;
                }
            }
            if (checksave == true)
            {
                FirebaseResponse response = await client.UpdateTaskAsync("Users/" + Currentuser, data);
                MessageBox.Show("Data Updated Successfully");
            }

        }

        private async void changepasswordbtn_Click(object sender, EventArgs e)
        {
            if (checkverify != true)
            {
                MessageBox.Show("Please verify your email first!");
            }
            else
            {
                if (string.IsNullOrEmpty(Current_Password.Text) || string.IsNullOrEmpty(New_Password.Text))
                {
                    if (string.IsNullOrEmpty(Current_Password.Text))
                    {
                        Current_Password.Text = "Please provide Current Password!";
                        Current_Password.BorderColor = System.Drawing.Color.Red;
                    }
                    if (string.IsNullOrEmpty(New_Password.Text))
                    {
                        New_Password.Text = "Please provide New Password!";
                        New_Password.BorderColor = System.Drawing.Color.Red;
                    }
                    checkchangepw = false;
                }
                else
                {
                    if (Current_Password.Text == New_Password.Text)
                    {
                        New_Password.Text = "Your new password is as same as current password!";
                        New_Password.BorderColor = System.Drawing.Color.Red;
                        checkchangepw = false;
                    }
                    else
                    {
                        checkchangepw = true;
                    }
                }
            }
            if (checkchangepw == true)
            {
                FirebaseResponse response = await client.GetTaskAsync("Users/" + Currentuser);
                Data obj2 = response.ResultAs<Data>();
                Data changepw = new Data();
                changepw.Userid = obj2.Userid;
                changepw.Password = New_Password.Text;
                changepw.firstime = false;
                changepw.verified = true;
                changepw.name =  obj2.name;
                changepw.email = obj2.email;
                changepw.phone = obj2.phone;
                changepw.desc = obj2.desc;
                changepw.sex = obj2.sex;
                changepw.Username = obj2.Username;
                FirebaseResponse response2 = await client.UpdateTaskAsync("Users/" + Currentuser, changepw);
                MessageBox.Show("Data Updated Successfully");
            }
        }

        private void verifybtn_Click(object sender, EventArgs e)
        {
            verifyemailpage verifyemailpage = new verifyemailpage(Currentuser);
            verifyemailpage.Show();
            this.Hide();
        }
    }
}
