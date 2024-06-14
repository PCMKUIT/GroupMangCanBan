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
        string strCon = @"Data Source=NHDK\SQLEXPRESS;Initial Catalog=hotelmanager;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public fReceiveRoom()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void InitializeComboBox()
        {
            cbRoomType.Items.AddRange(new object[]
            {
            "Phòng Tổng Thống",
            "Phòng Đôi",
            "Phòng Tiện Ích",
            "Phòng Tiêu Chuẩn",
            "Không"
            });

        }
        private void fReceiveRoom_Load(object sender, EventArgs e)
        {
            Hienthidanhsach();
        }
        private void dataGridViewReceiveRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewReceiveRoom.Rows.Count)
            {
                DataGridViewRow row = dataGridViewReceiveRoom.Rows[e.RowIndex];

                // Lấy IDBookRoom từ cột có tên là IDBookRoom trong DataGridView
                string idBookRoom = row.Cells["IDBookRoom"].Value.ToString();

                // Sử dụng IDBookRoom để truy vấn và lấy thông tin từ bảng BookRoom
                string query = "SELECT * FROM BookRoom WHERE IDBookRoom = @IDBookRoom";

                try
                {
                    using (SqlConnection connection = new SqlConnection(strCon))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@IDBookRoom", idBookRoom);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txbDateCheckIn.Text = reader["DateCheckin"].ToString();
                            txbDateCheckOut.Text = reader["DateCheckOut"].ToString();
                            txbFullName.Text = reader["FullName"].ToString();
                            txbIDCard.Text = reader["IDCard"].ToString();
                            txbRoomName.Text = reader["RoomName"].ToString();
                            txbRoomTypeName.Text = reader["RoomTypeName"].ToString();
                            txbPrice.Text = reader["Price"].ToString();
                            txbAmountPeople.Text = reader["AmountPeople"].ToString();
                        }
                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy thông tin từ BookRoom: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string GetIDCustomerFromBookRoom(string idBookRoom)
        {
            string idCustomer = "";

            try
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT IDCustomer FROM BookRoom WHERE IDBookRoom = @IDBookRoom", connection);
                    command.Parameters.AddWithValue("@IDBookRoom", idBookRoom);
                    idCustomer = command.ExecuteScalar()?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy IDCustomer từ BookRoom: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return idCustomer;
        }




        private void btnReceiveRoom_Click(object sender, System.EventArgs e)
        {

        }
        private void Hienthidanhsach()
        {
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM ReceiveRoom", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridViewReceiveRoom.DataSource = dataTable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string idBookRoomToSearch = txbIDBookRoom.Text.Trim();

            if (idBookRoomToSearch != string.Empty)
            {
                using (SqlConnection connection = new SqlConnection(strCon))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SELECT * FROM ReceiveRoom WHERE IDBookRoom LIKE @IDBookRoom", connection);
                    command.Parameters.AddWithValue("@IDBookRoom", "%" + idBookRoomToSearch + "%"); // Sử dụng % để cho phép tìm kiếm gần đúng
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dataGridViewReceiveRoom.DataSource = dataTable;

                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập ID để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose__Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
