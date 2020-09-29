using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NectarWeb.DAL;
using NectarWeb.Models;

namespace NectarWeb.Controllers
{
    public class SearchController : Controller
    {
        [Route("Contacter/Apiculteur")]
        public IActionResult Beekeeper()
        {
            ViewBag.HasFooter = true;
            ViewBag.HasNavBackgroundImage = true;
            return View();
        }


        [Route("Contacter/Apiculteur-resultats/")]
        public IActionResult BeekeeperResults(Models.ViewModels.SearchBeekeeperView model)
        {
            ViewBag.HasFooter = true;
            ViewBag.HasNavBackgroundImage = true;
            if (!ModelState.IsValid)
            {
                return View("Beekeeper", model);
            }


            using (var dal = new NectarDAL())
            {
                return View(dal.GetBeekeepersResultsByPostalCode(model.PostalCode));
            }

            //List<Beekeeper> results = new List<Beekeeper>();
            //results.Add(new Beekeeper()
            //{
            //    Id = 1,
            //    FirstName = "Johan",
            //    LastName = "Neveux",
            //    ZipCode = "92800",
            //    City = "Asnières",
            //    Email = "johan.neveux@gmail.com",
            //    Phone = new string[]
            //  {
            //    "0684666461"
            //  }
            //});

            //results.Add(new Beekeeper()
            //{
            //    Id = 2,
            //    FirstName = "Christopher",
            //    LastName = "Lallau",
            //    ZipCode = "93800",
            //    City = "Bondy",
            //    Email = "chris@gmail.com",
            //    Phone = new string[]
            //  {
            //    "0684515132"
            //  }
            //});

            //results.Add(new Models.Beekeeper()
            //{
            //    Id = 3,
            //    FirstName = "Francois",
            //    LastName = "Gittenait",
            //    ZipCode = "75018",
            //    City = "Paris",
            //    Email = "gittenait.francois@gmail.com",
            //    Phone = new string[]
            // {
            //    "0601020304"
            // }
            //});

            //return View(results);

        }
    }
}