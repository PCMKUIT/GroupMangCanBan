
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelManager
{
    public partial class fCustomer : Form
    {
        string strCon = @"Data Source=NHDK\SQLEXPRESS;Initial Catalog=hotelmanager;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        SqlConnection sqlCon = null;
        public fCustomer()
        {
            InitializeComponent();
        }

        private void fCustomer_Load(object sender, EventArgs e)
        {
            Hienthidanhsach();
        }

        private void Hienthidanhsach()
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
                string SOKH = reader.GetString(3);
                string DCHI = reader.GetString(4);  
                string QTICH =  reader.GetString(5);

                ListViewItem lvi = new ListViewItem(MAKH);  
                lvi.SubItems.Add(TENKH);
                lvi.SubItems.Add(LOAIKH);
                lvi.SubItems.Add(SOKH);
                lvi.SubItems.Add(DCHI);
                lvi.SubItems.Add(QTICH);

                lsvDanhSach.Items.Add(lvi);


            }
            reader.Close();
        }
    }
}
