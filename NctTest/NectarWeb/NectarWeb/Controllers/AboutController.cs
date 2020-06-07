using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NectarWeb.Controllers
{
  public class AboutController : Controller
  {
    [Route("APropos/CGU")]
    public IActionResult CGU()
    {
      ViewBag.HasNavBackgroundImage = false;
      return View();
    }

    [Route("APropos/FAQ")]
    public IActionResult FAQ()
    {
      ViewBag.HasNavBackgroundImage = false;
      return View();
    }
  }
}