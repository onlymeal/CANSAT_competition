using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;

namespace KITSAT_GROUND_STATION_V02
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        private float rotationx = 0.0f;
        private float rotationy = 0.0f;
        private float rotationz = 0.0f;
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();
        }
        
        ///////////// Data Transfer //////////////////
        private void imu_x_gl_TextChanged(object sender, EventArgs e)
        {
            rotationx = System.Convert.ToSingle(imu_x_gl.Text);
        }

        private void imu_y_gl_TextChanged(object sender, EventArgs e)
        {
            rotationz = -System.Convert.ToSingle(imu_y_gl.Text);
        }

        private void imu_z_gl_TextChanged(object sender, EventArgs e)
        {
            rotationy = System.Convert.ToSingle(imu_z_gl.Text);
        }
        ///////////// Data Transfer //////////////////
               
        /////////////////////////////////////////////////////////
        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, PaintEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            gl.LoadIdentity();

            //  Rotate around the Y axis.
            gl.Rotate(rotationx, rotationy, rotationz);

            //  Draw a coloured pyramid.
            gl.Begin(OpenGL.GL_TRIANGLES);
            //낙하산 1번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.Vertex(1.6f, 0.0f, 1.6f);
            //낙하산 2번
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.6f, 0.0f, 1.6f);
            gl.Vertex(0.0f, 0.0f, 2.0f);
            //낙하산 3번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 2.0f);
            gl.Vertex(-1.6f, 0.0f, 1.6f);
            //낙하산 4번
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.6f, 0.0f, 1.6f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            //낙하산 5번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);
            gl.Vertex(-1.6f, 0.0f, -1.6f);
            //낙하산 6번
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(-1.6f, 0.0f, -1.6f);
            gl.Vertex(0.0f, 0.0f, -2.0f);
            //낙하산 7번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, -2.0f);
            gl.Vertex(1.6f, 0.0f, -1.6f);
            //낙하산 8번
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(0.0f, 1.0f, 0.0f);
            gl.Vertex(1.6f, 0.0f, -1.6f);
            gl.Vertex(2.0f, 0.0f, 0.0f);
            gl.End();
            ///////////////////////////////////
            //캔-1번
            gl.Begin(OpenGL.GL_QUADS);
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(-0.5f, -2.0f, -0.5f);
            gl.Vertex(0.5f, -2.0f, -0.5f);
            gl.Vertex(0.5f, -3.0f, -0.5f);
            gl.Vertex(-0.5f, -3.0f, -0.5f);
            //캔-2번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(0.5f, -2.0f, -0.5f);
            gl.Vertex(0.5f, -2.0f, 0.5f);
            gl.Vertex(0.5f, -3.0f, 0.5f);
            gl.Vertex(0.5f, -3.0f, -0.5f);
            //캔-3번
            gl.Color(1.0f, 1.0f, 0.0f);
            gl.Vertex(0.5f, -2.0f, 0.5f);
            gl.Vertex(0.5f, -3.0f, 0.5f);
            gl.Vertex(-0.5f, -3.0f, 0.5f);
            gl.Vertex(-0.5f, -2.0f, 0.5f);
            //캔-4번
            gl.Color(1.0f, 0.3f, 0.3f);
            gl.Vertex(-0.5f, -2.0f, 0.5f);
            gl.Vertex(-0.5f, -3.0f, 0.5f);
            gl.Vertex(-0.5f, -3.0f, -0.5f);
            gl.Vertex(-0.5f, -2.0f, -0.5f);
            //캔-윗면
            gl.Color(0.3f, 0.3f, 0.5f);
            gl.Vertex(-0.5f, -2.0f, 0.5f);
            gl.Vertex(-0.5f, -2.0f, -0.5f);
            gl.Vertex(0.5f, -2.0f, -0.5f);
            gl.Vertex(0.5f, -2.0f, 0.5f);
            //캔-아래면
            gl.Color(0.3f, 0.3f, 0.5f);
            gl.Vertex(-0.5f, -3.0f, 0.5f);
            gl.Vertex(-0.5f, -3.0f, -0.5f);
            gl.Vertex(0.5f, -3.0f, -0.5f);
            gl.Vertex(0.5f, -3.0f, 0.5f);
            gl.End();
            //낙하산 연결 줄
            gl.Begin(OpenGL.GL_LINE_STRIP);
            gl.Color(1.0f, 1.0f, 1.0f);
            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(2.0f, 0.0f, 0.0f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(1.6f, 0.0f, 1.6f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, 2.0f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(-1.6f, 0.0f, 1.6f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(-2.0f, 0.0f, 0.0f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(-1.6f, 0.0f, -1.6f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(0.0f, 0.0f, -2.0f);

            gl.Vertex(0.0f, -2.0f, 0.0f);
            gl.Vertex(1.6f, 0.0f, -1.6f);

            gl.End();
        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0, 0, 0, 0);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)Width / (double)Height, 0.01, 100.0);

            //  Use the 'look at' helper function to position and aim the camera.
            gl.LookAt(5, 2, -5, 0, -1, 0, 0, 10, 0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }
    }
}
