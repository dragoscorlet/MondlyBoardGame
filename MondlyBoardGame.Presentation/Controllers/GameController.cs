using MondlyBoardGame.Domain;
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
        public ActionResult Join(string userName)
        {
            try
            {   
                //check db for username


                _game.JoinGame(new Player(userName));
                //Response.SetCookie(new HttpCookie("user",userName));
                ///number of players is minimum enable start game
                HttpContext.Response.Cookies.Add(new HttpCookie("user", userName));

                return Json("dsda",JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("dsda", JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult Start()
        {
            if(HasCookie(Request))
            {
               return  Content(string.Join(",", _game.GetUserNames()));
            }
            else
            {
                return Content("Failed");
            }
        }

        private bool HasCookie(HttpRequestBase request)
        {
            if (string.IsNullOrEmpty(request.Cookies.Get("user").Value))
                return false;

            return true;
        }

        public ActionResult RollDice()
        {   
            //return question
            return View();
        }

        public ActionResult AnswerQuestion()
        {   
            //move to next
            return null;
        }


    }
}