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
            var questionViewModel = new QuestionViewModel();

            var dummyQuestion = new Question()
            {
                Id = 0,
                QuestionType = QuestionType.MultipleImage,
                Statement = "Which picture contains a dog",
                HasMultipleAnswers = false,
                AnswerOptions = new List<AnswerOption<string>>
                {
                    new AnswerOption<string>()
                    {
                        Id = 0,
                        Option = "http://image1.jpg",
                        OptionType = AnswerOptionType.Image

                    }
                }
            };

            return Json(dummyQuestion,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult RollDice()
        {
            return Json(_game.RollDice(), JsonRequestBehavior.AllowGet);
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
            return View();

            if (HasCookie(Request))
            {
                return new FilePathResult("~/Views/board.html", "text/html");
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
                //check db for username


                _game.JoinGame(new Player(userName));
                //Response.SetCookie(new HttpCookie("user",userName));
                ///number of players is minimum enable start game
                HttpContext.Response.Cookies.Add(new HttpCookie("user", userName));

                return Json("dsda", JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("dsda", JsonRequestBehavior.AllowGet);
            }
        }

        private bool HasCookie(HttpRequestBase request)
        {
            if (string.IsNullOrEmpty(request.Cookies.Get("user").Value))
                return false;

            return true;
        }


    }
}