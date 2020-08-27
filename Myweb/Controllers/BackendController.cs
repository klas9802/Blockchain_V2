using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Myweb.Controllers
{
    public class BackendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Transterhistory()
        {
            return View();
        }
        public IActionResult Info()
        {
            return View();
        }
    }
}
