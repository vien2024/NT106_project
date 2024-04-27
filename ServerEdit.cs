using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;


namespace NT106_project
{
    public partial class ServerEdit : Form
    {
        public ServerEdit()
        {
            InitializeComponent();
        }
        SqlConnection cnn = new SqlConnection(@"Data Source=MSI\SQLEXPRESS;Initial Catalog=Login;Integrated Security=True;Encrypt=False");

        private void ServerEdit_Load(object sender, EventArgs e)
        {
            LayDSND();
        }
        private void LayDSND()
        {
            //khởi tạo các đối tượng SqlConnection, SqlDataAdapter, DataTable
            SqlConnection conn = new SqlConnection();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            //lấy chuỗi kết nối từ file App.config
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;

            try
            {
                //mở chuỗi kết nối
                conn.Open();
                //khai báo đối tượng SqlCommand trong SqlDataAdapter
                da.SelectCommand = new SqlCommand();
                //gọi thủ tục từ SQL
                da.SelectCommand.CommandText = "SP_Retrieve_Users";
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                //gán chuỗi kết nối
                da.SelectCommand.Connection = conn;
                //sử dụng phương thức fill để điền dữ liệu từ datatable vào SqlDataAdapter
                da.Fill(dt);
                //gán dữ liệu từ datatable vào datagridview
                dtgDSND.DataSource = dt;
                //đóng chuỗi kết nối
                conn.Close();
                //sử dụng thuộc tính Width và HeaderText để set chiều dài và tiêu đề cho các coloumns
                dtgDSND.Columns[0].Width = 80;
                dtgDSND.Columns[0].HeaderText = "UserID";
                dtgDSND.Columns[1].Width = 110;
                dtgDSND.Columns[1].HeaderText = "UserName";
                dtgDSND.Columns[2].Width = 110;
                dtgDSND.Columns[2].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dtgDSND_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dtgDSND.Rows[e.RowIndex];
            txtUserID.Text = Convert.ToString(row.Cells["Id"].Value);
            txtUserName.Text = Convert.ToString(row.Cells["Name"].Value);
            txtStatus.Text = Convert.ToString(row.Cells["Status"].Value);
        }
        private void Reset()
        {
            txtUserID.Text = "";
            txtUserName.Text = "";
            txtStatus.Text = "";
        }
        public void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public bool KTThongTin()
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Focus();
                return false;
            }
            if (txtUserName.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserName.Focus();
                return false;
            }
            if (txtStatus.Text == "")
            {
                MessageBox.Show("Vui lòng nhập trạng thái người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStatus.Focus();
                return false;
            }
            return true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserID cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Focus();
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_XoaUser";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(txtUserID.Text);

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSND();
                    Reset();
                    MessageBox.Show("Đã xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtUserID.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserID cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserID.Focus();
            }
            else if (KTThongTin())
            {
                try
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SP_SuaTrangThai";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(txtUserID.Text);
                    cmd.Parameters.Add("@TName", SqlDbType.NVarChar).Value = txtUserName.Text;
                    cmd.Parameters.Add("@EStatus", SqlDbType.NVarChar).Value = txtStatus.Text;

                    cmd.Connection = conn;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    LayDSND();
                    Reset();
                    MessageBox.Show("Đã sửa trạng thái thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lvMess_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LayDSND();
        }       

        private void ban_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
