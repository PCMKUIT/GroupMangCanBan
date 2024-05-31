using System.Data.SqlClient;
using System.Linq;
using System;
using System.Windows.Forms;
using System.Net;
using System.Data;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Collections.Generic;
using System.Xml.Linq;
using MetroFramework.Controls;

namespace HotelManager
{
    public partial class fCustomer : Form
    {
        string strCon = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        //string strCon = @"Data Source=NHDK\SQLEXPRESS;Initial Catalog=hotelmanager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        SqlConnection sqlCon = null;
        private string userName;
        private string passWord;
        public fCustomer(string username, string password)
        {
            this.userName = username;
            this.passWord = password;
            InitializeComponent();
            cbCustomerSearch.Items.Clear();
            cbCustomerSearch.Items.Add("IDCustomer");
            cbCustomerSearch.Items.Add("IDCard");
            cbCustomerSearch.Items.Add("Name");
            cbCustomerSearch.Items.Add("PhoneNumber");
            cbCustomerSearch.SelectedItem = "IDCustomer";

            comboBoxCustomerType.Items.Add("Khách du lịch");
            comboBoxCustomerType.Items.Add("Khách địa phương");
            comboBoxCustomerType.Items.Add("Khách vãng lai");
            comboBoxCustomerType.Items.Add("Khách từ bên thứ 3");
            comboBoxCustomerType.SelectedItem = "Khách du lịch";

            comboBoxSex.Items.Add("Nam");
            comboBoxSex.Items.Add("Nữ");
            CheckAdminPermission(username, password);
            //    txbFullName.DataBindings.Add("Text", dataGridCus.DataSource, "UserName");
            //   txbIDCard.DataBindings.Add("Text", dataGridCus.DataSource, "IDCard");
            //   comboBoxSex.DataBindings.Add("Text", dataGridCus.DataSource, "Sex");
            //   datepickerDateOfBirth.DataBindings.Add("Value", dataGridCus.DataSource, "DateOfBirth");
            //   txbPhoneNumber.DataBindings.Add("Text", dataGridCus.DataSource, "PhoneNumber");
            //   txbAddress.DataBindings.Add("Text", dataGridCus.DataSource, "Address");
        }

        private void fCustomer_Load(object sender, EventArgs e)
        {
            Hienthidanhsach();
            dataGridCus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridCus.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dataGridCus.ScrollBars = ScrollBars.Both;
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DataBinding();
        }
        private void DataBindingOld()
        {
            txbIDCustomer.DataBindings.Clear();
            txbFullName.DataBindings.Clear();
            txbIDCard.DataBindings.Clear();
            comboBoxCustomerType.DataBindings.Clear();
            comboBoxSex.DataBindings.Clear();
            datepickerDateOfBirth.DataBindings.Clear();
            txbPhoneNumber.DataBindings.Clear();
            txbAddress.DataBindings.Clear();
            txbNationality.DataBindings.Clear();

            txbIDCustomer.DataBindings.Add("Text", dataGridCus.DataSource, "IDCustomer");
            txbFullName.DataBindings.Add("Text", dataGridCus.DataSource, "Name");
            txbIDCard.DataBindings.Add("Text", dataGridCus.DataSource, "IDCard");
            comboBoxCustomerType.DataBindings.Add("Text", dataGridCus.DataSource, "IDCustomerType");
            comboBoxSex.DataBindings.Add("Text", dataGridCus.DataSource, "Sex");
            datepickerDateOfBirth.DataBindings.Add("Value", dataGridCus.DataSource, "DateOfBirth");
            txbPhoneNumber.DataBindings.Add("Text", dataGridCus.DataSource, "PhoneNumber");
            txbAddress.DataBindings.Add("Text", dataGridCus.DataSource, "Diachi");
            txbNationality.DataBindings.Add("Text", dataGridCus.DataSource, "Nationality");
        }
        private void DataBinding()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridCus.DataSource;

            txbIDCustomer.DataBindings.Clear();
            txbFullName.DataBindings.Clear();
            txbIDCard.DataBindings.Clear();
            comboBoxCustomerType.DataBindings.Clear();
            comboBoxSex.DataBindings.Clear();
            datepickerDateOfBirth.DataBindings.Clear();
            txbPhoneNumber.DataBindings.Clear();
            txbAddress.DataBindings.Clear();
            txbNationality.DataBindings.Clear();

