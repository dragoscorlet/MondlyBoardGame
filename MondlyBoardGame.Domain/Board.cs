using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public class Board
    {
        public int Size {get; private set;}
        public List<Position> Positions { get; private set; }
        private Random random;

        public Board()
        {
            Size = 25;
            random = new Random(DateTime.Now.Millisecond);
            Positions =  Enumerable.Range(1,25).Select(index =>new Position(GetRandQuestionType(),index)).ToList();
        }

        private QuestionType GetRandQuestionType()
        {
            return (QuestionType)Enum.Parse(typeof(QuestionType),random.Next(0, 3).ToString());
        }
    }
}
