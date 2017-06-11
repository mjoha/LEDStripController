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
            this.label1 = new System.Windows.Forms.Label();
            this.profileSelectionBox = new System.Windows.Forms.ComboBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorBox = new System.Windows.Forms.PictureBox();
            this.exitButton = new System.Windows.Forms.Button();
            this.onButton = new System.Windows.Forms.RadioButton();
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Choose profile:";
            // 
            // profileSelectionBox
            // 
            this.profileSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.profileSelectionBox.FormattingEnabled = true;
            this.profileSelectionBox.Location = new System.Drawing.Point(12, 30);
            this.profileSelectionBox.Name = "profileSelectionBox";
            this.profileSelectionBox.Size = new System.Drawing.Size(152, 22);
            this.profileSelectionBox.TabIndex = 1;
            this.profileSelectionBox.SelectedIndexChanged += new System.EventHandler(this.profileSelectionBox_SelectedIndexChanged);
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(12, 83);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(109, 23);
            this.colorButton.TabIndex = 3;
            this.colorButton.Text = "Change color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.colorBotton_Click);
            // 
            // colorBox
            // 
            this.colorBox.Location = new System.Drawing.Point(127, 73);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(36, 33);
            this.colorBox.TabIndex = 4;
            this.colorBox.TabStop = false;
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(12, 112);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // onButton
            // 
            this.onButton.AutoSize = true;
            this.onButton.Checked = true;
            this.onButton.Location = new System.Drawing.Point(12, 59);
            this.onButton.Name = "onButton";
            this.onButton.Size = new System.Drawing.Size(60, 18);
            this.onButton.TabIndex = 6;
            this.onButton.TabStop = true;
            this.onButton.Text = "On/Off";
            this.onButton.UseVisualStyleBackColor = true;
            this.onButton.CheckedChanged += new System.EventHandler(this.onButton_CheckedChanged);
            this.onButton.Click += new System.EventHandler(this.onButton_Click);
            // 
            // mainTimer
            // 
            this.mainTimer.Tick += new System.EventHandler(this.mainTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(180, 160);
            this.Controls.Add(this.onButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.profileSelectionBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.Text = "LED Strip Controller";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.colorBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox profileSelectionBox;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.PictureBox colorBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.RadioButton onButton;
        private System.Windows.Forms.Timer mainTimer;
    }
}

