using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public class Question<T>
    {
        public int Id { get; set; }
        public string Statement { get; set; }
        public bool HasMultipleAnswers { get; set; }
        public List<AnswerOption<T>> AnswerOptions { get; set; }
    }

}
