using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fLogin : Form
    {
         public fLogin()
        {
            InitializeComponent();
        }
        string connectstring = @"Data Source=LAPTOP-2IQS7P3R; Database=hotelmanager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        private void btnLogin_Click(object sender, System.EventArgs e)
        {
                if (con == null) { con = new SqlConnection(connectstring); }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                if (txbUserName.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng điền tên tài khoản");
                }
                else if (txbPassWord.Text == string.Empty)
                {
                    MessageBox.Show("Vui lòng điền mật khẩu");
                }
                string user = txbUserName.Text;
                string pw = txbPassWord.Text;
                cmd.CommandText = "select*from Staff where UserName='" + user + "'  and [PassWord]='" + pw + "' ";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() != false)
                {
                    this.Hide();
                    MessageBox.Show("Đăng nhập thành công !");
                    fMain fm = new fMain();
                    fm.Show();
                }
                else
                {
                    MessageBox.Show("Bạn đã nhập sai tên tài khoản hoặc mật khẩu!");
                }
            
        }

        private void btnExit__Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }
    }
}
