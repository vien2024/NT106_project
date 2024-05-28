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
            DataTable dt = new DataTable();
            dt.Columns.Add("file",typeof(string));
            dt.Rows.Add("1");
            dt.Rows.Add("2");
            dt.Rows.Add("3");
            dt.Rows.Add("4");
            guna2DataGridView1.DataSource = dt;
            guna2DataGridView1.ColumnHeadersVisible = false;
            guna2DataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            guna2DataGridView1.GridColor = guna2DataGridView1.BackgroundColor;
        }
    }
}
