using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }
        string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        SqlConnection con;
        SqlCommand cmd;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            if (txbUserName.Text == string.Empty && txbPassWord.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền tên tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txbUserName.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txbPassWord.Text == string.Empty)
            {
                MessageBox.Show("Vui lòng điền mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string user = txbUserName.Text;
            string pw = txbPassWord.Text;
            cmd.CommandText = "select*from Staff where UserName='" + user + "'  and [PassWord]='" + pw + "' ";
            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read() != false)
            {
                MessageBox.Show("Đăng nhập thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain fm = new fMain(user,pw);
                fm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            con.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnExit__Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void txbPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this ,new EventArgs());
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnExit__Click(this, new EventArgs());
            }
        }
        private void txbUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnExit__Click(this, new EventArgs());
            }
        }
    }
}
