using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System;
using System.Globalization;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace HotelManager
{
    
    public partial class fBill : Form
    {
        
        private BindingSource bindingSource = new BindingSource();
        public fBill()
        {
            InitializeComponent();
            LoadFullBill();
            UpdateRecordCount();
        }
        string connectstring = @"Data Source=LAPTOP-2IQS7P3R; Database=hotelmanager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        private void LoadFullBill()
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT b.IDBill, r.NameRoom, c.Name,b.StaffSetUp ,b.DateofCreate, sb.NameStatusBill, b.TotalPrice, (cast(Discount as nvarchar(4)) + '%') [Discount], cast(TotalPrice*( (100-Discount)/100.0) as int) [FinalPrice] " +
                              "FROM Bill b, receiveroom rv, bookroom br, Customer c, Room r, StatusBill sb " +
                              "WHERE b.IDReceiveRoom = rv.IDReceiveRoom AND rv.IDBookRoom = br.IDBookRoom AND br.IDCustomer = c.IDCustomer " +
                              "AND rv.IDRoom = r.IDRoom AND b.IDStatusBill = sb.IDStatusBill "+
                              "order by b.IDBill ASC";


            cmd.Connection = con;
            SqlDataReader reader = cmd.ExecuteReader();

            dataGridViewBill.Rows.Clear();
            while (reader.Read())
            {
                string dateOfCreateStr = reader["DateofCreate"].ToString();
                // Add a new row to the DataGridView
                dataGridViewBill.Rows.Add(reader["IDBill"], reader["NameRoom"], reader["Name"], reader["StaffSetUp"], dateOfCreateStr, reader["NameStatusBill"], reader["TotalPrice"], reader["Discount"], reader["FinalPrice"]);
            }

            con.Close();
            UpdateRecordCount();

        }
        private void UpdateRecordCount()
        {
            // Đếm số lượng hóa đơn từ dữ liệu của bạn
            int billCount = CountBills();

            // Cập nhật số lượng trên bindingNavigatorCountItem
            bindingNavigatorCountItem.Text = $"Tổng số hóa đơn : {billCount}";
        }
        private int CountBills()
        {
            int count = 0;
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT COUNT(*) FROM Bill";
            cmd.Connection = con;
            count = (int)cmd.ExecuteScalar();
            return count;
            con.Close();
        }
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbDateCreate.Text = string.Empty;
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                txbStatusRoom.Text = string.Empty;
                txbUser.Text = string.Empty;

                btnSearch.Visible = false;
                btnCancel.Visible = true;
                if (con == null) { con = new SqlConnection(connectstring); }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT b.IDBill, r.NameRoom, c.Name,b.StaffSetUp ,b.DateofCreate, sb.NameStatusBill, b.TotalPrice, (cast(Discount as nvarchar(4)) + '%') [Discount], cast(TotalPrice*( (100-Discount)/100.0) as int) [FinalPrice]  "+
                                  "FROM Bill b, receiveroom rv, bookroom br, Customer c, Room r, StatusBill sb " +
                                  "WHERE b.IDReceiveRoom = rv.IDReceiveRoom AND rv.IDBookRoom = br.IDBookRoom AND br.IDCustomer = c.IDCustomer " +
                                  "AND rv.IDRoom = r.IDRoom AND b.IDStatusBill = sb.IDStatusBill AND c.PhoneNumber='"+ txbSearch.Text+"' " +
                                  "order by b.IDBill ASC";


                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();

                dataGridViewBill.Rows.Clear();
                while (reader.Read())
                {
                    string dateOfCreateStr = reader["DateofCreate"].ToString();
                    // Add a new row to the DataGridView
                    dataGridViewBill.Rows.Add(reader["IDBill"], reader["NameRoom"], reader["Name"], reader["StaffSetUp"], dateOfCreateStr, reader["NameStatusBill"], reader["TotalPrice"], reader["Discount"], reader["FinalPrice"]);
                }

                con.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txbSearch.Text = "";
            LoadFullBill();
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnCLose1_Click(object sender, EventArgs e)
        {
             this.Hide();

    // Tạo một thể hiện mới của form chính (fMain)
    /*fMain mainForm = new fMain();

    // Hiển thị form chính
    mainForm.Show();*/
        }

        private void dataGridViewBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            txbMaHD.Text= dataGridViewBill.Rows[numrow].Cells[0].Value.ToString();
            txbName.Text = dataGridViewBill.Rows[numrow].Cells[1].Value.ToString();
            txbDateCreate.Text = dataGridViewBill.Rows[numrow].Cells[4].Value.ToString();
            txbFinalPrice.Text = dataGridViewBill.Rows[numrow].Cells[8].Value.ToString();
            txbUser.Text = dataGridViewBill.Rows[numrow].Cells[3].Value.ToString();
            txbStatusRoom.Text = dataGridViewBill.Rows[numrow].Cells[5].Value.ToString();
            txbPrice.Text = dataGridViewBill.Rows[numrow].Cells[6].Value.ToString();
            txbDiscount.Text = dataGridViewBill.Rows[numrow].Cells[7].Value.ToString();
        }

        fPrintBill fPrintBill = new fPrintBill();
        private void btnSeenBill_Click(object sender, EventArgs e)
        {
            if (txbMaHD.Text != string.Empty)
            {
                if (!txbStatusRoom.Text.Contains("Ch"))
                {
                    fPrintBill.SetPrintBill(txbMaHD.Text, txbDateCreate.Text);
                    fPrintBill.Show();
                    this.Hide() ;
                }
                else
                    MessageBox.Show("Hoá đơn chưa thanh toán\nBạn không có quyền truy cập", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void fBill_Load(object sender, EventArgs e)
        {

        }
    }
}
