using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class clientForm : Form
    {
        Socket _clientSocket;
        string _userName;
        Thread waitToReciveFromServer;
        string _roomName = "";
        System.Windows.Forms.Timer T;
        int min = 0, hour = 0, sec = 0;
        bool TurnFlag = false;
        int val;
        public clientForm(Socket s, string name)
        {
            InitializeComponent();
            _clientSocket = s;
            _userName = name;
            LBuserName.Text = _userName;
           
            waitToReciveFromServer = new Thread(ReceiveInformationFromServer);
            waitToReciveFromServer.Start();
            startClientForm();
        }
        private void addToListBox(ListBox lb, string name)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { addToListBox(lb, name); }));
                return;
            }
            lb.Items.Add(name);
        }


        private void startClientForm()
        {
            byte[] userData = Encoding.Unicode.GetBytes("users;new");
            _clientSocket.Send(userData);
        }
        private bool ownerNotInList(string v)
        {
            bool userExsit = false;
            int index = 0;
            while (!userExsit && index < LBroomList.Items.Count)
            {
                userExsit = LBroomList.Items[index].ToString() == v;
                index++;
            }
            return !userExsit;
        }
        private void ReceiveInformationFromServer()
        {
            byte[] buffer = new byte[1024];
            bool ownerExist = false;
            while (_clientSocket.Connected)
            {
                int rec = _clientSocket.Receive(buffer);
                byte[] tempBuffer = new byte[rec];
                Array.Copy(buffer, tempBuffer, rec);
                string serverInformation = Encoding.Unicode.GetString(tempBuffer);
                string[] messageInfo = serverInformation.Split(';');
                string Command = messageInfo[0];
                string option = messageInfo[1];
                if (Command.Equals("users"))
                {
                    if (option.Equals("new"))
                    {

                        int RoomStart = FindChar(messageInfo);
                        for (int i = 2; i < RoomStart; i += 2)
                        {
                            string user = messageInfo[i];
                            addToListBox(LBloginUsers, user);
                        }
                        for (int i = RoomStart + 1; i < messageInfo.Length; i += 2)
                        {
                            string roomName = messageInfo[i];
                            string owner = messageInfo[i + 1];
                            addToListBox(LBroomList, roomName + "---->" + owner);
                        }
                    }
                    if (option.Equals("add"))
                    {
                        string LastuserConnected = messageInfo[2];
                        addToListBox(LBloginUsers, LastuserConnected);
                    }
                }
                if (Command.Equals("room"))
                {
                    if (option.Equals("exist"))
                    {
                        MessageBox.Show("Room with this name allready exist");
                    }
                    if (option.Equals("add"))
                    {
                        string username = messageInfo[2];
                        string Rname = messageInfo[3];
                        addToListBox(LBroomList, username + "---->" + Rname);
                    }
                    if (option.Equals("join"))
                    {
                        string typeAct = messageInfo[2];
                        if (typeAct.Equals("add"))
                        {
                            string Ownername = messageInfo[5];
                            string roomName = messageInfo[6];
                            string zero = messageInfo[4];
                            string userName_ = messageInfo[3];
                            if (_userName == Ownername && ownerNotInList(Ownername))
                            {

                                _roomName = roomName;
                                if (!ownerExist)
                                {
                                    addToListBox(User, Ownername + "---->" + zero);
                                    ownerExist = true;
                                }
                            }
                            addToListBox(User, userName_ + "---->" + zero);
                        }
                        if (typeAct.Equals("new"))
                        {

                            for (int i = 3; i < messageInfo.Length; i += 2)
                            {
                                string userName = messageInfo[i];
                                string zero = messageInfo[i + 1];
                                addToListBox(User, userName + "---->" + zero);
                            }
                        }
                    }

                }
                if (Command.Equals("chat"))
                {
                    string UserName = messageInfo[2];
                    string TXT = messageInfo[3];               
                    if (option.Equals("Room"))
                    {
                        writeToChat(RTBroomChat, UserName, TXT);

                    }
                }
            }
        }
               
        private void writeToChat(RichTextBox RTB, string v1, string v2)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(delegate { writeToChat(RTB, v1, v2); }));
                return;
            }
            RTB.AppendText(v1 + " : " + v2 + "\n");
        }

        private int FindChar(string[] messageInfo)
        {
            int index = 0;
            bool flag = false;
            while (index < messageInfo.Length && flag == false)
            {
                if (messageInfo[index].Equals("#"))
                    flag = true;
                else index++;
            }
            return index;
        }

        

        private void BTcreate_Click(object sender, EventArgs e)
        {
            string UserInfo = "room;create;" + TBroomName.Text.ToString() + ";" + _userName ;
            TBroomName.Text = "";
            SendInformationToServer(UserInfo);

        }
        private void SendInformationToServer(string userInfo)
        //Sends infromation to the server
        //Recievs info and message the client accordinally
        {
            if (_clientSocket.Connected)
            {
                byte[] userData = Encoding.Unicode.GetBytes(userInfo);
                _clientSocket.Send(userData);
            }
        }
        
        private void BTjoin_Click(object sender, EventArgs e)
        {
            if (_roomName == "")
            {
                if (LBroomList.SelectedIndex == -1)
                    MessageBox.Show("You must select one of rooms in the list");
                else
                {
                    _roomName = LBroomList.SelectedItem.ToString();
                    string[] checkOwner = _roomName.Split('-');
                    if (!checkOwner[0].Equals(_userName))
                    {
                        string[] getroom = _roomName.Split('>');
                        _roomName = getroom[1];
                        SendInformationToServer("room;join;" + _userName + ";" + _roomName);
                    }
                    else
                    {
                        MessageBox.Show("You can't join the room you are the owner");
                    }

                }
            }
            else
            {
                MessageBox.Show("You can join only to one room");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LBloginUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BTstartGame_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RTBroomChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void PANgameBoard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void RTBglobalChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBglobalChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PANglobalchat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TBroomChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        
        private void BTsendChatRoom_Click(object sender, EventArgs e)
        {
            string userInfo = "chat;Room;" + _userName + ";" + TBroomChat.Text + ";" + _roomName;
            SendInformationToServer(userInfo);
            TBroomChat.Text = "";
        }
    }
}

        



