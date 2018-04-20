namespace MondlyBoardGame.Domain
{
    public class Position
    {
        public Position(QuestionTopic question, int index)
        {
            QuestionTopic = question;
            Index = index;
        } 

        public QuestionTopic QuestionTopic { get;  private set; }

        public int Index { get; set; }
    }
}