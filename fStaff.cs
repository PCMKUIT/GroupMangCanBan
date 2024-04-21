using System.Data.SqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Net;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HotelManager
{
    public partial class fStaff : Form
    {

        string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        public fStaff()
        {
            InitializeComponent();
            LoadDataToDataGridView();
            dataGridStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            comboBoxStaffType.Items.Add("Chế độ cập nhật");
            comboBoxStaffType.Items.Add("Chế độ thêm");
            comboBoxStaffType.Items.Add("Chế độ xóa");
            comboBoxStaffType.SelectedItem = "Chế độ cập nhật";
            metroComboBox1.Items.Clear();
            metroComboBox1.Items.Add("IDStaff");
            metroComboBox1.Items.Add("UserName");
            metroComboBox1.Items.Add("DisplayName");
            metroComboBox1.Items.Add("IDCardStaff");
            metroComboBox1.Items.Add("PhoneNumberStaff");
            metroComboBox1.SelectedItem = "IDStaff";

            txbUserName.DataBindings.Add("Text", dataGridStaff.DataSource, "UserName");
            txbStartDay.DataBindings.Add("Text", dataGridStaff.DataSource, "StartDay");
            txbName.DataBindings.Add("Text", dataGridStaff.DataSource, "DisplayName");
            txbIDcard.DataBindings.Add("Text", dataGridStaff.DataSource, "IDCardStaff");
            comboBoxSex.DataBindings.Add("Text", dataGridStaff.DataSource, "SexStaff");
            datepickerDateOfBirth.DataBindings.Add("Value", dataGridStaff.DataSource, "DateOfBirthStaff");
            txbPhoneNumber.DataBindings.Add("Text", dataGridStaff.DataSource, "PhoneNumberStaff");
            txbAddress.DataBindings.Add("Text", dataGridStaff.DataSource, "AddressStaff");
        }
        private void LoadDataToDataGridView()
        {
            string query = "SELECT * FROM Staff";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            dataGridStaff.DataSource = dataTable;
        }
        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string fieldToSearch = metroComboBox1.SelectedItem.ToString(); 
            string searchValue = txbSearch.Text.Trim(); 
            if (searchValue == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $"SELECT * FROM Staff WHERE {fieldToSearch} = @SearchValue"; 

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txbUserName.Text = reader["UserName"].ToString();
                            txbStartDay.Text = reader["StartDay"].ToString();
                            txbName.Text = reader["DisplayName"].ToString();
                            txbIDcard.Text = reader["IDCardStaff"].ToString();
                            comboBoxSex.SelectedItem = reader["SexStaff"].ToString();
                            datepickerDateOfBirth.Value = (DateTime)reader["DateOfBirthStaff"];
                            txbPhoneNumber.Text = reader["PhoneNumberStaff"].ToString();
                            txbAddress.Text = reader["AddressStaff"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu cho thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        private bool IsValidID(string idCard)
        {
            return idCard.Length == 12 && idCard.All(char.IsDigit);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxStaffType.SelectedItem.ToString() != "Chế độ cập nhật")
            {
                MessageBox.Show("Vui lòng chuyển sang chế độ cập nhật trước khi cập nhật nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbName.Text == string.Empty)
            {
                MessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDcard.Text))
            {
                MessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TimeSpan maxAge = new TimeSpan(365 * 100, 0, 0, 0);
            if (DateTime.Now.Date - datepickerDateOfBirth.Value > maxAge)
            {
                DialogResult result = MessageBox.Show("Ngày sinh này có vẻ không hợp lý, bạn có chắc muốn lưu như vậy không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (txbAddress.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống thông tin địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "UPDATE Staff SET UserName=@UserName, DisplayName = @DisplayName, IDCardStaff = @IDCardStaff, SexStaff = @SexStaff, DateOfBirthStaff = @DateOfBirthStaff, PhoneNumberStaff = @PhoneNumberStaff, AddressStaff = @AddressStaff WHERE UserName = @UserName";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", txbUserName.Text.Trim());
                    command.Parameters.AddWithValue("@DisplayName", txbName.Text.Trim());
                    command.Parameters.AddWithValue("@IDCardStaff", txbIDcard.Text.Trim());
                    command.Parameters.AddWithValue("@SexStaff", comboBoxSex.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@DateOfBirthStaff", datepickerDateOfBirth.Value);
                    command.Parameters.AddWithValue("@PhoneNumberStaff", txbPhoneNumber.Text);
                    command.Parameters.AddWithValue("@AddressStaff", txbAddress.Text.Trim());

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            LoadDataToDataGridView();
            dataGridStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (comboBoxStaffType.SelectedItem.ToString() != "Chế độ xóa")
            {
                MessageBox.Show("Vui lòng chuyển sang chế độ xóa trước khi xóa nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedProperty = metroComboBox1.SelectedItem.ToString(); 
            string valueToDelete = txbSearch.Text.Trim(); 

            if (string.IsNullOrEmpty(valueToDelete))
            {
                MessageBox.Show("Vui lòng nhập giá trị cần xóa trước khi thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = $"DELETE FROM Staff WHERE {selectedProperty} = @ValueToDelete"; 

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ValueToDelete", valueToDelete);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Nhân viên đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy nhân viên có thông tin này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            LoadDataToDataGridView(); 
            dataGridStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (comboBoxStaffType.SelectedItem.ToString() != "Chế độ thêm")
            {
                MessageBox.Show("Vui lòng chuyển sang chế độ thêm trước khi thêm nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbName.Text == string.Empty)
            {
                MessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDcard.Text))
            {
                MessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TimeSpan maxAge = new TimeSpan(365 * 100, 0, 0, 0);

            if (DateTime.Now.Date - datepickerDateOfBirth.Value > maxAge)
            {
                DialogResult result = MessageBox.Show("Ngày sinh này có vẻ không hợp lý, bạn có chắc muốn lưu như vậy không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return; 
                }
            }
            if (txbAddress.Text == string.Empty)
            {
                MessageBox.Show("Không được để trống thông tin địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string userName = txbUserName.Text.Trim();
            DateTime startDay = DateTime.Now.Date;
            string displayName = txbName.Text.Trim();
            string idCard = txbIDcard.Text.Trim();
            string sex = comboBoxSex.SelectedItem.ToString();
            DateTime dateOfBirth = datepickerDateOfBirth.Value;
            string phoneNumber = txbPhoneNumber.Text.Trim();
            string address = txbAddress.Text.Trim();
            string countQuery = "SELECT COUNT(*) FROM Staff";
            string id;
            using (SqlConnection connect = new SqlConnection(connectstring))
            {
                connect.Open();
                using (SqlCommand countCommand = new SqlCommand(countQuery, connect))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    id = "NV" + (totalCount + 1).ToString("D2");
                }
                connect.Close();
            }

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(displayName) || string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO Staff (IDStaff,UserName,DisplayName,PassWord, IDCardStaff, DateOfBirthStaff,SexStaff, AddressStaff,PhoneNumberStaff ,StartDay) " +
                           "VALUES (@IDStaff,@UserName,@DisplayName,@PassWord, @IDCardStaff, @DateOfBirthStaff,@SexStaff, @AddressStaff,@PhoneNumberStaff,@StartDay)";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {                  
                    command.Parameters.AddWithValue("@IDStaff", id);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@DisplayName", displayName);
                    command.Parameters.AddWithValue("@PassWord", "default");
                    command.Parameters.AddWithValue("@IDCardStaff", idCard);                                                      
                    command.Parameters.AddWithValue("@DateOfBirthStaff", dateOfBirth);
                    command.Parameters.AddWithValue("@SexStaff", sex);
                    command.Parameters.AddWithValue("@AddressStaff", address);
                    command.Parameters.AddWithValue("@PhoneNumberStaff", phoneNumber);
                    command.Parameters.AddWithValue("@StartDay", startDay);
                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Nhân viên đã được thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm mới nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            LoadDataToDataGridView();
            dataGridStaff.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void comboBoxStaffType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMode = comboBoxStaffType.SelectedItem.ToString();
            if (selectedMode == "Chế độ thêm")
            {
                txbUserName.Enabled = true;
                txbName.Enabled = true;
                txbIDcard.Enabled = true;
                txbAddress .Enabled = true;
                txbPhoneNumber.Enabled = true;
                comboBoxSex.Enabled = true;
            }
            else if (selectedMode == "Chế độ cập nhật")
            {
                txbUserName.Enabled = false;
                txbName.Enabled = true;
                txbIDcard.Enabled = true;
                txbAddress.Enabled = true;
                txbPhoneNumber.Enabled = true;
                comboBoxSex.Enabled = true;
            }
            else
            {
                txbUserName.Enabled = false;
                txbName.Enabled = false;
                txbIDcard.Enabled = false;
                txbAddress.Enabled = false;
                txbPhoneNumber.Enabled = false;
                comboBoxSex.Enabled = false;
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridStaff_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridStaff.Rows[e.RowIndex];
                txbUserName.Text = selectedRow.Cells["UserName"].Value.ToString();
                txbStartDay.Text = selectedRow.Cells["StartDay"].Value.ToString();
                txbName.Text = selectedRow.Cells["DisplayName"].Value.ToString();
                txbIDcard.Text = selectedRow.Cells["IDCardStaff"].Value.ToString();
                comboBoxSex.SelectedItem = selectedRow.Cells["SexStaff"].Value.ToString();
                datepickerDateOfBirth.Value = (DateTime)selectedRow.Cells["DateOfBirthStaff"].Value;
                txbPhoneNumber.Text = selectedRow.Cells["PhoneNumberStaff"].Value.ToString();
                txbAddress.Text = selectedRow.Cells["AddressStaff"].Value.ToString();
            }
        }
    }
}
