using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Formats.Asn1.AsnWriter;
using System.Reactive;
using FireSharp.Config;
using FireSharp.Interfaces;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Text.Json;
using System.Reflection;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Firebase.Database.Query;
using FireSharp.Response;
using System.Security.Cryptography;

namespace NT106_project
{
    public partial class Server : Form
    {

       // constructor .................................................................................................................................
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
        IPEndPoint iep;
        Socket server;
        List<Socket> clientList;
        private readonly object lockObj = new object();
        // End constructor ..............................................................................................................................



        // constructor .................................................................................................................................
        public Server()
        {
            InitializeComponent();

        }

        private void Server_Load(object sender, EventArgs e)
        {

        }
        // End constructor ..............................................................................................................................




        // Server started ..............................................................................................................................
        // Start Server
        private void InitializeServer()
        {
            try
            {
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9999);
                server.Bind(iep);
                Thread acceptClientThread = new Thread(AcceptClients);
                acceptClientThread.IsBackground = true;
                acceptClientThread.Start();


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing server: {ex.Message}");
            }
        }



        // Accept Clients
        private void AcceptClients()
        {
            try
            {
                server.Listen(10);
                while (true)
                {
                    Socket client = server.Accept();
                    lock (lockObj)
                    {
                        clientList.Add(client);
                       

                        Thread receiveThread = new Thread(() => receive(client));
                        receiveThread.IsBackground = true;
                        receiveThread.Start();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error accepting clients: {ex.Message}");
            }
        }
        // End Server started ..............................................................................................................................










        // send function ...................................................................................................................................
        private void SendData(Socket client, datasending data)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(data);
                byte[] sendData = Encoding.UTF8.GetBytes(jsonString);

                client.Send(sendData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in SendData: {ex.Message}");
            }
        }


        // End send function    ............................................................................................................................









        // all receive function ......................................................................................................................
        // Receive 
        private void receive(Socket client)
        {
            StringBuilder sb = new StringBuilder();
            try
            {

                while (true)
                {
                    byte[] buffer = new byte[5120];
                    int bytesRead = client.Receive(buffer);
                    if (bytesRead == 0)
                    {
                        // Client disconnected
                        RemoveClient(client);
                        break;
                    }

                    string jsonString = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    sb.Append(jsonString);
                    while (true)
                    {
                        string bufferContent = sb.ToString();
                        int startIndex = bufferContent.IndexOf('{');
                        int endIndex = bufferContent.IndexOf('}', startIndex + 1);
                        if (startIndex == -1 || endIndex == -1)
                        {
                            break;
                        }
                        string completeJson = bufferContent.Substring(startIndex, endIndex - startIndex + 1);
                        sb.Remove(startIndex, endIndex - startIndex + 1);
                        try
                        {
                            datasending data = JsonSerializer.Deserialize<datasending>(completeJson);
                            ProcessReceivedData(client, data);
                        }
                        catch (JsonException ex)
                        {
                            MessageBox.Show($"JSON Deserialization error: {ex.Message}");
                        }
                    }
                }
            }
            catch (SocketException ex)
            {
                if (ex.SocketErrorCode == SocketError.ConnectionAborted || ex.SocketErrorCode == SocketError.ConnectionReset)
                {
                    // Client disconnected
                    RemoveClient(client);
                }
                else
                {
                    MessageBox.Show($"SocketException: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
            }

        }
        





        // Process Received Data 
        private async void ProcessReceivedData(Socket client, datasending data)
        {
           
                string Userid1 = data.USerid1;
                bool isconnected = await IsUserConnectedAsync(Userid1);
            
            // checkmessage is value to check that client is sending message or not
            if (!data.Checkmessage)
            {
                if (!isconnected)   // check if user have connected for so or not by using Lastconnected
                {
                    
                    var Userconnect = new User_connect
                    {
                        Userid = Userid1,
                        client = client,
                        Lastconnected = "",
                    };
                    FirebaseResponse firebaseResponse2 = await firebaseClient.SetTaskAsync("User_connect/" + Userid1, Userconnect);
                }
                else
                {
                    FirebaseResponse firebaseResponse = await firebaseClient.GetTaskAsync("User_connect/" + Userid1);
                    User_connect user = firebaseResponse.ResultAs<User_connect>();
                    string User_id = user.Userid;
                    string Last_connected = user.Lastconnected;
                    if (Last_connected == "")
                    {
                        string mess = "None";
                        datasending data1 = new datasending(mess, false);
                        SendData(client, data1);
                    }
                    else if (Last_connected == "All")
                    {
                        string mess = "All";
                        datasending data1 = new datasending(mess, false);
                        SendData(client, data1);
                    }
                    else
                    {
                        string mess = $"{Last_connected}";
                        datasending data1 = new datasending(mess, false);
                        SendData(client, data1);
                    }
                }

            }
            else  // handle data  sending form client to client throught server
            {
               if (data.Checkloadmessage)
               {
                    if (data.USerid2 == "All")
                    {   

                        List<Socket> Forumclient = await GetClientConectedtoforum();
                        string logpath = "D:\\K2-N2\\lap_trinh_mang_can_ban\\git\\filelog\\forum.txt";
                        try
                        {
                            using (StreamReader sr = new StreamReader(logpath))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    foreach (Socket client1 in Forumclient)
                                    {
                                        datasending data1 = new datasending(line, true);
                                        SendData(client1, data1);
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error reading the log file: " + ex.Message);
                        }

                    }
                    else
                    {   
                         bool isfilelogexist = await IsFileLogExistAsync(data.USerid1, data.USerid2);
                        if (!isfilelogexist)
                        {
                            createfile();
                            var filelog = new FileLogdatabase
                            {
                                User1 = data.USerid1,
                                User2 = data.USerid2,
                                Name = fileName,
                                path = filePath,
                            };
                            FirebaseResponse firebaseResponse = await firebaseClient.SetTaskAsync("Filelog/" + fileName, filelog);
                        }
                        else
                        {
                            string a = await GetFileLogNameFromFirebaseAsync(data.USerid1,data.USerid2);
                            FirebaseResponse firebaseResponse2 = await firebaseClient.GetTaskAsync("filelog/" + a);
                            FileLogdatabase fileLog = firebaseResponse2.ResultAs<FileLogdatabase>();
                            string path = fileLog.path;
                            try
                            {
                                using (StreamReader sr = new StreamReader(path))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        datasending data1 = new datasending(line, true);
                                        SendData(client, data1);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error reading the log file: " + ex.Message);
                            }
                        }
                    }
               }
                else
                {
                    if( data.USerid2 == "All" )
                    {

                    }    
                    else
                    {

                    }
                } 
                    
            }

            


        }
        // End  all receive function .................................................................................................................





        //  other function ............................................................................................................................
        // Generate file id
        private void Generatefileid()
        {
            Vcode = random.Next(1000, 10000);
        }
        // create file log
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
            }
            else
            {
                fileName = "";
                filePath = "";
                createfile();
            }

        }



        // Remove Client 
        private void RemoveClient(Socket client)
        {
            try
            {
                lock (lockObj)
                {
                    if (clientList.Contains(client))
                    {
                        clientList.Remove(client);
                        client.Shutdown(SocketShutdown.Both);
                        client.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception in RemoveClient: {ex.Message}");
            }
        }

        // check function ..............................................................................
        // ham kiem tra xem user da ket noi chua.
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


        // function to get data  ......................................................................
        // function to get filelog name
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


        // function to take User  connect to  forum 
        private async Task<List<Socket>> GetClientConectedtoforum()
        {
            var firebaseClient = new Firebase.Database.FirebaseClient("https://appchatdizz-default-rtdb.firebaseio.com/");

            var data = await firebaseClient
                .Child("User_connect") // Replace with your data node in Firebase
                .OnceAsync<User_connect>();

            // Extract the names from the data
            return data.Where(item => item.Object.Lastconnected == "All").Select(item => item.Object.client).ToList();
        }

        // function to add data to file
        private void insertdatatofile(string a)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                {
                    file.WriteLine(a);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 

        //End  other function ........................................................................................................................
    }
}