using System;
using System.Collections.Generic;
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

        public fChatServer()
        {
            InitializeComponent();
            this.FormClosing += fChatServer_FormClosing;
            this.Load += fChatServer_Load;
        }

        private void fChatServer_Load(object sender, EventArgs e)
        {
            StartServer();
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
                MessageBox.Show("Error starting server: " + ex.Message);
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
                MessageBox.Show("Socket error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                MessageBox.Show("Error accepting client: " + ex.Message);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            try
            {
                NetworkStream clientStream = tcpClient.GetStream();

                byte[] message = new byte[4096];
                int bytesRead;

                while (true)
                {
                    bytesRead = clientStream.Read(message, 0, 4096);

                    if (bytesRead == 0)
                    {
                        break;
                    }

                    foreach (TcpClient otherClient in clients)
                    {
                        if (otherClient != tcpClient)
                        {
                            otherClient.GetStream().Write(message, 0, bytesRead);
                        }
                    }

                    Invoke(new Action(() =>
                    {
                        string msg = Encoding.ASCII.GetString(message, 0, bytesRead);
                        lv1.Items.Add(msg);
                    }));
                }
            }
            catch (Exception ex)
            {
                // Log or display the exception message
                MessageBox.Show("Error handling client: " + ex.Message);
            }
            finally
            {
                tcpClient.Close();
                clients.Remove(tcpClient);
            }
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
                MessageBox.Show("Error closing server: " + ex.Message);
            }
        }

        private void btsend_Click(object sender, EventArgs e)
        {
            string message = tbmessage.Text;
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);

            foreach (TcpClient client in clients)
            {
                client.GetStream().Write(messageBytes, 0, messageBytes.Length);
            }
        }

    }
}
