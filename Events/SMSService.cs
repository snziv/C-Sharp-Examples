using System;

namespace Events
{
    internal class SMSService
    {
        public SMSService()
        {
        }

        internal void Send(SMS sms)
        {
            throw new NotImplementedException();
        }
        public void OnVideoEncoded(object source, EventArgs eventArgs)
        {
            Console.WriteLine("SMS sent.");
        }

        public void OnVideoEncoded(object source, VideoEventArgs eventArgs)
        {
            Console.WriteLine($"SMS sent for {eventArgs.Video.Title}.");
        }
    }

    internal class SMS
    {

    }
}