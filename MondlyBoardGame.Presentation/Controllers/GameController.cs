using MondlyBoardGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MondlyBoardGame.Presentation.Controllers
{
    public class GameController : Controller
    {
        private GameEngine _game;

        public ActionResult JoinGame(string userName)
        {
            try
            {
                _game.JoinGame(new Player(userName));
                //redirect to game page
                return new JsonResult();
            }
            catch
            {
                return new JsonResult();
            }
        }


        public ActionResult RollDice()
        {
            return View();
        }
    }
}