using System;

namespace Events
{
    internal class MailService
    {
        internal void Send(Mail mail)
        {
            throw new NotImplementedException();
        }

        public void OnVideoEncoded(object source, EventArgs eventArgs)
        {
            Console.WriteLine("Mail sent.");
        }

        public void OnVideoEncoded(object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine($"Mail sent for {eventArgs.Video.Title}.");
        }
    }

    internal class Mail
    {

    }
}