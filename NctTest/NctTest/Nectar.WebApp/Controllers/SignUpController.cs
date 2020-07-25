using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Nectar.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Discover()
        {
            return View();
        }
    }
}