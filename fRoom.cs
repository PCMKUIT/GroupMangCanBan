using MetroFramework.Controls;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Data;
using System.Collections.Generic;
using System;

namespace HotelManager
{
    public partial class fRoom : Form
    {
        string connectstring = @"Data Source=PHAMCAOMINHKIEN\SQL;Initial Catalog=hotelmanager;Integrated Security=True";
        private string userName;
        private string passWord;
        bool first_time = true;
        public fRoom(string username, string password)
        {
            this.userName = username;
            this.passWord = password;
            InitializeComponent();
            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

            comboBoxStatusRoom.Items.Add("Trống");
            comboBoxStatusRoom.Items.Add("Có người");
            comboBoxStatusRoom.SelectedItem = "Trống";
            comboBoxRoomType.Items.Add("Phòng tiêu chuẩn");
            comboBoxRoomType.Items.Add("Phòng đôi");
            comboBoxRoomType.Items.Add("Phòng tiện ích");
            comboBoxRoomType.Items.Add("Phòng tổng thống");
            comboBoxRoomType.SelectedItem = "Phòng tiêu chuẩn";

            comboboxID.DataBindings.Add("Text", dataGridViewRoom.DataSource, "IDRoom");
            txbNameRoom.DataBindings.Add("Text", dataGridViewRoom.DataSource, "NameRoom");
            comboBoxStatusRoom.DataBindings.Add("Text", dataGridViewRoom.DataSource, "NameStatusRoom");
            comboBoxRoomType.DataBindings.Add("Text", dataGridViewRoom.DataSource, "NameRoomType");
            txbPrice.DataBindings.Add("Text", dataGridViewRoom.DataSource, "Price");
            txbLimitPerson.DataBindings.Add("Text", dataGridViewRoom.DataSource, "LimitPerson");

            CheckAdminPermission(username, password);
        }
        private void CheckAdminPermission(string username, string password)
        {
            if (username != "admin" || password != "admin")
            {
                comboboxID.Enabled = false;
                txbNameRoom.Enabled = false;
                comboBoxStatusRoom.Enabled = false;
                comboBoxRoomType.Enabled = false;
                txbPrice.Enabled = false;
                txbLimitPerson.Enabled = false;
            }
        }

        private void LoadDataToDataGridView()
        {
            string query = "SELECT Room.IDRoom AS IDRoom, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, RoomType.Price AS Price, RoomType.LimitPerson AS LimitPerson, StatusRoom.NameStatusRoom AS NameStatusRoom FROM Room INNER JOIN StatusRoom ON Room.IDStatusRoom = StatusRoom.IDStatusRoom INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType;";
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
            dataGridViewRoom.DataSource = dataTable;
            if (first_time)
            {
                List<string> idRooms = new List<string>();
                foreach (DataRow row in dataTable.Rows)
                {
                    idRooms.Add(row["IDRoom"].ToString());
                }
                comboboxID.DataSource = idRooms;
                first_time = false;
            }
        }

