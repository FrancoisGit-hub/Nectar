using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NectarWeb.Controllers
{
  public class BeekeeperController : Controller
  {
    [Route("/Apiculteur")]
    public IActionResult Index()
    {
      return View();
    }

    [Route("Apiculteur/Inscription")]
    public IActionResult Subscription()
    {
      return View();
    }
  }
}