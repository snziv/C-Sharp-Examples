using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Video video = new Video() { Title = "Light of sky" , Id = 1};
            VideoEncoder videoEncoder = new VideoEncoder();
            MailService mailService = new MailService();
            SMSService sMSService = new SMSService();

            videoEncoder.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder.VideoEncoded += sMSService.OnVideoEncoded;
            videoEncoder.Encode(video);

            VideoEncoder1 videoEncoder1 = new VideoEncoder1();
            videoEncoder1.VideoEncoded += mailService.OnVideoEncoded;
            videoEncoder1.VideoEncoded += sMSService.OnVideoEncoded;
            videoEncoder1.Encode(video);
        }
    }
}
