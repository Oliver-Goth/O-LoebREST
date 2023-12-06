namespace O_LoebREST.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string AnswerToQuestion { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public int QuestionId { get; set; }
    }


}
