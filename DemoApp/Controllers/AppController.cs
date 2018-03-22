using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoApp.Data;
using DemoApp.Data.Entities;
using DemoApp.Services;
using DemoApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoApp.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;

        private readonly IDemoAppRepository _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _cfg;


        public AppController(IMailService mailService, IDemoAppRepository repository, IMapper mapper, IConfiguration cfg)
        {
            _mailService = mailService;
            _repository = repository;
            _mapper = mapper;
            _cfg = cfg;
        }   
       
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
                     
            return View();
        
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                _mailService.SendMessage(_cfg["emails:emailTo"], model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear(); 
            }
          

            return View();
        }


        [HttpGet("about")]
        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();

        }

        [Authorize]
        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
            return View(results);
        }

        [Authorize]
        [HttpGet("messaging")]
        public IActionResult Message()
        {
            ViewBag.Title = "Messaging";

            var username = User.Identity.Name;

            var results = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageViewModel>>(_repository.GetMessages(username));

            return View(results);

        }
        [Authorize]
        [HttpGet("app/message1/{id}")]
        public string Message1(int Id)
        {
            ViewBag.Title = "Messaging";
                  
            

            var result = _mapper.Map<Message, MessageViewModel>(_repository.GetMessageById(Id));
            if (!result.IsRead)
            {
                var isread = _repository.GetMessageById(Id);
                isread.IsRead = true;
                _repository.SaveAll();

            }

            return (result.MessageItem);

        }
        [Authorize]
        [HttpGet("messaging/sendmessage")]
        public IActionResult CreateMessage()
        {
                        return View();
        }



        [Authorize]
        [HttpPost("messaging/sendmessage")]
        public IActionResult CreateMessage(CreateMessageViewModel model)
        {
            if (ModelState.IsValid)
            {
                Message message = new Message()
                {
                    IsRead = model.IsRead,
                    Receiver = model.Receiver,
                    Sender = User.Identity.Name,
                    TimeSent = model.TimeSent,
                    MessageItem = model.MessageItem,
                    Subject = model.Subject,

                };
                
                _repository.AddEntity(message);
                _repository.SaveAll();

                ModelState.Clear();
                ViewBag.Message = $"Message sent to {model.Receiver}";
            }

            return View();
        }
    }
}
