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
        private string profile;
        private string profileEvent = "NONE";
        private bool profileChanged = false;
        private int numberOfLEDs;
        private bool turnedOn = true;
        private Socket sock = new Socket(AddressFamily.InterNetwork,SocketType.Dgram,ProtocolType.Udp);
        private List<LED> LEDs = new List<LED>();
        private ScreenTracker screen = new ScreenTracker();
        private AudioTracker audio = new AudioTracker();
        public RPiComm rpi = new RPiComm("192.168.0.36",5005);


        public LEDStrip(Color col, string prof, int num)
        {
            this.color = col;
            this.profile = prof;
            this.numberOfLEDs = num;
            initializeStrip();
            setLEDs();
            runTimer();
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

        //Output LEDs to RPi - per local definition
        private void setLEDs()
        {
            string message = profile + ";" + profileEvent + ";";
            for (int i = 0; i < numberOfLEDs; i++)
            {
                message = message + LEDs[i].Index.ToString() + ";" + LEDs[i].Red.ToString() + ";" + LEDs[i].Green.ToString() + ";" + LEDs[i].Blue.ToString() + ";" + LEDs[i].Brightness.ToString() + ";";
            }
            if (profile == "GAMING" || profile == "MUSIC")
            {
                rpi.sendMessage(message, 1);
            }
            else
            {
                rpi.sendMessage(message);
            }
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

        private void runTimer()
        {
            System.Timers.Timer aTimer = new System.Timers.Timer(10000);

            aTimer.Elapsed += new ElapsedEventHandler(RunEvent);
            aTimer.Interval = 5;
            aTimer.Enabled = true;
        }

        private void RunEvent(object source, ElapsedEventArgs e)
        {
            updateLEDs();
        }

        private void constantProfile()
        {
            if (profileChanged)
            {
                setLEDs();
                profileChanged = false;
            }
            if (colorChanged)
            {
                setLEDs();
                colorChanged = false;
            }
        }

        private void strobeProfile()
        {
            if (profileChanged)
            {
                setLEDs();
                profileChanged = false;
            }
            if (colorChanged)
            {
                setLEDs(); ;
                colorChanged = false;
            }
        }

        private void pulseProfile()
        {
            if (profileChanged)
            {
                setLEDs();
                profileChanged = false;
            }
            if (colorChanged)
            {
                setLEDs();
                colorChanged = false;
            }
        }

        private void gamingProfile()
        {
            profileEvent = audio.mic.screamType;
            if (profileEvent == "NONE")
            {
                this.Color = screen.getDominantColor();
            }
            setLEDs();
        }

        private void musicProfile()
        {
            int startLeft = (numberOfLEDs/2) - 1;
            int endLeft = 0;
            int startRight = (numberOfLEDs / 2);
            int endRight = numberOfLEDs - 1;
            int currentVolume = audio.speakers.getPlaybackLevel(); 
            decimal numActivedec = (numberOfLEDs/2) * (currentVolume/100m);
            int numActive = (int)numActivedec;
            for (int i = startRight; i <= endRight; i++)
            {
                if ((i - startRight) > numActive)
                {
                    LEDs[i].setColor(Color.Black);
                }
                else
                {
                    LEDs[i].setColor(this.Color);
                }
            }
            for (int j = startLeft; j >= endLeft; j--)
            {
                if ((startLeft - j) < numActive)
                {
                    LEDs[j].setColor(this.Color);      
                }
                else
                {
                    LEDs[j].setColor(Color.Black);
                }
            }
            setLEDs();
        }

        private void demoProfile()
        {
            if (profileChanged)
            {
                setLEDs();
                profileChanged = false;
            }
            if (colorChanged)
            {
                setLEDs(); ;
                colorChanged = false;
            }
        }
    }
}
