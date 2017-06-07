using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Timers;

namespace LEDStripController
{
    class LEDStrip
    {
        private Color color;
        private bool colorChanged = false;
        private string ipaddr;
        private string profile;
        private string profileEvent = "NONE";
        private bool profileChanged = false;
        private bool screaming = false;
        private int screamCoolDownCounter = 0;
        private int numberOfLEDs;
        private bool turnedOn = true;
        private Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
        private List<LED> LEDs = new List<LED>();
        private ScreenTracker screen = new ScreenTracker();
        private AudioTracker audio = new AudioTracker();


        public LEDStrip(Color col, string ip, string prof, int num)
        {
            this.color = col;
            this.ipaddr = ip;
            this.profile = prof;
            this.numberOfLEDs = num;
            initializeStrip();
            runTimer();
            setLEDs();
        }

        //Initialize strip
        private void initializeStrip()
        {
            for (int i = 0; i < numberOfLEDs; i++)
            {
                LEDs.Add(new LED(i, color.R, color.G, color.B));
            }
        }


        //Turn off the strip - just the colors/communication
        private void turnOff()
        {
            for (int i = 0; i < numberOfLEDs; i++)
            {
                LEDs[i].Red = 0;
                LEDs[i].Green = 0;
                LEDs[i].Blue = 0;
            }
            setLEDs();
        }

        //Helper function 
        public void toggleOnOff(bool on)
        {
            if (!on && turnedOn)
            {
                turnOff();
            }
            else
            {
                setLEDs();
            }
            turnedOn = on;
        }


        //Should check if RPi is up and running
        public bool isAlive()
        {
            if (turnedOn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Output LEDs to RPi - per local definition
        private void setLEDs()
        {
            string udpMessage = profile + ";" + profileEvent + ";";
            for (int i = 0; i < numberOfLEDs; i++)
            {
                udpMessage = udpMessage + LEDs[i].Index.ToString() + ";" + LEDs[i].Red.ToString() + ";" + LEDs[i].Green.ToString() + ";" + LEDs[i].Blue.ToString() + ";" + LEDs[i].Brightness.ToString() + ";";
            }
            sendUDP(udpMessage);

        }

        //Getters and setters
        public Color Color
        {
            get { return color; }
            set
            {
                colorChanged = true;
                color = value;
                for (int i = 0; i < numberOfLEDs; i++)
                {
                    LEDs[i].Red = color.R;
                    LEDs[i].Green = color.G;
                    LEDs[i].Blue = color.B;
                }
            }
        }

        public string IPaddr
        {
            get { return ipaddr; }
            set { ipaddr = value; }
        }

        public string Profile
        {
            get { return profile; }
            set
            {
                profileChanged = true;
                profile = value;
            }
        }

        public int NumberOfLEDs
        {
            get { return numberOfLEDs; }
            set
            {
                if (numberOfLEDs != value)
                {
                    //TODO
                }
                numberOfLEDs = value;
            }
        }

        //Run profile
        public void updateLEDs()
        {
            if (turnedOn)
            {
                switch (profile)
                {
                    case "CONSTANT":
                        constantProfile();
                        break;
                    case "STROBE":
                        strobeProfile();
                        break;
                    case "PULSE":
                        pulseProfile();
                        break;
                    case "MUSIC":
                        musicProfile();
                        break;
                    case "GAMING":
                        gamingProfile();
                        break;
                    case "DEMO":
                        demoProfile();
                        break;
                }
            }
        }

        //Constant lightning - no need to send continusly unless the color has been changed
        private void constantProfile()
        {
            if (profileChanged)
            {
                //Send 10 messages.. since.. UDP
                for (int i = 0; i < 5; i++)
                {
                    setLEDs();
                }
                profileChanged = false;
            }
            if (colorChanged)
            {
                //Send 10 messages.. since.. UDP
                for (int i = 0; i < 5; i++)
                {
                    setLEDs();
                }
                colorChanged = false;
            }
        }

        private void strobeProfile()
        {
            if (profileChanged)
            {
                //Send 10 messages.. since.. UDP
                for (int i = 0; i < 5; i++)
                {
                    setLEDs();
                }
                profileChanged = false;
            }
            if (colorChanged)
            {
                for (int i = 0; i < 5; i++)
                {
                    setLEDs(); ;
                }
                colorChanged = false;
            }
        }

        private void pulseProfile()
        {
            if (profileChanged)
            {
                //Send 10 messages.. since.. UDP
                for (int i = 0; i < 5; i++)
                {
                    setLEDs();
                }
                profileChanged = false;
            }
            if (colorChanged)
            {
                for (int i = 0; i < 5; i++)
                {
                    setLEDs();
                }
                colorChanged = false;
            }
        }

        private void musicProfile()
        {

        }

        private void demoProfile()
        {
            if (profileChanged)
            {
                //Send 10 messages.. since.. UDP
                for (int i = 0; i < 10; i++)
                {
                    setLEDs();
                }
                profileChanged = false;
            }
            if (colorChanged)
            {
                for (int i = 0; i < 10; i++)
                {
                    setLEDs(); ;
                }
                colorChanged = false;
            }
        }

        private void gamingProfile()
        {
            profileEvent = audio.mic.screamType;
            if (profileEvent != "NONE")
            {
                this.Color = screen.getDominantColor();
            }
            setLEDs();
        }



        private void sendUDP(string str)
        {
            if (str != null)
            {
                IPAddress serverAddr = IPAddress.Parse(ipaddr);
                IPEndPoint endPoint = new IPEndPoint(serverAddr, 5005);
                byte[] sendBuffer = Encoding.ASCII.GetBytes(str);
                sock.SendTo(sendBuffer, sendBuffer.Length, SocketFlags.None, endPoint);
            }
        }
    }
}
