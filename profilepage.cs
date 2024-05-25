using FireSharp.Config;
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

namespace NT106_project
{
    public partial class profilepage : Form
    {
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        String Currentuser; 
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
        }
    }
}
