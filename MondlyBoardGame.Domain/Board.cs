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
            Positions = new List<Position>();
        }


    }
}
