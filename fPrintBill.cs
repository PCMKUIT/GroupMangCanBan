
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fPrintBill : Form
    {
        public fPrintBill()
        {
            InitializeComponent();
        }
        string connectstring = @"Data Source=LAPTOP-2IQS7P3R; Database=hotelmanager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        public void SetPrintBill(string idBill, string dateOfCreate)
        {

            ShowBillPreView(idBill);
            ShowInfo(idBill);
            lblIDBill.Text = idBill.ToString();
            lblDateCreate.Text = dateOfCreate;
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select StaffSetUp from Bill b Where b.IDBill='"+idBill+"'";
            cmd.Connection = con;
            lblStaffSetUp.Text =(string)cmd.ExecuteScalar();
        }
        int id = 1;
        public void ShowBillPreView(string idBill)
        {
            listViewUseService.Items.Clear();
            DataTable dataTable1 = new DataTable();
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT D.NameService AS [Tên dịch vụ], D.PriceService AS [Đơn giá], B.soluong AS [Số lượng], B.TotalPrice AS [Thành tiền] " +
                  "FROM Bill A, BillDetails B, Service D " +
                  "WHERE A.IDStatusBill = 2 AND A.IDBill = B.IDBill AND A.IDBill = '" + idBill + "' AND B.IDService = D.IDService";

            cmd.Connection = con;
            SqlDataReader reader1 = cmd.ExecuteReader();
            dataTable1.Load(reader1);
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            int _totalPrice = 0;
            foreach (DataRow item in dataTable1.Rows)
            {
                ListViewItem listViewItem = new ListViewItem(id.ToString());
                id++;

                ListViewItem.ListViewSubItem subItem1 = new ListViewItem.ListViewSubItem(listViewItem, item["Tên dịch vụ"].ToString());
                ListViewItem.ListViewSubItem subItem2 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Đơn giá"]).ToString("c0", cultureInfo));
                ListViewItem.ListViewSubItem subItem3 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Số lượng"]).ToString());
                ListViewItem.ListViewSubItem subItem4 = new ListViewItem.ListViewSubItem(listViewItem, ((int)item["Thành tiền"]).ToString("c0", cultureInfo));


                _totalPrice += (int)item["Thành tiền"];

                listViewItem.SubItems.Add(subItem1);
                listViewItem.SubItems.Add(subItem2);
                listViewItem.SubItems.Add(subItem3);
                listViewItem.SubItems.Add(subItem4);

                listViewUseService.Items.Add(listViewItem);
            }

            ListViewItem listViewItemTotalPrice = new ListViewItem();
            ListViewItem.ListViewSubItem subItemTotalPrice = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, _totalPrice.ToString("c0", cultureInfo));
            ListViewItem.ListViewSubItem _subItem1 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem2 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            ListViewItem.ListViewSubItem _subItem3 = new ListViewItem.ListViewSubItem(listViewItemTotalPrice, "");
            listViewItemTotalPrice.SubItems.Add(_subItem1);
            listViewItemTotalPrice.SubItems.Add(_subItem2);
            listViewItemTotalPrice.SubItems.Add(_subItem3);
            listViewItemTotalPrice.SubItems.Add(subItemTotalPrice);
            listViewUseService.Items.Add(listViewItemTotalPrice);
 listViewUseService.Items.Add(listViewItemTotalPrice);
 // cập nhật Service  Price cho bill
 /*
 SqlCommand cmd1;
 cmd1 = new SqlCommand();
 cmd1.CommandType = System.Data.CommandType.Text;
 cmd1.CommandText = " update Bill set ServicePrice = " + _totalPrice + " where IDBill= '"+idBill+"'  ";
 cmd1.Connection = con;
 int k = cmd1.ExecuteNonQuery();
 if ( k > 0)
 {
     MessageBox.Show("cập nhật service price thành công");
 } 
 */
            id = 1;
            con.Close();
        }
        public void ShowInfo(string idBill)
        {
            if (con == null) { con = new SqlConnection(connectstring); }
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT D.Name AS HoTen, D.IDCard AS CMND, D.PhoneNumber AS SDT, E.NameCustomerType AS LoaiKH, D.Diachi AS DiaChi, D.Nationality AS QuocTich, F.NameRoom AS TenPhong, G.NameRoomType AS LoaiPhong, G.Price AS DonGia, C.DateCheckIn AS NgayDen, C.DateCheckOut AS NgayDi, A.RoomPrice AS TienPhong, A.ServicePrice AS TienDichVu, A.Surcharge AS PhuThu, A.TotalPrice AS ThanhTien, A.Discount AS GiamGia " +
     "FROM Bill A, ReceiveRoom B, BookRoom C, Customer D, CustomerType E, Room F, RoomType G " +
     "WHERE A.IDReceiveRoom = B.IDReceiveRoom AND B.IDBookRoom = C.IDBookRoom AND C.IDCustomer = D.IDCustomer AND D.IDCustomerType = E.IDCustomerType AND B.IDRoom = F.IDRoom AND F.IDRoomType = G.IDRoomType AND A.IDBill = '" + idBill + "'";
            cmd.Connection = con;
            DataTable dataTable = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            dataTable.Load(reader);
            DataRow data = dataTable.Rows[0];
            DateTime dateCheckIn = (DateTime)data["NgayDen"];
            DateTime dateCheckOut = (DateTime)data["NgayDi"];
            int days = dateCheckOut.Subtract(dateCheckIn).Days;
 /*
 SqlCommand cmd2;
 cmd2 = new SqlCommand();
 cmd2.CommandType = System.Data.CommandType.Text;
 int totalprice = ((int)data["DonGia"] * days + (int)data["TienDichVu"] + (int)data["PhuThu"]);
 int roomprice = (int)data["DonGia"] * days;
 cmd2.CommandText = " update Bill set RoomPrice = " + roomprice + ", TotalPrice ="+ totalprice + " "+
                                " where IDBill= '" + idBill + "'  ";
 cmd2.Connection = con;
 int k = cmd2.ExecuteNonQuery();
 if (k > 0)
 {
     MessageBox.Show("cập nhật room price thành công");
 }
 */
            CultureInfo cultureInfo = new CultureInfo("vi-vn");
            lblCustomerName.Text = data["HoTen"].ToString();
            lblIDCard.Text = data["CMND"].ToString();
            lblPhoneNumber.Text = ((int)data["SDT"]).ToString();
            lblCustomerTypeName.Text = data["LoaiKH"].ToString();
            label23.Text = data["DiaChi"].ToString();
            lblNationality.Text = data["QuocTich"].ToString();
            lblRoomName.Text = data["TenPhong"].ToString();
            lblRoomTypeName.Text = data["LoaiPhong"].ToString();
            lblRoomPrice_.Text = ((int)data["DonGia"]).ToString("c0", cultureInfo);
            lblDateCheckIn.Text = ((DateTime)data["NgayDen"]).ToString().Split(' ')[0];
            lblDays.Text = days.ToString();
            lblSurcharge.Text = ((int)data["PhuThu"]).ToString("c0", cultureInfo);
            lblServicePrice.Text = ((int)data["TienDichVu"]).ToString("c0", cultureInfo);
            lblRoomPrice.Text = ((int)data["TienPhong"]).ToString("c0", cultureInfo);
            lblTotalPrice.Text = ((int)data["ThanhTien"]).ToString("c0", cultureInfo);
            lblFinalPrice.Text = ((int)data["ThanhTien"] * ((100 - (int)data["GiamGia"]) / 100.0)).ToString("c0", cultureInfo);
            lblDiscount.Text = ((int)data["GiamGia"]).ToString() + " %";
            con.Close();
        }
    }
}
