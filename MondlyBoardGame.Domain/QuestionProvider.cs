using System;

namespace MondlyBoardGame.Domain
{
    public class QuestionProvider
    {
        public Question GetRandomQuestion(QuestionType topic)
        {
            throw new InvalidOperationException();
        } 

        public Answer GetAnswer(int questionId)
        {
            return null;
        }
    }
}