
using System;
using System.Threading;

namespace Events
{
    public class VideoEventArgs : EventArgs
    {
        public Video Video { get; set; }
    }

    public class VideoEncoder1
    {
        //public delegate void VideoEncodedEventHandler(object source, VideoEventArgs e);

        //public event VideoEncodedEventHandler VideoEncoded;

        // delegate creation and creating event based on that delegate can be done in one line like this
        public event EventHandler<VideoEventArgs> VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            //Encode logic goes here
            //...
            //...
            Console.WriteLine("Video Encoded.");


            //OnEncoded
            //MailService mailservice = new MailService();
            //mailservice.Send(new Mail());

            //SMSService smsservice = new SMSService();
            //smsservice.Send(new SMS());

            //using event
            OnVideoEncoded(video);
        }

        protected virtual void OnVideoEncoded(Video video)
        {
            if (VideoEncoded != null)
                VideoEncoded(this, new VideoEventArgs { Video = video});
        }
    }
}
