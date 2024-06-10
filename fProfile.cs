using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fProfile : Form
    {
        string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        private string userName;
        public fProfile(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            LoadProfile(userName);
        }
        public void LoadProfile(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                string query = "select*from Staff where UserName='" + username + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (username != "admin") txbStaffType.Text = "Nhân viên";
                            else txbStaffType.Text = "Quản lý";
                            txbUserName.Text = reader["UserName"].ToString();
                            txbDisplayName.Text = reader["DisplayName"].ToString();
                            txbIDCard.Text = reader["IDCardStaff"].ToString();
                            txbPhoneNumber.Text = reader["PhoneNumberStaff"].ToString();
                            txbStartDay.Text = reader["StartDay"].ToString();
                            dpkDateOfBirth.Value = Convert.ToDateTime(reader["DateOfBirthStaff"]);
                            cbSex.SelectedItem = reader["SexStaff"].ToString();
                            txbAddress.Text = reader["AddressStaff"].ToString();
                            textBox1.Text = reader["IDStaff"].ToString();
                            textBox2.Text = reader["DisplayName"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dữ liệu cho ID đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                connection.Close();
            }
        }
        public void UpdateProfile(string username, string displayName)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                string query = "UPDATE Staff SET DisplayName=@DisplayName WHERE UserName='" + username + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DisplayName", displayName);

                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                connection.Close();
            }
        }
        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBookRoom_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string displayName = txbDisplayName.Text;
            if (displayName == string.Empty)
            {
                MessageBox.Show("Tên hiển thị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            UpdateProfile(username, displayName);
            LoadProfile(userName);
        }
        private bool CheckCurrentPassword(string username, string currentPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM Staff WHERE UserName = @UserName AND PassWord = @PassWord";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@PassWord", currentPassword);
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool UpdatePassword(string username, string newPassword)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                string query = "UPDATE Staff SET PassWord = @PassWord WHERE UserName = @UserName";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserName", username);
                    command.Parameters.AddWithValue("@PassWord", newPassword);
                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string currentPassword = txbPass.Text;
            string newPassword = txbNewPass.Text;
            string confirmNewPassword = txbReNewPass.Text;
            if (userName == "admin")
            {
                MessageBox.Show("Mật khẩu của admin là cố định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentPassword == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!CheckCurrentPassword(username, currentPassword))
            {
                MessageBox.Show("Mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                MessageBox.Show("Xác nhận mật khẩu mới không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentPassword == newPassword)
            {
                MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UpdatePassword(username, newPassword))
            {
                MessageBox.Show("Mật khẩu đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbPass.Text = newPassword;
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi cập nhật mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber.Length == 10 && phoneNumber.All(char.IsDigit);
        }
        private bool IsValidID(string idCard)
        {
            return idCard.Length == 12 && idCard.All(char.IsDigit);
        }
        private bool SaveDataToDatabase(string username, string idCard, string phoneNumber, string sex, string address, DateTime dateOfBirth)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                string query = "UPDATE Staff SET IDCardStaff = @IDCardStaff, PhoneNumberStaff = @PhoneNumberStaff, SexStaff = @SexStaff, AddressStaff = @AddressStaff, DateOfBirthStaff = @DateOfBirthStaff WHERE UserName='" + username + "'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("IDCardStaff", idCard);
                    command.Parameters.AddWithValue("@PhoneNumberStaff", phoneNumber);
                    command.Parameters.AddWithValue("@SexStaff", sex);
                    command.Parameters.AddWithValue("@AddressStaff", address);
                    command.Parameters.AddWithValue("@DateOfBirthStaff", dateOfBirth);

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text;
            string idCard = txbIDCard.Text;
            string phoneNumber = txbPhoneNumber.Text;
            string sex = cbSex.SelectedItem.ToString();
            string address = txbAddress.Text;
            DateTime dateOfBirth = dpkDateOfBirth.Value;

            if (!IsValidID(idCard))
            {
                MessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dpkDateOfBirth.Value > DateTime.Now.Date)
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TimeSpan maxAge = new TimeSpan(365 * 100, 0, 0, 0);
            if (DateTime.Now.Date - dpkDateOfBirth.Value > maxAge)
            {
                DialogResult result = MessageBox.Show("Ngày sinh này có vẻ không hợp lý, bạn có chắc muốn lưu như vậy không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (address == string.Empty)
            {
                MessageBox.Show("Không được để trống thông tin địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SaveDataToDatabase(username, idCard, phoneNumber, sex, address, dateOfBirth))
            {
                MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Đã xảy ra lỗi khi lưu thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
