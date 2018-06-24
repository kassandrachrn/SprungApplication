using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SprungGerman.Models;
using SprungGermanData;

namespace SprungGerman.Controllers
{
    public class HomeController : Controller
    {
        private readonly SignInManager<Learner> _signInManager;

        public HomeController(SignInManager<Learner> signInManager)
        {
            _signInManager = signInManager;
        }


        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User)) {

               var model = new LearnerHomeViewModel();
               return View(model);

            }
            else {
               return View();
            }  
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sprung can be your German friend";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact details";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
