using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
     

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            SimpleDataStorage db = new SimpleDataStorage();
            var catlist = db.Cats.ToList();
            return View(db);
        }

        public IActionResult Contact(SimpleDataStorage db)
        {

            for (int i = 0; i < 1000; i++)
            {
                db.Cats.Add(new Cat() { Name = "Caty McCat: " + i });
            }
            db.SaveChanges(true);
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index()
        {
           
            return View();
        }
    }
}
