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
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp;
using Firebase.Database;
using Firebase.Database.Query;
using System.Net;



namespace NT106_project
{
    public partial class Privatechat : Form
    {
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;
        string name;
        string currentuser;
        public Privatechat(string UserID)
        {
            InitializeComponent();
            currentuser = UserID;
            
        }

        private async void Privatechat_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            LoadData();

            FirebaseResponse response = await client.GetTaskAsync("Users/" + currentuser);
            Data obj = response.ResultAs<Data>();
            User.Text = obj.name;

        }
       
       
        private async void LoadData()
        {
            await LoadDataIntoDataGridView();
        }
        private async Task LoadDataIntoDataGridView()
        {
            var names = await GetNamesFromFirebaseAsync();
            // Ensure we update the DataGridView on the UI thread
            if (userlist.InvokeRequired)
            {
                userlist.Invoke(new Action(() =>
                {
                    userlist.DataSource = names.Select(name => new { Name = name }).ToList();
                }));
            }
            else
            {
                userlist.DataSource = names.Select(name => new { Name = name }).ToList();
            }
        }
        private async Task<List<string>> GetNamesFromFirebaseAsync()
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Users") // Replace with your data node in Firebase
                .OnceAsync<Data>();

            // Extract the names from the data
            return data.Select(item => item.Object.name).ToList();
        }

    }
}
