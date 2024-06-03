using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Firebase.Database.Query;
using static Guna.UI2.Native.WinApi;
using FireSharp;

namespace NT106_project
{
    public partial class Severtexting : Form
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
        IFirebaseClient firebaseClient;
        public Severtexting()
        {
            InitializeComponent();
        }
        IPEndPoint ipe;
        TcpListener tcplisten;

        // ham ket noi
        void Connect()
        {
            IPAddress ipAddress = IPAddress.Any;
            TcpListener server = new TcpListener(ipAddress, 8080);
            server.Start();

            IPEndPoint localEndPoint = (IPEndPoint)server.LocalEndpoint;
            IPAddress serverIpAddress = localEndPoint.Address;
            int serverPort = localEndPoint.Port;
            // AddMessage("Server running on " + serverIpAddress.ToString() + ":" + serverPort.ToString());
            Thread listen = new Thread(() =>
            {
                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread recv = new Thread(() => Receive(client));
                    recv.IsBackground = true;
                    recv.Start();
                }

            });
            listen.IsBackground = true;
            listen.Start();
        }
        //


        // ham kiem tra xem user da ket noi chua
        public async Task<bool> IsUserConnectedAsync(string Userid)
        {
            Firebase.Database.FirebaseClient firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");
            var users = await firebaseClient
                .Child("User_connect")
                .OrderBy("Userid")
                .EqualTo(Userid)
                .OnceAsync<User_connect>();

            return users.Any();
        }
        //

        // function to check that 2 user have file log or not
        private async Task<bool> IsFileLogExistAsync(string User1, string User2)
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Filelog") // Replace with your data node in Firebase
                .OnceAsync<FileLogdatabase>();

            // Check if there is a FileLogdatabase object that matches User1 and User2
            return data.Any(item => item.Object.User1 == User1 && item.Object.User2 == User2);
        }
        // 



        // ham lay filelogname tu firebase
        private async Task<string> GetFileLogNameFromFirebaseAsync(string User1, string User2)
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("Filelog") // Replace with your data node in Firebase
                .OnceAsync<FileLogdatabase>();

            // Find the first FileLogdatabase object that matches User1 and User2 and return its Name
            var fileLog = data.FirstOrDefault(item => item.Object.User1 == User1 && item.Object.User2 == User2)?.Object;

            return fileLog?.Name;
        }
        //



        // ham tao filelog
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
        ///

        // ham random
        private void Generatefileid()
        {
            Vcode = random.Next(1000, 10000);
        }
        //



        // ham receive
        private async void Receive(TcpClient client)
        {
            string message;
            string Username;
            string[] sendedmess;
            byte[] recv = new byte[2048];
            NetworkStream stream = client.GetStream();
            NetworkStream ns_temp;
            stream.Read(recv, 0, recv.Length);
            string s = Encoding.UTF32.GetString(recv);
            
            //check xem User đã từng kết nối với server chưa
            bool isconnected = await IsUserConnectedAsync(s);
            if (!isconnected)
            {
                // nếu chưa tạo mới
                var Userconnect = new User_connect
                {
                    Userid = s,
                    client = client,
                    Lastconnected = "",
                };
                FirebaseResponse firebaseResponse2 = await firebaseClient.SetTaskAsync("User_connect/" + s, Userconnect);
            }
            else
            {
                // nếu có gửi file log
                // lấy thông tin user
                FirebaseResponse firebaseResponse = await firebaseClient.GetTaskAsync("User_connect/" + s);
                User_connect user = firebaseResponse.ResultAs<User_connect>();
                string User_id = user.Userid;
                string Last_connected = user.Lastconnected;
                if (Last_connected == "")
                {
                    string mess = "You have not connected to anyone yet";
                    Send(client,null, mess);
                }
                else if (Last_connected == "All")
                { 
                    string mess = "You have connected to all users";
                    Send(client,null, mess);
                }
                else
                {   
                    string a = await GetFileLogNameFromFirebaseAsync(User_id, Last_connected);
                    FirebaseResponse firebaseResponse2 = await firebaseClient.GetTaskAsync("filelog/" + a);
                    FileLogdatabase fileLog = firebaseResponse2.ResultAs<FileLogdatabase>();
                    string path = fileLog.path;
                    string[] lines = File.ReadAllLines(path);
                    Send(client, lines, null);

                }
                IPAddress clientIpAddress = ((IPEndPoint)client.Client.RemoteEndPoint).Address;
                int clientPort = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
                while(true)
                {
                    string c;
                    Array.Clear(recv, 0, recv.Length);
                    // Start receiving
                    stream.Read(recv, 0, recv.Length);
                    c = Encoding.UTF32.GetString(recv);
                    sendedmess = c.Split(']');
                    string connected = sendedmess[1];
                    message = sendedmess[2];
                    string connector = sendedmess[0];
                    if (connected != "All")
                    {
                        if (message == "")
                        {

                            var Userconnect = new User_connect
                            {
                                Userid = s,
                                client = client,
                                Lastconnected = sendedmess[1],
                            };
                            // update last connected
                            FirebaseResponse firebaseResponse3 = await firebaseClient.UpdateTaskAsync("User_connect/" + s, Userconnect);
                            // check if 2 player have filelog or not
                            bool isFileLogExist = await IsFileLogExistAsync(s, connected);
                            if (isFileLogExist)
                            {
                                string a = await GetFileLogNameFromFirebaseAsync(s, connected);
                                FirebaseResponse firebaseResponse2 = await firebaseClient.GetTaskAsync("filelog/" + a);
                                FileLogdatabase fileLog = firebaseResponse2.ResultAs<FileLogdatabase>();
                                string path = fileLog.path;
                                string[] lines = File.ReadAllLines(path);
                                Send(client, lines, null);
                            }
                            else 
                            {
                                // create file 
                                createfile();
                                // add file log to firebase
                                var fileLog = new FileLogdatabase
                                {
                                    Name = fileName,
                                    User1 = s,
                                    User2 = connected,
                                    path = filePath,
                                };
                                FirebaseResponse response = await firebaseClient.SetTaskAsync("Filelog/" + fileName, fileLog);
                                string mess = "Starting chat with New Friend";
                                Send(client, null, mess);
                            }

                        }
                    }
                    
                }    
            }
        }
        //


        // function to create file log

        //









        // hàm send mes
        void Send(TcpClient client, string[] mess1,string mess2)
        {
            NetworkStream ns_temp = client.GetStream();
            byte[] recv = new byte[2048];
            if (mess1 == null)
            {
                recv = Encoding.UTF32.GetBytes(mess2);
                ns_temp.Write(recv, 0, recv.Length);
                ns_temp.Flush();
            }
            if (mess2 == null)
            {
                string combinedMessage = string.Join(Environment.NewLine, mess1);
                recv = Encoding.UTF32.GetBytes(combinedMessage);
                ns_temp.Write(recv, 0, recv.Length);
                ns_temp.Flush();
            }
            
        }



        // ham load form
        private void Severtexting_Load(object sender, EventArgs e)
        {
            firebaseClient = new FireSharp.FirebaseClient(ifc);

            if (firebaseClient == null)
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
            else { MessageBox.Show("Connected to the server"); }
        }
        ///
    }
}
