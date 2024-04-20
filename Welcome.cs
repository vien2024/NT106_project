using ChatAppForms.Chat;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppForms
{
    public partial class Welcome : Form
    {

        public Welcome()
        {
            InitializeComponent();
        }

        private async void btChatAppSrv_Click(object sender, EventArgs e)
        {       //Opens another form for server usage
            ChatServer ChatServer = new ChatServer();
            ChatServer.ShowDialog();
            this.Hide();
            this.Close();
        }

        private void btChatAppCli_Click(object sender, EventArgs e)
        {
            ChatClient ChatClient = new ChatClient();
            ChatClient.ShowDialog();
            this.Hide();
            this.Close();
        }
    }
}
