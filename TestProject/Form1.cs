using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using OpenCvSharp;

namespace TestProject
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
            timer3.Interval = 17000;
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

        CvVideoWriter OpenCV_video;//전역 변수

        private void timer2_Tick(object sender, EventArgs e)
        {
            OpenCV_video.WriteFrame(src);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("녹화 시작");
            string save_name = DateTime.Now.ToString("yyyy-MM-dd hh시mm분ss초");
            OpenCV_video = new CvVideoWriter("D:\\example\\img\\" + save_name + ".avi", "XVID", 15, Cv.GetSize(src));//버튼 눌렀을 때 생성
            timer2.Enabled = true;

            timer3.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("녹화 중지");
            timer2.Enabled = false;//timer2를 Enable = false하여 녹화를 중지
            timer3.Stop();
        }
    }
}
