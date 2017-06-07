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
            int level = screamLevel();
            if(level > 8)
            {
                screaming = true;
                if (level > 8 && level < 20)
                {
                    profileEvent = "YELLOWSCREAM";
                }
                else if (level >= 20)
                {
                    profileEvent = "REDSCREAM";
                }
                setLEDs();
                profileEvent = "NONE";
            }
            else
            {
                this.Color = getDominantColor();
                setLEDs();
            }
        }


        private int screamLevel()
        {
            if (!screaming)
            {
                MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
                MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
                float currVolume = defaultDevice.AudioMeterInformation.MasterPeakValue;
                return (int)(currVolume * 100);
            }
            else
            {
                return 0;
            }
        }

        public void runTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(10000);

            aTimer.Elapsed += new ElapsedEventHandler(RunEvent);
            aTimer.Interval = 1000;
            aTimer.Enabled = true;
        }

        //This method will get called every second until the timer stops or the program exits.
        public void RunEvent(object source, ElapsedEventArgs e)
        {
            if (screaming)
            {
                screamCoolDownCounter++;
                if (screamCoolDownCounter == 5)
                {
                    screaming = false;
                    screamCoolDownCounter = 0;
                }
            }
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

        public Color getDominantColor()
        {
            using (Bitmap bmp = new Bitmap(SystemInformation.VirtualScreen.Width, SystemInformation.VirtualScreen.Height, PixelFormat.Format32bppArgb))
            {
                using (Graphics screenGraph = Graphics.FromImage(bmp))
                {
                    screenGraph.CopyFromScreen(SystemInformation.VirtualScreen.X, SystemInformation.VirtualScreen.Y, 0, 0, SystemInformation.VirtualScreen.Size, CopyPixelOperation.SourceCopy);

                    if (bmp == null)
                    {
                        throw new ArgumentNullException("bmp");
                    }

                    BitmapData srcData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, bmp.PixelFormat);
                    int bytesPerPixel = Image.GetPixelFormatSize(srcData.PixelFormat) / 8;

                    int stride = srcData.Stride;

                    IntPtr scan0 = srcData.Scan0;

                    long[] totals = new long[] { 0, 0, 0 };

                    int width = bmp.Width * bytesPerPixel;
                    int height = bmp.Height;

                    unsafe
                    {
                        byte* p = (byte*)(void*)scan0;

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x += bytesPerPixel)
                            {
                                totals[0] += p[x + 0];
                                totals[1] += p[x + 1];
                                totals[2] += p[x + 2];
                            }

                            p += stride;
                        }
                    }

                    long pixelCount = bmp.Width * height;

                    int avgB = Convert.ToInt32(totals[0] / pixelCount);
                    int avgG = Convert.ToInt32(totals[1] / pixelCount);
                    int avgR = Convert.ToInt32(totals[2] / pixelCount);

                    bmp.UnlockBits(srcData);
                    srcData = null;
                    return Color.FromArgb(avgR, avgG, avgB);
                }
            }
        }
    }
}
