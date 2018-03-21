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

            var results = _mapper.Map <IEnumerable<Message>, IEnumerable<MessageViewModel>>(_repository.GetMessages(username));

            return View(results);

        }

        [HttpPost("messaging")]
        public IActionResult Message(MessageViewModel model)
        {
            if (User.Identity.IsAuthenticated)
            {
                _repository.AddEntity(model.IsRead == true);
            }

            return View();
        }
    }
}
