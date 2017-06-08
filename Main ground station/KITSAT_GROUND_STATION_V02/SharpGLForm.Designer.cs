namespace KITSAT_GROUND_STATION_V02
{
    partial class SharpGLForm
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
            this.imu_x_gl = new System.Windows.Forms.TextBox();
            this.imu_z_gl = new System.Windows.Forms.TextBox();
            this.imu_y_gl = new System.Windows.Forms.TextBox();
            this.openGLControl = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // imu_x_gl
            // 
            this.imu_x_gl.BackColor = System.Drawing.SystemColors.MenuText;
            this.imu_x_gl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imu_x_gl.Location = new System.Drawing.Point(407, 3);
            this.imu_x_gl.Name = "imu_x_gl";
            this.imu_x_gl.Size = new System.Drawing.Size(85, 14);
            this.imu_x_gl.TabIndex = 5;
            this.imu_x_gl.TextChanged += new System.EventHandler(this.imu_x_gl_TextChanged);
            // 
            // imu_z_gl
            // 
            this.imu_z_gl.BackColor = System.Drawing.SystemColors.MenuText;
            this.imu_z_gl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imu_z_gl.Location = new System.Drawing.Point(407, 57);
            this.imu_z_gl.Name = "imu_z_gl";
            this.imu_z_gl.Size = new System.Drawing.Size(85, 14);
            this.imu_z_gl.TabIndex = 6;
            this.imu_z_gl.TextChanged += new System.EventHandler(this.imu_z_gl_TextChanged);
            // 
            // imu_y_gl
            // 
            this.imu_y_gl.BackColor = System.Drawing.SystemColors.MenuText;
            this.imu_y_gl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imu_y_gl.Location = new System.Drawing.Point(407, 30);
            this.imu_y_gl.Name = "imu_y_gl";
            this.imu_y_gl.Size = new System.Drawing.Size(85, 14);
            this.imu_y_gl.TabIndex = 7;
            this.imu_y_gl.TextChanged += new System.EventHandler(this.imu_y_gl_TextChanged);
            // 
            // openGLControl
            // 
            this.openGLControl.BitDepth = 24;
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = true;
            this.openGLControl.FrameRate = 20;
            this.openGLControl.Location = new System.Drawing.Point(0, 0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.openGLControl.Size = new System.Drawing.Size(294, 282);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new System.Windows.Forms.PaintEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 282);
            this.Controls.Add(this.imu_y_gl);
            this.Controls.Add(this.imu_z_gl);
            this.Controls.Add(this.imu_x_gl);
            this.Controls.Add(this.openGLControl);
            this.Name = "SharpGLForm";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox imu_x_gl;
        public System.Windows.Forms.TextBox imu_z_gl;
        public System.Windows.Forms.TextBox imu_y_gl;
        private SharpGL.OpenGLControl openGLControl;
    }
}

