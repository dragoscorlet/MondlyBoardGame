using MondlyBoardGame.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MondlyBoardGame.Domain
{
    public class QuestionProvider
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionProvider()
        {
            _questionRepository = new QuestionRepository();
        }

        public Question GetRandomQuestion(QuestionType topic)
        {
            var questionsData = _questionRepository.GetQuestions((int)topic);

            Random rnd = new Random();
            int index = rnd.Next(questionsData.Count);

            var questionData = questionsData[index];
            var answers = _questionRepository.GetAnswerOptions(questionData.Id);

            return MapQuestionToBussiness(questionData, answers);
        } 

        private Question MapQuestionToBussiness(QuestionData q, List<AnswerOptionData> a)
        {   
            return new Question
            {
                Id = q.Id,
                Statement = q.Statement,
                QuestionType = (QuestionType)Enum.Parse(typeof(QuestionType), q.QuestionType.ToString()),
                HasMultipleAnswers = q.HasMultipleAnswers,
                AnswerOptions = a.Select(ans => new AnswerOption<string>
                {
                    Id = ans.Id,
                    Option = ans.Option
                }).ToList()
            };
        }

        public bool IsValidAnswer(string answer, int questionId)
        {
           return _questionRepository.IsCorrectAnswer(answer, questionId);
        }
    }
}