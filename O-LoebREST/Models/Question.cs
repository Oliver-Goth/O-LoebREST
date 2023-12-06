namespace O_LoebREST.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionToAnswer { get; set; }
        public bool IsAnswered { get; set; }
        public int? PostId { get; set; }

        public void ValidateQuestion()
        {
            if (QuestionToAnswer == null)
            {
                throw new ArgumentNullException(nameof(Question), "Question cannot be null");
            }
            if (QuestionToAnswer.Length > 150)
            {
                throw new ArgumentOutOfRangeException(nameof(Question), "Question cannot be longer than 150 characters");
            }
        }
    }
}
