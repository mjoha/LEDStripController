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

        private void colorBotton_Click(object sender, EventArgs e)
        {
            ColorDialog cDlg = new ColorDialog();
            cDlg.ShowDialog();
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
            mainTimer.Interval = 1;
            mainTimer.Tick += new EventHandler(mainTimer_Tick);
            mainTimer.Enabled = true;
        }

        //"main" loop
        private void mainTimer_Tick(object sender, EventArgs e)
        {
            if (Strip.rpi.isConnected())
            {
                profileSelectionBox.Enabled = true;
                if ((Strip.Profile == "GAMING") || (Strip.Profile == "MUSIC") || (Strip.Profile== "DEMO"))
                {
                    colorButton.Enabled = false;
                }
                else
                {
                    colorButton.Enabled = true;
                }
                Strip.updateLEDs();
            }
            else
            {
                profileSelectionBox.Enabled = false;
                colorButton.Enabled = false;
            }
        }
    }
}
