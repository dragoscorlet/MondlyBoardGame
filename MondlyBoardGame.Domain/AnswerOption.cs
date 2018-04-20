using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public class AnswerOption<T>
    {
        public int Id { get; set; }
        public T Option { get; set; }
        public AnswerOptionType OptionType { get; set; }
    }

}
