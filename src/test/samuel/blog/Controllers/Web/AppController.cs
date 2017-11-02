using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Models;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blog.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;
        private MongoDateRepository _repository;

        public AppController(IMailService mailService,
                             IConfigurationRoot config,
                             MongoDateRepository repository)
        {
            this._mailService = mailService;
            this._config = config;
            this._repository = repository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var trips = this._repository.Trips;

            return View(trips);
        }

        public IActionResult About()
        {
           

            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel vm){

            if(vm.Email.Contains("aol.com")) ModelState.AddModelError("", "AOL is awesome");

            if(ModelState.IsValid){
                _mailService.SendMail(_config["MailSettings:ToAddress"], 
                                        vm.Email, 
                                        "Mail from me", 
                                        vm.Message);
            }

            return View();
        }

        public IActionResult Contact(){

            return View();
        }

        
    }
}
