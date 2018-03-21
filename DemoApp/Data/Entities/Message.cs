using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Data.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessageItem { get; set; }
        public bool IsRead { get; set; }
        public string Receiver { get; set; }
        public DateTime TimeSent { get; set; }
    }
}
