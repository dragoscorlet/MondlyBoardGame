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
                Response.SetCookie(new HttpCookie("user",userName));
                ///number of players is minimum enable start game

                return new JsonResult();
            }
            catch
            {
                return new JsonResult();
            }
        }

        public ActionResult StartGame()
        {
            // return grid with players
            //with curent player
            //enable roll dice

            return null;
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