using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.Timers;

namespace LEDStripController
{
    class AudioTracker
    {
        public AudioTracker()
        {
        }
        public struct Microphone
        {
            private bool screaming = false;
            private int screamCoolDownCounter = 0;

            public string screamType
            {
                get
                {
                    int level = screamLevel();
                    if(level > 8)
                    {
                        screaming = true;
                        if (level > 8 && level < 20)
                        {
                            return "YELLOWSCREAM";
                        }
                        else if (level >= 20)
                        {
                            return "REDSCREAM";
                        }
                    }
                    else
                    {
                        return "NONE";
                    }
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

            private void runTimer()
            {
                System.Timers.Timer aTimer = new System.Timers.Timer(10000);

                aTimer.Elapsed += new ElapsedEventHandler(RunEvent);
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
            }

            //This method will get called every second until the timer stops or the program exits.
            private void RunEvent(object source, ElapsedEventArgs e)
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
        }

        public struct SpeakerOutput
        {

        }
        public Microphone mic = new Microphone();
        public SpeakerOutput speakers = new SpeakerOutput();
    }
}
