using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MondlyBoardGame.DAL
{
    public class QuestionRepository : RepositoryBase
    {
        public List<QuestionData> GetQuestions(int questionType)
        {
            List<QuestionData> questions = new List<QuestionData>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = Commands.GetQuestionDetails;

                    cmd.Parameters.AddWithValue("@QuestionType", questionType);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            questions.Add(new QuestionData
                            {
                                Id = (int)reader["QuestionId"],
                                Statement = (string)reader["Statement"],
                                QuestionType = (int)reader["QuestionType"],
                                HasMultipleAnswers = (bool)reader["HasMultipleQuestions"]

                            });
                        }
                    }
                }
            }

            return questions;
        }

        public List<AnswerOptionData> GetAnswerOptions(int questionId)
        {
            List<AnswerOptionData> answers = new List<AnswerOptionData>();

            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = Commands.GeAnswerDetails;

                    cmd.Parameters.AddWithValue("@Questionid", questionId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            answers.Add(new AnswerOptionData
                            {
                                Id = (int)reader["Answerid"],
                                Option = (string)reader["Option"]

                            });
                        }
                    }
                }

                return answers;
            }
        }

        public bool IsCorrectAnswer(string answer, int questionid)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var cmd = connection.CreateCommand())
                {
                    connection.Open();
                    cmd.CommandText = Commands.IsCorrect;

                    cmd.Parameters.AddWithValue("@Answer", answer);
                    cmd.Parameters.AddWithValue("@Id", questionid);

                    var result = cmd.ExecuteScalar();

                    return result != null;
                }
            }
        }
    }
}