        private void bunifuImageButton1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnCLose1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, System.EventArgs e)
        {
            string searchValue = txbSearch.Text.Trim();
            if (searchValue == string.Empty)
            {
                MessageBox.Show("Vui lòng nhập thông tin trước khi tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = $"SELECT Room.IDRoom AS IDRoom, Room.NameRoom AS NameRoom, RoomType.NameRoomType AS NameRoomType, RoomType.Price AS Price, RoomType.LimitPerson AS LimitPerson, StatusRoom.NameStatusRoom AS NameStatusRoom FROM Room INNER JOIN StatusRoom ON Room.IDStatusRoom = StatusRoom.IDStatusRoom INNER JOIN RoomType ON Room.IDRoomType = RoomType.IDRoomType WHERE IDRoom LIKE '%{searchValue}%' OR NameRoom LIKE '%{searchValue}%';";

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


                    dataGridViewRoom.DataSource = dataTable;

                    if (dataTable.Rows.Count > 0)
                    {
                        DataRow firstRow = dataTable.Rows[0];
                        comboboxID.SelectedItem = firstRow["IDRoom"].ToString();
                        txbNameRoom.Text = firstRow["NameRoom"].ToString();
                        comboBoxStatusRoom.SelectedItem = firstRow["NameStatusRoom"].ToString();
                        comboBoxRoomType.SelectedItem = firstRow["NameRoomType"].ToString();
                        txbPrice.Text = firstRow["Price"].ToString();
                        txbLimitPerson.Text = firstRow["LimitPerson"].ToString();
                    }
                    else
                    {
                        comboboxID.SelectedItem = -1;
                        txbNameRoom.Text = string.Empty;
                        comboBoxStatusRoom.SelectedItem = -1;
                        comboBoxRoomType.SelectedItem = -1;
                        txbPrice.Text = string.Empty;
                        txbLimitPerson.Text = string.Empty ;
                        MessageBox.Show("Không tìm thấy dữ liệu cho thông tin đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            btnSearch.Visible = false;
            btnCancel.Visible = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnSearch.Visible = true;
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            if (this.userName != "admin" || passWord != "admin")
            {
                MessageBox.Show("Bạn không có quyền thêm thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbNameRoom.Text == string.Empty)
            {
                MessageBox.Show("Tên phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string roomName = txbNameRoom.Text;
            string roomNumber = roomName.Substring(6);
            if (roomName.Length != 9 || !roomName.StartsWith("Phòng ") || !int.TryParse(roomNumber, out int number))
            {
                MessageBox.Show("Tên phòng phải có định dạng (Phòng ___).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isDuplicate = false;
            string queryCheckDuplicate = "SELECT COUNT(*) FROM Room WHERE NameRoom = @NameRoom";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicate, connection))
                {
                    command.Parameters.AddWithValue("@NameRoom", roomName);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicate = true;
                    }
                    connection.Close();
                }
            }

            if (isDuplicate)
            {
                MessageBox.Show("Phòng này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbPrice.Text == string.Empty)
            {
                MessageBox.Show("Giá phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txbPrice.Text, out int price) || price < 1000)
            {
                    MessageBox.Show("Giá phòng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            if (txbLimitPerson.Text == string.Empty)
            {
                MessageBox.Show("Số người tối đa trong phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txbLimitPerson.Text, out int limitPerson) || limitPerson <= 0 || limitPerson > 12)
            {
                MessageBox.Show("Số người tối đa trong phòng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ID = comboboxID.SelectedItem.ToString();
            string nameRoom = txbNameRoom.Text.Trim();
            string statusRoom = comboBoxStatusRoom.SelectedItem.ToString();
            string idstatusRoom = "";
            if (statusRoom == "Trống")  idstatusRoom = "1"; 
            if (statusRoom == "Có người")  idstatusRoom = "2"; 
            string roomType = comboBoxRoomType.SelectedItem.ToString();
            string idroomType = "";
            if (roomType == "Phòng tổng thống") idroomType = "LP001";
            if (roomType == "Phòng đôi") idroomType = "LP002";
            if (roomType == "Phòng tiện ích") idroomType = "LP003";
            if (roomType == "Phòng tiêu chuẩn") idroomType = "LP004";
            string Price = txbPrice.Text.Trim();
            string LimitPerson = txbLimitPerson.Text.Trim();
            string countQuery = "SELECT COUNT(*) FROM Room";
            string id;
            using (SqlConnection connect = new SqlConnection(connectstring))
            {
                connect.Open();
                using (SqlCommand countCommand = new SqlCommand(countQuery, connect))
                {
                    int totalCount = (int)countCommand.ExecuteScalar();
                    id = "PH" + (totalCount + 1).ToString("D3");
                }
                connect.Close();
            }

            int rowsAffected;
            string queryroom = @"INSERT INTO Room (IDRoom,NameRoom,IDRoomType,IDStatusRoom) VALUES (@IDRoom,@NameRoom,@IDRoomType,@IDStatusRoom);";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(queryroom, connection))
                {
                    command.Parameters.AddWithValue("@IDRoom", id);
                    command.Parameters.AddWithValue("@NameRoom", nameRoom);
                    command.Parameters.AddWithValue("@IDRoomType", idroomType);
                    command.Parameters.AddWithValue("@IDStatusRoom", idstatusRoom);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }          


            if (rowsAffected > 0)
            {
                MessageBox.Show("Phòng đã được thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể thêm phòng mới.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.userName != "admin" || passWord != "admin")
            {
                MessageBox.Show("Bạn không có quyền cập nhật thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbNameRoom.Text == string.Empty)
            {
                MessageBox.Show("Tên phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string roomName = txbNameRoom.Text;
            string roomNumber = roomName.Substring(6);
            if (roomName.Length != 9 || !roomName.StartsWith("Phòng ") || !int.TryParse(roomNumber, out int number))
            {
                MessageBox.Show("Tên phòng phải có định dạng (Phòng ___).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool isDuplicate = false;
            string queryCheckDuplicate = "SELECT COUNT(*) FROM Room WHERE NameRoom = @NameRoom AND IDRoom != @IDRoom";
            string IDroom = comboboxID.SelectedItem.ToString();
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(queryCheckDuplicate, connection))
                {
                    command.Parameters.AddWithValue("@NameRoom", roomName);
                    command.Parameters.AddWithValue("@IDRoom", IDroom);
                    connection.Open();

                    int count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        isDuplicate = true;
                    }
                    connection.Close();
                }
            }

            if (isDuplicate)
            {
                MessageBox.Show("Phòng này đã tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txbPrice.Text == string.Empty)
            {
                MessageBox.Show("Giá phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txbPrice.Text, out int price) || price < 1000)
            {
                MessageBox.Show("Giá phòng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txbLimitPerson.Text == string.Empty)
            {
                MessageBox.Show("Số người tối đa trong phòng không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(txbLimitPerson.Text, out int limitPerson) || limitPerson <= 0 || limitPerson > 12)
            {
                MessageBox.Show("Số người tối đa trong phòng không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ID = comboboxID.SelectedItem.ToString();
            string nameRoom = txbNameRoom.Text.Trim();
            string statusRoom = comboBoxStatusRoom.SelectedItem.ToString();
            string idstatusRoom = "";
            if (statusRoom == "Trống") idstatusRoom = "1";
            if (statusRoom == "Có người") idstatusRoom = "2";
            string roomType = comboBoxRoomType.SelectedItem.ToString();
            string idroomType = "";
            if (roomType == "Phòng tổng thống") idroomType = "LP001";
            if (roomType == "Phòng đôi") idroomType = "LP002";
            if (roomType == "Phòng tiện ích") idroomType = "LP003";
            if (roomType == "Phòng tiêu chuẩn") idroomType = "LP004";
            string Price = txbPrice.Text.Trim();
            string LimitPerson = txbLimitPerson.Text.Trim();

            int rowsAffected;
  
            string queryroom = "UPDATE Room SET NameRoom=@NameRoom, IDRoomType = @IDRoomType, IDStatusRoom = @IDStatusRoom WHERE NameRoom=@NameRoom AND IDRoom=@ID";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                using (SqlCommand command = new SqlCommand(queryroom, connection))
                {
                    command.Parameters.AddWithValue("@NameRoom", nameRoom);
                    command.Parameters.AddWithValue("@IDRoomType", idroomType);
                    command.Parameters.AddWithValue("@IDStatusRoom", idstatusRoom);
                    command.Parameters.AddWithValue("@ID", ID);
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                }
            }

            if (rowsAffected > 0)
            {
                MessageBox.Show("Phòng đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnRoomType_Click(object sender, EventArgs e)
        {
            if (userName != "admin" || passWord != "admin")
            {
                MessageBox.Show("Bạn không có quyền xóa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ID = comboboxID.SelectedItem.ToString();
            string nameRoom = txbNameRoom.Text.Trim();
            string query = $"DELETE FROM Room WHERE NameRoom=@NameRoom AND IDRoom=@ID";

            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(query, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@ID", ID);
                            command.Parameters.AddWithValue("@NameRoom", nameRoom);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Phòng đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                DataTable dataTable = new DataTable();

                                using (SqlCommand selectCommand = new SqlCommand("SELECT IDRoom FROM Room ORDER BY CAST(SUBSTRING(IDRoom, 3, 3) AS INT)", connection, transaction))
                                {
                                    using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
                                    {
                                        adapter.Fill(dataTable);
                                    }
                                }

                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    string oldID = dataTable.Rows[i]["IDRoom"].ToString();
                                    int newIndex = i + 1;
                                    string newID = "PH" + newIndex.ToString("D3");

                                    string updateQuery = "UPDATE Room SET IDRoom = @NewID WHERE IDRoom = @OldID";

                                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection, transaction))
                                    {
                                        updateCommand.Parameters.AddWithValue("@NewID", newID);
                                        updateCommand.Parameters.AddWithValue("@OldID", oldID);
                                        updateCommand.ExecuteNonQuery();
                                    }
                                }
                                transaction.Commit();
                            }
                            else
                            {
                                MessageBox.Show("Không tìm thấy phòng có thông tin này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                transaction.Rollback();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        transaction.Rollback();
                    }
                }
            }


            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            LoadDataToDataGridView();
            dataGridViewRoom.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            btnSearch.Visible = true;
        }
    }
}
