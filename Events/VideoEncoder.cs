
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Events
{
    public class VideoEncoder
    {
        //public delegate void VideoEncodedEventHandler(object source, EventArgs e);

        //public event VideoEncodedEventHandler VideoEncoded;

        // delegate creation and creating event based on that delegate can be done in one line like this
        public event EventHandler VideoEncoded;

        public void Encode(Video video)
        {
            Console.WriteLine("Encoding Video...");
            Thread.Sleep(3000);
            //Encode logic goes here
            //...
            //...
            Console.WriteLine("Video Encoded.");


            //OnEncoded without event
            //MailService mailservice = new MailService();
            //mailservice.Send(new Mail());

            //SMSService smsservice = new SMSService();
            //smsservice.Send(new SMS());

            //using event
            OnVideoEncoded();
        }

        protected virtual void OnVideoEncoded()
        {
            if (VideoEncoded != null)
                VideoEncoded(this, EventArgs.Empty);
        }
    }
}
