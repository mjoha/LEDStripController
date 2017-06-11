namespace LEDStripController
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.profileSelectionBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.RadioButton();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.AppLabel = new System.Windows.Forms.Label();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.autoPage = new System.Windows.Forms.TabPage();
            this.manPage = new System.Windows.Forms.TabPage();
            this.settingsPage = new System.Windows.Forms.TabPage();
            this.settingsControl = new System.Windows.Forms.TabControl();
            this.RPiPage = new System.Windows.Forms.TabPage();
            this.PrioPage = new System.Windows.Forms.TabPage();
            this.ProfilePage = new System.Windows.Forms.TabPage();
            this.ApplicationPage = new System.Windows.Forms.TabPage();
            this.IPLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.NumLEDsLabel = new System.Windows.Forms.Label();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.numLEDsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.mainTabControl.SuspendLayout();
            this.manPage.SuspendLayout();
            this.settingsPage.SuspendLayout();
            this.settingsControl.SuspendLayout();
            this.RPiPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // profileSelectionBox
            // 
            this.profileSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSelectionBox.FormattingEnabled = true;
            this.profileSelectionBox.Location = new System.Drawing.Point(6, 50);
            this.profileSelectionBox.Name = "profileSelectionBox";
            this.profileSelectionBox.Size = new System.Drawing.Size(152, 26);
            this.profileSelectionBox.TabIndex = 1;
            this.profileSelectionBox.SelectedIndexChanged += new System.EventHandler(this.profileSelectionBox_SelectedIndexChanged);
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(6, 82);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(152, 26);
            this.colorBox.TabIndex = 4;
            this.colorBox.TabStop = false;
            this.colorBox.Click += new System.EventHandler(this.colorBox_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(369, 9);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(27, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // onButton
            // 
            this.onButton.Checked = true;
            this.onButton.Location = new System.Drawing.Point(348, 9);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(15, 23);
            this.onButton.TabIndex = 6;
            this.onButton.TabStop = true;
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.CheckedChanged += new System.EventHandler(this.onButton_CheckedChanged);
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // AppLabel
            // 
            this.AppLabel.AutoSize = true;
            this.AppLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppLabel.Location = new System.Drawing.Point(8, 9);
            this.AppLabel.Name = "AppLabel";
            this.AppLabel.Size = new System.Drawing.Size(127, 19);
            this.AppLabel.TabIndex = 8;
            this.AppLabel.Text = "LED CONTROLLER";
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.autoPage);
            this.mainTabControl.Controls.Add(this.manPage);
            this.mainTabControl.Controls.Add(this.settingsPage);
            this.mainTabControl.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTabControl.ItemSize = new System.Drawing.Size(115, 23);
            this.mainTabControl.Location = new System.Drawing.Point(12, 39);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(384, 236);
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.mainTabControl.TabIndex = 9;
            // 
            // autoPage
            // 
            this.autoPage.Location = new System.Drawing.Point(4, 27);
            this.autoPage.Name = "autoPage";
            this.autoPage.Padding = new System.Windows.Forms.Padding(3);
            this.autoPage.Size = new System.Drawing.Size(376, 205);
            this.autoPage.TabIndex = 0;
            this.autoPage.Text = "AUTOMATIC";
            this.autoPage.UseVisualStyleBackColor = true;
            // 
            // manPage
            // 
            this.manPage.Controls.Add(this.profileSelectionBox);
            this.manPage.Controls.Add(this.colorBox);
            this.manPage.Location = new System.Drawing.Point(4, 27);
            this.manPage.Name = "manPage";
            this.manPage.Padding = new System.Windows.Forms.Padding(3);
            this.manPage.Size = new System.Drawing.Size(376, 205);
            this.manPage.TabIndex = 1;
            this.manPage.Text = "MANUAL";
            this.manPage.UseVisualStyleBackColor = true;
            // 
            // settingsPage
            // 
            this.settingsPage.Controls.Add(this.settingsControl);
            this.settingsPage.Location = new System.Drawing.Point(4, 27);
            this.settingsPage.Name = "settingsPage";
            this.settingsPage.Size = new System.Drawing.Size(376, 205);
            this.settingsPage.TabIndex = 2;
            this.settingsPage.Text = "SETTINGS";
            this.settingsPage.UseVisualStyleBackColor = true;
            // 
            // settingsControl
            // 
            this.settingsControl.Controls.Add(this.RPiPage);
            this.settingsControl.Controls.Add(this.PrioPage);
            this.settingsControl.Controls.Add(this.ProfilePage);
            this.settingsControl.Controls.Add(this.ApplicationPage);
            this.settingsControl.ItemSize = new System.Drawing.Size(80, 25);
            this.settingsControl.Location = new System.Drawing.Point(4, 4);
            this.settingsControl.Multiline = true;
            this.settingsControl.Name = "settingsControl";
            this.settingsControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.settingsControl.SelectedIndex = 0;
            this.settingsControl.Size = new System.Drawing.Size(369, 198);
            this.settingsControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.settingsControl.TabIndex = 0;
            // 
            // RPiPage
            // 
            this.RPiPage.Controls.Add(this.numLEDsTextBox);
            this.RPiPage.Controls.Add(this.PortTextBox);
            this.RPiPage.Controls.Add(this.IPtextBox);
            this.RPiPage.Controls.Add(this.NumLEDsLabel);
            this.RPiPage.Controls.Add(this.PortLabel);
            this.RPiPage.Controls.Add(this.IPLabel);
            this.RPiPage.Location = new System.Drawing.Point(4, 29);
            this.RPiPage.Name = "RPiPage";
            this.RPiPage.Padding = new System.Windows.Forms.Padding(3);
            this.RPiPage.Size = new System.Drawing.Size(361, 165);
            this.RPiPage.TabIndex = 0;
            this.RPiPage.Text = "RASPBERRY";
            this.RPiPage.UseVisualStyleBackColor = true;
            // 
            // PrioPage
            // 
            this.PrioPage.Location = new System.Drawing.Point(4, 29);
            this.PrioPage.Name = "PrioPage";
            this.PrioPage.Padding = new System.Windows.Forms.Padding(3);
            this.PrioPage.Size = new System.Drawing.Size(361, 165);
            this.PrioPage.TabIndex = 1;
            this.PrioPage.Text = "PRIO";
            this.PrioPage.UseVisualStyleBackColor = true;
            // 
            // ProfilePage
            // 
            this.ProfilePage.Location = new System.Drawing.Point(4, 29);
            this.ProfilePage.Name = "ProfilePage";
            this.ProfilePage.Size = new System.Drawing.Size(361, 165);
            this.ProfilePage.TabIndex = 2;
            this.ProfilePage.Text = "PROFILES";
            this.ProfilePage.UseVisualStyleBackColor = true;
            // 
            // ApplicationPage
            // 
            this.ApplicationPage.Location = new System.Drawing.Point(4, 29);
            this.ApplicationPage.Name = "ApplicationPage";
            this.ApplicationPage.Size = new System.Drawing.Size(361, 165);
            this.ApplicationPage.TabIndex = 3;
            this.ApplicationPage.Text = "APP";
            this.ApplicationPage.UseVisualStyleBackColor = true;
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(11, 18);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(24, 18);
            this.IPLabel.TabIndex = 0;
            this.IPLabel.Text = "IP:";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(108, 51);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(38, 18);
            this.PortLabel.TabIndex = 1;
            this.PortLabel.Text = "Port:";
            // 
            // NumLEDsLabel
            // 
            this.NumLEDsLabel.AutoSize = true;
            this.NumLEDsLabel.Location = new System.Drawing.Point(106, 84);
            this.NumLEDsLabel.Name = "NumLEDsLabel";
            this.NumLEDsLabel.Size = new System.Drawing.Size(40, 18);
            this.NumLEDsLabel.TabIndex = 2;
            this.NumLEDsLabel.Text = "LEDs:";
            // 
            // IPtextBox
            // 
            this.IPtextBox.Location = new System.Drawing.Point(41, 15);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.Size = new System.Drawing.Size(165, 26);
            this.IPtextBox.TabIndex = 3;
            this.IPtextBox.TextChanged += new System.EventHandler(this.IPtextBox_TextChanged);
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(152, 48);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(54, 26);
            this.PortTextBox.TabIndex = 4;
            this.PortTextBox.TextChanged += new System.EventHandler(this.PortTextBox_TextChanged);
            // 
            // numLEDsTextBox
            // 
            this.numLEDsTextBox.Location = new System.Drawing.Point(152, 81);
            this.numLEDsTextBox.Name = "numLEDsTextBox";
            this.numLEDsTextBox.Size = new System.Drawing.Size(54, 26);
            this.numLEDsTextBox.TabIndex = 5;
            this.numLEDsTextBox.TextChanged += new System.EventHandler(this.numLEDsTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(408, 286);
            this.ControlBox = false;
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.AppLabel);
            this.Controls.Add(this.exitButton);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "LED Strip Controller";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.mainTabControl.ResumeLayout(false);
            this.manPage.ResumeLayout(false);
            this.settingsPage.ResumeLayout(false);
            this.settingsControl.ResumeLayout(false);
            this.RPiPage.ResumeLayout(false);
            this.RPiPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox profileSelectionBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.RadioButton onButton;
        private System.Windows.Forms.Timer mainTimer;
        private System.Windows.Forms.Label AppLabel;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage autoPage;
        private System.Windows.Forms.TabPage manPage;
        private System.Windows.Forms.TabPage settingsPage;
        private System.Windows.Forms.TabControl settingsControl;
        private System.Windows.Forms.TabPage RPiPage;
        private System.Windows.Forms.TabPage PrioPage;
        private System.Windows.Forms.TabPage ProfilePage;
        private System.Windows.Forms.TabPage ApplicationPage;
        private System.Windows.Forms.Label NumLEDsLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox numLEDsTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox IPtextBox;
    }
}

