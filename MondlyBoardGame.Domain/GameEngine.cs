using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.Domain
{
    public class GameEngine
    {
        private readonly Board _board;
        private readonly List<Player> _players;
        private GameState _state;
        private Player _currentPlayer;
        private int _currentDiceValue;
        private QuestionProvider _questionProvider;

        public GameEngine(int boardSize)
        {
            _board = new Board(boardSize);
            _players = new List<Player>();
            _questionProvider = new QuestionProvider();
        }

        public void JoinGame(Player player)
        {
            if (_state == GameState.Created)
            {
                _players.Add(player);
            }
            else
            {
                throw new InvalidOperationException("Can't join game in progress");
            }
        }

        public Player MoveToNextPlayer()
        {
            if (_currentPlayer == null)
            {
                _currentPlayer = _players.First();
            }
            else
            {
                var nextPlayer = _players.SkipWhile(item =>
                item.Name != _currentPlayer.Name).Skip(1).FirstOrDefault();

                _currentPlayer = (nextPlayer == null) ? _players.First() : nextPlayer;
            }

            return _currentPlayer;
        }

        public int RollDice()
        {   
            _currentDiceValue = _currentPlayer.RollDice();

            return _currentDiceValue;
        }

        public Question<T> GetQuestion<T>()
        {
            var questionType = _board.Positions
                .Where(position => position.Index == GetNextPosition())
                .Select(postion => postion.QuestionTopic)
                .FirstOrDefault();

           return  _questionProvider.GetRandomQuestion<T>(questionType);
        }

        private bool IsValidAnswer(Answer playerAnswer)
        {
            var rightAnswer = _questionProvider.GetAnswer(playerAnswer.QuestionId);

            return string.Equals(playerAnswer.Value.Trim()
                , rightAnswer.Value
                , StringComparison.InvariantCultureIgnoreCase);
        }

        private void MovePlayerToNextPosition()
        {
            _currentPlayer.CurrentPosition.Index += _currentDiceValue;
        }

        private int GetNextPosition()
        {
            return _currentPlayer.CurrentPosition.Index + _currentDiceValue;
        }

        public string GetCurrentPlayerName()
        {
            return _currentPlayer.Name;
        }

        private bool IsGameOver()
        {
            var isgameOver =  _players.Any(p => p.CurrentPosition.Index == _board.Size);

            if (isgameOver)
            {
                _state = GameState.Finished;
            }

            return isgameOver;
        }
    }
}
