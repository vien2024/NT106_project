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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace NT106_project
{
    public partial class newUIloginsiguppage1 : Form
    {   
         private int  check = 0;
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
            if (string.IsNullOrEmpty(tbEmailSign.Text) || string.IsNullOrEmpty(tbPassSign.Text) || string.IsNullOrEmpty(tbPassConfirmSign.Text))
            {
                if (string.IsNullOrEmpty(tbEmailSign.Text))
                {
                    tbEmailSign.Text = "Please provide Email!";
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
                check = 1;
                return;
            }
            else
            {
                if ((tbPassSign.Text != tbPassConfirmSign.Text) && tbPassConfirmSign.Text != null)
                {
                    tbPassSign.BorderColor = Color.Red;
                    tbPassSign.Text = " Confirm password and password are not the same";
                    tbPassConfirmSign.BorderColor = Color.Red;
                    tbPassConfirmSign.Text = " Confirm password and password are not the same";
                    check = 1;
                    return;
                }
                else
                {   
                    check =0;
                    
                    var data = new Data
                    {
                        Userid = tbEmailSign.Text + "_id",
                        Username = tbEmailSign.Text,
                        Password = tbPassSign.Text,
                        email = null,
                        phone = null,
                        disc = null,
                    };
                    if (check == 0)
                    {
                        SetResponse response = client.Set("User/" + tbEmailSign.Text + "id", data);
                        Data result = response.ResultAs<Data>();
                        MessageBox.Show("Data inserted successfull " + result.Userid);
                    }
                }


            }
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


        }

        private void tbEmailSign_Click(object sender, EventArgs e)
        {
            tbEmailSign.BorderColor = Color.White;
            tbEmailSign.Text = "";
        }

        private void tbPassSign_Click(object sender, EventArgs e)
        {
            tbPassSign.BorderColor = Color.White;
            tbPassSign.Text = "";
        }
        private void tbPassConfirmSign_Click(object sender, EventArgs e)
        {
            tbPassConfirmSign.BorderColor = Color.White;
            tbPassConfirmSign.Text = "";
        }
       

        private void newUIloginsiguppage1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            else { MessageBox.Show("Connected to the server"); }
        }
    }
}
