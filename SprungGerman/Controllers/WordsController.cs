using Microsoft.AspNetCore.Mvc;
using SprungGerman.Models;
using SprungGermanData.Interfaces;
using System.Linq;

namespace SprungGerman.Controllers
{
    public class WordsController : Controller
    {
        private IWords _words;

        public WordsController(IWords words)
        {
            _words = words;
        }

        public IActionResult Index() {

            var listModel = _words.GetAll();

            var wordModel = listModel.Select(result => new WordsViewModel
            {
                Id = result.Id,
                EnglishVersion = result.EnglishVersion,
                GermanVersion = result.GermanVersion
            });

            var model = new WordsListViewModel()
            {
                Words = wordModel
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var wordModel = _words.GetWordById(id);

            var model = new WordsViewModel()
            {
                Id = wordModel.Id,
                EnglishVersion = wordModel.EnglishVersion,
                GermanVersion = wordModel.GermanVersion
            };

            return View(model);
        }
    }
}
