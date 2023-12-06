using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class QuestionRepoDB
    {
        private readonly DataBaseContext _context;

        public QuestionRepoDB(DataBaseContext DbContext)
        {
            _context = DbContext;
        }
        public Question AddQuestion(Question question)
        {
            question.ValidateQuestion();

            _context.Questions.Add(question);

            _context.SaveChanges();

            return question;
        }
    }
}
