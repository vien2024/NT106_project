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
using Firebase.Database;
using Firebase.Database.Query;





namespace NT106_project
{
    public partial class Form4 : Form
    {
        private static Random random = new Random();
        int Vcode;
        string fileName;
        string filePath;
        bool checkedcreate = false;
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "kHKs9ZwngaoM2odQCgyLjDzG7sF0JVQzNEf1IA1N",
            BasePath = "https://appchatdizz-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;

        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {

            client = new FireSharp.FirebaseClient(ifc);

            if (client == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            else { MessageBox.Show("Connected to the server"); }
           
        }

        private async void guna2Button1_Click(object sender, EventArgs e)
        {
            createfile();
            if (checkedcreate)
            {
                guna2TextBox1.Text = filePath;
                guna2TextBox3.Text = fileName;
                var FileLogdata = new FileLogdatabase
                {

                    Name = fileName,
                    path = filePath,
                    User1 = "User1",
                    User2 = "User2",
                };

                FirebaseResponse response = await client.SetTaskAsync("Filelog/" + fileName, FileLogdata);
                FileLogdatabase result = response.ResultAs<FileLogdatabase>();

            }
        }
        private void createfile() 
        {
            Generatefileid();
            string folderpath = @"D:\K2-N2\lap_trinh_mang_can_ban\git\filelog";
            string idnumber = Vcode.ToString();
            string fileid = $"filelog{Vcode}.txt";
            fileName = "filelog" + idnumber;
            filePath = Path.Combine(folderpath, fileid);
            
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
                checkedcreate = true;
            }
            else
            {
                fileName = "";
                filePath = "";
                checkedcreate = false;
                createfile();
            }

        }
        private void Generatefileid()
        {
            Vcode = random.Next(1000, 10000);
        }
    }
}
