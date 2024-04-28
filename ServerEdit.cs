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
                ListInfo.DataSource = dt;
                //đóng chuỗi kết nối
                conn.Close();
                //sử dụng thuộc tính Width và HeaderText để set chiều dài và tiêu đề cho các coloumns
                ListInfo.Columns[0].Width = 80;
                ListInfo.Columns[0].HeaderText = "UserID";
                ListInfo.Columns[1].Width = 110;
                ListInfo.Columns[1].HeaderText = "UserName";
                ListInfo.Columns[2].Width = 110;
                ListInfo.Columns[2].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = ListInfo.Rows[e.RowIndex];
            textBox3.Text = Convert.ToString(row.Cells["Id"].Value);
            textBox1.Text = Convert.ToString(row.Cells["Name"].Value);
            textBox2.Text = Convert.ToString(row.Cells["Status"].Value);
        }
        private void Reset()
        {
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public bool KTThongTin()
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập ID người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
                return false;
            }
            if (textBox1.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Focus();
                return false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Vui lòng nhập trạng thái người dùng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Focus();
                return false;
            }
            return true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            LayDSND();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //sử dụng thuộc tính RowFilter để tìm kiếm theo tên "Name"
            string rowFilter = string.Format("{0} like '{1}'", "Name", "*" + textBox4.Text + "*");
            (ListInfo.DataSource as DataTable).DefaultView.RowFilter = rowFilter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserID cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
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
                    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);

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
        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Vui lòng nhập UserID cần sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox3.Focus();
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
                    cmd.Parameters.Add("@ID", SqlDbType.Int).Value = Convert.ToInt32(textBox3.Text);
                    cmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = textBox1.Text;
                    cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = textBox2.Text;

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

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
