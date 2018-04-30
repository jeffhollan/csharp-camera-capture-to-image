using System;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Threading;

namespace CameraCapture
{
    class Program
    {
        static FilterInfoCollection WebcamColl;
        static VideoCaptureDevice Device;

        static void Main(string[] args)
        {
            Console.WriteLine("Camera capture starting up...");
            WebcamColl = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            string name = WebcamColl[0].Name;
            string moniker = WebcamColl[0].MonikerString;
            Console.WriteLine($"Starting capture for camera: {name}...");
            Device = new VideoCaptureDevice(moniker);
            Device.Start();
            Device.NewFrame += new NewFrameEventHandler(Device_NewFrame);
        }

        static void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Console.WriteLine("Image captured");
            Image img = (Bitmap)eventArgs.Frame.Clone();
            img.Save(@"C:\Image\picture.jpg");
            Console.WriteLine("Image saved");
            Thread.Sleep(500);
        }
    }
}