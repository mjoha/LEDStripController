using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LEDStripController
{
    class RPiComm
    {
        private string ipaddr;
        private int port;
        private Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        public RPiComm(string ip, int p)
        {
            ipaddr = ip;
            port = p;
            connect(ipaddr, port);
        }

        public String IPAddr
        {
            get { return ipaddr; }
            set
            {
                ipaddr = value;
                connect(ipaddr, port);
            }
        }
        public int Port
        {
            get { return port; }
            set
            {
                port = value;
                connect(ipaddr, port);
            }
        }

        public bool connect(string ip, int port)
        {
            return true;
        }

        public bool isConnected()
        {
            return true;
        }

        public bool sendMessage(string message, bool acknowledge, int count = 5)
        {
            if (acknowledge)
            {
                //TODO
                return false;
            }
            else
            {
                for (int i = 0; i <= count; i++)
                {
                    sendUDP(message);
                }
                return true;
            }
        }
        private void sendUDP(string message)
        {
            if (message != null)
            {
                IPAddress ip = IPAddress.Parse(ipaddr);
                IPEndPoint endPoint = new IPEndPoint(ip, port);
                byte[] sendBuffer = Encoding.ASCII.GetBytes(message);
                sock.SendTo(sendBuffer, sendBuffer.Length, SocketFlags.None, endPoint);
            }
        }
    }
}
