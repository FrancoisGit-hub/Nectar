using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NectarWeb.DAL;
using NectarWeb.Models.ViewModels;

namespace NectarWeb.Controllers
{
  public class BeekeeperController : Controller
  {
    [Route("Apiculteur/Inscription")]
    public IActionResult Subscription()
    {
      ViewBag.IsHome = false;
      return View();
    }

    [Route("Beekeeper/ValidateSubscription")]
    public IActionResult ValidateSubscription(BeekeeperSubscriptionView model)
    {
      ViewBag.IsHome = false;
      if (!ModelState.IsValid)
      {
        return View("Subscription", model);
      }

      // Save subscription
      using(var dal = new NectarDAL())
      {
        dal.SaveBeekeeperSubscription(model);
      }
      return View();
    }
  }
}