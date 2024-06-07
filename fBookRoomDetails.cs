using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System;
using System.Xml.Linq;
using System.Linq;

namespace HotelManager
{
    public partial class fBookRoomDetails : Form
    {
        string idBookRoom;
        string idCard;
        string username;
        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        public fBookRoomDetails(string _idBookRoom, string _idCard, string _username)
        {
            idBookRoom = _idBookRoom;
            idCard = _idCard;
            username = _username;
            InitializeComponent();
            LoadRoomType();
            LoadCustomerType();
            LoadData();
            LoadDays();
            txbIDBookRoom.Text = _idBookRoom.ToString();
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
        public void LoadData()
        {
            DataTable src = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select B.Name[FullName],B.IDCard[IDCard],C.NameRoomType[NameRoomType],A.DateCheckIn[DateCheckIn],A.DateCheckOut[DateCheckOut],C.LimitPerson[LimitPerson],C.Price[Price] from BookRoom A,Customer B,RoomType C where A.idBookRoom=@idBookRoom and A.IDCustomer=B.IDCustomer and A.IDRoomType=C.IDRoomType";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idBookRoom", idBookRoom);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            DataRow dataRow = src.Rows[0];
            dpkDateCheckIn.Value = (DateTime)dataRow["DateCheckIn"];
            dpkDateCheckOut.Value = (DateTime)dataRow["DateCheckOut"];

            src = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select B.* from BookRoom A, RoomType B where A.idBookRoom=@idBookRoom and A.IDRoomType=B.IDRoomType";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idBookRoom", idBookRoom);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            dataRow = src.Rows[0];
            cbRoomType.Text = dataRow["NameRoomType"].ToString();

            src = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Customer where IDCard=@idCard ";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idCard", idCard);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            dataRow = src.Rows[0];
            txbIDCard.Text = dataRow["IDCard"].ToString();
            txbFullName.Text = dataRow["Name"].ToString();
            txbAddress.Text = dataRow["Diachi"].ToString();
            dpkDateOfBirth.Value = (DateTime)dataRow["DateOfBirth"];
            cbSex.Text = dataRow["Sex"].ToString();
            txbPhoneNumber.Text = dataRow["PhoneNumber"].ToString();
            cbNationality.Text = dataRow["Nationality"].ToString();
            con.Close();
        }
        public void LoadDays()
        {
            txbDays.Text = (dpkDateCheckOut.Value.Date - dpkDateCheckIn.Value.Date).Days.ToString();
        }
        public bool IsIdCardExists(string IDCard, string IDBookRoom)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Customer, BookRoom where IDCard=@idCard and IDBookRoom != @idbookroom";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idCard", IDCard);
            cmd.Parameters.AddWithValue("@idbookroom", IDBookRoom);
            DataTable src = new DataTable();
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            con.Close();
            int count = src.Rows.Count;
            return count > 0;
        }
        private bool IsValidDOB(DateTime dateOfBirth)
        {
            return dateOfBirth <= DateTime.Now;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        private bool IsValidID(string idCard)
        {
            return idCard.Length == 12 && idCard.All(char.IsDigit);
        }
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {      
            if (username != "admin")
            {
                cMessageBox.Show("Bạn không có quyền thực hiện chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbAddress.Text != string.Empty && cbNationality.Text != string.Empty && txbPhoneNumber.Text != string.Empty)
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
                if (!IsIdCardExists(txbIDCard.Text, txbIDBookRoom.Text))
                {
                    UpdateCustomer();
                }
                else
                    cMessageBox.Show("Thẻ căn cước/ CMND không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                cMessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            LoadData();
        }
        private void UpdateCustomer()
        {
            int idCustomerTypee_index = cbCustomerType.SelectedIndex;
            string idCustomerType = ((DataTable)cbCustomerType.DataSource).Rows[idCustomerTypee_index]["idCustomerType"].ToString();
            DataTable src = new DataTable();
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from Customer where IDCard=@idCard ";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@idCard", idCard);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(src);
            DataRow dataRow = src.Rows[0];
            string idCustomer = dataRow["IDCustomer"].ToString();
            UpdateCustomer(idCustomer, txbFullName.Text, txbIDCard.Text, idCustomerType, txbPhoneNumber.Text, dpkDateOfBirth.Value, txbAddress.Text, cbSex.Text, cbNationality.Text);
           
        }
        private void UpdateCustomer(string IDCustomer, string Name, string IDCard, string IDCustomerType, string phoneNumber, DateTime dateOfBirth, string Diachi, string sex, string nationality)
        {
            string query = "UPDATE Customer SET Name=@Name,IDCard = @IDCard ,IDCustomerType=@IDCustomerType,PhoneNumber=@PhoneNumber,DateOfBirth=@DateOfBirth,Diachi=@Diachi,Sex=@Sex,Nationality=@Nationality WHERE IDCustomer=@IDCustomer";
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IDCustomer", IDCustomer);
            cmd.Parameters.AddWithValue("@IDCard", IDCard);
            cmd.Parameters.AddWithValue("@IDCustomerType", IDCustomerType);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
            cmd.Parameters.AddWithValue("@Diachi ", Diachi);
            cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
            cmd.Parameters.AddWithValue("@Sex", sex);
            cmd.Parameters.AddWithValue("@Nationality", nationality);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                cMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                idCard = IDCard;
            }
            else
            {
                cMessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnUpdateBookRoom_Click(object sender, EventArgs e)
        {
            int idRoomType_index = cbCustomerType.SelectedIndex;
            string idRoomType = ((DataTable)cbRoomType.DataSource).Rows[idRoomType_index]["IDRoomType"].ToString();
            UpdateBookRoom(idBookRoom, idRoomType, dpkDateCheckIn.Value, dpkDateCheckOut.Value);
            cMessageBox.Show("Cập nhật thông tin đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadData();
        }
        private void UpdateBookRoom(string IDbookroom, string IDroomtype, DateTime datecheckin, DateTime datecheckout)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();         
            }
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "update BookRoom set IDRoomType=@IDRoomType,DateCheckIn=@DateCheckIn,DateCheckOut=@DateCheckOut where IDBookRoom =@IDBookRoom";
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@IDBookRoom ", IDbookroom);
            cmd.Parameters.AddWithValue("@IDRoomType", IDroomtype);
            cmd.Parameters.AddWithValue("@DateCheckIn", datecheckin);
            cmd.Parameters.AddWithValue("@DateCheckOut", datecheckout);
            int rowsAffected = cmd.ExecuteNonQuery();
            con.Close();
            if (rowsAffected > 0)
            {
                cMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cMessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            con.Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
             this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEraseCustomer_Click(object sender, EventArgs e)
        {
            if (cMessageBox.Show("Xóa thông tin đặt phòng dẫn đến phiếu đặt phòng cũng bị xóa!\nBạn có muốn tiếp tục?", "Cảnh báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
               try
                {
                    if (con == null) { con = new SqlConnection(connectstring); }
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "delete from BookRoom where IDBookRoom=@IDBookRoom";
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@IDBookRoom ", idBookRoom);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    con.Close();
                    cMessageBox.Show("Xóa thông tin đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch
                {
                    cMessageBox.Show("Xóa thông tin đặt phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
