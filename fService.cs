using System.Windows.Forms;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System;
using System.Windows.Forms.Design;
using System.Collections.Generic;

namespace HotelManager
{
    public partial class fService : Form
    {
        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public fService()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadFullServiceType();
            LoadFullService(GetFullService());
            comboboxID.DisplayMember = "id";
            dataGridViewService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        private void LoadFullService(DataTable table)
        {
            BindingSource source = new BindingSource();
            source.DataSource = table;
            dataGridViewService.DataSource = source;
            comboboxID.DataSource = source;
            bindingService.BindingSource = source;
            txbName.DataBindings.Add("Text", source, "name");
            txbPrice.DataBindings.Add("Text", source, "price_new");
        }
        private DataTable GetFullService()
        {
            DataTable src= new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT Service.IDService as [id], Service.NameService as [name], PriceService as [price_new], ServiceType.NameServiceType as [nameServiceType] FROM Service INNER JOIN ServiceType ON ServiceType.IDServiceType = Service.IDServiceType";
            cmd.Connection = con;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            con.Close();
            return src;
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
        private void btnInsert_Click(object sender, System.EventArgs e)
        {   
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            fAddService fAddService = new fAddService();
            this.Hide();
            fAddService.ShowDialog();
            this.Show();
            if (btnCancel.Visible == false)
                LoadFullService(GetFullService());
            else
                BtnCancel_Click(null, null);
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            DialogResult result = cMessageBox.Show("Bạn có muốn cập nhật lại dịch vụ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
           if (result == DialogResult.OK)
                UpdateService();
            comboboxID.Focus();
        }

        private void UpdateService()
        {
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            if (comboboxID.Text == string.Empty)
                cMessageBox.Show("Dịch vụ không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            if (txbName.Text == "" || txbPrice.Text == "" || comboBoxServiceType.SelectedItem.ToString() == "")
            {
                cMessageBox.Show("Không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int ServiceTypeID_index = comboBoxServiceType.SelectedIndex;
                string ServiceTypeID = ((DataTable)comboBoxServiceType.DataSource).Rows[ServiceTypeID_index]["IDServiceType"].ToString();
                string query = "UPDATE Service SET NameService = @NameService,IDServiceType = @IDServiceType, PriceService = @PriceService WHERE IDService = @IDService";
                if (con == null) { con = new SqlConnection(connectstring); }
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@NameService", txbName.Text.Trim());
                cmd.Parameters.AddWithValue("@IDService", comboboxID.Text.Trim());
                cmd.Parameters.AddWithValue("@PriceService", txbPrice.Text.Trim());
                cmd.Parameters.AddWithValue("@IDServiceType", ServiceTypeID);
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                if (rowsAffected > 0)
                {
                    cMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (btnCancel.Visible == false)
                    {   
                        
                        LoadFullService(GetFullService());
                    }
                    else
                        BtnCancel_Click(null, null);
                }
                else
                {
                    cMessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCLose1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbName.Text = string.Empty;
                txbPrice.Text = string.Empty;
                btnSearch.Visible = false;
                btnCancel.Visible = true;
                LoadFullService(GetSearchService());
            }
        }
        private DataTable GetSearchService()
        {
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            string searchValue = txbSearch.Text.Trim();
            if (searchValue == string.Empty)
            {
                cMessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return GetFullService();
            }
            string query = "Select Service.IDService as id, Service.NameService as name, PriceService as price_new, ServiceType.NameServiceType as nameServiceType FROM Service, ServiceType where ServiceType.IDServiceType = Service.IDServiceType and NameService like '%'+@SearchValue+'%'";
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand command = new SqlCommand(query, con);
            command.Parameters.AddWithValue("@SearchValue", searchValue);
            adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            con.Close();
            return data;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            txbName.DataBindings.Clear();
            txbPrice.DataBindings.Clear();
            LoadFullService(GetFullService());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
