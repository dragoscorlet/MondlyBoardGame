using System;

namespace MondlyBoardGame.Domain
{
    public class QuestionProvider
    {
        public Question<T> GetRandomQuestion<T>(QuestionTopic topic)
        {
            throw new InvalidOperationException();
        } 

        public Answer GetAnswer(int questionId)
        {
            return null;
        }
    }
}