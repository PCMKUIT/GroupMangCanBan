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

    public partial class fReceiveRoom : Form
    {
        string connectstring = @"Data Source=NHDK\SQLEXPRESS;Initial Catalog=hotelmanager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
        //string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        private string userName;
        public fReceiveRoom(string username)
        {
            this.userName = username;
            InitializeComponent();
            LoadDataToDataGridView();
            dataGridViewReceiveRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            metroComboBox1.Items.Clear();
            metroComboBox1.Items.Add("Name");
            metroComboBox1.Items.Add("IDCard");
            metroComboBox1.Items.Add("NameRoom");
            metroComboBox1.Items.Add("NameRoomType");
            metroComboBox1.Items.Add("DateCheckIn");
            metroComboBox1.Items.Add("DateCheckOut");
            metroComboBox1.Items.Add("LimitPerson");
            metroComboBox1.Items.Add("Price");
            metroComboBox1.SelectedItem = "Name";
            InitializeComboBox();
            DataBinding();
        }

        private void DataBinding()
        {
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridViewReceiveRoom.DataSource;

            txbFullName.DataBindings.Clear();
            txbIDCard.DataBindings.Clear();
            txbRoomName.DataBindings.Clear();
            txbRoomTypeName.DataBindings.Clear();
            txbDateCheckIn.DataBindings.Clear();
            txbDateCheckOut.DataBindings.Clear();
            txbAmountPeople.DataBindings.Clear();
            txbPrice.DataBindings.Clear();

            txbFullName.DataBindings.Add("Text", bindingSource, "Name", true, DataSourceUpdateMode.Never);
            txbIDCard.DataBindings.Add("Text", bindingSource, "IDCard", true, DataSourceUpdateMode.Never);
            txbRoomName.DataBindings.Add("Text", bindingSource, "NameRoom", true, DataSourceUpdateMode.Never);
            txbRoomTypeName.DataBindings.Add("Text", bindingSource, "NameRoomType", true, DataSourceUpdateMode.Never);
            txbDateCheckIn.DataBindings.Add("Text", bindingSource, "DateCheckIn", true, DataSourceUpdateMode.Never);
            txbDateCheckOut.DataBindings.Add("Text", bindingSource, "DateCheckOut", true, DataSourceUpdateMode.Never);
            txbAmountPeople.DataBindings.Add("Text", bindingSource, "LimitPerson", true, DataSourceUpdateMode.Never);
            txbPrice.DataBindings.Add("Text", bindingSource, "Price", true, DataSourceUpdateMode.Never);
           
            dataGridViewReceiveRoom.DataSource = bindingSource;
        }
        private void LoadDataToDataGridView()
        {
            string query =  "SELECT Customer.Name AS Name, Customer.IDCard AS IDCard, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, BookRoom.DateCheckIn AS DateCheckIn, BookRoom.DateCheckOut AS DateCheckOut, RoomType.LimitPerson AS LimitPerson, RoomType.Price AS Price " +
                            "FROM ReceiveRoom " +
                            "INNER JOIN BookRoom ON ReceiveRoom.IDBookRoom = BookRoom.IDBookRoom " +
                            "INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom " +
                            "INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType " +
                            "INNER JOIN Customer ON BookRoom.IDCustomer = Customer.IDCustomer " +
                            "WHERE BookRoom.DateCheckIn >= @currentDate;";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@currentDate", DateTime.Now.Date);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            dataGridViewReceiveRoom.DataSource = dataTable;
        }
        private void InitializeComboBox()
        {
            cbRoomType.Items.Clear();
            cbRoomType.Items.Add("Phòng tiêu chuẩn");
            cbRoomType.Items.Add("Phòng đôi");
            cbRoomType.Items.Add("Phòng tiện ích");
            cbRoomType.Items.Add("Phòng tổng thống");
            cbRoomType.SelectedItem = "Phòng tiêu chuẩn";

            cbRoomType.SelectedIndexChanged += new EventHandler(cbRoomType_SelectedIndexChanged);

            LoadRoomsBasedOnRoomType(cbRoomType.SelectedItem.ToString());
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoomsBasedOnRoomType(cbRoomType.SelectedItem.ToString());
        }

        private void LoadRoomsBasedOnRoomType(string roomType)
        {
            string query = "SELECT DISTINCT Room.NameRoom AS NameRoom " +
                           "FROM ReceiveRoom " +
                           "INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom " +
                           "INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType " +
                           "WHERE Room.IDStatusRoom = 1 AND RoomType.NameRoomType = @RoomType;";

            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                }
            }
            cbRoom.Items.Clear();
            foreach (DataRow row in dataTable.Rows)
            {
                cbRoom.Items.Add(row["NameRoom"].ToString());
            }


            if (cbRoom.Items.Count > 0)
            {
                cbRoom.SelectedIndex = 0;
            }
        }







        private void btnSearch_Click(object sender, EventArgs e)
        {
            string fieldToSearch = metroComboBox1.SelectedItem.ToString();
            string searchValue = txbSearch.Text.Trim();
            if (searchValue == string.Empty)
            {
                cMessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = "";
            if (btnDisplay.Visible == false)
            {
                query = "SELECT Customer.Name AS Name, Customer.IDCard AS IDCard, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, BookRoom.DateCheckIn AS DateCheckIn, BookRoom.DateCheckOut AS DateCheckOut, RoomType.LimitPerson AS LimitPerson, RoomType.Price AS Price " +
                        "FROM ReceiveRoom " +
                        "INNER JOIN BookRoom ON ReceiveRoom.IDBookRoom = BookRoom.IDBookRoom " +
                        "INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom " +
                        "INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType " +
                        "INNER JOIN Customer ON BookRoom.IDCustomer = Customer.IDCustomer " +
                        $"WHERE BookRoom.DateCheckIn >= @currentDate AND {fieldToSearch} LIKE '%' + @SearchValue + '%';";
            }
            else
            {
                query = "SELECT Customer.Name AS Name, Customer.IDCard AS IDCard, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, BookRoom.DateCheckIn AS DateCheckIn, BookRoom.DateCheckOut AS DateCheckOut, RoomType.LimitPerson AS LimitPerson, RoomType.Price AS Price " +
                        "FROM ReceiveRoom " +
                        "INNER JOIN BookRoom ON ReceiveRoom.IDBookRoom = BookRoom.IDBookRoom " +
                        "INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom " +
                        "INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType " +
                        "INNER JOIN Customer ON BookRoom.IDCustomer = Customer.IDCustomer " +
                        $"WHERE {fieldToSearch} LIKE '%' + @SearchValue + '%';";
            }

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@SearchValue", searchValue);
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    connection.Close();


                    dataGridViewReceiveRoom.DataSource = dataTable;

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow firstRow = dataTable.Rows[0];
                        txbFullName.Text = firstRow["Name"].ToString();
                        txbIDCard.Text = firstRow["IDCard"].ToString();
                        txbRoomName.Text = firstRow["NameRoom"].ToString();
                        txbRoomTypeName.Text = firstRow["NameRoomType"].ToString();
                        txbDateCheckIn.Text = firstRow["DateCheckIn"].ToString();
                        txbDateCheckOut.Text = firstRow["DateCheckOut"].ToString();
                        txbAmountPeople.Text = firstRow["LimitPerson"].ToString();
                        txbPrice.Text = firstRow["Price"].ToString();
                    }
                    else
                    {
                        txbFullName.Text = string.Empty;
                        txbIDCard.Text = string.Empty;
                        txbRoomName.Text = string.Empty;
                        txbRoomTypeName.Text = string.Empty;
                        txbDateCheckIn.Text = string.Empty;
                        txbDateCheckOut.Text = string.Empty;
                        txbAmountPeople.Text = string.Empty;
                        txbPrice.Text = string.Empty;
                        cMessageBox.Show("Không tìm thấy dữ liệu cho thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            btnSearch.Visible = false;
            btnCancel.Visible = true;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dataGridViewReceiveRoom.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewReceiveRoom.SelectedRows[0];
                string idBookRoom = selectedRow.Cells["IDBookRoom"].Value.ToString();

                // Lấy thông tin từ bảng BookRoom
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectstring))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SELECT DateCheckIn FROM BookRoom WHERE IDBookRoom = @IDBookRoom", connection);
                        command.Parameters.AddWithValue("@IDBookRoom", idBookRoom);


                        object dateCheckIn = command.ExecuteScalar();
                        if (dateCheckIn != null && dateCheckIn != DBNull.Value)
                        {
                            txbDateCheckIn.Text = ((DateTime)dateCheckIn).ToString("dd/MM/yyyy");
                        }
                        else
                        {
                            txbDateCheckIn.Text = "";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin DateCheckIn từ BookRoom: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDisplayAll_Click(object sender, EventArgs e)
        {
            ClearData();
            string query = "SELECT Customer.Name AS Name, Customer.IDCard AS IDCard, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, BookRoom.DateCheckIn AS DateCheckIn, BookRoom.DateCheckOut AS DateCheckOut, RoomType.LimitPerson AS LimitPerson, RoomType.Price AS Price FROM ReceiveRoom INNER JOIN BookRoom ON ReceiveRoom.IDBookRoom = BookRoom.IDBookRoom INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType INNER JOIN Customer ON BookRoom.IDCustomer = Customer.IDCustomer;";
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
            dataGridViewReceiveRoom.DataSource = dataTable;
            dataGridViewReceiveRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DataBinding();
            btnDisplayAll.Visible = false;
            btnDisplay.Visible = true;
            btnSearch.Visible = true;
            btnCancel.Visible = false;
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadDataToDataGridView();
            dataGridViewReceiveRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            DataBinding();
            btnDisplayAll.Visible = true;
            btnDisplay.Visible = false;
            btnSearch.Visible = true;
            btnCancel.Visible = false;
        }

        private void ClearData()
        {
            txbFullName.Text = "";
            txbIDCard.Text = "";
            txbRoomName.Text = "";
            txbRoomTypeName.Text = "";
            txbDateCheckIn.Text = "";
            txbDateCheckOut.Text = "";
            txbAmountPeople.Text = "";
            txbPrice.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnDisplay.Visible == false)
            {
                ClearData();
                LoadDataToDataGridView();
                dataGridViewReceiveRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                DataBinding();
            }
            else
            {
                ClearData();
                string query = "SELECT Customer.Name AS Name, Customer.IDCard AS IDCard, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, BookRoom.DateCheckIn AS DateCheckIn, BookRoom.DateCheckOut AS DateCheckOut, RoomType.LimitPerson AS LimitPerson, RoomType.Price AS Price FROM ReceiveRoom INNER JOIN BookRoom ON ReceiveRoom.IDBookRoom = BookRoom.IDBookRoom INNER JOIN Room ON Room.IDRoom = ReceiveRoom.IDRoom INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType INNER JOIN Customer ON BookRoom.IDCustomer = Customer.IDCustomer;";
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
                dataGridViewReceiveRoom.DataSource = dataTable;
                dataGridViewReceiveRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                DataBinding();
            }
            btnSearch.Visible = true;
            btnCancel.Visible = false;
        }

        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {

        }
    }
}
