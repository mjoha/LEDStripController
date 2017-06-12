using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace LEDStripController
{
    class RPiComm
    {
        private string ipaddr;
        private int port;
        private Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        public bool connected = false;

        public RPiComm(string ip, int p)
        {
            ipaddr = ip;
            port = p;
            runTimer();
            connected = checkConnection();
        }

        public String IPAddr
        {
            get { return ipaddr; }
            set
            {
                ipaddr = value;
            }
        }
        public int Port
        {
            get { return port; }
            set
            {
                port = value;
            }
        }


        public bool checkConnection()
        {
            Ping pinger = new Ping();
            bool pingable = false;
            try
            {
                PingReply reply = pinger.Send(IPAddress.Parse(ipaddr), 20);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                //disregard and return false
            }
            connected = pingable;
            return pingable;
        }

        public void sendMessage(string message, int count = 5)
        {
            for (int i = 0; i <= count; i++)
            {
                sendUDP(message);
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

        private void runTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(10000);

            aTimer.Elapsed += new ElapsedEventHandler(RunEvent);
            aTimer.Interval = 10000;
            aTimer.Enabled = true;
        }

        private void RunEvent(object source, ElapsedEventArgs e)
        {
            connected = checkConnection();
        }
    }
}
