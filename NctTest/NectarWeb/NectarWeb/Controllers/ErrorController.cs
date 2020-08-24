using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NectarWeb.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet("/error/{statusCode}")]
        public IActionResult Index(int statusCode)
        {
            ViewBag.HasFooter = false;
            ViewBag.HasNavBackgroundImage = true;
            return View(statusCode);
        }
    }
}