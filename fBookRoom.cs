using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Net;
using System.Collections;
using System.Linq;
namespace HotelManager
{
    public partial class fBookRoom : Form
    {
        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        string username;
        public fBookRoom(string _username)
        {
            this.username = _username;
            this.DoubleBuffered = true;
            InitializeComponent();
            LoadData();

        }
        public void LoadData()
        {
            LoadRoomType();
            LoadCustomerType();
            LoadDate();
            LoadDays();
            LoadBookRoom();
        }
        public void LoadRoomType()
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * from Roomtype";
            cmd.Connection = con;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            cbRoomType.DataSource = src;
            cbRoomType.DisplayMember = "NameRoomType";
        }
        public void LoadRoomTypeInfo(string id)
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * from Roomtype where IDRoomType = @IDRoomType ";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@IDRoomType ", id);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            DataRow row = src.Rows[0];
            txbRoomTypeID.Text = row["IDRoomType"].ToString();
            txbRoomTypeName.Text = row["NameRoomType"].ToString();
            txbPrice.Text = row["Price"].ToString();
            txbAmountPeople.Text = row["LimitPerson"].ToString();
        }
        public void LoadDOB()
        {
            dpkDateOfBirth.Value = new DateTime(2004, 1, 1);
        }
        public void LoadDate()
        {
            
            dpkDateCheckIn.Value = DateTime.Now;
            dpkDateCheckOut.Value = DateTime.Now.AddDays(1);
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public void LoadCustomerType()
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * from CustomerType";
            cmd.Connection = con;
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            cbCustomerType.DataSource = src;
            cbCustomerType.DisplayMember = "NameCustomerType";
        }
        public void LoadBookRoom()
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select A.IDBookRoom[Mã đặt phòng], b.Name[Họ và tên],b.IDCard[CMND],C.NameRoomType[Loại phòng],A.DateCheckIn[Ngày nhận],A.DateCheckOut[Ngày trả] from BookRoom A,Customer B, RoomType C where a.IDRoomType=c.IDRoomType and A.IDCustomer=B.IDCustomer and A.DateBookRoom>=@date order by A.DateBookRoom desc";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@date", DateTime.Now.Date);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            dataGridViewBookRoom.DataSource = src;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        private bool IsValidID(string idCard)
        {
            return idCard.Length == 12 && idCard.All(char.IsDigit);
        }

        private string getID(string typeId, string table)
        {
            string id, newid;
            
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT TOP 1 " + typeId + " FROM " + table + " ORDER BY " + typeId + " DESC";
            cmd.Connection = con;
            id = (string)cmd.ExecuteScalar();
            con.Close();
            string TienTo;
            int HauTo;
            TienTo = id.Substring(0, 2);
            HauTo = int.Parse(id.Substring(2).ToString());
            HauTo++;
            if (HauTo < 10)
            {
                newid = string.Concat(TienTo, "00", HauTo.ToString());
            }
            else
            {
                if (HauTo < 100)
                {
                    newid = string.Concat(TienTo, "0", HauTo.ToString());
                }
                else
                {
                    newid = string.Concat(TienTo, HauTo.ToString());
                }
            }
            return newid;
        }

        private bool IsValidDOB(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now;
        }
        private void btnBookRoom_Click(object sender, System.EventArgs e)
        {
            if (cMessageBox.Show("Bạn có muốn đặt phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbIDCard.Text != String.Empty && txbFullName.Text != String.Empty && txbAddress.Text != String.Empty && txbPhoneNumber.Text != String.Empty && cbNationality.Text != String.Empty)
                {  
                     if (!IsValidID(txbIDCard.Text))
                        {
                            MessageBox.Show("ID không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    if (!IsValidPhoneNumber(txbPhoneNumber.Text))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!IsValidDOB(dpkDateOfBirth.Value))
                    {
                        MessageBox.Show("Ngày sinh không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (!IsIdCardExists(txbIDCard.Text))
                    {
                        txtIDCustomer.Text = getID("IDCustomer", "Customer");
                        int idCustomerTypee_index = cbCustomerType.SelectedIndex;
                        string idCustomerType = ((DataTable)cbCustomerType.DataSource).Rows[idCustomerTypee_index]["idCustomerType"].ToString();
                        InsertCustomer(txtIDCustomer.Text, txbIDCard.Text, txbFullName.Text, idCustomerType, dpkDateOfBirth.Value, txbAddress.Text, txbPhoneNumber.Text, cbSex.Text, cbNationality.Text);
                    }
                    string idBookroom = getID("IDBookroom", "BookRoom");
                    if (con == null) { con = new SqlConnection(connectstring); }
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select IDCustomer from Customer where IDcard = @IDCard";
                    cmd.Parameters.AddWithValue("@IDCard", txbIDCard.Text);
                    cmd.Connection = con;
                    string IDCustomer = (string)cmd.ExecuteScalar();
                    con.Close();
                    int IDRoomType_index = cbRoomType.SelectedIndex;
                    string IDRoomType = ((DataTable)cbRoomType.DataSource).Rows[IDRoomType_index]["IDRoomType"].ToString();
                    InsertBookRoom(idBookroom, IDCustomer, IDRoomType, dpkDateCheckIn.Value, dpkDateCheckOut.Value, DateTime.Now);
                    cMessageBox.Show("Đặt phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearData();
                    LoadBookRoom();
                    if (bunifuCheckbox1.Checked)
                    {
                        fReceiveRoom fReceiveRoom = new fReceiveRoom();
                       this.Hide();
                        fReceiveRoom.ShowDialog();
                        fReceiveRoom.Show();
                    }
                }
                else
                    cMessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public bool IsIdCardExists(string IDCard)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Customer where IDCard=@idCard ";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idCard", IDCard);
            DataTable src = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            con.Close();
            int count = src.Rows.Count;
            return count > 0;
        }
        private void  InsertCustomer (string IDCustomer, string idCard, string name, string idCustomerType, DateTime dateofBirth, string Diachi, string phonenumber, string sex, string nationality)
        {
            
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "INSERT INTO Customer(IDCustomer, IDCard, IDCustomerType, Name, DateOfBirth, Diachi , PhoneNumber, Sex, Nationality) VALUES(@IDCustomer, @idCard, @idCustomerType, @customerName, @dateOfBirth, @Diachi , @phoneNumber, @sex, @nationality)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@IDCustomer", IDCustomer);
            cmd.Parameters.AddWithValue("@idCard", idCard);
            cmd.Parameters.AddWithValue("@idCustomerType", idCustomerType);
            cmd.Parameters.AddWithValue("@customerName", name);
            cmd.Parameters.AddWithValue("@dateOfBirth", dateofBirth);
            cmd.Parameters.AddWithValue("@Diachi ", Diachi);
            cmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
            cmd.Parameters.AddWithValue("@Sex", sex);
            cmd.Parameters.AddWithValue("@Nationality", nationality);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                cMessageBox.Show("Thêm thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cMessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }
        public void InsertBookRoom(string IDBookRoom, string idCustomer, string idRoomType, DateTime datecheckin, DateTime datecheckout, DateTime datebookroom)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "insert into BookRoom (IDBookRoom,IDCustomer,IDRoomType,DateCheckIn,DateCheckOut,DateBookRoom) values(@IDBookRoom,@idCustomer,@idRoomType,@datecheckin,@datecheckout,@datebookroom)";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@IDBookRoom ", IDBookRoom);
            cmd.Parameters.AddWithValue("@IDCustomer", idCustomer);
            cmd.Parameters.AddWithValue("@IDRoomType", idRoomType);
            cmd.Parameters.AddWithValue("@DateCheckIn", datecheckin);
            cmd.Parameters.AddWithValue("@DateCheckOut", datecheckout);
            cmd.Parameters.AddWithValue("@DateBookRoom", datebookroom);
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
        }
        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IDRoomType_index = cbRoomType.SelectedIndex;
            string IDRoomType = ((DataTable)cbRoomType.DataSource).Rows[IDRoomType_index]["IDRoomType"].ToString();
            LoadRoomTypeInfo(IDRoomType);
        }
        private void ClearData()
        {
            txbIDCardSearch.Text = txbIDCard.Text = txbFullName.Text = txbAddress.Text = txbPhoneNumber.Text = cbNationality.Text = String.Empty;
            LoadDate();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            string idBookRoom = dataGridViewBookRoom.SelectedRows[0].Cells[0].Value.ToString();
            string idCard = dataGridViewBookRoom.SelectedRows[0].Cells[2].Value.ToString();
            fBookRoomDetails f = new fBookRoomDetails(idBookRoom, idCard, username);
            this.Hide();
            f.ShowDialog();
            this.Show();
            LoadBookRoom();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDCardSearch.Text != String.Empty)
            {
                if (IsIdCardExists(txbIDCardSearch.Text))
                {
                    DataTable src = new DataTable();
                    if (con == null) { con = new SqlConnection(connectstring); }
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select * from Customer where IDCard=@idCard ";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@idCard", txbIDCardSearch.Text);
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(src);
                    DataRow dataRow = src.Rows[0];
                    txtIDCustomer.Text = dataRow["IDCustomer"].ToString();
                    txbIDCard.Text = dataRow["IDCard"].ToString();
                    txbFullName.Text = dataRow["Name"].ToString();
                    txbAddress.Text = dataRow["Diachi"].ToString();
                    dpkDateOfBirth.Value = (DateTime)dataRow["DateOfBirth"];
                    cbSex.Text = dataRow["Sex"].ToString();
                    txbPhoneNumber.Text = dataRow["PhoneNumber"].ToString();
                    cbNationality.Text = dataRow["Nationality"].ToString();

                    src = new DataTable();
                    src.Clear();
                    cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "select B.NameCustomerType from Customer A, CustomerType B where A.IDCustomerType=B.IDCustomerType and A.IDCard=@idCard";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@idCard", dataRow["IDCard"].ToString());
                    adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(src);
                     dataRow = src.Rows[0];
                    cbCustomerType.Text = dataRow["NameCustomerType"].ToString();
                    con.Close();
                }
                else
                    cMessageBox.Show("Thẻ căn cước/ CMND không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dpkDateCheckOut_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckOut.Value <= DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value <= dpkDateCheckIn.Value)
                LoadDate();
            LoadDays();
        }

        private void dpkDateCheckIn_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateCheckIn.Value < DateTime.Now)
                LoadDate();
            if (dpkDateCheckOut.Value.Date <= dpkDateCheckIn.Value.Date)
                LoadDate();
            LoadDays();
        }

        private void dpkDateOfBirth_onValueChanged(object sender, EventArgs e)
        {
            if (dpkDateOfBirth.Value> DateTime.Now)
                LoadDOB();
        }
    }
}
