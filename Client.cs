using FireSharp.Config;
using FireSharp.Interfaces;
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
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
namespace NT106_project
{

   
    public partial class Client : Form
    {

        // public value
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
        IPEndPoint iep;
        Socket clientdevice;

        //............................................

        public Client(string UserID)
        {
            
            InitializeComponent();
            Currentuser = UserID;
            connect();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // private chat





            // forum chat 






            // profile chat

        }

        // private ui










        // forum ui











        // profile ui
















        // logout fuction



        // public function  :
        // .............................
        //connect function
        private void connect()
        {
            iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            clientdevice = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientdevice.Connect(iep);
                Thread listen = new Thread(receive);
                listen.IsBackground = true;
                listen.Start();

                datasending data = new datasending(Currentuser);

                string jsonString = JsonSerializer.Serialize(data);
                byte[] sendData = Encoding.UTF8.GetBytes(jsonString); ;

                clientdevice.Send(sendData);

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }


        // end connect function
        // ..............................



        // ........................
        // receive & handle data function
        private void receive()
        {   








            // private chat
            










            // forum chat




        }

        private void handle_data(Data obj )
        {
            
        }




        // end receive & handle data function
        //.......................
    }
}
