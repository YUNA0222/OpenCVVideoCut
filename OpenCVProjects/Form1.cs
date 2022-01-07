using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;

namespace OpenCVProjects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        CvCapture capture;
        IplImage src;

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                capture = CvCapture.FromFile("C:\\Users\\ds\\Desktop\\20211110JAM1.mp4");//경로
                capture.SetCaptureProperty(CaptureProperty.FrameWidth, 1280);
                capture.SetCaptureProperty(CaptureProperty.FrameHeight, 720);
            }
            catch
            {

                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            src = capture.QueryFrame();
            pictureBoxIpl1.ImageIpl = src;
        }
    }
}
