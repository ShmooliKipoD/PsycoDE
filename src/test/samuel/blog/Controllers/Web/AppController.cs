using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blog.Controllers.Web
{
    public class AppController : Controller
    {

        IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService,
                             IConfigurationRoot config)
        {
            this._mailService = mailService;
            this._config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
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
