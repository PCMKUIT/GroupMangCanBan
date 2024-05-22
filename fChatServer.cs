using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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
        SqlDataAdapter adapter;
        SqlDataReader reader;
        public fChatServer(string username)
        {
            InitializeComponent();
            _username = username;
            txbID.Text = _username;
            lv1.DrawItem += lv1_DrawItem;
            lv1.DrawSubItem += lv1_DrawSubItem;
            lv1.View = View.Details;
            lv1.Columns.Add("Messages", -2, HorizontalAlignment.Left);
            this.FormClosing += fChatServer_FormClosing;
            this.Load += fChatServer_Load;
        }
        private void lv1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = false;

            using (Font font = new Font("Segoe UI", 10f)) // Change the font size here
            {
                using (SolidBrush brush = new SolidBrush(Color.White)) // Change the text color here
                {
                    e.Graphics.DrawString(e.Item.Text, font, brush, e.Bounds);
                }
            }
        }
        private void lv1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = false;

            using (Font font = new Font("Segoe UI", 10f)) // Change the font size here
            {
                using (SolidBrush brush = new SolidBrush(Color.White)) // Change the text color here
                {
                    e.Graphics.DrawString(e.SubItem.Text, font, brush, e.Bounds);
                }
            }
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
                    lv1.Items.Add(msgWithTimestamp); // Assuming you have a ListView named lv1
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
            string searchTerm = tbmessage.Text; // Assuming you have a TextBox named tbSearch
            SearchListView(searchTerm);
        }
        private void SearchListView(string searchTerm)
        {
            foreach (ListViewItem item in lv1.Items)
            {
                if (item.Text.Contains(searchTerm))
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    break;
                }
            }
        }
    }
}
