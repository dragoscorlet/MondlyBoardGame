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

        public Board(int size)
        {
            Size = size;
            Positions =  Enumerable.Range(1,25).Select(index =>new Position(GetRandQuestionType(),index)).ToList();
        }

        private QuestionType GetRandQuestionType()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            return (QuestionType)Enum.Parse(typeof(QuestionType),rnd.Next(0, 3).ToString());
        }
    }
}
