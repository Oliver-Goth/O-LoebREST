namespace O_LoebREST.Models
{
    public class QuizQuestions
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public bool IsCorrect { get; set; }
        public bool IsAnswered { get; set; }

        //Liste af QuizQuestions
        public QuizQuestions(string question, string answer, bool isCorrect, bool isAnswered)
        {
            Question = question;
            Answer = answer;
            IsCorrect = isCorrect;
            IsAnswered = isAnswered;
        }

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

        public void ValidateAnswer()
        {
            if (Answer == null)
            {
                throw new ArgumentNullException(nameof(Answer), "Answer cannot be null");
            }
            if (Answer.Length > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(Answer), "Answer cannot be longer than 100 characters");
            }
        }
    }
}
