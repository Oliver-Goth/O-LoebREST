using O_LoebREST.DBContext;
using O_LoebREST.Models;

namespace O_LoebREST.Repository
{
    public class AnswerRepoDB : IAnswerRepo
    {
        private readonly DataBaseContext _context;
        public AnswerRepoDB(DataBaseContext context)
        {
            _context = context;
        }
        public Answer AddAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            _context.SaveChanges();
            return answer;
        }

        public List<Answer> GetAnswersByQuestion(int questionId)
        {
            return _context.Answers.Where(a => a.QuestionId == questionId).ToList();
        }

        public IEnumerable<Answer> GetAll()
        {
            return _context.Answers.AsQueryable();
        }
    }
}
