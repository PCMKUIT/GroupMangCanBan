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

            if (txbUserName.Text == string.Empty && txbPassWord.Text == string.Empty)
            {
                cMessageBox.Show("Vui lòng điền tên tài khoản và mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txbUserName.Text == string.Empty)
            {
                cMessageBox.Show("Vui lòng điền tên tài khoản", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (txbPassWord.Text == string.Empty)
            {
                cMessageBox.Show("Vui lòng điền mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string user = txbUserName.Text;
            string pw = txbPassWord.Text;

            cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;

            if (user == "admin")
            {
                cmd.CommandText = "SELECT StatusLogin FROM Staff WHERE UserName='admin'";
                object result = cmd.ExecuteScalar();
                if (result != null && result.ToString() == "Online")
                {
                    cMessageBox.Show("Tài khoản admin đang được đăng nhập ở một nơi khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //return;
                }
            }

            cmd.CommandText = "SELECT * FROM Staff WHERE UserName=@User AND PassWord=@Pass";
            cmd.Parameters.AddWithValue("@User", user);
            cmd.Parameters.AddWithValue("@Pass", pw);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                reader.Close();
                cmd.CommandText = "UPDATE Staff SET StatusLogin='Online' WHERE UserName=@User";
                cmd.ExecuteNonQuery();

                cMessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain fm = new fMain(user, pw);
                fm.Show();
                this.Hide();
            }
            else
            {
                cMessageBox.Show("Sai tên tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button1_Click(object sender, EventArgs e)
        {
            txbPassWord.isPassword = false;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txbPassWord.isPassword = true;
            button1.Visible = true;
            button2.Visible = false;
        }
    }
}
