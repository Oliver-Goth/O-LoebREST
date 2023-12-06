namespace O_LoebREST.Models
{
    public class QuizQuestion
    {
        public string Name { get; set; }
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public bool IsAnswered { get; set; }
        public int IsCorrect { get; set; }
        public int Id { get; set; }

        public void ValidateQuestion()
        {
            if (Question == null)
            {
                throw new ArgumentNullException(nameof(Question), "Question cannot be null");
            }
            if (Question.Length > 80)
            {
                throw new ArgumentOutOfRangeException(nameof(Question), "Question cannot be longer than 80 characters");
            }
        }
    }
}
