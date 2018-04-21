using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.DAL
{
    public class QuestionData
    {
        public int Id { get; set; }
        public int QuestionType { get; set; }
        public string Statement { get; set; }
        public bool HasMultipleAnswers { get; set; }
    }
}
