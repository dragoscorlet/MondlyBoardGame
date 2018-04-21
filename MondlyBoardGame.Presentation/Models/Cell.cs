using MondlyBoardGame.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MondlyBoardGame.Presentation.Models
{
    public class Cell
    {
        public QuestionType QuestionTopic { get;  set; }

        public int Index { get; set; }

        public List<string> PlayerNames { get; set; }

        public bool HasPlayers { get; set; }
    }
}