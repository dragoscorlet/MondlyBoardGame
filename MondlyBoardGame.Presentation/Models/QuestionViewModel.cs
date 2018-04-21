using MondlyBoardGame.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MondlyBoardGame.Presentation.Models
{
    public class QuestionViewModel
    {
        public string GetQuestionJson(Question question)
        {
            return JsonConvert.SerializeObject(question);
        }

        public Question GetQuestion(string json)
        {
            return JsonConvert.DeserializeObject<Question>(json);
        }
    }
}