            txbIDCustomer.DataBindings.Add("Text", bindingSource, "IDCustomer", true, DataSourceUpdateMode.Never);
            txbFullName.DataBindings.Add("Text", bindingSource, "Name", true, DataSourceUpdateMode.Never);
            txbIDCard.DataBindings.Add("Text", bindingSource, "IDCard", true, DataSourceUpdateMode.Never);
            comboBoxCustomerType.DataBindings.Add("Text", bindingSource, "NameCustomerType", true, DataSourceUpdateMode.Never);
            comboBoxSex.DataBindings.Add("Text", bindingSource, "Sex", true, DataSourceUpdateMode.Never);
            datepickerDateOfBirth.DataBindings.Add("Value", bindingSource, "DateOfBirth", true, DataSourceUpdateMode.Never);
            txbPhoneNumber.DataBindings.Add("Text", bindingSource, "PhoneNumber", true, DataSourceUpdateMode.Never);
            txbAddress.DataBindings.Add("Text", bindingSource, "Diachi", true, DataSourceUpdateMode.Never);
            txbNationality.DataBindings.Add("Text", bindingSource, "Nationality", true, DataSourceUpdateMode.Never);

            dataGridCus.DataSource = bindingSource;
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
            string query = $"SELECT Customer.IDCustomer AS IDCustomer, Customer.IDCard AS IDCard, CustomerType.NameCustomerType AS NameCustomerType , Customer.Name AS Name, Customer.DateOfBirth AS DateOfBirth, Customer.Diachi AS Diachi, Customer.PhoneNumber AS PhoneNumber,Customer.Sex AS Sex, Customer.Nationality AS Nationality FROM Customer INNER JOIN CustomerType ON Customer.IDCustomerType = CustomerType.IDCustomerType;";
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

        /*
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
        */
        private void CheckAdminPermission(string username, string password)
        {
            if (username != "admin" || password != "admin")
            {
                txbIDCustomer.Enabled = false;
                txbFullName.Enabled = false;
                txbIDCard.Enabled = false;
                comboBoxCustomerType.Enabled = false;
                comboBoxSex.Enabled = false ;
                //datepickerDateOfBirth.Enabled = false;
                txbPhoneNumber.Enabled = false;
                txbAddress.Enabled = false;
                txbNationality.Enabled = false;
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

            if (txbFullName.Text == string.Empty)
            {
                cMessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDCard.Text))
            {
                cMessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                cMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                cMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            string query = "UPDATE Customer SET IDCustomer=@IDCustomer, IDCard = @IDCard, IDCustomerType = @IDCustomerType, Name = @Name, DateOfBirth = @DateOfBirth, Diachi=@Diachi, PhoneNumber = @PhoneNumber, Sex=@Sex, Nationality=@Nationality WHERE IDCustomer = @IDCustomer";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDCustomer", txbIDCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@IDCard", txbIDCard.Text.Trim());
                    command.Parameters.AddWithValue("@IDCustomerType", comboBoxCustomerType.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Name", txbFullName.Text.Trim());
                    command.Parameters.AddWithValue("@DateOfBirth", datepickerDateOfBirth.Value);
                    command.Parameters.AddWithValue("@Diachi", txbAddress.Text.Trim());
                    command.Parameters.AddWithValue("@PhoneNumber", txbPhoneNumber.Text);
                    command.Parameters.AddWithValue("@Sex", comboBoxSex.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Nationality", txbNationality.Text.Trim());

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
            Hienthidanhsach();
            DataBinding();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {


            if (txbFullName.Text == string.Empty)
            {
                cMessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDCard.Text))
            {
                cMessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                cMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                cMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string userName = txbFullName.Text.Trim();
            string idCard = txbIDCard.Text.Trim();
            string sex = comboBoxSex.SelectedItem.ToString();
            DateTime dateOfBirth = datepickerDateOfBirth.Value;
            string phoneNumber = txbPhoneNumber.Text.Trim();
            string address = txbAddress.Text.Trim();
            string countQuery = "SELECT COUNT(*) FROM Customer";
            string id;
            using (SqlConnection connect = new SqlConnection(strCon))
            {
                connect.Open();
                using (SqlCommand countCommand = new SqlCommand(countQuery, connect))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    id = "NV" + (totalCount + 1).ToString("D2");
                }
                connect.Close();
            }


            string query = "INSERT INTO Customer (IDCustomer,FullName,DisplayName,PassWord, IDCard, DateOfBirthStaff,SexStaff, AddressStaff,PhoneNumberStaff ,StartDay) " +
                           "VALUES (@IDStaff,@UserName,@DisplayName,@PassWord, @IDCardStaff, @DateOfBirthStaff,@SexStaff, @AddressStaff,@PhoneNumberStaff,@StartDay)";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDStaff", id);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@PassWord", "default");
                    command.Parameters.AddWithValue("@IDCardStaff", idCard);
                    command.Parameters.AddWithValue("@DateOfBirthStaff", dateOfBirth);
                    command.Parameters.AddWithValue("@SexStaff", sex);
                    command.Parameters.AddWithValue("@AddressStaff", address);
                    command.Parameters.AddWithValue("@PhoneNumberStaff", phoneNumber);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        cMessageBox.Show("Nhân viên đã được thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cMessageBox.Show("Không thể thêm mới nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Hienthidanhsach();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void txbIDCustomer_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            if (this.userName != "admin" || passWord != "admin")
            {
                cMessageBox.Show("Bạn không có quyền thêm thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbFullName.Text == string.Empty)
            {
                cMessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDCard.Text))
            {
                cMessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string idCard = txbIDCard.Text.Trim();
            string idcus = txbIDCustomer.Text.Trim();
            bool isDuplicateIDCard = false;

            string queryCheckDuplicateIDCard = "SELECT COUNT(*) FROM Customer WHERE IDCard = @IDCard";
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicateIDCard, connection))
                {
                    command.Parameters.AddWithValue("@IDCard", idCard);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicateIDCard = true;
                    }
                }
            }

            if (isDuplicateIDCard)
            {
                cMessageBox.Show("Số căn cước/ CMND đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                cMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phoneNumber = txbPhoneNumber.Text.Trim();
            bool isDuplicatePhoneNumber = false;
            string queryCheckDuplicatePhoneNumber = "SELECT COUNT(*) FROM Customer WHERE PhoneNumber = @PhoneNumber";
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicatePhoneNumber, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicatePhoneNumber = true;
                    }
                }
            }

