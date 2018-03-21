using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.ViewModels
{
    public class MessageViewModel
    {

        public int Id { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        [Required]
        public string MessageItem { get; set; }
        public bool IsRead { get; set; }

        [Required]
        [EmailAddress]
        public string Receiver { get; set; }

        public DateTime TimeSent { get; set; }

    }
}
