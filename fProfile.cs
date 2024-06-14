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
                            cMessageBox.Show("Không tìm thấy dữ liệu cho ID đã cho.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        cMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cMessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cMessageBox.Show("Tên hiển thị không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                cMessageBox.Show("Mật khẩu của admin là cố định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentPassword == string.Empty)
            {
                cMessageBox.Show("Vui lòng nhập mật khẩu hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (newPassword == string.Empty)
            {
                cMessageBox.Show("Vui lòng nhập mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!CheckCurrentPassword(username, currentPassword))
            {
                cMessageBox.Show("Mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmNewPassword)
            {
                cMessageBox.Show("Xác nhận mật khẩu mới không khớp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (currentPassword == newPassword)
            {
                cMessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (UpdatePassword(username, newPassword))
            {
                cMessageBox.Show("Mật khẩu đã được thay đổi thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txbPass.Text = newPassword;
            }
            else
            {
               cMessageBox.Show("Đã xảy ra lỗi khi cập nhật mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                cMessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(phoneNumber))
            {
                cMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dpkDateOfBirth.Value > DateTime.Now.Date)
            {
                cMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            TimeSpan maxAge = new TimeSpan(365 * 100, 0, 0, 0);
            if (DateTime.Now.Date - dpkDateOfBirth.Value > maxAge)
            {
                DialogResult result = cMessageBox.Show("Ngày sinh này có vẻ không hợp lý, bạn có chắc muốn lưu như vậy không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return;
                }
            }
            if (address == string.Empty)
            {
                cMessageBox.Show("Không được để trống thông tin địa chỉ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SaveDataToDatabase(username, idCard, phoneNumber, sex, address, dateOfBirth))
            {
                cMessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cMessageBox.Show("Đã xảy ra lỗi khi lưu thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txbPass.isPassword = false;
            button1.Visible = false;
            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txbPass.isPassword = true;
            button1.Visible = true;
            button2.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txbNewPass.isPassword = false;
            button5.Visible = false;
            button3.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txbNewPass.isPassword = true;
            button5.Visible = true;
            button3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txbReNewPass.isPassword = false;
            button6.Visible = false;
            button4.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txbReNewPass.isPassword = true;
            button6.Visible = true;
            button4.Visible = false;
        }
        private void txbPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton22_Click(this, new EventArgs());
            }
        }
        private void txbNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton22_Click(this, new EventArgs());
            }
        }
        private void txbReNewPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton22_Click(this, new EventArgs());
            }
        }
        private void txbDisplayName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBookRoom_Click(this, new EventArgs());
            }
        }
        private void txbIDcard_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton21_Click(this, new EventArgs());
            }
        }
        private void txbPhoneNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton21_Click(this, new EventArgs());
            }
        }
        private void txbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bunifuThinButton21_Click(this, new EventArgs());
            }
        }
    }
}