            if (isDuplicatePhoneNumber)
            {
                cMessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                cMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string Name = txbFullName.Text.Trim();
            string sex = comboBoxSex.SelectedItem.ToString();
            string nametype = comboBoxCustomerType.SelectedItem.ToString();
            string idtype = "";
            if (nametype == "Khách du lịch") idtype = "LK001";
            if (nametype == "Khách địa phương") idtype = "LK002";
            if (nametype == "Khách vãng lai") idtype = "LK003";
            if (nametype == "Khách từ bên thứ 3") idtype = "LK004";
            DateTime dateOfBirth = datepickerDateOfBirth.Value;
            string address = txbAddress.Text.Trim();
            string nation = txbNationality.Text.Trim();
            string countQuery = "SELECT COUNT(*) FROM Customer";
            string id;
            using (SqlConnection connect = new SqlConnection(strCon))
            {
                connect.Open();
                using (SqlCommand countCommand = new SqlCommand(countQuery, connect))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    id = "KH" + (totalCount + 1).ToString("D3");
                }
                connect.Close();
            }


            string query = "INSERT INTO Customer (IDCustomer,IDCard,IDCustomerType,Name,DateOfBirth,Diachi,PhoneNumber,Sex,Nationality) " +
                           "VALUES (@IDCustomer,@IDCard,@IDCustomerType,@Name,@DateOfBirth,@Diachi,@PhoneNumber,@Sex,@Nationality)";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDCustomer", id);
                    command.Parameters.AddWithValue("@IDCard", idCard);
                    command.Parameters.AddWithValue("@IDCustomerType", idtype);
                    command.Parameters.AddWithValue("@Name", Name);
                    command.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    command.Parameters.AddWithValue("@Diachi", address);
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@Sex", sex);
                    command.Parameters.AddWithValue("@Nationality", nation);

