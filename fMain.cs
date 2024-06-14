using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fMain : Form
    {
        private string userName;
        private string passWord;
        public fMain(string userName, string passWord)
        {
            this.userName = userName;
            this.passWord = passWord;
            InitializeComponent();
        }

        private void btnAccountProfile_Click(object sender, System.EventArgs e)
        {
            fProfile fp = new fProfile(userName);
            fp.Show();
        }

        private void bunifuFlatButton2_Click(object sender, System.EventArgs e)
        {
            fCustomer fc = new fCustomer(userName,passWord);
            fc.Show();
        }

        private void bunifuFlatButton6_Click(object sender, System.EventArgs e)
        {
            fRoom fr = new fRoom(userName,passWord);
            fr.Show();
        }

        private void bunifuFlatButton5_Click(object sender, System.EventArgs e)
        {
            fBill fb = new fBill();
            fb.Show();
        }

        private void bunifuFlatButton4_Click(object sender, System.EventArgs e)
        {
            fStaff fs = new fStaff(userName,passWord);
            fs.Show();
        }

        private void bunifuFlatButton3_Click(object sender, System.EventArgs e)
        {
            fBookRoom fbr = new fBookRoom();
            fbr.Show();
        }

        private void bunifuFlatButton7_Click(object sender, System.EventArgs e)
        {
            fReceiveRoom frr = new fReceiveRoom();
            frr.Show();
        }

        private void bunifuFlatButton8_Click(object sender, System.EventArgs e)
        {
            fUseService fus = new fUseService();
            fus.Show();
        }

        private void bunifuFlatButton9_Click(object sender, System.EventArgs e)
        {
            if (userName != "admin") { fChatClient fchat = new fChatClient(userName); fchat.Show(); }
            else { fChatServer fchat = new fChatServer(userName); fchat.Show(); }
        }

        private void btnLogOut_Click(object sender, System.EventArgs e)
        {
            UpdateStatusLogin(userName, "Offline");
            fLogin fG = new fLogin();
            fG.Show();
            this.Hide(); 
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            UpdateStatusLogin(userName, "Offline");
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
        private void UpdateStatusLogin(string userName, string status)
        {
            string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectstring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Staff SET StatusLogin=@Status WHERE UserName=@UserName", con))
                {
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.ExecuteNonQuery();
                }
                con.Close();
            }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                btnLogOut_Click(this, new System.EventArgs());
            }
        }
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusLogin(userName, "Offline");
        }

    }
}
    

