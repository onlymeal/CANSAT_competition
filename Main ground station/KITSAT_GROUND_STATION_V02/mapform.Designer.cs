namespace KITSAT_GROUND_STATION_V02
{
    partial class mapform
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
            this.cmbBaud = new System.Windows.Forms.ComboBox();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.baudlabel = new System.Windows.Forms.Label();
            this.portlabel = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.gps_original = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gps_latitude = new System.Windows.Forms.TextBox();
            this.ImuValue_x = new System.Windows.Forms.TextBox();
            this.CameraCheck = new System.Windows.Forms.CheckBox();
            this.ImuCheck = new System.Windows.Forms.CheckBox();
            this.GpsCheck = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Thread_start = new System.Windows.Forms.Button();
            this.ImuValue_y = new System.Windows.Forms.TextBox();
            this.ImuValue_z = new System.Windows.Forms.TextBox();
            this.ImuValue_all = new System.Windows.Forms.TextBox();
            this.progress_x = new System.Windows.Forms.ProgressBar();
            this.progress_y = new System.Windows.Forms.ProgressBar();
            this.progress_z = new System.Windows.Forms.ProgressBar();
            this.Thread_Stop = new System.Windows.Forms.Button();
            this.gps_longitude = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.call_sizetxt = new System.Windows.Forms.TextBox();
            this.SensorCheck = new System.Windows.Forms.CheckBox();
            this.Humidity_txt = new System.Windows.Forms.TextBox();
            this.Humidity_label = new System.Windows.Forms.Label();
            this.Vocs_sensor = new System.Windows.Forms.Label();
            this.Vocs_txt = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbBaud
            // 
            this.cmbBaud.FormattingEnabled = true;
            this.cmbBaud.Items.AddRange(new object[] {
            "9600",
            "38400",
            "115200"});
            this.cmbBaud.Location = new System.Drawing.Point(84, 48);
            this.cmbBaud.Name = "cmbBaud";
            this.cmbBaud.Size = new System.Drawing.Size(63, 20);
            this.cmbBaud.TabIndex = 18;
            this.cmbBaud.SelectedIndexChanged += new System.EventHandler(this.cmbBaud_SelectedIndexChanged);
            // 
            // cmbPort
            // 
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Location = new System.Drawing.Point(84, 22);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(63, 20);
            this.cmbPort.TabIndex = 17;
            this.cmbPort.SelectedIndexChanged += new System.EventHandler(this.cmbPort_SelectedIndexChanged);
            // 
            // baudlabel
            // 
            this.baudlabel.AutoSize = true;
            this.baudlabel.Location = new System.Drawing.Point(16, 56);
            this.baudlabel.Name = "baudlabel";
            this.baudlabel.Size = new System.Drawing.Size(55, 12);
            this.baudlabel.TabIndex = 16;
            this.baudlabel.Text = "Baudrate";
            // 
            // portlabel
            // 
            this.portlabel.AutoSize = true;
            this.portlabel.Location = new System.Drawing.Point(33, 29);
            this.portlabel.Name = "portlabel";
            this.portlabel.Size = new System.Drawing.Size(38, 12);
            this.portlabel.TabIndex = 15;
            this.portlabel.Text = "PORT";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(14, 29);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(434, 290);
            this.webBrowser1.TabIndex = 21;
            // 
            // gps_original
            // 
            this.gps_original.Location = new System.Drawing.Point(16, 325);
            this.gps_original.Name = "gps_original";
            this.gps_original.Size = new System.Drawing.Size(166, 21);
            this.gps_original.TabIndex = 22;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(16, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(373, 279);
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(153, 20);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(89, 23);
            this.btnOpen.TabIndex = 11;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(153, 48);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 22);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Exit";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gps_latitude
            // 
            this.gps_latitude.Location = new System.Drawing.Point(202, 325);
            this.gps_latitude.Name = "gps_latitude";
            this.gps_latitude.Size = new System.Drawing.Size(91, 21);
            this.gps_latitude.TabIndex = 37;
            // 
            // ImuValue_x
            // 
            this.ImuValue_x.Location = new System.Drawing.Point(15, 45);
            this.ImuValue_x.Name = "ImuValue_x";
            this.ImuValue_x.Size = new System.Drawing.Size(68, 21);
            this.ImuValue_x.TabIndex = 38;
            // 
            // CameraCheck
            // 
            this.CameraCheck.AutoSize = true;
            this.CameraCheck.Location = new System.Drawing.Point(58, 121);
            this.CameraCheck.Name = "CameraCheck";
            this.CameraCheck.Size = new System.Drawing.Size(69, 16);
            this.CameraCheck.TabIndex = 42;
            this.CameraCheck.Text = "Camera";
            this.CameraCheck.UseVisualStyleBackColor = true;
            this.CameraCheck.CheckedChanged += new System.EventHandler(this.CameraCheck_CheckedChanged);
            // 
            // ImuCheck
            // 
            this.ImuCheck.AutoSize = true;
            this.ImuCheck.Location = new System.Drawing.Point(134, 122);
            this.ImuCheck.Name = "ImuCheck";
            this.ImuCheck.Size = new System.Drawing.Size(46, 16);
            this.ImuCheck.TabIndex = 43;
            this.ImuCheck.Text = "IMU";
            this.ImuCheck.UseVisualStyleBackColor = true;
            this.ImuCheck.CheckedChanged += new System.EventHandler(this.ImuCheck_CheckedChanged);
            // 
            // GpsCheck
            // 
            this.GpsCheck.AutoSize = true;
            this.GpsCheck.Location = new System.Drawing.Point(58, 143);
            this.GpsCheck.Name = "GpsCheck";
            this.GpsCheck.Size = new System.Drawing.Size(49, 16);
            this.GpsCheck.TabIndex = 44;
            this.GpsCheck.Text = "GPS";
            this.GpsCheck.UseVisualStyleBackColor = true;
            this.GpsCheck.CheckedChanged += new System.EventHandler(this.GpsCheck_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(276, 312);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(96, 21);
            this.textBox2.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 315);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 12);
            this.label4.TabIndex = 46;
            this.label4.Text = "image size";
            // 
            // Thread_start
            // 
            this.Thread_start.Location = new System.Drawing.Point(58, 77);
            this.Thread_start.Name = "Thread_start";
            this.Thread_start.Size = new System.Drawing.Size(89, 32);
            this.Thread_start.TabIndex = 47;
            this.Thread_start.Text = "시작";
            this.Thread_start.UseVisualStyleBackColor = true;
            this.Thread_start.Click += new System.EventHandler(this.Timer_start_Click_1);
            // 
            // ImuValue_y
            // 
            this.ImuValue_y.Location = new System.Drawing.Point(14, 73);
            this.ImuValue_y.Name = "ImuValue_y";
            this.ImuValue_y.Size = new System.Drawing.Size(68, 21);
            this.ImuValue_y.TabIndex = 48;
            // 
            // ImuValue_z
            // 
            this.ImuValue_z.Location = new System.Drawing.Point(13, 100);
            this.ImuValue_z.Name = "ImuValue_z";
            this.ImuValue_z.Size = new System.Drawing.Size(69, 21);
            this.ImuValue_z.TabIndex = 49;
            // 
            // ImuValue_all
            // 
            this.ImuValue_all.Location = new System.Drawing.Point(15, 19);
            this.ImuValue_all.Name = "ImuValue_all";
            this.ImuValue_all.Size = new System.Drawing.Size(211, 21);
            this.ImuValue_all.TabIndex = 50;
            // 
            // progress_x
            // 
            this.progress_x.Location = new System.Drawing.Point(96, 46);
            this.progress_x.Maximum = 400;
            this.progress_x.Name = "progress_x";
            this.progress_x.Size = new System.Drawing.Size(130, 20);
            this.progress_x.TabIndex = 51;
            // 
            // progress_y
            // 
            this.progress_y.Location = new System.Drawing.Point(96, 74);
            this.progress_y.Maximum = 400;
            this.progress_y.Name = "progress_y";
            this.progress_y.Size = new System.Drawing.Size(130, 20);
            this.progress_y.TabIndex = 52;
            // 
            // progress_z
            // 
            this.progress_z.Location = new System.Drawing.Point(96, 100);
            this.progress_z.Maximum = 400;
            this.progress_z.Name = "progress_z";
            this.progress_z.Size = new System.Drawing.Size(130, 20);
            this.progress_z.TabIndex = 53;
            // 
            // Thread_Stop
            // 
            this.Thread_Stop.Location = new System.Drawing.Point(153, 76);
            this.Thread_Stop.Name = "Thread_Stop";
            this.Thread_Stop.Size = new System.Drawing.Size(89, 33);
            this.Thread_Stop.TabIndex = 54;
            this.Thread_Stop.Text = "정지";
            this.Thread_Stop.UseVisualStyleBackColor = true;
            this.Thread_Stop.Click += new System.EventHandler(this.Timer_Stop_Click);
            // 
            // gps_longitude
            // 
            this.gps_longitude.Location = new System.Drawing.Point(316, 325);
            this.gps_longitude.Name = "gps_longitude";
            this.gps_longitude.Size = new System.Drawing.Size(91, 21);
            this.gps_longitude.TabIndex = 55;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 57;
            this.label5.Text = "call size";
            // 
            // call_sizetxt
            // 
            this.call_sizetxt.Location = new System.Drawing.Point(88, 312);
            this.call_sizetxt.Name = "call_sizetxt";
            this.call_sizetxt.Size = new System.Drawing.Size(96, 21);
            this.call_sizetxt.TabIndex = 56;
            // 
            // SensorCheck
            // 
            this.SensorCheck.AutoSize = true;
            this.SensorCheck.Location = new System.Drawing.Point(134, 144);
            this.SensorCheck.Name = "SensorCheck";
            this.SensorCheck.Size = new System.Drawing.Size(64, 16);
            this.SensorCheck.TabIndex = 59;
            this.SensorCheck.Text = "Sensor";
            this.SensorCheck.UseVisualStyleBackColor = true;
            this.SensorCheck.CheckedChanged += new System.EventHandler(this.SensorCheck_CheckedChanged);
            // 
            // Humidity_txt
            // 
            this.Humidity_txt.Location = new System.Drawing.Point(109, 18);
            this.Humidity_txt.Name = "Humidity_txt";
            this.Humidity_txt.Size = new System.Drawing.Size(89, 21);
            this.Humidity_txt.TabIndex = 60;
            // 
            // Humidity_label
            // 
            this.Humidity_label.AutoSize = true;
            this.Humidity_label.Location = new System.Drawing.Point(49, 26);
            this.Humidity_label.Name = "Humidity_label";
            this.Humidity_label.Size = new System.Drawing.Size(54, 12);
            this.Humidity_label.TabIndex = 61;
            this.Humidity_label.Text = "Humidity";
            // 
            // Vocs_sensor
            // 
            this.Vocs_sensor.AutoSize = true;
            this.Vocs_sensor.Location = new System.Drawing.Point(49, 56);
            this.Vocs_sensor.Name = "Vocs_sensor";
            this.Vocs_sensor.Size = new System.Drawing.Size(42, 12);
            this.Vocs_sensor.TabIndex = 63;
            this.Vocs_sensor.Text = "VOCs ";
            // 
            // Vocs_txt
            // 
            this.Vocs_txt.Location = new System.Drawing.Point(109, 47);
            this.Vocs_txt.Name = "Vocs_txt";
            this.Vocs_txt.Size = new System.Drawing.Size(89, 21);
            this.Vocs_txt.TabIndex = 62;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Controls.Add(this.gps_original);
            this.groupBox1.Controls.Add(this.gps_latitude);
            this.groupBox1.Controls.Add(this.gps_longitude);
            this.groupBox1.Location = new System.Drawing.Point(25, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(466, 367);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Google Map";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.call_sizetxt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(25, 426);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 344);
            this.groupBox2.TabIndex = 65;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Camera";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SensorCheck);
            this.groupBox3.Controls.Add(this.Thread_Stop);
            this.groupBox3.Controls.Add(this.Thread_start);
            this.groupBox3.Controls.Add(this.GpsCheck);
            this.groupBox3.Controls.Add(this.ImuCheck);
            this.groupBox3.Controls.Add(this.CameraCheck);
            this.groupBox3.Controls.Add(this.cmbBaud);
            this.groupBox3.Controls.Add(this.cmbPort);
            this.groupBox3.Controls.Add(this.baudlabel);
            this.groupBox3.Controls.Add(this.portlabel);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnOpen);
            this.groupBox3.Location = new System.Drawing.Point(507, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(252, 169);
            this.groupBox3.TabIndex = 66;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial Communication";
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(440, 426);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(319, 344);
            this.groupBox4.TabIndex = 68;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Can Satelite position";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.progress_z);
            this.groupBox5.Controls.Add(this.progress_y);
            this.groupBox5.Controls.Add(this.progress_x);
            this.groupBox5.Controls.Add(this.ImuValue_all);
            this.groupBox5.Controls.Add(this.ImuValue_z);
            this.groupBox5.Controls.Add(this.ImuValue_y);
            this.groupBox5.Controls.Add(this.ImuValue_x);
            this.groupBox5.Location = new System.Drawing.Point(507, 205);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 127);
            this.groupBox5.TabIndex = 69;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "IMU";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.Vocs_sensor);
            this.groupBox6.Controls.Add(this.Vocs_txt);
            this.groupBox6.Controls.Add(this.Humidity_label);
            this.groupBox6.Controls.Add(this.Humidity_txt);
            this.groupBox6.Location = new System.Drawing.Point(507, 338);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(252, 80);
            this.groupBox6.TabIndex = 70;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Sensor";
            // 
            // mapform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 782);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "mapform";
            this.Text = "KITSAT Ground Station";
            this.Load += new System.EventHandler(this.mapform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label portlabel;
        private System.Windows.Forms.Label baudlabel;
        private System.Windows.Forms.ComboBox cmbBaud;
        private System.Windows.Forms.ComboBox cmbPort;

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox gps_original;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox gps_latitude;
        private System.Windows.Forms.TextBox ImuValue_x;
        private System.Windows.Forms.CheckBox CameraCheck;
        private System.Windows.Forms.CheckBox ImuCheck;
        private System.Windows.Forms.CheckBox GpsCheck;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Thread_start;
        private System.Windows.Forms.TextBox ImuValue_y;
        private System.Windows.Forms.TextBox ImuValue_z;
        private System.Windows.Forms.TextBox ImuValue_all;
        private System.Windows.Forms.ProgressBar progress_x;
        private System.Windows.Forms.ProgressBar progress_y;
        private System.Windows.Forms.ProgressBar progress_z;
        private System.Windows.Forms.Button Thread_Stop;
        private System.Windows.Forms.TextBox gps_longitude;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox call_sizetxt;
        private System.Windows.Forms.CheckBox SensorCheck;
        private System.Windows.Forms.TextBox Humidity_txt;
        private System.Windows.Forms.Label Humidity_label;
        private System.Windows.Forms.Label Vocs_sensor;
        private System.Windows.Forms.TextBox Vocs_txt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        

    }
}