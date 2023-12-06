using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class QuizQuestionsRepoDB
    {
        private readonly DataBaseContext _context;

        public QuizQuestionsRepoDB(DataBaseContext DbContext)
        {
            _context = DbContext;
        }
        public QuizQuestion AddPost(QuizQuestion quizquestions)
        {
            quizquestions.ValidateQuestion();

            _context.QuizQuestions.Add(quizquestions);

            _context.SaveChanges();

            return quizquestions;
        }
    }
}
