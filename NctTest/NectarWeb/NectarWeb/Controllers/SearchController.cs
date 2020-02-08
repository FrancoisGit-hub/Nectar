using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NectarWeb.Controllers
{
    public class SearchController : Controller
    {
       [Route("Contacter/Apiculteur")]
        public IActionResult Beekeeper()
        {
            return View();
        }
    }
}