using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fChatClient : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;
        string _username;
        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        SqlDataReader reader;
        public fChatClient(string username)
        {
            InitializeComponent();
            _username = username;
            txbID.Text = _username;
            lv1.View = View.Details;
            lv1.Columns.Add("Messages", -2, HorizontalAlignment.Left);
            lv1.Font = new Font("Segoe UI", 10f);
            lv1.ForeColor = Color.Gold; // Change the text color here
            cbSearch.Items.Add("search by Name");
            cbSearch.Items.Add("search by Message");
            this.FormClosing += ChatClient_FormClosing;
            this.Load += ChatClient_Load;
            btnCancel.Visible = false;

        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            ConnectToServer();
            LoadMessagesFromDatabase();
        }
        private void LoadMessagesFromDatabase()
        {
            using (con = new SqlConnection(connectstring))
            {
                con.Open();
                using (cmd = new SqlCommand("SELECT Message, Timestamp FROM ChatMessages ORDER BY Timestamp", con))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = reader.GetString(0);
                            DateTime timestamp = reader.GetDateTime(1);
                            lv1.Items.Add($"{timestamp}: {message}");
                        }
                    }
                }
            }
        }
        private void ChatClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            listenThread?.Abort();
            stream?.Close();
            client?.Close();
        }

        private void ConnectToServer()
        {
            try
            {
                client = new TcpClient("localhost", 8000);
                stream = client.GetStream();
                listenThread = new Thread(new ThreadStart(ListenForMessages));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                // Handle connection errors here
                cMessageBox.Show("Error connecting to server: " + ex.Message);
                btSend.Enabled = false;
            }
        }

        private void ListenForMessages()
        {
            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = stream.Read(message, 0, 4096);
                }
                catch
                {
                    // Handle stream reading errors here
                    break;
                }

                if (bytesRead == 0)
                {
                    // The server has disconnected
                    break;
                }

                Invoke(new Action(() =>
                {
                    string msg = Encoding.UTF8.GetString(message, 0, bytesRead);
                    lv1.Items.Add(msg); // Assuming you have a ListView named lv1
                }));
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string message = $"{_username}| {tbmessage.Text}";
            string timestamp = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            string msgWithTimestamp = $"{timestamp}| {message}";
            byte[] messageBytes = Encoding.UTF8.GetBytes(msgWithTimestamp);

            try
            {
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex)
            {
                // Handle errors here
                cMessageBox.Show("Error sending message: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            lv1.Items.Clear();
            string searchTerm = tbmessage.Text; // Assuming you have a TextBox named tbSearch
            SearchListView(searchTerm);
            btnCancel.Visible = true;
            btSearch.Visible = false;
        }
        private void SearchListView(string searchTerm)
        {
            string query = "";
            if (cbSearch.SelectedItem == null)
            {
                cMessageBox.Show("Please select a search option");
                return;
            }
            switch (cbSearch.SelectedItem.ToString())
            {
                case "search by Name":
                    query = "SELECT Message, Timestamp FROM ChatMessages WHERE UserName LIKE @SearchTerm ORDER BY Timestamp";
                    break;
                case "search by Message":
                    query = "SELECT Message, Timestamp FROM ChatMessages WHERE Message LIKE @SearchTerm ORDER BY Timestamp";
                    break;
            }

            using (con = new SqlConnection(connectstring))
            {
                con.Open();
                using (cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");

                    using (reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string message = reader.GetString(0);
                            DateTime timestamp = reader.GetDateTime(1);
                            lv1.Items.Add($"{timestamp}: {message}");
                        }
                    }
                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadMessagesFromDatabase();
            btnCancel.Visible = false;
            btSearch.Visible = true;
        }

        private void bt_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
