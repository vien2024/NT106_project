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


namespace NT106_project
{
    public partial class Form4 : Form
    {
        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "fbuBetnnPUKCEfn8z7p47QS8AG9aXzkXhAi2YoXE",
            BasePath = "https://appchat-73740-default-rtdb.firebaseio.com/",
        };
        IFirebaseClient client;

        public Form4()
        {
            InitializeComponent();

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(ifc);
            }
            catch
            {
                MessageBox.Show("There was a problem in connecting to the server");
            }
        }
    }
}
