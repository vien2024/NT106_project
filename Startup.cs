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
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void btServer_Click(object sender, EventArgs e)
        {
            var server = new Server();
            server.Show();
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            var client = new newUIloginsiguppage();
            client.Show();
        }
    }
}
