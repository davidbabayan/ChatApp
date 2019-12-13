using System;

namespace ChatApp.Shared.Models
{
    public class Message
    {
        public string Text { get; set; }
        public User Sender { get; set; }
        public DateTime SendingTime { get; set; }
    }
}