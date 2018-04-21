using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.DAL
{
    public static class Commands
    {
        public static string  IsValidUser = @"select 1 from Users where Name = @Name";

        public static string GetQuestionDetails = @"select 
                                                     q.Id QuestionId,
                                                     q.HasMultipleQuestions,
                                                     q.QuestionType,
                                                     q.[Statement]
                                                      from Questions q
                                                      where q.QuestionType = @QuestionType";
        public static string GeAnswerDetails = @"select
                                                 a.Id Answerid,
                                                 a.[Option]
                                                 from AnswerOptions a
                                                 where a.QuestionId = @Questionid";

        public static string IsCorrect = @"select 1 from CorrectAnswer
                                            where QuestionId = @Id
                                            and Answer = @Answer";
    }
}
