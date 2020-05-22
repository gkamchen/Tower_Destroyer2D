using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Base
{
    public class Client
    {
        private string ip;
        private int port;
        private ThreadRead threadRead;
        private ThreadWrite threadWrite;

        public Client(string ip, int port)
        {
            this.ip = ip;
            this.port = port;
        }

        public void Connect(EventHandler OnReceiveMessage)
        {
            TcpClient tcpClient = new TcpClient();

            tcpClient.Connect(IPAddress.Parse(this.ip), this.port);

            NetworkStream networkStream = tcpClient.GetStream();

            this.threadRead = new ThreadRead(networkStream);
            this.threadRead.OnReceiveMessage += OnReceiveMessage;

            this.threadWrite = new ThreadWrite(new BinaryWriter(networkStream));

            this.threadRead.Start();
            this.threadWrite.Start();
        }

        public void SendMessage(dynamic message)
        {
            this.threadWrite.SendMessage(message);
        }

        public void Close()
        {
            this.threadRead.Stop();
            this.threadWrite.Stop();
        }
    }
}
