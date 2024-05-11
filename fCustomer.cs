﻿using System.Data.SqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Net;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HotelManager
{
    public partial class fCustomer : Form
    {
        string strCon = @"Data Source=NHDK\SQLEXPRESS;Initial Catalog=hotelmanager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection sqlCon = null;
        public fCustomer()
        {
            InitializeComponent();
        }

        private void fCustomer_Load(object sender, EventArgs e)
        {
            Hienthidanhsach();
        }

       /*  private void Hienthidanhsach()
        {
            if (sqlCon == null) 
            {
                sqlCon = new SqlConnection(strCon);
            }

            if (sqlCon.State == ConnectionState.Closed) 
            {
                sqlCon.Open();
            }

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM Customer";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();  
            lsvDanhSach.Items.Clear();
            while (reader.Read()) 
            {
                string MAKH = reader.GetString(0);
                string TENKH = reader.GetString(1);
                string LOAIKH = reader.GetString(2);
                string SDT = reader.GetString(3);
                string DCHI = reader.GetString(4);  
                string QTICH =  reader.GetString(5);
                string ID =reader.GetString(6);
                string GT = reader.GetString(7);
                DateTime NS = reader.GetDateTime(8);
                

                ListViewItem lvi = new ListViewItem(MAKH);  
                lvi.SubItems.Add(TENKH);
                lvi.SubItems.Add(LOAIKH);
                lvi.SubItems.Add(SDT);
                lvi.SubItems.Add(DCHI);
                lvi.SubItems.Add(QTICH);
                lvi.SubItems.Add(ID);
                lvi.SubItems.Add(GT);
                lvi.SubItems.Add(NS.ToString());

                lsvDanhSach.Items.Add(lvi);


            }
            reader.Close();
        } */



        private void Hienthidanhsach()
        {
            string query = "SELECT * FROM Customer";
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            dataGridCus.DataSource = dataTable;
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddN();
        }

        private void AddN()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }



            //lay du lieu
            string MAKH = comboboxID.Text.Trim();
            string TENKH = txbFullName.Text.Trim();
            string LOAIKH = comboBoxCustomerType.Text.Trim();
            string SDT = txbPhoneNumber.Text.Trim();
            string QTICH = txbNationality.Text.Trim();
            string ID = txbIDCard.Text.Trim();
            string GT = comboBoxSex.Text.Trim();
            DateTime NS = datepickerDateOfBirth.Value;
            string DCHI = txbAddress.Text.Trim();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT into Customer values (N'"+MAKH+"', N'"+ID+"', N'"+LOAIKH+"', N'"+TENKH+"',, N'"+DCHI+"', "+SDT+", N'"+GT+"', N'"+QTICH+"' )";

            sqlCmd.Connection = sqlCon;

            int kq = sqlCmd.ExecuteNonQuery();
            if(kq > 0)
            {
                MessageBox.Show("Thêm dữ liệu thành công!");
                Hienthidanhsach();
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

        /*private void btnInsert_Click(object sender, EventArgs e)
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
        */

    }
}
