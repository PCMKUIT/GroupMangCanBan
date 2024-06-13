using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fReceiveRoom : Form
    {
        List<string> ListIDCustomer = new List<string>();
        string IDBookRoom;
        DateTime dateCheckIn;
        string connectstring = @"Data Source=NHDK\SQL;Initial Catalog=hotelmanager;Integrated Security=True";

        public fReceiveRoom(string idBookRoom)
        {
            IDBookRoom = idBookRoom;
            InitializeComponent();
            LoadData();
            ShowBookRoomInfo(IDBookRoom);
        }

        public fReceiveRoom()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            LoadListRoomType();
            LoadReceiveRoomInfo();
        }

        public void LoadListRoomType()
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM RoomType", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<RoomType> rooms = new List<RoomType>();
                while (reader.Read())
                {
                    RoomType room = new RoomType
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString()
                    };
                    rooms.Add(room);
                }
                cbRoomType.DataSource = rooms;
                cbRoomType.DisplayMember = "Name";
            }
        }

        public void LoadEmptyRoom(string idRoomType)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Room WHERE RoomTypeId = @RoomTypeId AND Status = 'Empty'", connection);
                command.Parameters.AddWithValue("@RoomTypeId", idRoomType);
                SqlDataReader reader = command.ExecuteReader();
                List<Room> rooms = new List<Room>();
                while (reader.Read())
                {
                    Room room = new Room
                    {
                        Id = reader["Id"].ToString(),
                        Name = reader["Name"].ToString()
                    };
                    rooms.Add(room);
                }
                cbRoom.DataSource = rooms;
                cbRoom.DisplayMember = "Name";
            }
        }

        public bool IsIDBookRoomExists(string idBookRoom)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM BookRoom WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", idBookRoom);
                return (int)command.ExecuteScalar() > 0;
            }
        }

        public void ShowBookRoomInfo(string idBookRoom)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM BookRoom WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", idBookRoom);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow dataRow = dataTable.Rows[0];
                    txbFullName.Text = dataRow["FullName"].ToString();
                    txbIDCard.Text = dataRow["IDCard"].ToString();
                    txbRoomTypeName.Text = dataRow["RoomTypeName"].ToString();
                    cbRoomType.Text = dataRow["RoomTypeName"].ToString();
                    txbDateCheckIn.Text = dataRow["DateCheckIn"].ToString().Split(' ')[0];
                    dateCheckIn = (DateTime)dataRow["DateCheckIn"];
                    txbDateCheckOut.Text = dataRow["DateCheckOut"].ToString().Split(' ')[0];
                    txbAmountPeople.Text = dataRow["LimitPerson"].ToString();
                    txbPrice.Text = dataRow["Price"].ToString();
                }
            }
        }

        public bool InsertReceiveRoom(string id, string idBookRoom, string idRoom)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ReceiveRoom (Id, BookRoomId, RoomId) VALUES (@Id, @BookRoomId, @RoomId)", connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@BookRoomId", idBookRoom);
                command.Parameters.AddWithValue("@RoomId", idRoom);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public bool InsertReceiveRoomDetails(string idReceiveRoom, string idCustomerOther)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ReceiveRoomDetails (ReceiveRoomId, CustomerId) VALUES (@ReceiveRoomId, @CustomerId)", connection);
                command.Parameters.AddWithValue("@ReceiveRoomId", idReceiveRoom);
                command.Parameters.AddWithValue("@CustomerId", idCustomerOther);
                return command.ExecuteNonQuery() > 0;
            }
        }

        public void LoadReceiveRoomInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ReceiveRoom", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewReceiveRoom.DataSource = dataTable;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomTypeName.Text = (cbRoomType.SelectedItem as RoomType).Name;
            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id);
        }

        private void cbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            txbRoomName.Text = cbRoom.Text;
        }

        private void txbIDBookRoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnSearch_Click(sender, null);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txbIDBookRoom.Text != string.Empty)
            {
                if (IsIDBookRoomExists(txbIDBookRoom.Text))
                {
                    btnSearch.Tag = txbIDBookRoom.Text;
                    ShowBookRoomInfo(txbIDBookRoom.Text);
                }
                else
                    MessageBox.Show("Mã đặt phòng không tồn tại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txbIDBookRoom.Text = string.Empty;
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            fCustomer customer = new fCustomer();
            customer.ShowDialog(); 
        }


        private void btnReceiveRoom_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn nhận phòng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txbRoomName.Text != string.Empty && txbRoomTypeName.Text != string.Empty && txbFullName.Text != string.Empty && txbIDCard.Text != string.Empty && txbDateCheckIn.Text != string.Empty && txbDateCheckOut.Text != string.Empty && txbAmountPeople.Text != string.Empty && txbPrice.Text != string.Empty)
                {
                    if (dateCheckIn == DateTime.Now.Date)
                    {
                        string idBookRoom;
                        if (IDBookRoom != "")
                            idBookRoom = IDBookRoom;
                        else
                            idBookRoom = btnSearch.Tag.ToString();
                        string idRoom = (cbRoom.SelectedItem as Room).Id;
                        string idReceiveRoom = GetAutomaticIDReceiveRoom();
                        if (InsertReceiveRoom(idReceiveRoom, idBookRoom, idRoom))
                        {
                            if (fCustomer.ListIdCustomer != null)
                            {
                                foreach (string item in fCustomer.ListIdCustomer)
                                {
                                    if (item != txbIDCard.Text)
                                        InsertReceiveRoomDetails(idReceiveRoom, item);
                                }
                            }
                            MessageBox.Show("Nhận phòng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadEmptyRoom((cbRoomType.SelectedItem as RoomType).Id); // Chuyển đổi về RoomType
                        }
                        else
                            MessageBox.Show("Tạo phiếu nhận phòng thất bại.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Ngày nhận phòng không hợp lệ.\nVui lòng nhập lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearData();
                    LoadReceiveRoomInfo();
                }
                else
                    MessageBox.Show("Vui lòng nhập lại đầy đủ thông tin.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void ClearData()
        {
            txbFullName.Text = txbIDCard.Text = txbRoomTypeName.Text = txbDateCheckIn.Text = txbDateCheckOut.Text = txbAmountPeople.Text = txbPrice.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private string GetAutomaticIDReceiveRoom()
        {
            return GetAutomaticID("ReceiveRoom", "ID");
        }

        private string GetAutomaticIDRoom()
        {
            return GetAutomaticID("Room", "ID");
        }

        private string GetAutomaticIDBookRoom()
        {
            return GetAutomaticID("BookRoom", "ID");
        }

        private string GetAutomaticID(string tableName, string columnName)
        {
            using (SqlConnection connection = new SqlConnection(connectstring))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT MAX(CAST(SUBSTRING({columnName}, 3, LEN({columnName}) - 2) AS INT)) + 1 FROM {tableName}", connection);
                object result = command.ExecuteScalar();
                return "ID" + (result != DBNull.Value ? result.ToString() : "1");
            }
        }
    }
}
