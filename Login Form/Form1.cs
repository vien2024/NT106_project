namespace Login_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_supanel_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void btn_lgnpanel_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btn_lgnpanel.PerformClick();
        }
    }
}
