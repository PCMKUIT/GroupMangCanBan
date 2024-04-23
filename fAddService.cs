using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using static System.Net.Mime.MediaTypeNames;
namespace HotelManager
{
    public partial class fAddService : Form
    {

        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public fAddService()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadFullServiceType();
        }
        private void LoadFullServiceType()
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * from ServiceType";
            cmd.Connection = con;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            comboBoxServiceType.DataSource = src;
            comboBoxServiceType.DisplayMember = "NameServiceType";
            con.Close();
            ;
            if (src.Rows.Count > 0)
                comboBoxServiceType.SelectedIndex = 0;
        }
        private void btnAddCustomer_Click(object sender, System.EventArgs e)
        {
            if (txbName.Text == "")
            { MessageBox.Show("Tên dịch vụ chưa được nhập");
                return;
            }
            if (txbPrice.Text == "" || !(int.TryParse(txbPrice.Text.Trim(), out int result)))
            {
                MessageBox.Show("Giá dịch vụ không hợp lệ");
                return;
            }
            if (txbPrice.Text.Length < 3)
            {
                MessageBox.Show("Giá dịch vụ quá nhỏ ");
                return;
            }
            string countQuery = "SELECT COUNT(*) FROM Service";
            string IDService;
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            using (SqlCommand countCommand = new SqlCommand(countQuery, con))
            {
                int totalCount = (int)countCommand.ExecuteScalar();
                IDService = "DV";
                if (totalCount < 100)
                {
                    IDService = IDService + "0";
                }
                if (totalCount < 10)
                {
                    IDService = IDService + "0";
                }
                IDService = IDService + (totalCount + 1).ToString("D2");
            }
            int ServiceTypeID_index = comboBoxServiceType.SelectedIndex;
            string ServiceTypeID = ((DataTable)comboBoxServiceType.DataSource).Rows[ServiceTypeID_index]["IDServiceType"].ToString();
            string query = "Insert into Service (IDService,NameService, PriceService, IDServiceType) Values (@IDService,@NameService, @PriceService,@IDServiceType)";
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NameService", txbName.Text.Trim());
            cmd.Parameters.AddWithValue("@PriceService", txbPrice.Text.Trim());
            cmd.Parameters.AddWithValue("@IDServiceType", ServiceTypeID);
            cmd.Parameters.AddWithValue("@IDService", IDService);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("Thêm thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnClose__Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
