using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DemoApp.ViewModels
{
    public class CreateMessageViewModel
    {
        

        public int Id { get; set; }
        public string Sender { get; set; }
        [System.ComponentModel.DefaultValue("screw you")]
        public string Subject { get; set; }
        [Required]
        public string MessageItem { get; set; }
        public bool IsRead { get {
                return false;
            } }

        [Required]
        [EmailAddress]
        public string Receiver { get; set; }

        public DateTime TimeSent { get {
                return DateTime.Now;
            }  }

        
        
    }
}
