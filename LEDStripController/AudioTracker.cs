using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDStripController
{
    class AudioTracker
    {
        public struct Microphone
        {
        }

        public struct SpeakerOutput
        {

        }
        /*MMDeviceEnumerator devEnum = new MMDeviceEnumerator();
        MMDevice defaultDevice = devEnum.GetDefaultAudioEndpoint(DataFlow.Capture, Role.Multimedia);
        float currVolume = defaultDevice.AudioMeterInformation.MasterPeakValue;
                return (int) (currVolume* 100);*/
    }
}
