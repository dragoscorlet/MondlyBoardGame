using MondlyBoardGame.Domain;
using MondlyBoardGame.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MondlyBoardGame.Presentation.Controllers
{
    public class GameController : Controller
    {
        private  static GameEngine _game = new GameEngine(10);

        [HttpGet]
        public JsonResult Board()
        {
            var board = new BoardViewModel(_game.GetBoard(), _game.GetAllPlayers());

             return Json(board.GetBoardCells(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDiceRoll()
        {
            return Json(_game.GetCurrentDiceValue());
        }

        [HttpGet]
        public JsonResult CurrentPlayer()
        {
            return Json(_game.GetCurrentPlayerName(),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult CurrentQuestion()
        {
            return Json(_game.GetCurrentQuestion(),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult Question(int diceValue)
        {   
            return Json(_game.GetQuestion(diceValue), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult AnswerQuestion(string answer, int questionId)
        {
           var success =  _game.ProcessAnswer(new Answer { Value = answer, QuestionId = questionId });

            return Json(success, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Start()
        {
            if (HasCookie(Request))
            {
                return View();
            }
            else
            {
               return RedirectToAction("Join");
            }
        }

        [HttpGet]
        public ActionResult CanStart()
        {
            return Json(_game.CanStartGame(),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Join(string userName)
        {
            try
            {
                if (UserProvider.IsValidUser(userName))
                {
                    _game.JoinGame(new Player(userName));

                    if (_game.CanStartGame())
                    {
                        _game.MoveToNextPlayer();
                    }

                    HttpContext.Response.Cookies.Add(new HttpCookie("user", userName));

                    return RedirectToAction("Start");
                }

                return RedirectToAction("InvalidUser");
            }
            catch(Exception e)
            {
                return RedirectToAction("InvalidUser");
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InvalidUser()
        {
            return Content("Invalid request");
        }

        private bool HasCookie(HttpRequestBase request)
        {
            if (string.IsNullOrEmpty(request.Cookies.Get("user").Value))
                return false;

            return true;
        }

        private bool IsCurrentUser(HttpRequestBase request)
        {
          return  HasCookie(request) 
                && _game.GetCurrentPlayerName().ToLowerInvariant()
                .Equals(request.Cookies.Get("user").Value.ToLowerInvariant());
        }
    }
}