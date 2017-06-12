using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDStripController
{
    public partial class MainForm : Form
    {
        private bool isTurnedOn = false;
        private LEDStrip Strip = new LEDStrip(Color.Red,"CONSTANT",60);
        private bool mouseDown;
        private Point lastLocation;


        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeTimer();
            profileSelectionBox.Items.Add("CONSTANT");
            profileSelectionBox.Items.Add("STROBE");
            profileSelectionBox.Items.Add("PULSE");
            profileSelectionBox.Items.Add("MUSIC");
            profileSelectionBox.Items.Add("GAMING");
            profileSelectionBox.Items.Add("DEMO");
            profileSelectionBox.SelectedItem = "CONSTANT";
            colorBox.BackColor = Color.Red;

            IPtextBox.Text = Strip.rpi.IPAddr;
            PortTextBox.Text = Strip.rpi.Port.ToString();
            numLEDsTextBox.Text = Strip.NumberOfLEDs.ToString();
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void profileSelectionBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string pickedProfile = null;
            pickedProfile = profileSelectionBox.SelectedItem.ToString();

            if (pickedProfile != Strip.Profile)
            {
                Strip.Profile = pickedProfile;
                Strip.Color = colorBox.BackColor;
            }
        }


        private void exitButton_Click(object sender, EventArgs e)
        {
            Strip.toggleOnOff(false);
            this.Close();
        }

        private void onButton_CheckedChanged(object sender, EventArgs e)
        {
            isTurnedOn = onButton.Checked;
            Strip.Color = colorBox.BackColor;
            Strip.toggleOnOff(isTurnedOn);
        }

        private void onButton_Click(object sender, EventArgs e)
        {
            if (onButton.Checked && !isTurnedOn)
            {
                onButton.Checked = false;
            }
            else
            {
                onButton.Checked = true;
                isTurnedOn = false;
            }
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = 3000;
            mainTimer.Tick += new EventHandler(mainTimer_Tick);
            mainTimer.Enabled = true;
        }

        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (Strip.rpi.connected)
            {
                AppLabel.Text = "LED CONTROLLER - CONNECTED";
                onButton.ForeColor = Color.Green;
                profileSelectionBox.Enabled = true;
                if ((Strip.Profile == "GAMING") || (Strip.Profile == "MUSIC") || (Strip.Profile== "DEMO"))
                {
                    colorBox.Enabled = false;
                } 
                else
                {
                    colorBox.Enabled = true;
                }
            }
            else
            {
                onButton.ForeColor = Color.Red;
                AppLabel.Text = "LED CONTROLLER - NOT CONNECTED";
                profileSelectionBox.Enabled = false;
                colorBox.Enabled = false;
            }
        }

        private void colorBox_Click(object sender, EventArgs e)
        {
            ColorDialog cDlg = new ColorDialog();
            if (cDlg.ShowDialog() == DialogResult.OK)
            {
                Color pickedColor;
                pickedColor = cDlg.Color;
                if (pickedColor != Strip.Color)
                {
                    Strip.Color = pickedColor;
                }
                colorBox.BackColor = cDlg.Color;
            }
        }

        private void rpiSettingsButton_Click(object sender, EventArgs e)
        {
            Strip.rpi.IPAddr = IPtextBox.Text;
            Strip.rpi.Port = int.Parse(PortTextBox.Text);
            Strip.NumberOfLEDs = int.Parse(numLEDsTextBox.Text);
            if (Strip.rpi.checkConnection())
            {
                AppLabel.Text = "LED CONTROLLER - NOT CONNECTED";
            }
            else
            {
                AppLabel.Text = "LED CONTROLLER - CONNECTED";
            }
        }
    }
}
