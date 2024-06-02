using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace HotelManager
{
    public partial class fChatServer : Form
    {
        private TcpListener listener;
        private Thread listenThread;
        private List<TcpClient> clients = new List<TcpClient>();
        string _username;
        string connectstring = @"Data Source=HONDAMACH\SQLEXPRESS; Database=HotelManager;Trusted_Connection=True";
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader reader;
        public fChatServer(string username)
        {
            InitializeComponent();
            _username = username;
            txbID.Text = _username;
            lv1.Font = new Font("Segoe UI", 12f);
            lv1.ForeColor = Color.Gold; // Change the text color here
            lv1.View = View.Details;
            lv1.Columns.Add("Messages", -2, HorizontalAlignment.Left);
            cbSearch.Items.Add("search by Name");
            cbSearch.Items.Add("search by Message");
            this.FormClosing += fChatServer_FormClosing;
            this.Load += fChatServer_Load;
            btnCancel.Visible = false;
        }
        
        private void fChatServer_Load(object sender, EventArgs e)
        {
            StartServer();
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
        private void StartServer()
        {
            try
            {
                listenThread = new Thread(new ThreadStart(ListenForClients));
                listenThread.Start();
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                cMessageBox.Show("Error starting server: " + ex.Message);
            }
        }

        private void ListenForClients()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, 8000);
                listener.Start();

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    clients.Add(client);
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                    clientThread.Start(client);
                }
            }
            catch (SocketException ex)
            {
                // Log or display the exception message
                cMessageBox.Show("Socket error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                cMessageBox.Show("Error accepting client: " + ex.Message);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            byte[] message = new byte[4096];
            int bytesRead;

            while (true)
            {
                bytesRead = 0;

                try
                {
                    bytesRead = clientStream.Read(message, 0, 4096);
                }
                catch
                {
                    break;
                }

                if (bytesRead == 0)
                {
                    break;
                }

                // Extract the sender's name and the message
                string msgWithTimestamp = Encoding.UTF8.GetString(message, 0, bytesRead);
                string[] parts = msgWithTimestamp.Split('|');
                string timestamp = parts[0].Trim();
                string senderName = parts[1].Trim();
                string msg = parts[2].Trim();

                // Store the message in the database
                using (con = new SqlConnection(connectstring))
                {
                    con.Open();
                    using (cmd = new SqlCommand("INSERT INTO ChatMessages (UserName, Message) VALUES (@Sender, @Message)", con))
                    {
                        cmd.Parameters.AddWithValue("@Sender", senderName);
                        cmd.Parameters.AddWithValue("@Message", msg);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Convert the message with timestamp back to bytes
                byte[] msgWithTimestampBytes = Encoding.UTF8.GetBytes(msgWithTimestamp);

                // Forward the message to all other clients
                foreach (TcpClient Client in clients)
                {

                    Client.GetStream().Write(msgWithTimestampBytes, 0, msgWithTimestampBytes.Length);

                }

                Invoke(new Action(() =>
                {   
                    if (btnCancel.Visible == false)
                    {
                        lv1.Items.Add(msgWithTimestamp);
                    }
                     // Assuming you have a ListView named lv1
                }));
            }

            tcpClient.Close();
            clients.Remove(tcpClient);
        }


        private void fChatServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                listener?.Stop();
                listenThread?.Abort();
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                cMessageBox.Show("Error closing server: " + ex.Message);
            }
        }

        private void btsend_Click(object sender, EventArgs e)
        {
            string message = $"{_username}: {tbmessage.Text}";
            string timestamp = DateTime.Now.ToString("HH:mm:ss dd/MM/yyyy");
            string msgWithTimestamp = $"{timestamp}: {message}";
            byte[] messageBytes = Encoding.UTF8.GetBytes(msgWithTimestamp);

            foreach (TcpClient client in clients)
            {
                client.GetStream().Write(messageBytes, 0, messageBytes.Length);
            }

            // Store the message in the database
            using (con = new SqlConnection(connectstring))
            {
                con.Open();
                using (cmd = new SqlCommand("INSERT INTO ChatMessages (UserName, Message) VALUES (@Sender, @Message)", con))
                {
                    cmd.Parameters.AddWithValue("@Sender", _username);
                    cmd.Parameters.AddWithValue("@Message", tbmessage.Text);
                    cmd.ExecuteNonQuery();
                }
            }

            // Add the message to the ListView
            lv1.Items.Add(msgWithTimestamp);
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


    }
}
