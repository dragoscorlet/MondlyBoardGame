using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public class Player
    {
        public string Name { get; set; }

        public Position CurrentPosition { get; set; }

        public Player(string name)
        {
            Name = name;
            CurrentPosition = new Position(QuestionTopic.Undefined, 0);
        }

        public int RollDice()
        {
            var rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(1, 6);
        }
    }
}
