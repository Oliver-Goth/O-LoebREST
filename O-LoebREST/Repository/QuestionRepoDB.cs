using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class QuestionRepoDB : IQuestionRepo
    {
        private readonly DataBaseContext _context;

        public QuestionRepoDB(DataBaseContext DbContext)
        {
            _context = DbContext;
        }


        public Question GetById(int id)
        {
            Question Send = _context.Questions.FirstOrDefault(Q => Q.Id == id);

            return Send;
        }

        public Question AddQuestion(Question question)
        {
            question.ValidateQuestion();

            _context.Questions.Add(question);

            _context.SaveChanges();

            return question;
        }

        public IEnumerable<Question> GetAll()
        {

            IQueryable<Question> query = _context.Questions.AsQueryable();

            return query;
        }
    }
}
