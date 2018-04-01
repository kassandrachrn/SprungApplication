using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SprungGerman.Models;
using SprungGermanData.Interfaces;

namespace SprungGerman.Controllers
{
    public class HomeController : Controller
    {
      
        public IActionResult Index()
        {
            var model = new HomePageViewModel(); 
            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
