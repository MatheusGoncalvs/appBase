using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appBase.Data;
using appBase.Services;
using appBase.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace appBase.Controllers
{
    public class AppController : Controller
    {
        private readonly INullMailService mailService;
        private readonly appBaseContext context;

        public AppController(INullMailService mailService, appBaseContext context)
        {
            this.mailService = mailService;
            this.context = context;
        }

        public IActionResult Index()
        {
            var results = context.Products.ToList();
            return View();
        }
        //O link com TagHelper funcionará normalmente.
        [HttpGet("about")]
        public IActionResult About()
        {
            throw new InvalidOperationException("Bad Things Happen.");
            ViewBag.Title = "About";
            return View();
        }
        //Alteração na rota para a página contact. O link sem TagHelper dará erro.
        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }
        [HttpGet("contact2")]
        public IActionResult Contact2()
        {
            return View();
        }

        [HttpPost("contact2")]
        public IActionResult Contact2(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send email
                mailService.SendMessage("matheusgoncalvs@hotmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message:{ model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            else
            {
                //Show the errors
            }

            return View();
        }
        public IActionResult Shop()
        {
            var results = context.Products
                .OrderBy(p => p.Category)
                .ToList();
            return View(results);
        }
    }
}