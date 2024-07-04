using FireSharp.Extensions;

namespace NT106_project
{
    public partial class Form1 : Form
    {

        public Form1()
        {

            InitializeComponent();

        }



        private void button1_Click(object sender, EventArgs e)
        {
            Server server = new Server();
            server.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newUIloginsiguppage1 newUIloginsiguppage = new newUIloginsiguppage1();
            newUIloginsiguppage.Show();
        }
    }
}
