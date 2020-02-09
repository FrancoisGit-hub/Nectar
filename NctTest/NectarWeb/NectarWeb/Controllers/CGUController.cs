using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NectarWeb.Models;

namespace NectarWeb.Controllers
{
    public class CGUController : Controller
    {
        private readonly ILogger<CGUController> _logger;

        public CGUController(ILogger<CGUController> logger)
        {
            _logger = logger;
        }

        [Route("About/CGU/")]
        public IActionResult CGU()
        {
            return View();
        }
    }
}
