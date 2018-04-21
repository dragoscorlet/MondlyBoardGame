namespace MondlyBoardGame.Domain
{
    public class Position
    {
        public Position(QuestionType question, int index)
        {
            QuestionTopic = question;
            Index = index;
        } 

        public QuestionType QuestionTopic { get;  private set; }

        public int Index { get; set; }
    }
}