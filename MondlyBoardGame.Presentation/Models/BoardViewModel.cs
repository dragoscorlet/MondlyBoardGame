using MondlyBoardGame.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MondlyBoardGame.Presentation.Models
{
    public class BoardViewModel
    {
        private Board _board;
        private List<Player> _players;
        private List<List<Cell>> _cells;

        public BoardViewModel(Board board, List<Player> players)
        {
            _board = board;
            _players = players;
        }

        public List<List<Cell>> GetBoardCells()
        {
            var cells = _board.Positions.Select(p => new Cell
            {
                Index = p.Index,
                QuestionTopic = p.QuestionTopic,
                HasPlayers = _players.Any(pl => p.Index == pl.CurrentPosition.Index),
                PlayerNames = _players.Select(pl => pl.Name).ToList()

            }).ToList();

            return Split(cells);
        }

        private static List<List<T>> Split<T>(IList<T> source)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / 5)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}