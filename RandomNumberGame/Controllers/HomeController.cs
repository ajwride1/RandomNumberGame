using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RandomNumberGame.Models;

namespace RandomNumberGame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Game(FormCollection collection)
        {
            if (collection["select-difficulty"] == null)
                throw new Exception("We cannot find a selected difficulty so we've sent you back to the home page");

            string selectedDifficulty = collection["select-difficulty"];

            Enum.TryParse(selectedDifficulty, true, out Enums.DifficultyLevel difficultyLevel);

            Models.Game newGame = new Game(difficultyLevel);

            return View(newGame);
        }
    }
}