                    connection.Open();

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        cMessageBox.Show("Nhân viên đã được thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        cMessageBox.Show("Không thể thêm mới nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            Hienthidanhsach();
            DataBinding();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if (this.userName != "admin" || passWord != "admin")
            {
                cMessageBox.Show("Bạn không có quyền cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbFullName.Text == string.Empty)
            {
                cMessageBox.Show("Tên không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidID(txbIDCard.Text))
            {
                cMessageBox.Show("Số căn cước/ CMND không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string idCard = txbIDCard.Text.Trim();
            string idcus = txbIDCustomer.Text.Trim();
            bool isDuplicateIDCard = false;

            string queryCheckDuplicateIDCard = "SELECT COUNT(*) FROM Customer WHERE IDCard = @IDCard AND IDCustomer != @IDCustomer";
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicateIDCard, connection))
                {
                    command.Parameters.AddWithValue("@IDCard", idCard);
                    command.Parameters.AddWithValue("@IDCustomer", idcus);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicateIDCard = true;
                    }
                }
            }

            if (isDuplicateIDCard)
            {
                cMessageBox.Show("Số căn cước/ CMND đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!IsValidPhoneNumber(txbPhoneNumber.Text))
            {
                cMessageBox.Show("Số điện thoại không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string phoneNumber = txbPhoneNumber.Text.Trim();
            bool isDuplicatePhoneNumber = false;
            string queryCheckDuplicatePhoneNumber = "SELECT COUNT(*) FROM Customer WHERE PhoneNumber = @PhoneNumber AND IDCustomer != IDCustomer";
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicatePhoneNumber, connection))
                {
                    command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@IDCustomer", idcus);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicatePhoneNumber = true;
                    }
                }
            }

            if (isDuplicatePhoneNumber)
            {
                cMessageBox.Show("Số điện thoại đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (datepickerDateOfBirth.Value > DateTime.Now.Date)
            {
                cMessageBox.Show("Ngày sinh không thể lớn hơn ngày hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            string nametype = comboBoxCustomerType.SelectedItem.ToString();
            string idtype = "";
            if (nametype == "Khách du lịch") idtype = "LK001";
            if (nametype == "Khách địa phương") idtype = "LK002";
            if (nametype == "Khách vãng lai") idtype = "LK003";
            if (nametype == "Khách từ bên thứ 3") idtype = "LK004";
            DateTime dateOfBirth = datepickerDateOfBirth.Value;
            string query = "UPDATE Customer SET IDCustomer=@IDCustomer, IDCard = @IDCard, IDCustomerType = @IDCustomerType, Name = @Name, DateOfBirth = @DateOfBirth, Diachi=@Diachi, PhoneNumber = @PhoneNumber, Sex=@Sex, Nationality=@Nationality WHERE IDCustomer = @IDCustomer";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IDCustomer", txbIDCustomer.Text.Trim());
                    command.Parameters.AddWithValue("@IDCard", txbIDCard.Text.Trim());
                    command.Parameters.AddWithValue("@IDCustomerType", idtype);
                    command.Parameters.AddWithValue("@Name", txbFullName.Text.Trim());
                    command.Parameters.AddWithValue("@DateOfBirth", datepickerDateOfBirth.Value);
                    command.Parameters.AddWithValue("@Diachi", txbAddress.Text.Trim());
                    command.Parameters.AddWithValue("@PhoneNumber", txbPhoneNumber.Text);
                    command.Parameters.AddWithValue("@Sex", comboBoxSex.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@Nationality", txbNationality.Text.Trim());

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
            Hienthidanhsach();
            DataBinding();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fieldToSearch = cbCustomerSearch.SelectedItem.ToString();
            string searchValue = txbSearch.Text.Trim();
            if (searchValue == string.Empty)
            {
                cMessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $"SELECT Customer.IDCustomer AS IDCustomer, Customer.IDCard AS IDCard, CustomerType.NameCustomerType AS NameCustomerType , Customer.Name AS Name, Customer.DateOfBirth AS DateOfBirth, Customer.Diachi AS Diachi, Customer.PhoneNumber AS PhoneNumber,Customer.Sex AS Sex, Customer.Nationality AS Nationality FROM Customer INNER JOIN CustomerType ON Customer.IDCustomerType = CustomerType.IDCustomerType WHERE {fieldToSearch} LIKE '%' + @SearchValue + '%';";

            using (SqlConnection connection = new SqlConnection(strCon))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();


                    dataGridCus.DataSource = dataTable;

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow firstRow = dataTable.Rows[0];
                        txbIDCustomer.Text = firstRow["IDCustomer"].ToString();
                        txbIDCard.Text = firstRow["IDCard"].ToString();
                        comboBoxCustomerType.SelectedItem = firstRow["NameCustomerType"].ToString();
                        txbFullName.Text = firstRow["Name"].ToString();
                        datepickerDateOfBirth.Value = (DateTime)firstRow["DateOfBirth"];
                        txbAddress.Text = firstRow["Diachi"].ToString();
                        txbPhoneNumber.Text = firstRow["PhoneNumber"].ToString();
                        comboBoxSex.SelectedItem = firstRow["Sex"].ToString();
                        txbNationality.SelectedItem = firstRow["Nationality"].ToString();
                    }
                    else
                    {
                        txbIDCustomer.Text = string.Empty;
                        txbIDCard.Text = string.Empty;
                        comboBoxCustomerType.SelectedIndex = -1;
                        txbFullName.Text = string.Empty;
                        datepickerDateOfBirth.Value = DateTime.Now;
                        txbAddress.Text = string.Empty;
                        txbPhoneNumber.Text = string.Empty;
                        comboBoxSex.SelectedIndex = -1;
                        txbNationality.SelectedItem = string.Empty;
                        cMessageBox.Show("Không tìm thấy dữ liệu cho thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            btnSearch.Visible = false;
            btnCancel.Visible = true;
            DataBinding();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hienthidanhsach();
            DataBinding();
            dataGridCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnSearch.Visible = true;
        }
    }
}
