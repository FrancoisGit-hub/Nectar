using Microsoft.AspNetCore.Mvc;

namespace NectarWeb.Controllers
{
    public class AboutController : Controller
    {
        [Route("APropos/CGU")]
        public IActionResult CGU()
        {
            ViewBag.HasFooter = true;
            ViewBag.HasNavBackgroundImage = false;
            return View();
        }

        [Route("APropos/FAQ")]
        public IActionResult FAQ()
        {
            ViewBag.HasFooter = true;
            ViewBag.HasNavBackgroundImage = false;
            return View();
        }
    }
}