using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace appBase.Controllers
{
    public class AppController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //O link com TagHelper funcionará normalmente.
        [HttpGet("About")]
        public IActionResult About()
        {
            throw new InvalidOperationException("Bad Things Happen.");
            ViewBag.Title = "About";
            return View();
        }
        //Alteração na rota para a página contact. O link sem TagHelper dará erro.
        [HttpGet("Contact")]
        public IActionResult Contact()
        {
            
            return View();
        }
    }
}