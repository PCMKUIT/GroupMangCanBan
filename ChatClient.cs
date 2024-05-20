using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class ChatClient : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private Thread listenThread;

        public ChatClient()
        {
            InitializeComponent();
            this.FormClosing += ChatClient_FormClosing;
            this.Load += ChatClient_Load;
        }

        private void ChatClient_Load(object sender, EventArgs e)
        {
            ConnectToServer();
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
                MessageBox.Show("Error connecting to server: " + ex.Message);
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
                    string msg = Encoding.ASCII.GetString(message, 0, bytesRead);
                    lv1.Items.Add(msg); // Assuming you have a ListView named lv1
                }));
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            string message = tbmessage.Text;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            try
            {
                stream.Write(messageBytes, 0, messageBytes.Length);
            }
            catch (Exception ex)
            {
                // Handle stream writing errors here
                MessageBox.Show("Error sending message: " + ex.Message);
            }
        }
    }
}
