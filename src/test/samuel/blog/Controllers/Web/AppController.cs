using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog.Services;
using blog.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blog.Controllers.Web
{
    public class AppController : Controller
    {

        IMailService _mailService;

        public AppController(IMailService mailService)
        {
            this._mailService = mailService;
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

             _mailService.SendMail("my@mail.com", 
                                    vm.Email, 
                                    "Mail from me", 
                                    vm.Message);

            return View();
        }

        public IActionResult Contact(){

            return View();
        }
    }
}
