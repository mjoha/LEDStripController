using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEDStripController
{
    class LED
    {
        private int index;
        private int red;
        private int green;
        private int blue;
        private int brightness;

        public LED(int i, int r, int g, int b)
        {
            this.index = i;
            this.red = r;
            this.green = g;
            this.blue = b;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public int Red
        {
            get { return red; }
            set { red = value; }
        }

        public int Green
        {
            get { return green; }
            set { green = value; }
        }

        public int Blue
        {
            get { return blue; }
            set { blue = value; }
        }

        public int Brightness
        {
            get { return brightness; }
            set { brightness = value; }
        }

        public void setColor(Color color)
        {
            red = color.R;
            green = color.G;
            blue = color.B;
        }
    }
}
