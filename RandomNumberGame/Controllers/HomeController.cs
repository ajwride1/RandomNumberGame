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
        
        public ActionResult Game(FormCollection collection)
        {
            try
            {
                if (Session["CurrentGame"] == null)
                {
                    if (collection["select-difficulty"] == null)
                        throw new Exception("We cannot find a selected difficulty so we've sent you back to the home page");

                    string selectedDifficulty = collection["select-difficulty"];

                    Enum.TryParse(selectedDifficulty, true, out Enums.DifficultyLevel difficultyLevel);

                    Models.Game newGame = new Game(difficultyLevel);

                    Session["CurrentGame"] = newGame;

                    return View(newGame);
                }
                else
                {
                    Game currentGame = (Game)Session["CurrentGame"];
                    return View(currentGame);
                }
            }
            catch (Exception e)
            {
                return _handleException(e);
            }
        }

        public ActionResult MakeGuess(int guess)
        {
            try
            {
                if (Session["CurrentGame"] == null)
                    throw new Exception("Unfortunately the session has timed out! Please start a new game");

                Game currentGame = (Game) Session["CurrentGame"];
                currentGame.MakeGuess(guess);

                return View("Game", currentGame);
            }
            catch (Exception e)
            {
                return _handleException(e);
            }
        }

        private ActionResult _handleException(Exception e)
        {
            Session["error"] = e.Message;
            return RedirectToAction("Index");
        }
    }
}